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
    public class FilterExpiringInsurance
    {
        [Test]
        public void ShouldReturnIEnumerableCollection_WhenPassedParametersAreCorrect()
        {
            // Arrange
            var collectionOfCars = new List<Car>
            {
                new Car() { Id = Guid.NewGuid(), Manufacturer = "VW", Model = "Golf", ValidUntilInsurance = DateTime.Now },
                new Car() { Id = Guid.NewGuid(), Manufacturer = "BMW", Model = "e40", ValidUntilInsurance = DateTime.Now },
                new Car() { Id = Guid.NewGuid(), Manufacturer = "Lada", Model = "2105", ValidUntilInsurance = DateTime.Now }
            };
            var mockedRepo = new Mock<IEfGenericRepository<Car>>();
            mockedRepo.Setup(m => m.All()).Returns(collectionOfCars);
            var service = new FilterService(mockedRepo.Object);

            // Act
            var result = service.FilterExpiringInsuranceInTheNextSevenDays().ToList();

            // Assert
            Assert.AreEqual(collectionOfCars.Count, result.Count);
        }

        [Test]
        public void VerifyThatTheMethodIsCalledExactOneTime_WhenPassedParametersAreCorrect()
        {
            // Arrange
            var collectionOfCars = new List<Car>
            {
                new Car() { Id = Guid.NewGuid(), Manufacturer = "VW", Model = "Golf", ValidUntilInsurance = DateTime.Now },
                new Car() { Id = Guid.NewGuid(), Manufacturer = "BMW", Model = "e40", ValidUntilInsurance = DateTime.Now },
                new Car() { Id = Guid.NewGuid(), Manufacturer = "Lada", Model = "2105", ValidUntilInsurance = DateTime.Now }
            };
            var mockedRepo = new Mock<IEfGenericRepository<Car>>();
            mockedRepo.Setup(m => m.All()).Returns(collectionOfCars);
            var service = new FilterService(mockedRepo.Object);

            // Act
            service.FilterExpiringInsuranceInTheNextSevenDays();

            // Assert
            mockedRepo.Verify(m => m.All(), Times.Exactly(1));
        }
    }
}
