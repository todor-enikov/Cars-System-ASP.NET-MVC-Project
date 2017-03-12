using CarsSystem.Data;
using NUnit.Framework;

namespace CarsSystem.Tests.Data.CarsSystem.Data
{
    [TestFixture]
    public class CarsSystemDbContextTests
    {
        [Test]
        public void CarsSystemDbContext_ShouldCreateInstanceOfDatabase()
        {
            // Arrange
            var db = new CarsSystemDbContext();

            // Act & Assert
            Assert.IsInstanceOf<CarsSystemDbContext>(db);
        }

        [Test]
        public void CarsSystemDbContext_ShouldBeTypeOfICarsDbContext()
        {
            // Arrange
            var db = new CarsSystemDbContext();

            // Act & Assert
            Assert.IsInstanceOf<ICarsSystemDbContext>(db);
        }

        [Test]
        public void CarsSystemDbContext_CreateMethodShouldReturnInstanceOfCarsDbContext()
        {
            // Arrange
            var db = CarsSystemDbContext.Create();

            // Act & Assert
            Assert.IsInstanceOf<CarsSystemDbContext>(db);
        }

        [Test]
        public void CarsSystemDbContext_CreateMethodShouldReturnInstanceOfICarsDbContext()
        {
            // Arrange
            var db = CarsSystemDbContext.Create();

            // Act & Assert
            Assert.IsInstanceOf<ICarsSystemDbContext>(db);
        }
    }
}
