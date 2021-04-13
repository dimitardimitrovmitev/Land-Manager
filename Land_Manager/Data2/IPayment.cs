using System;
using System.Collections.Generic;
using System.Text;
using Data.Models;
namespace Data
{
    public interface IPayment
    {
        void Add(Payment payment);
        Payment Get(int id);
        IEnumerable<Payment> GetAll();
        IEnumerable<Payment> GetAllFromCustomer(int Id);
        IEnumerable<Payment> GetAllFromMonth(int month);
        double GetPaymentSum(int customerId);
        double GetAmountFromMonth(int month);
        double GetAmountFromYear(int year);
        double GetAmountFromAllTime();
    }
}
