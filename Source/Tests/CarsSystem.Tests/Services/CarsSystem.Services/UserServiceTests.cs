using CarsSystem.Data.Models;
using CarsSystem.Data.Repositories;
using CarsSystem.Services;
using CarsSystem.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarsSystem.Tests.Services.CarsSystem.Services.Data
{
    [TestFixture]
    public class UserServiceTests
    {
        [Test]
        public void UsersService_ShouldThrowArgumentNullException_WhenPassedRepositoryIsNull()
        {
            // Arrange
            IEfGenericRepository<User> mockedRepository = null;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new UsersService(mockedRepository));
        }

        [Test]
        public void UsersService_ShouldThrowArgumentNullExceptionWithExpectedMessage_WhenPassedRepositoryIsNull()
        {
            // Arrange
            IEfGenericRepository<User> mockedRepository = null;

            // Act
            var expectedMessage = Assert.Throws<ArgumentException>(() => new UsersService(mockedRepository));

            // Assert
            Assert.IsTrue(expectedMessage.Message.Contains("null"));
        }

        [Test]
        public void UsersService_ShouldCreateInstanceOfUsersService_WhenPassedRepositoryIsCorrectly()
        {
            // Arrange
            var mockedRepository = new Mock<IEfGenericRepository<User>>();

            // Act
            var service = new UsersService(mockedRepository.Object);

            // Assert
            Assert.IsInstanceOf<UsersService>(service);
        }

        [Test]
        public void UsersService_ShouldImplementsInterfaceIUsersService_WhenPassedRepositoryIsCorrectly()
        {
            // Arrange
            var mockedRepository = new Mock<IEfGenericRepository<User>>();

            // Act
            var service = new UsersService(mockedRepository.Object);

            // Assert
            Assert.IsInstanceOf<IUsersService>(service);
        }

        [Test]
        public void UsersService_VerifyTheMethodGetAllCars_IsCalled_WhenPassedParametersAreCorrect()
        {
            // Arrange
            var listOfUser = new List<User>
            {
                new User() { Id="test", FirstName="Gosho", LastName="Pochivkata" },
                new User() { Id="test1", FirstName="Monti", LastName="Picha" },
                new User() { Id="test2", FirstName="Marin", LastName="The hunter" },

            };
            var mockedRepo = new Mock<IEfGenericRepository<User>>();
            mockedRepo.Setup(m => m.All()).Returns(listOfUser);
            var service = new UsersService(mockedRepo.Object);

            // Act
            service.GetAllUsers();

            // Assert
            mockedRepo.Verify(m => m.All(), Times.Exactly(1));
        }

        [Test]
        public void UsersService_VerifyTheMethodGetCarById_IsCalled_WhenPassedParametersAreCorrect()
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
        public void UsersService_GetUserByIdWorksProperly_WhenPassedParametersAreCorrect()
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

        [Test]
        public void UsersService_GetAllUsersMethodWorksProperly_WhenPassedParametersAreCorrect()
        {
            // Arrange
            var listOfUser = new List<User>
            {
                new User() { Id="test", FirstName="Gosho", LastName="Pochivkata" },
                new User() { Id="test1", FirstName="Monti", LastName="Picha" },
                new User() { Id="test2", FirstName="Marin", LastName="The hunter" },

            };
            var mockedRepo = new Mock<IEfGenericRepository<User>>();
            mockedRepo.Setup(m => m.All()).Returns(listOfUser);
            var service = new UsersService(mockedRepo.Object);

            // Act
            var result = service.GetAllUsers().ToList();

            // Assert
            Assert.AreEqual(listOfUser.Count, result.Count);
        }

        [Test]
        public void UsersService_MethodGetUserId_ReturnsExpectedUserId()
        {
            // Arrange
            var car = new Car() { UserId = "test", Manufacturer = "Trabant", Model = "Iztrebitel" };
            var listOfUser = new List<User>
            {
                new User() { Id="test", FirstName="Gosho", LastName="Pochivkata" },
                new User() { Id="test1", FirstName="Monti", LastName="Picha" },
                new User() { Id="test2", FirstName="Marin", LastName="The hunter" },

            };
            var mockedRepo = new Mock<IEfGenericRepository<User>>();
            mockedRepo.Setup(m => m.All()).Returns(listOfUser);
            var service = new UsersService(mockedRepo.Object);

            // Act
            var actualResult = service.GetUserId(car);
            var expectedResult = "test";

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void UsersService_VerifyTheMethodGetUserByEGN_IsCalled_WhenPassedParametersAreCorrect()
        {
            // Arrange
            var listOfUser = new List<User>
            {
                new User() { Id = "test", FirstName = "Gosho", LastName = "Pochivkata", EGN = 6402234353 },
                new User() { Id = "test1", FirstName = "Monti", LastName = "Picha", EGN = 6402234343 },
                new User() { Id = "test2", FirstName = "Marin", LastName = "The hunter", EGN = 6406544343 },
            };

            var mockedRepo = new Mock<IEfGenericRepository<User>>();
            mockedRepo.Setup(c => c.All()).Returns(listOfUser);
            var service = new UsersService(mockedRepo.Object);

            // Act
            service.GetUserByEGN(6402234353);

            // Assert
            mockedRepo.Verify(m => m.All(), Times.Exactly(1));
        }

        [Test]
        public void UsersService_MethodGetUserByEGN_ShouldReturnTheExpectedResult()
        {
            // Arrange
            var listOfUser = new List<User>
            {
                new User() { Id = "test", FirstName = "Gosho", LastName = "Pochivkata", EGN = 6402234353 },
                new User() { Id = "test1", FirstName = "Monti", LastName = "Picha", EGN = 6402234343 },
                new User() { Id = "test2", FirstName = "Marin", LastName = "The hunter", EGN = 6406544343 },
            };

            var mockedRepo = new Mock<IEfGenericRepository<User>>();
            mockedRepo.Setup(c => c.All()).Returns(listOfUser);
            var service = new UsersService(mockedRepo.Object);

            // Act
            var actualResult = service.GetUserByEGN(6402234353).ToList();
            var expectedResult = 1;

            // Assert
            Assert.AreEqual(expectedResult, actualResult.Count);
        }
    }
}
