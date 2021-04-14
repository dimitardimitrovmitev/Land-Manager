using System;
using System.Collections.Generic;
using System.Text;
using Data.Models;
    
namespace Data
{
    public interface ICustomer
    {
        void Add(Customer customer, int rentedLandId);
        void Update(Customer customer);
        Customer Get(int id);
        IEnumerable<Customer> GetAll();
        IEnumerable<Customer> GetAllFromLand(int landId);
        int GetNumberOfCustomers();
        int GetNumberOfCustomersInLand(int landId);
        bool IsEmailTaken(string email);
        bool HasPayments(int id);

        double GetMoneyOwed(int customerId);

        void Cancel(int id);
    }
}
