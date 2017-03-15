using CarsSystem.Data;
using CarsSystem.Data.Models;
using CarsSystem.Data.Repositories;
using Moq;
using NUnit.Framework;
using System;

namespace CarsSystem.Tests.Data.CarsSystem.Data.EfGenericRepositoryTests
{
    [TestFixture]

    public class Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenThePassedContextIsNull()
        {
            // Arrange
            ICarsSystemDbContext context = null;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new EfGenericRepository<Car>(context));
        }

        [Test]
        public void CreateCarRepository_WhenThePassedParametersAreValid()
        {
            // Arrange
            var context = new Mock<ICarsSystemDbContext>();

            // Act
            var repository = new EfGenericRepository<Car>(context.Object);

            // Assert
            Assert.IsInstanceOf<EfGenericRepository<Car>>(repository);
        }

        [Test]
        public void CreateUserRepository_WhenThePassedParametersAreValid()
        {
            // Arrange
            var context = new Mock<ICarsSystemDbContext>();

            // Act
            var repository = new EfGenericRepository<User>(context.Object);

            // Assert
            Assert.IsInstanceOf<EfGenericRepository<User>>(repository);
        }

        [Test]
        public void CreateCarIRepository_WhenThePassedParametersAreValid()
        {
            // Arrange
            var context = new Mock<ICarsSystemDbContext>();

            // Act
            var repository = new EfGenericRepository<Car>(context.Object);

            // Assert
            Assert.IsInstanceOf<IEfGenericRepository<Car>>(repository);
        }

        [Test]
        public void CreateUserIRepository_WhenThePassedParametersAreValid()
        {
            // Arrange
            var context = new Mock<ICarsSystemDbContext>();

            // Act
            var repository = new EfGenericRepository<User>(context.Object);

            // Assert
            Assert.IsInstanceOf<IEfGenericRepository<User>>(repository);
        }
    }
}
