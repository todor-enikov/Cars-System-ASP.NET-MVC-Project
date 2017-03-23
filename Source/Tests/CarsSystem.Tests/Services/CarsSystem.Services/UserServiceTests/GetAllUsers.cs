using CarsSystem.Data.Models;
using CarsSystem.Data.Repositories;
using CarsSystem.Services;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CarsSystem.Tests.Services.CarsSystem.Services.UserServiceTests
{
    [TestFixture]
    public class GetAllUsers
    {
        [Test]
        public void IsCalled_WhenPassedParametersAreCorrect()
        {
            // Arrange
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
            service.GetAllUsers();

            // Assert
            mockedRepo.Verify(m => m.All(), Times.Exactly(1));
        }

        [Test]
        public void MethodWorksProperly_WhenPassedParametersAreCorrect()
        {
            // Arrange
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
            var result = service.GetAllUsers().ToList();

            // Assert
            Assert.AreEqual(listOfUser.Count, result.Count);
        }
    }
}
