using CarsSystem.Data.Models;
using CarsSystem.Data.Repositories;
using CarsSystem.Services;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace CarsSystem.Tests.Services.CarsSystem.Services.UserServiceTests
{
    [TestFixture]
    public class GetUserId
    {
        [Test]
        public void ReturnsExpectedUserId()
        {
            // Arrange
            var car = new Car() { UserId = "test", Manufacturer = "Trabant", Model = "Iztrebitel" };
            var listOfUser = new List<User>
            {
                new User() { Id = "test", FirstName = "Gosho", LastName = "Pochivkata" },
                new User() { Id = "test1", FirstName = "Monti", LastName = "Picha" },
                new User() { Id = "test2", FirstName = "Marin", LastName = "The hunter" },
            };

            var mockedRepo = new Mock<IEfGenericRepository<User>>();
            mockedRepo.Setup(m => m.All()).Returns(listOfUser);
            var service = new UsersService(mockedRepo.Object);

            // Act
            var actualResult = service.GetUserId(car);
            var expectedResult = "test";

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
