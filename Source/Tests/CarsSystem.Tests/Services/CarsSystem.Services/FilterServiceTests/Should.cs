using CarsSystem.Data.Models;
using CarsSystem.Data.Repositories;
using CarsSystem.Services;
using CarsSystem.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;

namespace CarsSystem.Tests.Services.CarsSystem.Services.FilterServiceTests
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
            Assert.Throws<ArgumentException>(() => new FilterService(mockedRepository));
        }

        [Test]
        public void ThrowArgumentNullExceptionWithExpectedMessage_WhenPassedRepositoryIsNull()
        {
            // Arrange
            IEfGenericRepository<Car> mockedRepository = null;

            // Act
            var expectedMessage = Assert.Throws<ArgumentException>(() => new FilterService(mockedRepository));

            // Assert
            Assert.IsTrue(expectedMessage.Message.Contains("null"));
        }

        [Test]
        public void CreateInstanceOfFilterService_WhenPassedRepositoryIsCorrectly()
        {
            // Arrange
            var mockedRepository = new Mock<IEfGenericRepository<Car>>();

            // Act
            var service = new FilterService(mockedRepository.Object);

            // Assert
            Assert.IsInstanceOf<FilterService>(service);
        }

        [Test]
        public void ImplementsInterfaceIFilterService_WhenPassedRepositoryIsCorrectly()
        {
            // Arrange
            var mockedRepository = new Mock<IEfGenericRepository<Car>>();

            // Act
            var service = new FilterService(mockedRepository.Object);

            // Assert
            Assert.IsInstanceOf<IFilterService>(service);
        }
    }
}
