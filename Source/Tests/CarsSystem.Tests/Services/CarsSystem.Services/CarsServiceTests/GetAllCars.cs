using CarsSystem.Data.Models;
using CarsSystem.Data.Repositories;
using CarsSystem.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarsSystem.Tests.Services.CarsSystem.Services.CarsServiceTests
{
    [TestFixture]
    public class GetAllCars
    {
        [Test]
        public void IsCalled_WhenPassedParametersAreCorrect()
        {
            // Arrange
            var listOfCars = new List<Car>
            {
                new Car() { Id = Guid.NewGuid(), Manufacturer = "VW", Model = "Golf",  },
                new Car() { Id = Guid.NewGuid(), Manufacturer = "BMW", Model = "e40",  },
                new Car() { Id = Guid.NewGuid(), Manufacturer = "Lada", Model = "2105",  }
            };
            var mockedRepo = new Mock<IEfGenericRepository<Car>>();
            mockedRepo.Setup(m => m.All()).Returns(listOfCars);
            var service = new CarsService(mockedRepo.Object);

            // Act
            service.GetAllCars();

            // Assert
            mockedRepo.Verify(m => m.All(), Times.Exactly(1));
        }

        [Test]
        public void WorksProperly_WhenPassedParametersAreCorrect()
        {
            // Arrange
            var listOfCars = new List<Car>
            {
                new Car() { Id = Guid.NewGuid(), Manufacturer = "VW", Model = "Golf",  },
                new Car() { Id = Guid.NewGuid(), Manufacturer = "BMW", Model = "e40",  },
                new Car() { Id = Guid.NewGuid(), Manufacturer = "Lada", Model = "2105",  }
            };
            var mockedRepo = new Mock<IEfGenericRepository<Car>>();
            mockedRepo.Setup(m => m.All()).Returns(listOfCars);
            var service = new CarsService(mockedRepo.Object);

            // Act
            var result = service.GetAllCars().ToList();

            // Assert
            Assert.AreEqual(listOfCars.Count, result.Count);
        }
    }
}
