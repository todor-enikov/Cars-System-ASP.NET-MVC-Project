using CarsSystem.Data;
using CarsSystem.Data.Models;
using CarsSystem.Data.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace CarsSystem.Tests.Data.CarsSystem.Data
{
    [TestFixture]
    public class EfGenericRepositoryTests
    {
        [Test]
        public void EfGenericRepository_ShouldThrowArgumentNullException_WhenThePassedContextIsNull()
        {
            // Arrange
            ICarsSystemDbContext context = null;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new EfGenericRepository<Car>(context));
        }

        [Test]
        public void EfGenericRepository_ShouldCreateCarRepository_WhenThePassedParametersAreValid()
        {
            // Arrange
            var context = new Mock<ICarsSystemDbContext>();

            // Act
            var repository = new EfGenericRepository<Car>(context.Object);

            // Assert
            Assert.IsInstanceOf<EfGenericRepository<Car>>(repository);
        }

        [Test]
        public void EfGenericRepository_ShouldCreateUserRepository_WhenThePassedParametersAreValid()
        {
            // Arrange
            var context = new Mock<ICarsSystemDbContext>();

            // Act
            var repository = new EfGenericRepository<User>(context.Object);

            // Assert
            Assert.IsInstanceOf<EfGenericRepository<User>>(repository);
        }

        [Test]
        public void EfGenericRepository_ShouldCreateCarIRepository_WhenThePassedParametersAreValid()
        {
            // Arrange
            var context = new Mock<ICarsSystemDbContext>();

            // Act
            var repository = new EfGenericRepository<Car>(context.Object);

            // Assert
            Assert.IsInstanceOf<IEfGenericRepository<Car>>(repository);
        }

        [Test]
        public void EfGenericRepository_ShouldCreateUserIRepository_WhenThePassedParametersAreValid()
        {
            // Arrange
            var context = new Mock<ICarsSystemDbContext>();

            // Act
            var repository = new EfGenericRepository<User>(context.Object);

            // Assert
            Assert.IsInstanceOf<IEfGenericRepository<User>>(repository);
        }

        [Test]
        public void EfGenericRepository_ShouldGetSpecificUserById()
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

        [Test]
        public void EfGenericRepository_ShouldReturnCollectionOfUsers()
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

        [Test]
        public void EfGenericRepository_ShouldVerifyThatAddsUser_WhenPassedParametersAreValid()
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
        public void EfGenericRepository_ShouldVerifyThatNotAddUser_WhenPassedParametersAreInValid()
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

        [Test]
        public void EfGenericRepository_ShouldVerifyThatUpdateUserCorrectly_WhenPassedParametersAreValid()
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

        [Test]
        public void EfGenericRepository_ShouldVerifyThatDeleteUserCorrectlyByObject_WhenPassedParametersAreValid()
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
        public void EfGenericRepository_ShouldVerifyThatDeleteUserCorrectlyById_WhenPassedParametersAreValid()
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
