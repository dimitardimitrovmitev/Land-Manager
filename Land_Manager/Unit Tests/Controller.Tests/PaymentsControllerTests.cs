using Data;
using Moq;
using NUnit.Framework;
using Services;
using Land_Manager.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Data.Models;
using UnitTests.Data;
using System;


namespace UnitTests.Controller.Tests
{
    [TestFixture]
    public class PaymentsControllerTests
    {
        Mock<RmsContext> dbContext;
        PaymentService paymentService;
        CustomerService customerService;
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
                    Cost = 100,
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
            landService = new LandService(dbContext.Object);
            customerService = new CustomerService(dbContext.Object, landService, paymentService);
        }

        [Test]
        public void All_Not_Null()
        {
            PaymentsController controller = new PaymentsController(paymentService, customerService);

            ViewResult result = controller.All() as ViewResult;

            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void Customer_Not_Null()
        {
            int customerId = 1;
            PaymentsController controller = new PaymentsController(paymentService, customerService);

            ViewResult result = controller.Customer(customerId) as ViewResult;

            Assert.That(result, Is.Not.Null);
        }
    }
}
