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




    }
}
