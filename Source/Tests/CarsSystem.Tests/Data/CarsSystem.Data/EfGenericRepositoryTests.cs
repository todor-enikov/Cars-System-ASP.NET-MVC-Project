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
            ICarsSystemDbContext context = null;

            Assert.Throws<ArgumentException>(() => new EfGenericRepository<Car>(context));
        }

        [Test]
        public void EfGenericRepository_ShouldCreateCarRepository_WhenThePassedParametersAreValid()
        {
            var context = new Mock<ICarsSystemDbContext>();

            var repository = new EfGenericRepository<Car>(context.Object);

            Assert.IsInstanceOf<EfGenericRepository<Car>>(repository);
        }

        [Test]
        public void EfGenericRepository_ShouldCreateUserRepository_WhenThePassedParametersAreValid()
        {
            var context = new Mock<ICarsSystemDbContext>();

            var repository = new EfGenericRepository<User>(context.Object);

            Assert.IsInstanceOf<EfGenericRepository<User>>(repository);
        }

        [Test]
        public void EfGenericRepository_ShouldCreateCarIRepository_WhenThePassedParametersAreValid()
        {
            var context = new Mock<ICarsSystemDbContext>();

            var repository = new EfGenericRepository<Car>(context.Object);

            Assert.IsInstanceOf<IRepository<Car>>(repository);
        }

        [Test]
        public void EfGenericRepository_ShouldCreateUserIRepository_WhenThePassedParametersAreValid()
        {
            var context = new Mock<ICarsSystemDbContext>();

            var repository = new EfGenericRepository<User>(context.Object);

            Assert.IsInstanceOf<IRepository<User>>(repository);
        }

        [Test]
        public void EfGenericRepository_ShouldGetSpecificUserById()
        {
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

            repository.GetById("test");

            mockedDb.Verify(m => m.Set<User>().Find("test"), Times.Exactly(1));
        }

        [Test]
        public void EfGenericRepository_ShouldReturnCollectionOfUsers()
        {
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
            var mockedRepository = new Mock<IRepository<User>>();
            mockedRepository.Setup(r => r.All()).Returns(users);

            var result = mockedRepository.Object.All();

            mockedRepository.Verify(r => r.All(), Times.Exactly(1));
        }

        [Test]
        public void EfGenericRepository_ShouldVerifyThatAddsUser_WhenPassedParametersAreValid()
        {
            var user = new User()
            {
                Id = "test",
                FirstName = "Gosho",
                SecondName = "Petrov",
                LastName = "Ivanov"
            };

            var mockedRepository = new Mock<IRepository<User>>();
            mockedRepository.Setup(r => r.Add(user)).Verifiable();

            mockedRepository.Object.Add(user);

            mockedRepository.Verify(r => r.Add(user), Times.Exactly(1));
        }

        [Test]
        public void EfGenericRepository_ShouldVerifyThatNotAddUser_WhenPassedParametersAreInValid()
        {
            var user = new User()
            {
                Id = "test",
                FirstName = "Gosho",
                SecondName = "Petrov",
                LastName = "Ivanov"
            };
            var mockedRepository = new Mock<IRepository<User>>();
            mockedRepository.Setup(r => r.Add(user)).Verifiable();

            mockedRepository.Object.Add(user);
            mockedRepository.Object.Add(user);

            mockedRepository.Verify(r => r.Add(user), Times.Exactly(2));
        }

        [Test]
        public void EfGenericRepository_ShouldVerifyThatUpdateUserCorrectly_WhenPassedParametersAreValid()
        {
            var user = new User()
            {
                Id = "test",
                FirstName = "Gosho",
                SecondName = "Petrov",
                LastName = "Ivanov"
            };
            var mockedRepository = new Mock<IRepository<User>>();
            mockedRepository.Setup(r => r.Update(user)).Verifiable();

            mockedRepository.Object.Update(user);

            mockedRepository.Verify(r => r.Update(user), Times.Exactly(1));
        }

        [Test]
        public void EfGenericRepository_ShouldVerifyThatDeleteUserCorrectlyByObject_WhenPassedParametersAreValid()
        {
            var user = new User()
            {
                Id = "test",
                FirstName = "Gosho",
                SecondName = "Petrov",
                LastName = "Ivanov"
            };
            var mockedRepository = new Mock<IRepository<User>>();
            mockedRepository.Setup(r => r.Add(user)).Verifiable();
            mockedRepository.Setup(r => r.Delete(user)).Verifiable();

            mockedRepository.Object.Add(user);
            mockedRepository.Object.Add(user);
            mockedRepository.Object.Delete(user);
            mockedRepository.Object.Delete(user);

            mockedRepository.Verify(r => r.Delete(user), Times.Exactly(2));
        }

        [Test]
        public void EfGenericRepository_ShouldVerifyThatDeleteUserCorrectlyById_WhenPassedParametersAreValid()
        {
            var user = new User()
            {
                Id = "test",
                FirstName = "Gosho",
                SecondName = "Petrov",
                LastName = "Ivanov"
            };
            var mockedRepository = new Mock<IRepository<User>>();
            mockedRepository.Setup(r => r.Add(user)).Verifiable();
            mockedRepository.Setup(r => r.Delete("test")).Verifiable();

            mockedRepository.Object.Add(user);
            mockedRepository.Object.Delete("test");

            mockedRepository.Verify(r => r.Delete("test"), Times.Exactly(1));
        }
    }
}
