using CarsSystem.Data.Models;
using CarsSystem.Data.Repositories;
using CarsSystem.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarsSystem.Tests.Services.CarsSystem.Services.FilterServiceTests
{
    [TestFixture]
    public class FilterExpiringVignetteCars
    {
        [Test]
        public void ShouldReturnIEnumerableCollection_WhenPassedParametersAreCorrect()
        {
            // Arrange
            var collectionOfCars = new List<Car>
            {
                new Car() { Id = Guid.NewGuid(), Manufacturer = "VW", Model = "Golf", ValidUntilVignette = DateTime.Now },
                new Car() { Id = Guid.NewGuid(), Manufacturer = "BMW", Model = "e40", ValidUntilVignette = DateTime.Now },
                new Car() { Id = Guid.NewGuid(), Manufacturer = "Lada", Model = "2105", ValidUntilVignette = DateTime.Now }
            };
            var mockedRepo = new Mock<IEfGenericRepository<Car>>();
            mockedRepo.Setup(m => m.All()).Returns(collectionOfCars);
            var service = new FilterService(mockedRepo.Object);

            // Act
            var result = service.FilterExpiringVignetteCarsInTheNextSevenDays().ToList();

            // Assert
            Assert.AreEqual(collectionOfCars.Count, result.Count);
        }

        [Test]
        public void VerifyThatTheMethodIsCalledExactOneTime_WhenPassedParametersAreCorrect()
        {
            // Arrange
            var collectionOfCars = new List<Car>
            {
                new Car() { Id = Guid.NewGuid(), Manufacturer = "VW", Model = "Golf", ValidUntilVignette = DateTime.Now },
                new Car() { Id = Guid.NewGuid(), Manufacturer = "BMW", Model = "e40", ValidUntilVignette = DateTime.Now },
                new Car() { Id = Guid.NewGuid(), Manufacturer = "Lada", Model = "2105", ValidUntilVignette = DateTime.Now }
            };
            var mockedRepo = new Mock<IEfGenericRepository<Car>>();
            mockedRepo.Setup(m => m.All()).Returns(collectionOfCars);
            var service = new FilterService(mockedRepo.Object);

            // Act
            service.FilterExpiringVignetteCarsInTheNextSevenDays();

            // Assert
            mockedRepo.Verify(m => m.All(), Times.Exactly(1));
        }
    }
}
