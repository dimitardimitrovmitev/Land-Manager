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

        public double GetMoneyOwed(int tenantId)
        {
            int factor = GetMonthsSinceRenting(tenantId);

            // If the tenent has no previous payments, get the date of moving in
            if (HasPayments(tenantId))
            {
                factor = GetMonthsSinceLastPayment(tenantId);
            }

            return CalculateMonthlyRent(tenantId) * factor;
        }

        private int GetMonthsSinceRenting(int tenantId)
        {
            return (int)(DateTime.Now - Get(tenantId).DateOfRenting).TotalDays / 30;
        }

         public bool HasPayments(int tenantId)
        {
            if (Get(tenantId) == null || _payments.GetAllFromCustomer(tenantId).FirstOrDefault() == null)
            {
                return false;
            }

            return true;
        }


    }
}
