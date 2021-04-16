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
    public class LandControllerTests
    {
        Mock<RmsContext> dbContext;

        CustomerService customerService;
        PaymentService paymentService;
        LandService landService;

        List<Land> properties;
        List<Customer> tenants;
        List<Payment> payments;

        [SetUp]
        public void SetUp()
        {
            properties = new List<Land>
            {
                new Land {
                    Id = 1,
                    Address = "Drujba, 6",
                    Area = 100,
                    Rent = 150
                }
            };

            tenants = new List<Customer>()
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
                    RentedLand = properties[0]

                }
            };

            payments = new List<Payment>();

            dbContext = new Mock<RmsContext>();

            dbContext.Setup(p => p.Customers)
                .Returns(DbContextMock.GetQueryableMockDbSet(tenants));

            dbContext.Setup(p => p.Lands)
                .Returns(DbContextMock.GetQueryableMockDbSet(properties));

            dbContext.Setup(p => p.Payments)
                .Returns(DbContextMock.GetQueryableMockDbSet(payments));

            paymentService = new PaymentService(dbContext.Object);
            landService = new LandService(dbContext.Object);
            customerService = new CustomerService(dbContext.Object, landService, paymentService);
        }

        [Test]
        public void All_Not_Null()
        {
            LandController controller = new LandController(landService, customerService);

            ViewResult result = controller.All() as ViewResult;

            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void Add_Not_Null()
        {
            LandController controller = new LandController(landService, customerService);

            ViewResult result = controller.Add() as ViewResult;

            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void Index_Not_Null()
        {
            int propertyId = 1;
            LandController controller = new LandController(landService, customerService);

            ViewResult result = controller.Index(propertyId) as ViewResult;

            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void Edit_Not_Null()
        {
            int propertyId = 1;
            LandController controller = new LandController(landService, customerService);

            ViewResult result = controller.Edit(propertyId) as ViewResult;

            Assert.That(result, Is.Not.Null);
        }
    }
}
