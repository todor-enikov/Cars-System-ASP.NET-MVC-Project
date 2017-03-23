using System;
using NUnit.Framework;
using CarsSystem.Data.Models;
using CarsSystem.Data.Repositories;
using Moq;
using CarsSystem.Services;

namespace CarsSystem.Tests.Services.CarsSystem.Services.UserServiceTests
{
    [TestFixture]
    public class Update
    {
        [Test]
        public void IsCalled_WhenPassedParametersAreCorrect()
        {
            // Arrange
            var user = new User() { Id = "test", FirstName = "Gosho", LastName = "Pochivkata" };
            var mockedRepo = new Mock<IEfGenericRepository<User>>();
            mockedRepo.Setup(c => c.Update(user)).Verifiable();
            var service = new UsersService(mockedRepo.Object);

            // Act
            service.Update(user);

            // Assert
            mockedRepo.Verify(c => c.Update(user), Times.Exactly(1));
        }
    }
}
