using Data;
using Data.Models;
using Moq;
using NUnit.Framework;
using Services;
using System;
using System.Collections.Generic;
using UnitTests.Data;

namespace UnitTests.Services.Tests
{
    [TestFixture]
    public class CustomersServiceTests
    {
        Mock<RmsContext> dbContext;

        CustomerService customerService;
        PaymentService paymentService;
        LandService landService;

        List<Land> lands;
        List<Customer> customers;
        List<Payment> payments;

        [SetUp]
        public void SetUp()
        {
            lands = new List<Land>
            {
                new Land {
                    Id = 1,
                    Address = "Drujba, 6",
                    Area = 100,
                    Rent = 150
                }
            };

            customers = new List<Customer>()
            {
                new Customer
                {
                    Id = 1,
                    FirstName = "Dan",
                    LastName = "Ivanov",
                    Email = "dan@abv.bg",
                    PhoneNumber = "0879542734",
                    DateOfRenting = DateTime.Now,
                    IsCancelled = false,
                    RentedLand = lands[0]

                }
            };

            payments = new List<Payment>();

            dbContext = new Mock<RmsContext>();

            dbContext.Setup(p => p.Customers)
                .Returns(DbContextMock.GetQueryableMockDbSet(customers));

            dbContext.Setup(p => p.Lands)
                .Returns(DbContextMock.GetQueryableMockDbSet(lands));

            dbContext.Setup(p => p.Payments)
                .Returns(DbContextMock.GetQueryableMockDbSet(payments));

            paymentService = new PaymentService(dbContext.Object);
            landService = new LandService(dbContext.Object);
            customerService = new CustomerService(dbContext.Object, landService, paymentService);
        }

        [Test]
        public void GetAll_Not_Null()
        {
            IEnumerable<Customer> customers = customerService.GetAll();

            Assert.That(customers, Is.Not.Null);
        }

        [Test]
        public void Get_Not_Null()
        {
            int customerId = 1;
            Customer customer = customerService.Get(customerId);

            Assert.That(customer, Is.Not.Null);
        }

        [Test]
        public void GetAllFromLand_Not_Null()
        {
            int landId = 1;
            IEnumerable<Customer> customers = customerService.GetAllFromLand(landId);

            Assert.That(customers, Is.Not.Null);
        }

        [Test]
        public void GetMoneyOwed_Not_Null()
        {
            int customerId = 1;
            double debt = customerService.GetMoneyOwed(customerId);

            Assert.That(debt, Is.Not.Null);
        }

        [Test]
        public void GetNumberOfCustomers_Correct_Count()
        {
            int expectedCount = customers.Count;
            int count = customerService.GetNumberOfCustomers();

            Assert.That(expectedCount == count);
        }

        [Test]
        public void IsEmailTaken_Existing_Email_True()
        {
            string email = customers[0].Email;
            bool result = customerService.IsEmailTaken(email);

            Assert.That(result, Is.True);
        }

        [Test]
        public void IsEmailTaken_Not_Existing_Email_False()
        {
            string email = "jojo@gmail.com";
            bool result = customerService.IsEmailTaken(email);

            Assert.That(result, Is.False);
        }

        [Test]
        public void GetNumberOfCustomersInLand_NotNull()
        {
            int landId = 1;
            int count = customerService.GetNumberOfCustomersInLand(landId);

            Assert.That(count, Is.Not.Null);
        }

        [Test]
        public void HasPayments_No_Payments_False()
        {
            int customerId = 1;
            bool result = customerService.HasPayments(customerId);

            Assert.That(result, Is.False);
        }
    }
}
