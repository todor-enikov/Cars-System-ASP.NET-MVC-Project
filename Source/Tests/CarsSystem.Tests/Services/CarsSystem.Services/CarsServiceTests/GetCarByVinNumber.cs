using CarsSystem.Data.Models;
using CarsSystem.Data.Repositories;
using CarsSystem.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsSystem.Tests.Services.CarsSystem.Services.CarsServiceTests
{
    [TestFixture]
    public class GetCarByVinNumber
    {
        [Test]
        public void IsCalled_WhenPassedParametersAreCorrect()
        {
            // Arrange
            var listOfCars = new List<Car>
            {
                new Car() { Id = Guid.NewGuid(), Manufacturer = "VW", Model = "Golf", VINNumber = "12345678901234567" },
                new Car() { Id = Guid.NewGuid(), Manufacturer = "BMW", Model = "e40", VINNumber = "12345673401234567" },
                new Car() { Id = Guid.NewGuid(), Manufacturer = "Lada", Model = "2105", VINNumber = "12306878901234567" }
            };

            var mockedRepo = new Mock<IEfGenericRepository<Car>>();
            mockedRepo.Setup(c => c.All()).Returns(listOfCars);
            var service = new CarsService(mockedRepo.Object);

            // Act
            service.GetCarByVinNumber("12345678901234567");

            // Assert
            mockedRepo.Verify(m => m.All(), Times.Exactly(1));
        }

        [Test]
        public void ShouldReturnTheExpectedResult()
        {
            // Arrange
            var listOfCars = new List<Car>
            {
                new Car() { Id = Guid.NewGuid(), Manufacturer = "VW", Model = "Golf", VINNumber = "12345678901234567" },
                new Car() { Id = Guid.NewGuid(), Manufacturer = "BMW", Model = "e40", VINNumber = "12345673401234567" },
                new Car() { Id = Guid.NewGuid(), Manufacturer = "Lada", Model = "2105", VINNumber = "12306878901234567" }
            };

            var mockedRepo = new Mock<IEfGenericRepository<Car>>();
            mockedRepo.Setup(c => c.All()).Returns(listOfCars);
            var service = new CarsService(mockedRepo.Object);

            // Act
            var actualResult = service.GetCarByVinNumber("12345678901234567").ToList();
            var expectedResult = 1;

            // Assert
            Assert.AreEqual(expectedResult, actualResult.Count);
        }
    }
}
