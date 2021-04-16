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
    public class CustomersControllerTests
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
        public void All_Not_Null()
        {
            CustomerController controller = new CustomerController(landService, customerService, paymentService);

            ViewResult result = controller.All() as ViewResult;

            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void Add_Not_Null()
        {
            CustomerController controller = new CustomerController(landService, customerService, paymentService);

            ViewResult result = controller.Add() as ViewResult;

            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void Index_Not_Null()
        {
            int customerId = 1;
            CustomerController controller = new CustomerController(landService, customerService, paymentService);

            ViewResult result = controller.Index(customerId) as ViewResult;

            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void Edit_Not_Null()
        {
            int customerId = 1;
            CustomerController controller = new CustomerController(landService, customerService, paymentService);

            ViewResult result = controller.Edit(customerId) as ViewResult;

            Assert.That(result, Is.Not.Null);
        }
    }
}
