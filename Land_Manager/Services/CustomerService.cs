using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Services.Common;

namespace Services
{
    public class CustomerService : ICustomer
    {
        private RmsContext _context;
        private ILand _lands;
        private IPayment _payments;

        public CustomerService(RmsContext context, ILand lands, IPayment payments)
        {
            _context = context;
            _lands = lands;
            _payments = payments;
        }
        public void Add(Customer customer, int rentedPropertyId)
        {
            customer.FirstName = StringManipulation.NormalizeName(customer.FirstName);
            customer.LastName = StringManipulation.NormalizeName(customer.LastName);
            customer.FullName = customer.FirstName + " " + customer.LastName;

            customer.RentedLand = _lands.Get(rentedPropertyId);

            _context.Add(customer);
            _context.SaveChanges();
        }

        public void Update(Customer customer)
        {
            Customer entityToUpdate = Get(customer.Id);
            _context.Entry(entityToUpdate).CurrentValues.SetValues(customer);

            _context.SaveChanges();
        }

        public int GetNumberOfCustomers()
        {
            return GetAll().Count();
        }

        public bool IsEmailTaken(string email)
        {
            return GetAll().Any(t => t.Email == email);
        }
        public Customer Get(int id)
        {
            return GetAll().FirstOrDefault(t => t.Id == id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers
                .Where(t => !t.IsCancelled)
                .Include(t => t.RentedLand)
                .Include(t => t.Payments);
        }

        public IEnumerable<Customer> GetAllFromLand(int landId)
        {
            return GetAll().Where(t => t.RentedLand.Id == landId);
        }

        private int GetMonthsSinceLastPayment(int customerId)
        {
            // Check if payments is empty
            if (_payments.GetAllFromCustomer(customerId).FirstOrDefault() == null)
            {
                return 0;
            }

            TimeSpan date = DateTime.Now - Get(customerId).Payments.Last().Date;
            return date.Days / 30;
        }

        public double GetMoneyOwed(int customerId)
        {
            int factor = GetMonthsSinceRenting(customerId);

            
            if (HasPayments(customerId))
            {
                factor = GetMonthsSinceLastPayment(customerId);
            }

            return CalculateMonthlyRent(customerId) * factor;
        }

        public int GetNumberOfCustomersInLand(int landId)
        {
            return GetAll().Where(t => t.RentedLand.Id == landId).Count();
        }

        private double CalculateMonthlyRent(int customerId)
        {
            int landId = Get(customerId).RentedLand.Id;
            return _lands.Get(landId).Rent / GetNumberOfCustomersInLand(landId);
        }

        private int GetMonthsSinceRenting(int customerId)
        {
            return (int)(DateTime.Now - Get(customerId).DateOfRenting).TotalDays / 30;
        }

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
