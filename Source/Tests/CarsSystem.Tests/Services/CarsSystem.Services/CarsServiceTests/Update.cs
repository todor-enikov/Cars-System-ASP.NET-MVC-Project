using CarsSystem.Data.Models;
using CarsSystem.Data.Repositories;
using CarsSystem.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsSystem.Tests.Services.CarsSystem.Services.CarsServiceTests
{
    [TestFixture]
    public class Update
    {
        [Test]
        public void IsCalled_WhenPassedParametersAreCorrect()
        {
            // Arrange
            var car = new Car() { Id = new Guid(), Manufacturer = "VW", Model = "Golf", };
            var mockedRepo = new Mock<IEfGenericRepository<Car>>();
            mockedRepo.Setup(c => c.Update(car)).Verifiable();
            var service = new CarsService(mockedRepo.Object);

            // Act
            service.Update(car);

            // Assert
            mockedRepo.Verify(c => c.Update(car), Times.Exactly(1));
        }
    }
}
