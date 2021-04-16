using Data;
using Data.Models;
using Moq;
using NUnit.Framework;
using Services;
using System.Collections.Generic;
using UnitTests.Data;

namespace UnitTests.Services.Tests
{
    [TestFixture]
    public class LandServiceTests
    {
        Mock<RmsContext> dbContext;
        LandService landService;
        List<Land> lands;

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

            dbContext = new Mock<RmsContext>();
            dbContext.Setup(p => p.Lands)
                .Returns(DbContextMock.GetQueryableMockDbSet(lands));

            landService = new LandService(dbContext.Object);
        }

        [Test]
        public void GetAll_Not_Null()
        {
            IEnumerable<Land> properties = landService.GetAll();

            Assert.That(properties, Is.Not.Null);
        }

        [Test]
        public void Get_Not_Null()
        {
            int propertyId = 1;
            Land property = landService.Get(propertyId);

            Assert.That(property, Is.Not.Null);
        }

        [Test]
        public void GetNumberOfLands_Returns_Correct_Value()
        {
            int expectedCount = lands.Count;
            int count = landService.GetNumberOfLands();

            Assert.That(count == expectedCount);
        }
    }
}
