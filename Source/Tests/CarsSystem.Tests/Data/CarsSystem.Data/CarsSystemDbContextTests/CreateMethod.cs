using CarsSystem.Data;
using NUnit.Framework;

namespace CarsSystem.Tests.Data.CarsSystem.Data.CarsSystemDbContextTests
{
    [TestFixture]
    public class CreateMethod
    {
        [Test]
        public void ShouldReturnInstanceOfCarsDbContext()
        {
            // Arrange
            var db = CarsSystemDbContext.Create();

            // Act & Assert
            Assert.IsInstanceOf<CarsSystemDbContext>(db);
        }

        [Test]
        public void ShouldReturnInstanceOfICarsDbContext()
        {
            // Arrange
            var db = CarsSystemDbContext.Create();

            // Act & Assert
            Assert.IsInstanceOf<ICarsSystemDbContext>(db);
        }
    }
}
