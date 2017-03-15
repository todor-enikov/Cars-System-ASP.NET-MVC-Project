using CarsSystem.Data.Models;
using CarsSystem.Data.Repositories;
using Moq;
using NUnit.Framework;

namespace CarsSystem.Tests.Data.CarsSystem.Data.EfGenericRepositoryTests
{
    [TestFixture]
    public class Add
    {
        [Test]
        public void VerifyThatAddsUser_WhenPassedParametersAreValid()
        {
            // Arrange
            var user = new User()
            {
                Id = "test",
                FirstName = "Gosho",
                SecondName = "Petrov",
                LastName = "Ivanov"
            };

            var mockedRepository = new Mock<IEfGenericRepository<User>>();
            mockedRepository.Setup(r => r.Add(user)).Verifiable();

            // Act
            mockedRepository.Object.Add(user);

            // Assert
            mockedRepository.Verify(r => r.Add(user), Times.Exactly(1));
        }

        [Test]
        public void VerifyThatNotAddUser_WhenPassedParametersAreInValid()
        {
            // Arrange
            var user = new User()
            {
                Id = "test",
                FirstName = "Gosho",
                SecondName = "Petrov",
                LastName = "Ivanov"
            };
            var mockedRepository = new Mock<IEfGenericRepository<User>>();
            mockedRepository.Setup(r => r.Add(user)).Verifiable();

            // Act
            mockedRepository.Object.Add(user);
            mockedRepository.Object.Add(user);

            // Assert
            mockedRepository.Verify(r => r.Add(user), Times.Exactly(2));
        }
    }
}
