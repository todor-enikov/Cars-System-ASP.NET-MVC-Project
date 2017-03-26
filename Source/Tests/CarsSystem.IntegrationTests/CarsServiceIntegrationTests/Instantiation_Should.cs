using System;
using NUnit.Framework;
using CarsSystem.Data.Repositories;
using CarsSystem.Data.Models;
using CarsSystem.Services;
using CarsSystem.Data;
using CarsSystem.Services.Contracts;

namespace CarsSystem.IntegrationTests
{
    [TestFixture]
    public class Instantiation_Should
    {
        [Test]
        public void ThrowArgumentException_IfEfRepositoryIsNull()
        {
            // Arrange
            EfGenericRepository<Car> carRepo = null;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new CarsService(carRepo));
            Assert.IsNull(carRepo);
        }

        [Test]
        public void CreateCorrectlyCarsService_IfEfRepositoryIsNotNull()
        {
            // Arrange
            CarsSystemDbContext context = new CarsSystemDbContext();
            EfGenericRepository<Car> carRepo = new EfGenericRepository<Car>(context);

            // Act & Assert
            Assert.DoesNotThrow(() => new CarsService(carRepo));
            Assert.IsNotNull(carRepo);
        }

        [Test]
        public void CreateInstance_OfTypeICarsService()
        {
            // Arrange
            CarsSystemDbContext context = new CarsSystemDbContext();
            EfGenericRepository<Car> carRepo = new EfGenericRepository<Car>(context);

            // Act
            var carsService = new CarsService(carRepo);

            // Assert
            Assert.IsInstanceOf<ICarsService>(carsService);
        }
    }
}
