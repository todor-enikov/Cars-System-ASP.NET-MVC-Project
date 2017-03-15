using CarsSystem.Data.Models;
using CarsSystem.Data.Repositories;
using CarsSystem.Services;
using Moq;
using NUnit.Framework;

namespace CarsSystem.Tests.Services.CarsSystem.Services.UserServiceTests
{
    [TestFixture]
    public class GetUserById
    {
        [Test]
        public void IsCalled_WhenPassedParametersAreCorrect()
        {
            // Arrange
            var user = new User() { Id = "test", FirstName = "Gosho", LastName = "Pochivkata" };
            var mockedRepo = new Mock<IEfGenericRepository<User>>();
            mockedRepo.Setup(c => c.GetById("test")).Returns(user);
            var service = new UsersService(mockedRepo.Object);

            // Act
            service.GetUserById("test");

            // Assert
            mockedRepo.Verify(m => m.GetById("test"), Times.Exactly(1));
        }

        [Test]
        public void WorksProperly_WhenPassedParametersAreCorrect()
        {
            // Arrange
            var user = new User() { Id = "test", FirstName = "Gosho", LastName = "Pochivkata" };
            var mockedRepo = new Mock<IEfGenericRepository<User>>();
            mockedRepo.Setup(c => c.GetById("test")).Returns(user);
            var service = new UsersService(mockedRepo.Object);

            // Act
            var result = service.GetUserById("test");

            // Assert
            Assert.AreEqual(user.FirstName, result.FirstName);
        }
    }
}
