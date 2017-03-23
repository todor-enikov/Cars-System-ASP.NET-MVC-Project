using CarsSystem.Data.Models;
using CarsSystem.Data.Repositories;
using CarsSystem.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace CarsSystem.Tests.Services.CarsSystem.Services.FilterServiceTests
{
    [TestFixture]
    public class GetMailsFor
    {
        [Test]
        public void CarsVignetteExpiration_VerifysThatMethodAllIsCalledExactlyOneTime()
        {
            // Arrange
            var collectionOfCars = new List<Car>
            {
                new Car() { Id = Guid.NewGuid(), Manufacturer = "VW", Model = "Golf", ValidUntilVignette = DateTime.Now,  },
                new Car() { Id = Guid.NewGuid(), Manufacturer = "BMW", Model = "e40", ValidUntilVignette = DateTime.Now,  },
                new Car() { Id = Guid.NewGuid(), Manufacturer = "Lada", Model = "2105", ValidUntilVignette = DateTime.Now, }
            };

            var mockedRepo = new Mock<IEfGenericRepository<Car>>();
            mockedRepo.Setup(m => m.All()).Returns(collectionOfCars);
            var service = new FilterService(mockedRepo.Object);

            // Act
            service.GetMailsForCarsVignetteExpiration();

            // Assert
            mockedRepo.Verify(m => m.All(), Times.Exactly(1));
        }

        [Test]
        public void CarsInsuranceExpiration_VerifysThatMethodAllIsCalledExactlyOneTime()
        {
            // Arrange
            var collectionOfCars = new List<Car>
            {
                new Car() { Id = Guid.NewGuid(), Manufacturer = "VW", Model = "Golf", ValidUntilVignette = DateTime.Now,  },
                new Car() { Id = Guid.NewGuid(), Manufacturer = "BMW", Model = "e40", ValidUntilVignette = DateTime.Now,  },
                new Car() { Id = Guid.NewGuid(), Manufacturer = "Lada", Model = "2105", ValidUntilVignette = DateTime.Now, }
            };

            var mockedRepo = new Mock<IEfGenericRepository<Car>>();
            mockedRepo.Setup(m => m.All()).Returns(collectionOfCars);
            var service = new FilterService(mockedRepo.Object);

            // Act
            service.GetMailsForCarsInsuranceExpiration();

            // Assert
            mockedRepo.Verify(m => m.All(), Times.Exactly(1));
        }

        [Test]
        public void CarsAnnualCheckUpExpiration_VerifysThatMethodAllIsCalledExactlyOneTime()
        {
            // Arrange
            var collectionOfCars = new List<Car>
            {
                new Car() { Id = Guid.NewGuid(), Manufacturer = "VW", Model = "Golf", ValidUntilVignette = DateTime.Now,  },
                new Car() { Id = Guid.NewGuid(), Manufacturer = "BMW", Model = "e40", ValidUntilVignette = DateTime.Now,  },
                new Car() { Id = Guid.NewGuid(), Manufacturer = "Lada", Model = "2105", ValidUntilVignette = DateTime.Now, }
            };

            var mockedRepo = new Mock<IEfGenericRepository<Car>>();
            mockedRepo.Setup(m => m.All()).Returns(collectionOfCars);
            var service = new FilterService(mockedRepo.Object);

            // Act
            service.GetMailsForCarsAnnualCheckUpExpiration();

            // Assert
            mockedRepo.Verify(m => m.All(), Times.Exactly(1));
        }
    }
}
