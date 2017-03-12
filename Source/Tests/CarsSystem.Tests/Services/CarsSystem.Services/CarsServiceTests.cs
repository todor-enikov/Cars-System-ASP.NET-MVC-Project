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
    public class CarsServiceTests
    {
        [Test]
        public void CarsService_ShouldThrowArgumentNullException_WhenPassedRepositoryIsNull()
        {
            // Arrange
            IEfGenericRepository<Car> mockedRepository = null;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new CarsService(mockedRepository));
        }

        [Test]
        public void CarsService_ShouldThrowArgumentNullExceptionWithExpectedMessage_WhenPassedRepositoryIsNull()
        {
            // Arrange
            IEfGenericRepository<Car> mockedRepository = null;

            // Act
            var expectedMessage = Assert.Throws<ArgumentException>(() => new CarsService(mockedRepository));

            // Assert
            Assert.IsTrue(expectedMessage.Message.Contains("null"));
        }

        [Test]
        public void CarsService_ShouldCreateInstanceOfCarsService_WhenPassedRepositoryIsCorrectly()
        {
            // Arrange
            var mockedRepository = new Mock<IEfGenericRepository<Car>>();

            // Act
            var service = new CarsService(mockedRepository.Object);

            // Assert
            Assert.IsInstanceOf<CarsService>(service);
        }

        [Test]
        public void CarsService_ShouldImplementsInterfaceICarsService_WhenPassedRepositoryIsCorrectly()
        {
            // Arrange
            var mockedRepository = new Mock<IEfGenericRepository<Car>>();

            // Act
            var service = new CarsService(mockedRepository.Object);

            // Assert
            Assert.IsInstanceOf<ICarsService>(service);
        }

        [Test]
        public void CarsService_VerifyTheMethodGetAllCars_IsCalled_WhenPassedParametersAreCorrect()
        {
            // Arrange
            var listOfCars = new List<Car>
            {
                new Car() { Id=1, Manufacturer="VW", Model="Golf",  },
                new Car() { Id=2, Manufacturer="BMW", Model="e40",  },
                new Car() { Id=3, Manufacturer="Lada", Model="2105",  }
            };
            var mockedRepo = new Mock<IEfGenericRepository<Car>>();
            mockedRepo.Setup(m => m.All()).Returns(listOfCars);
            var service = new CarsService(mockedRepo.Object);

            // Act
            service.GetAllCars();

            // Assert
            mockedRepo.Verify(m => m.All(), Times.Exactly(1));
        }

        [Test]
        public void CarsService_VerifyTheMethodGetCarById_IsCalled_WhenPassedParametersAreCorrect()
        {
            // Arrange
            var car = new Car() { Id = 1, Manufacturer = "VW", Model = "Golf", };
            var mockedRepo = new Mock<IEfGenericRepository<Car>>();
            mockedRepo.Setup(m => m.GetById(2)).Returns(car);
            var service = new CarsService(mockedRepo.Object);

            // Act
            service.GetCarById(1);

            // Assert
            mockedRepo.Verify(m => m.GetById(1), Times.Exactly(1));
        }

        [Test]
        public void CarsService_VerifyTheMethodAddCar_IsCalled_WhenPassedParametersAreCorrect()
        {
            // Arrange
            var car = new Car() { Id = 1, Manufacturer = "VW", Model = "Golf", };
            var mockedRepo = new Mock<IEfGenericRepository<Car>>();
            mockedRepo.Setup(m => m.Add(car)).Verifiable();
            var service = new CarsService(mockedRepo.Object);

            // Act
            service.AddCar(car);

            // Assert
            mockedRepo.Verify(m => m.Add(car), Times.Exactly(1));
        }

        [Test]
        public void CarsService_GetAllCarsWorksProperly_WhenPassedParametersAreCorrect()
        {
            // Arrange
            var listOfCars = new List<Car>
            {
                new Car() { Id=1, Manufacturer="VW", Model="Golf",  },
                new Car() { Id=2, Manufacturer="BMW", Model="e40",  },
                new Car() { Id=3, Manufacturer="Lada", Model="2105",  }
            };
            var mockedRepo = new Mock<IEfGenericRepository<Car>>();
            mockedRepo.Setup(m => m.All()).Returns(listOfCars);
            var service = new CarsService(mockedRepo.Object);

            // Act
            var result = service.GetAllCars().ToList();

            // Assert
            Assert.AreEqual(listOfCars.Count, result.Count);
        }

        [Test]
        public void CarsService_GetCarByIdWorksProperly_WhenPassedParametersAreCorrect()
        {
            // Arrange
            var car = new Car() { Id = 1, Manufacturer = "VW", Model = "Golf", };
            var mockedRepo = new Mock<IEfGenericRepository<Car>>();
            mockedRepo.Setup(m => m.GetById(1)).Returns(car);
            var service = new CarsService(mockedRepo.Object);

            // Act
            var result = service.GetCarById(1);

            // Assert
            Assert.AreEqual(car.Manufacturer, result.Manufacturer);
        }

        [Test]
        public void CarsService_MethodGetCarId_ReturnsExpectedCarId()
        {
            // Arrange
            var user = new User() { Id = "test", FirstName = "Gosho", LastName = "Pochivkata" };
            var listOfCars = new List<Car>
            {
                new Car() { Id=1, Manufacturer="VW", Model="Golf", UserId="test" },
                new Car() { Id=2, Manufacturer="BMW", Model="e40", UserId="test1" },
                new Car() { Id=3, Manufacturer="Lada", Model="2105", UserId="test2" }
            };
            var mockedRepo = new Mock<IEfGenericRepository<Car>>();
            mockedRepo.Setup(m => m.All()).Returns(listOfCars);
            var service = new CarsService(mockedRepo.Object);

            // Act
            var actualResult = service.GetCarId(user);
            var expectedResult = 1;

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
