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
    public class PaymentServiceTests
    {
        Mock<RmsContext> dbContext;
        PaymentService paymentService;

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
                    Address = "Location, 6",
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

            payments = new List<Payment>()
            {
                new Payment
                {
                    Id = 1,
                    Cost = 150,
                    Date = DateTime.Now,
                    Customer = customers[0]
                }
            };

            dbContext = new Mock<RmsContext>();

            dbContext.Setup(p => p.Customers)
                .Returns(DbContextMock.GetQueryableMockDbSet(customers));

            dbContext.Setup(p => p.Lands)
                .Returns(DbContextMock.GetQueryableMockDbSet(lands));

            dbContext.Setup(p => p.Payments)
                .Returns(DbContextMock.GetQueryableMockDbSet(payments));

            paymentService = new PaymentService(dbContext.Object);
        }

        [Test]
        public void GetAll_Not_Null()
        {
            IEnumerable<Payment> payments = paymentService.GetAll();

            Assert.That(payments, Is.Not.Null);
        }

        [Test]
        public void Get_Not_Null()
        {
            int paymentId = 1;
            Payment payment = paymentService.Get(paymentId);

            Assert.That(payment, Is.Not.Null);
        }

        [Test]
        public void GetAllFromCustomer_Not_Null()
        {
            int tenantId = 1;
            IEnumerable<Payment> payments = paymentService.GetAllFromCustomer(tenantId);

            Assert.That(payments, Is.Not.Null);
        }

        [Test]
        public void GetAmountFromMonth_Not_Null()
        {
            int month = DateTime.Now.Month;
            double amount = paymentService.GetAmountFromMonth(month);

            Assert.That(amount, Is.Not.Null);
        }

        [Test]
        public void GetPaymentSum_Not_Null()
        {
            int tenantId = 1;
            double sum = paymentService.GetPaymentSum(tenantId);

            Assert.That(sum, Is.Not.Null);
        }

        [Test]
        public void GetAllFromMonth_Not_Null()
        {
            int month = DateTime.Now.Month;
            IEnumerable<Payment> payments = paymentService.GetAllFromMonth(month);

            Assert.That(payments, Is.Not.Null);
        }

        [Test]
        public void GetAmountFromYear_Not_Null()
        {
            int year = DateTime.Now.Year;
            double sum = paymentService.GetAmountFromYear(year);

            Assert.That(sum, Is.Not.Null);
        }

        [Test]
        public void GetAmountFromAllTime_Not_Null()
        {
            double sum = paymentService.GetAmountFromAllTime();

            Assert.That(sum, Is.Not.Null);
        }
    }
}
