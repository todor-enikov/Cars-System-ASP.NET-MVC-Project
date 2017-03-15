using CarsSystem.Data;
using CarsSystem.Data.Models;
using CarsSystem.Data.Repositories;
using Moq;
using NUnit.Framework;

namespace CarsSystem.Tests.Data.CarsSystem.Data.EfGenericRepositoryTests
{
    [TestFixture]
    public class GetById
    {
        [Test]
        public void SpecificUserById()
        {
            // Arrange
            var user = new User()
            {
                Id = "test",
                FirstName = "Gosho",
                SecondName = "Petrov",
                LastName = "Ivanov"
            };
            var mockedDb = new Mock<ICarsSystemDbContext>();
            mockedDb.Setup(m => m.Set<User>().Find("test")).Returns(user);
            var repository = new EfGenericRepository<User>(mockedDb.Object);

            // Act
            repository.GetById("test");

            // Assert
            mockedDb.Verify(m => m.Set<User>().Find("test"), Times.Exactly(1));
        }
    }
}
