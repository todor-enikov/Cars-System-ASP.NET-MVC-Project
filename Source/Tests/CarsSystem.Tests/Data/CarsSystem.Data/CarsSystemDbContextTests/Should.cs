using CarsSystem.Data;
using NUnit.Framework;

namespace CarsSystem.Tests.Data.CarsSystem.Data.CarsSystemDbContextTests
{
    [TestFixture]
    public class Should
    {
        [Test]
        public void CreateInstanceOfDatabase()
        {
            // Arrange
            var db = new CarsSystemDbContext();

            // Act & Assert
            Assert.IsInstanceOf<CarsSystemDbContext>(db);
        }

        [Test]
        public void BeTypeOfICarsDbContext()
        {
            // Arrange
            var db = new CarsSystemDbContext();

            // Act & Assert
            Assert.IsInstanceOf<ICarsSystemDbContext>(db);
        }
    }
}
