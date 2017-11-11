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
    public class FilterExpiringAnnualCheckUp
    {
        [Test]
        public void FilterService_FilterExpiringAnnualCheckUp_ShouldReturnIEnumerableCollection_WhenPassedParametersAreCorrect()
        {
            // Arrange
            var collectionOfCars = new List<Car>
            {
                new Car() { Id = Guid.NewGuid(), Manufacturer = "VW", Model = "Golf", ValidUntilAnnualCheckUp = DateTime.Now },
                new Car() { Id = Guid.NewGuid(), Manufacturer = "BMW", Model = "e40", ValidUntilAnnualCheckUp = DateTime.Now },
                new Car() { Id = Guid.NewGuid(), Manufacturer = "Lada", Model = "2105", ValidUntilAnnualCheckUp = DateTime.Now }
            };
            var mockedRepo = new Mock<IEfGenericRepository<Car>>();
            mockedRepo.Setup(s => s.All()).Returns(collectionOfCars);
            var service = new FilterService(mockedRepo.Object);

            // Act
            var result = service.FilterExpiringAnnualCheckUpInTheNextSevenDays().ToList();

            // Assert
            Assert.AreEqual(collectionOfCars.Count, result.Count);
        }

        [Test]
        public void FilterService_FilterExpiringAnnualCheckUp_VerifyThatTheMethodIsCalledExactOneTime_WhenPassedParametersAreCorrect()
        {
            // Arrange
            var collectionOfCars = new List<Car>
            {
                new Car() { Id = Guid.NewGuid(), Manufacturer = "VW", Model = "Golf", ValidUntilAnnualCheckUp = DateTime.Now },
                new Car() { Id = Guid.NewGuid(), Manufacturer = "BMW", Model = "e40", ValidUntilAnnualCheckUp = DateTime.Now },
                new Car() { Id = Guid.NewGuid(), Manufacturer = "Lada", Model = "2105", ValidUntilAnnualCheckUp = DateTime.Now }
            };
            var mockedRepo = new Mock<IEfGenericRepository<Car>>();
            mockedRepo.Setup(m => m.All()).Returns(collectionOfCars);
            var service = new FilterService(mockedRepo.Object);

            // Act
            service.FilterExpiringAnnualCheckUpInTheNextSevenDays();

            // Assert
            mockedRepo.Verify(m => m.All(), Times.Exactly(1));
        }
    }
}
