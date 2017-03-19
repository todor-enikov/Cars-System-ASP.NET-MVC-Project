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
        public void VerifyTheMethodGetCarById_IsCalled_WhenPassedParametersAreCorrect()
        {
            // Arrange
            var car = new Car() { Id = Guid.NewGuid(), Manufacturer = "VW", Model = "Golf", };
            var mockedRepo = new Mock<IEfGenericRepository<Car>>();
            mockedRepo.Setup(m => m.GetById(car.Id)).Returns(car);
            var service = new CarsService(mockedRepo.Object);

            // Act
            service.GetCarById(car.Id);

            // Assert
            mockedRepo.Verify(m => m.GetById(car.Id), Times.Exactly(1));
        }

        [Test]
        public void WorksProperly_WhenPassedParametersAreCorrect()
        {
            // Arrange
            var car = new Car() { Id = Guid.NewGuid(), Manufacturer = "VW", Model = "Golf", };
            var mockedRepo = new Mock<IEfGenericRepository<Car>>();
            mockedRepo.Setup(m => m.GetById(car.Id)).Returns(car);
            var service = new CarsService(mockedRepo.Object);

            // Act
            var result = service.GetCarById(car.Id);

            // Assert
            Assert.AreEqual(car.Manufacturer, result.Manufacturer);
        }
    }
}
