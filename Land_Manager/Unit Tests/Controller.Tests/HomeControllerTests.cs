using Data;
using Moq;
using NUnit.Framework;
using Services;
using Land_Manager.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Data.Models;
using UnitTests.Data;

namespace Unit_Tests.Controller.Tests
{
    
        [TestFixture]
        public class HomeControllerTests
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
                customers = new List<Customer>();
                lands = new List<Land>();
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
            public void Index_Not_Null()
            {
                HomeController controller = new HomeController(landService, customerService, paymentService);

                ViewResult result = controller.Index() as ViewResult;

                Assert.That(result, Is.Not.Null);
            }
        }
    
}
