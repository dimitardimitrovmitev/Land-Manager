using System;
using System.Collections.Generic;
using System.Text;
using Data.Models;
    
namespace Data
{
    public interface ICustomer
    {
        void Add(Customer customer, int rentedLandId);
        void KickOut(int id);
        void Update(Customer customer);
        Customer Get(int id);
        IEnumerable<Customer> GetAll();
        IEnumerable<Customer> GetAllFromProperty(int landId);
        int GetNumberOfCustomers();
        int GetNumberOfCustomersInLand(int landId);
        double GetMoneyOwed(int customerId);
        bool IsEmailTaken(string email);
        bool HasPayments(int id);
    }
}
