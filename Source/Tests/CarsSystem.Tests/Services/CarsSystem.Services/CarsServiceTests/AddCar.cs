using CarsSystem.Data.Models;
using CarsSystem.Data.Repositories;
using CarsSystem.Services;
using Moq;
using NUnit.Framework;
using System;

namespace CarsSystem.Tests.Services.CarsSystem.Services.CarsServiceTests
{
    [TestFixture]
    public class AddCar
    {
        [Test]
        public void CarsService_VerifyTheMethodAddCar_IsCalled_WhenPassedParametersAreCorrect()
        {
            // Arrange
            var car = new Car() { Id = new Guid(), Manufacturer = "VW", Model = "Golf", };
            var mockedRepo = new Mock<IEfGenericRepository<Car>>();
            mockedRepo.Setup(m => m.Add(car)).Verifiable();
            var service = new CarsService(mockedRepo.Object);

            // Act
            service.AddCar(car);

            // Assert
            mockedRepo.Verify(m => m.Add(car), Times.Exactly(1));
        }
    }
}
