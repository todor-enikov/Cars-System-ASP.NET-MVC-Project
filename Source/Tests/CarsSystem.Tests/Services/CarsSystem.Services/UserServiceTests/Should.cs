using CarsSystem.Data.Models;
using CarsSystem.Data.Repositories;
using CarsSystem.Services;
using CarsSystem.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;

namespace CarsSystem.Tests.Services.CarsSystem.Services.UserServiceTests
{
    [TestFixture]
    public class Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenPassedRepositoryIsNull()
        {
            // Arrange
            IEfGenericRepository<User> mockedRepository = null;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new UsersService(mockedRepository));
        }

        [Test]
        public void ThrowArgumentNullExceptionWithExpectedMessage_WhenPassedRepositoryIsNull()
        {
            // Arrange
            IEfGenericRepository<User> mockedRepository = null;

            // Act
            var expectedMessage = Assert.Throws<ArgumentException>(() => new UsersService(mockedRepository));

            // Assert
            Assert.IsTrue(expectedMessage.Message.Contains("null"));
        }

        [Test]
        public void CreateInstanceOfUsersService_WhenPassedRepositoryIsCorrectly()
        {
            // Arrange
            var mockedRepository = new Mock<IEfGenericRepository<User>>();

            // Act
            var service = new UsersService(mockedRepository.Object);

            // Assert
            Assert.IsInstanceOf<UsersService>(service);
        }

        [Test]
        public void ImplementsInterfaceIUsersService_WhenPassedRepositoryIsCorrectly()
        {
            // Arrange
            var mockedRepository = new Mock<IEfGenericRepository<User>>();

            // Act
            var service = new UsersService(mockedRepository.Object);

            // Assert
            Assert.IsInstanceOf<IUsersService>(service);
        }
    }
}
