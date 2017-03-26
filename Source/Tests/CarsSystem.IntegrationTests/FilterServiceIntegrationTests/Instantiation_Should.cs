using CarsSystem.Data;
using CarsSystem.Data.Models;
using CarsSystem.Data.Repositories;
using CarsSystem.Services;
using CarsSystem.Services.Contracts;
using NUnit.Framework;
using System;

namespace CarsSystem.IntegrationTests.FilterServiceTests
{
    [TestFixture]
    public class Instantiation_Should
    {
        [Test]
        public void ThrowArgumentException_IfEfRepositoyryIsNull()
        {
            // Arrange
            EfGenericRepository<Car> carRepo = null;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new FilterService(carRepo));
            Assert.IsNull(carRepo);
        }

        [Test]
        public void CreateCorrectlyFilterService_IfEfRepositoyryIsNotNull()
        {
            // Arrange
            CarsSystemDbContext context = new CarsSystemDbContext();
            EfGenericRepository<Car> carRepo = new EfGenericRepository<Car>(context);

            // Act & Assert
            Assert.DoesNotThrow(() => new FilterService(carRepo));
            Assert.IsNotNull(carRepo);
        }

        [Test]
        public void CreateInstance_OfTypeIFilterService()
        {
            // Arrange
            CarsSystemDbContext context = new CarsSystemDbContext();
            EfGenericRepository<Car> carRepo = new EfGenericRepository<Car>(context);

            // Act
            var filterService = new FilterService(carRepo);

            // Assert
            Assert.IsInstanceOf<IFilterService>(filterService);
        }
    }
}
