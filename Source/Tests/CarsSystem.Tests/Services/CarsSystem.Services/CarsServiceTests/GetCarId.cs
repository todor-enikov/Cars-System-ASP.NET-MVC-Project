using CarsSystem.Data.Models;
using CarsSystem.Data.Repositories;
using CarsSystem.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace CarsSystem.Tests.Services.CarsSystem.Services.CarsServiceTests
{
    [TestFixture]
    public class GetCarId
    {
        [Test]
        public void CarsService_MethodGetCarId_ReturnsExpectedCarId()
        {
            // Arrange
            var user = new User() { Id = "test", FirstName = "Gosho", LastName = "Pochivkata" };
            var listOfCars = new List<Car>
            {
                new Car() { Id = Guid.NewGuid(), Manufacturer = "VW", Model = "Golf", UserId = "test" },
                new Car() { Id = Guid.NewGuid(), Manufacturer = "BMW", Model = "e40", UserId = "test1" },
                new Car() { Id = Guid.NewGuid(), Manufacturer = "Lada", Model = "2105", UserId = "test2" }
            };
            var mockedRepo = new Mock<IEfGenericRepository<Car>>();
            mockedRepo.Setup(m => m.All()).Returns(listOfCars);
            var service = new CarsService(mockedRepo.Object);

            // Act
            var actualResult = service.GetCarId(user);
            var expectedResult = listOfCars[0].Id;

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
