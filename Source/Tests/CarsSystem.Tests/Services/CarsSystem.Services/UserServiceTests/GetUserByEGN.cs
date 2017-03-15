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
    public class GetUserByEGN
    {
        [Test]
        public void IsCalled_WhenPassedParametersAreCorrect()
        {
            // Arrange
            var listOfUser = new List<User>
            {
                new User() { Id = "test", FirstName = "Gosho", LastName = "Pochivkata", EGN = 6402234353 },
                new User() { Id = "test1", FirstName = "Monti", LastName = "Picha", EGN = 6402234343 },
                new User() { Id = "test2", FirstName = "Marin", LastName = "The hunter", EGN = 6406544343 },
            };

            var mockedRepo = new Mock<IEfGenericRepository<User>>();
            mockedRepo.Setup(c => c.All()).Returns(listOfUser);
            var service = new UsersService(mockedRepo.Object);

            // Act
            service.GetUserByEGN(6402234353);

            // Assert
            mockedRepo.Verify(m => m.All(), Times.Exactly(1));
        }

        [Test]
        public void ShouldReturnTheExpectedResult()
        {
            // Arrange
            var listOfUser = new List<User>
            {
                new User() { Id = "test", FirstName = "Gosho", LastName = "Pochivkata", EGN = 6402234353 },
                new User() { Id = "test1", FirstName = "Monti", LastName = "Picha", EGN = 6402234343 },
                new User() { Id = "test2", FirstName = "Marin", LastName = "The hunter", EGN = 6406544343 },
            };

            var mockedRepo = new Mock<IEfGenericRepository<User>>();
            mockedRepo.Setup(c => c.All()).Returns(listOfUser);
            var service = new UsersService(mockedRepo.Object);

            // Act
            var actualResult = service.GetUserByEGN(6402234353).ToList();
            var expectedResult = 1;

            // Assert
            Assert.AreEqual(expectedResult, actualResult.Count);
        }
    }
}
