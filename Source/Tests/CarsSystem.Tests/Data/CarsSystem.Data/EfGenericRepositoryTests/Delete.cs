using CarsSystem.Data.Models;
using CarsSystem.Data.Repositories;
using Moq;
using NUnit.Framework;

namespace CarsSystem.Tests.Data.CarsSystem.Data.EfGenericRepositoryTests
{
    [TestFixture]
    public class Delete
    {
        [Test]
        public void VerifyThatDeleteUserCorrectlyByObject_WhenPassedParametersAreValid()
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
            mockedRepository.Setup(r => r.Delete(user)).Verifiable();

            // Act
            mockedRepository.Object.Add(user);
            mockedRepository.Object.Add(user);
            mockedRepository.Object.Delete(user);
            mockedRepository.Object.Delete(user);

            // Assert
            mockedRepository.Verify(r => r.Delete(user), Times.Exactly(2));
        }

        [Test]
        public void VerifyThatDeleteUserCorrectlyById_WhenPassedParametersAreValid()
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
            mockedRepository.Setup(r => r.Delete("test")).Verifiable();

            // Act
            mockedRepository.Object.Add(user);
            mockedRepository.Object.Delete("test");

            // Assert
            mockedRepository.Verify(r => r.Delete("test"), Times.Exactly(1));
        }
    }
}
