using CarsSystem.Data.Models;
using CarsSystem.Data.Repositories;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace CarsSystem.Tests.Data.CarsSystem.Data.EfGenericRepositoryTests
{
    [TestFixture]
    public class All
    {
        [Test]
        public void ShouldReturnCollectionOfUsers()
        {
            // Arrange
            var firstUser = new User()
            {
                Id = "test",
                FirstName = "Gosho",
                SecondName = "Petrov",
                LastName = "Ivanov"
            };
            var secondUser = new User()
            {
                Id = "test",
                FirstName = "Gosho",
                SecondName = "Petrov",
                LastName = "Ivanov"
            };
            var users = new List<User>();
            users.Add(firstUser);
            users.Add(secondUser);
            var mockedRepository = new Mock<IEfGenericRepository<User>>();
            mockedRepository.Setup(r => r.All()).Returns(users);

            // Act
            var result = mockedRepository.Object.All();

            // Assert
            mockedRepository.Verify(r => r.All(), Times.Exactly(1));
        }
    }
}
