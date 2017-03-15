using CarsSystem.Data.Models;
using CarsSystem.Data.Repositories;
using CarsSystem.Services;
using Moq;
using NUnit.Framework;
using System;

namespace CarsSystem.Tests.Services.CarsSystem.Services.CarsServiceTests
{
    [TestFixture]
    public class GetCarById
    {
        [Test]
        public void CarsService_VerifyTheMethodGetCarById_IsCalled_WhenPassedParametersAreCorrect()
        {
            // Arrange
            var car = new Car() { Id = new Guid(), Manufacturer = "VW", Model = "Golf", };
            var mockedRepo = new Mock<IEfGenericRepository<Car>>();
            mockedRepo.Setup(m => m.GetById(2)).Returns(car);
            var service = new CarsService(mockedRepo.Object);

            // Act
            service.GetCarById(1);

            // Assert
            mockedRepo.Verify(m => m.GetById(1), Times.Exactly(1));
        }

        [Test]
        public void WorksProperly_WhenPassedParametersAreCorrect()
        {
            // Arrange
            var car = new Car() { Id = new Guid(), Manufacturer = "VW", Model = "Golf", };
            var mockedRepo = new Mock<IEfGenericRepository<Car>>();
            mockedRepo.Setup(m => m.GetById(1)).Returns(car);
            var service = new CarsService(mockedRepo.Object);

            // Act
            var result = service.GetCarById(1);

            // Assert
            Assert.AreEqual(car.Manufacturer, result.Manufacturer);
        }
    }
}
