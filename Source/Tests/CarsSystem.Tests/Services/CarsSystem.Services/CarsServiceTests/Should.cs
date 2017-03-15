using CarsSystem.Data.Models;
using CarsSystem.Data.Repositories;
using CarsSystem.Services;
using CarsSystem.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;

namespace CarsSystem.Tests.Services.CarsSystem.Services.CarsServiceTests
{
    [TestFixture]
    public class Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenPassedRepositoryIsNull()
        {
            // Arrange
            IEfGenericRepository<Car> mockedRepository = null;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new CarsService(mockedRepository));
        }

        [Test]
        public void ThrowArgumentNullExceptionWithExpectedMessage_WhenPassedRepositoryIsNull()
        {
            // Arrange
            IEfGenericRepository<Car> mockedRepository = null;

            // Act
            var expectedMessage = Assert.Throws<ArgumentException>(() => new CarsService(mockedRepository));

            // Assert
            Assert.IsTrue(expectedMessage.Message.Contains("null"));
        }

        [Test]
        public void CreateInstanceOfCarsService_WhenPassedRepositoryIsCorrectly()
        {
            // Arrange
            var mockedRepository = new Mock<IEfGenericRepository<Car>>();

            // Act
            var service = new CarsService(mockedRepository.Object);

            // Assert
            Assert.IsInstanceOf<CarsService>(service);
        }

        [Test]
        public void ImplementsInterfaceICarsService_WhenPassedRepositoryIsCorrectly()
        {
            // Arrange
            var mockedRepository = new Mock<IEfGenericRepository<Car>>();

            // Act
            var service = new CarsService(mockedRepository.Object);

            // Assert
            Assert.IsInstanceOf<ICarsService>(service);
        }
    }
}
