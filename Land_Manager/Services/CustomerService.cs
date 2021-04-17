using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Services.Common;

namespace Services
{
    /// <summary>
    /// Handles most of the business logic, that has to do with the tenant
    /// </summary>
    public class CustomerService : ICustomer
    {
        private RmsContext _context;
        private ILand _lands;
        private IPayment _payments;
        /// <summary>
        /// Constructor for the class
        /// </summary>
        /// <param name="context"></param>
        /// <param name="lands"></param>
        /// <param name="payments"></param>
        public CustomerService(RmsContext context, ILand lands, IPayment payments)
        {
            _context = context;
            _lands = lands;
            _payments = payments;
        }
        /// <summary>
        /// Adds a new Customer and links him to a land
        /// </summary>
        /// <param name="customer">Customer object</param>
        /// <param name="rentedLandId">Id for a rented land instance</param>
        public void Add(Customer customer, int rentedLandId)
        {
            customer.FirstName = StringManipulation.NormalizeName(customer.FirstName);
            customer.LastName = StringManipulation.NormalizeName(customer.LastName);
            customer.FullName = customer.FirstName + " " + customer.LastName;

            customer.RentedLand = _lands.Get(rentedLandId);

            _context.Add(customer);
            _context.SaveChanges();
        }
        /// <summary>
        /// Update customer data
        /// </summary>
        /// <param name="customer"></param>
        public void Update(Customer customer)
        {
            Customer entityToUpdate = Get(customer.Id);
            _context.Entry(entityToUpdate).CurrentValues.SetValues(customer);

            _context.SaveChanges();
        }
        /// <summary>
        /// Get the number of all customer records
        /// </summary>
        /// <returns>Customer count</returns>
        public int GetNumberOfCustomers()
        {
            return GetAll().Count();
        }
        /// <summary>
        /// Checks if there's a customer with the given email
        /// </summary>
        /// <param name="email">The email being checked</param>
        /// <returns></returns>
        public bool IsEmailTaken(string email)
        {
            return GetAll().Any(t => t.Email == email);
        }
        /// <summary>
        /// Get a single customer by id
        /// </summary>
        /// <param name="id">Customer id</param>
        /// <returns>Customer with the corresponding id or null if not found</returns>
        public Customer Get(int id)
        {
            return GetAll().FirstOrDefault(t => t.Id == id);
        }
        /// <summary>
        ///  Get all customer records, except the ones that have left the land
        /// </summary>
        /// <returns>All customers</returns>
        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers
                .Where(t => !t.IsCancelled)
                .Include(t => t.RentedLand)
                .Include(t => t.Payments);
        }
        /// <summary>
        /// Get all customer records from a specific land
        /// </summary>
        /// <param name="landId">Id of the land</param>
        /// <returns>All customers found</returns>
        public IEnumerable<Customer> GetAllFromLand(int landId)
        {
            return GetAll().Where(t => t.RentedLand.Id == landId);
        }
        /// <summary>
        /// Get the number of months passed since a customer's last payment
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        private int GetMonthsSinceLastPayment(int customerId)
        {
            if (_payments.GetAllFromCustomer(customerId).FirstOrDefault() == null)
            {
                return 0;
            }

            TimeSpan date = DateTime.Now - Get(customerId).Payments.Last().Date;
            return date.Days / 30;
        }
        /// <summary>
        /// Calculate the debt of a single customer
        /// </summary>
        /// <param name="customerId">Id of the customer</param>
        /// <returns>The amount of money owed</returns>
        public double GetMoneyOwed(int customerId)
        {
            int factor = GetMonthsSinceRenting(customerId);

            
            if (HasPayments(customerId))
            {
                factor = GetMonthsSinceLastPayment(customerId);
            }

            return CalculateMonthlyRent(customerId) * factor;
        }
        /// <summary>
        /// Set Cancled to thrue
        /// </summary>
        /// <param name="id">Id of user who leaves the land</param>
        public void Cancel(int id)
        {
            Customer customer = Get(id);
            _context.Update(customer);

            customer.IsCancelled = true;

            _context.SaveChanges();
        }
        /// <summary>
        /// Get the number of all customer records that have rented land
        /// </summary>
        /// <param name="landId">Id of the land</param>
        /// <returns>The number of customers</returns>
        public int GetNumberOfCustomersInLand(int landId)
        {
            return GetAll().Where(t => t.RentedLand.Id == landId).Count();
        }
        /// <summary>
        /// Split the rent of the land equally between the customers (if tow or more have rented one)
        /// </summary>
        /// <param name="customerId">Id of the customer beign evaluated</param>
        /// <returns></returns>
        private double CalculateMonthlyRent(int customerId)
        {
            int landId = Get(customerId).RentedLand.Id;
            return _lands.Get(landId).Rent / GetNumberOfCustomersInLand(landId);
        }
        /// <summary>
        /// Get the number of months passed since a customer moved into a property
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        private int GetMonthsSinceRenting(int customerId)
        {
            return (int)(DateTime.Now - Get(customerId).DateOfRenting).TotalDays / 30;
        }
        /// <summary>
        /// Check if a customer has made any payments
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public bool HasPayments(int customerId)
        {
            if (Get(customerId) == null || _payments.GetAllFromCustomer(customerId).FirstOrDefault() == null)
            {
                return false;
            }
            return true;
        }
    }
}
