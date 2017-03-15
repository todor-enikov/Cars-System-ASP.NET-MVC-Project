using CarsSystem.Data.Models;
using CarsSystem.Data.Repositories;
using Moq;
using NUnit.Framework;

namespace CarsSystem.Tests.Data.CarsSystem.Data.EfGenericRepositoryTests
{
    [TestFixture]
    public class Update
    {
        [Test]
        public void VerifyThatUpdateUserCorrectly_WhenPassedParametersAreValid()
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
            mockedRepository.Setup(r => r.Update(user)).Verifiable();

            // Act
            mockedRepository.Object.Update(user);

            // Assert
            mockedRepository.Verify(r => r.Update(user), Times.Exactly(1));
        }
    }
}
