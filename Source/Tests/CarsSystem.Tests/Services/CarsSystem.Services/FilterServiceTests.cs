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
    public class FilterServiceTests
    {
        [Test]
        public void FilterService_ShouldThrowArgumentNullException_WhenPassedRepositoryIsNull()
        {
            // Arrange
            IEfGenericRepository<Car> mockedRepository = null;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new FilterService(mockedRepository));
        }

        [Test]
        public void FilterService_ShouldThrowArgumentNullExceptionWithExpectedMessage_WhenPassedRepositoryIsNull()
        {
            // Arrange
            IEfGenericRepository<Car> mockedRepository = null;

            // Act
            var expectedMessage = Assert.Throws<ArgumentException>(() => new FilterService(mockedRepository));

            // Assert
            Assert.IsTrue(expectedMessage.Message.Contains("null"));
        }

        [Test]
        public void FilterService_ShouldCreateInstanceOfFilterService_WhenPassedRepositoryIsCorrectly()
        {
            // Arrange
            var mockedRepository = new Mock<IEfGenericRepository<Car>>();

            // Act
            var service = new FilterService(mockedRepository.Object);

            // Assert
            Assert.IsInstanceOf<FilterService>(service);
        }

        [Test]
        public void FilterService_ShouldImplementsInterfaceIFilterService_WhenPassedRepositoryIsCorrectly()
        {
            // Arrange
            var mockedRepository = new Mock<IEfGenericRepository<Car>>();

            // Act
            var service = new FilterService(mockedRepository.Object);

            // Assert
            Assert.IsInstanceOf<IFilterService>(service);
        }

        [Test]
        public void FilterService_FilterExpiringVignetteCars_ShouldReturnIEnumerableCollection_WhenPassedParametersAreCorrect()
        {
            // Arrange
            var collectionOfCars = new List<Car>
            {
                new Car() { Id = Guid.NewGuid(), Manufacturer="VW", Model="Golf", ValidUntilVignette=DateTime.Now },
                new Car() { Id = Guid.NewGuid(), Manufacturer="BMW", Model="e40", ValidUntilVignette=DateTime.Now },
                new Car() { Id = Guid.NewGuid(), Manufacturer="Lada", Model="2105", ValidUntilVignette=DateTime.Now }
            };
            var mockedRepo = new Mock<IEfGenericRepository<Car>>();
            mockedRepo.Setup(m => m.All()).Returns(collectionOfCars);
            var service = new FilterService(mockedRepo.Object);

            // Act
            var result = service.FilterExpiringVignetteCars().ToList();

            // Assert
            Assert.AreEqual(collectionOfCars.Count, result.Count);
        }

        [Test]
        public void FilterService_FilterExpiringVignetteCars_VerifyThatTheMethodIsCalledExactOneTime_WhenPassedParametersAreCorrect()
        {
            // Arrange
            var collectionOfCars = new List<Car>
            {
                new Car() { Id = Guid.NewGuid(), Manufacturer="VW", Model="Golf", ValidUntilVignette=DateTime.Now },
                new Car() { Id = Guid.NewGuid(), Manufacturer="BMW", Model="e40", ValidUntilVignette=DateTime.Now },
                new Car() { Id = Guid.NewGuid(), Manufacturer="Lada", Model="2105", ValidUntilVignette=DateTime.Now }
            };
            var mockedRepo = new Mock<IEfGenericRepository<Car>>();
            mockedRepo.Setup(m => m.All()).Returns(collectionOfCars);
            var service = new FilterService(mockedRepo.Object);

            // Act
            service.FilterExpiringVignetteCars();

            // Assert
            mockedRepo.Verify(m => m.All(), Times.Exactly(1));
        }

        [Test]
        public void FilterService_FilterExpiringInsurance_ShouldReturnIEnumerableCollection_WhenPassedParametersAreCorrect()
        {
            // Arrange
            var collectionOfCars = new List<Car>
            {
                new Car() { Id = Guid.NewGuid(), Manufacturer="VW", Model="Golf", ValidUntilInsurance=DateTime.Now },
                new Car() { Id = Guid.NewGuid(), Manufacturer="BMW", Model="e40", ValidUntilInsurance=DateTime.Now },
                new Car() { Id = Guid.NewGuid(), Manufacturer="Lada", Model="2105", ValidUntilInsurance=DateTime.Now }
            };
            var mockedRepo = new Mock<IEfGenericRepository<Car>>();
            mockedRepo.Setup(m => m.All()).Returns(collectionOfCars);
            var service = new FilterService(mockedRepo.Object);

            // Act
            var result = service.FilterExpiringInsurance().ToList();

            // Assert
            Assert.AreEqual(collectionOfCars.Count, result.Count);
        }

        [Test]
        public void FilterService_FilterExpiringInsurance_VerifyThatTheMethodIsCalledExactOneTime_WhenPassedParametersAreCorrect()
        {
            // Arrange
            var collectionOfCars = new List<Car>
            {
                new Car() { Id = Guid.NewGuid(), Manufacturer="VW", Model="Golf", ValidUntilInsurance=DateTime.Now },
                new Car() { Id = Guid.NewGuid(), Manufacturer="BMW", Model="e40", ValidUntilInsurance=DateTime.Now },
                new Car() { Id = Guid.NewGuid(), Manufacturer="Lada", Model="2105", ValidUntilInsurance=DateTime.Now }
            };
            var mockedRepo = new Mock<IEfGenericRepository<Car>>();
            mockedRepo.Setup(m => m.All()).Returns(collectionOfCars);
            var service = new FilterService(mockedRepo.Object);

            // Act
            service.FilterExpiringInsurance();

            // Assert
            mockedRepo.Verify(m => m.All(), Times.Exactly(1));
        }

        [Test]
        public void FilterService_FilterExpiringAnnualCheckUp_ShouldReturnIEnumerableCollection_WhenPassedParametersAreCorrect()
        {
            // Arrange
            var collectionOfCars = new List<Car>
            {
                new Car() { Id = Guid.NewGuid(), Manufacturer="VW", Model="Golf", ValidUntilAnnualCheckUp=DateTime.Now },
                new Car() { Id = Guid.NewGuid(), Manufacturer="BMW", Model="e40", ValidUntilAnnualCheckUp=DateTime.Now },
                new Car() { Id = Guid.NewGuid(), Manufacturer="Lada", Model="2105", ValidUntilAnnualCheckUp=DateTime.Now }
            };
            var mockedRepo = new Mock<IEfGenericRepository<Car>>();
            mockedRepo.Setup(s => s.All()).Returns(collectionOfCars);
            var service = new FilterService(mockedRepo.Object);

            // Act
            var result = service.FilterExpiringAnnualCheckUp().ToList();

            // Assert
            Assert.AreEqual(collectionOfCars.Count, result.Count);
        }

        [Test]
        public void FilterService_FilterExpiringAnnualCheckUp_VerifyThatTheMethodIsCalledExactOneTime_WhenPassedParametersAreCorrect()
        {
            // Arrange
            var collectionOfCars = new List<Car>
            {
                new Car() { Id = Guid.NewGuid(), Manufacturer="VW", Model="Golf", ValidUntilAnnualCheckUp=DateTime.Now },
                new Car() { Id = Guid.NewGuid(), Manufacturer="BMW", Model="e40", ValidUntilAnnualCheckUp=DateTime.Now },
                new Car() { Id = Guid.NewGuid(), Manufacturer="Lada", Model="2105", ValidUntilAnnualCheckUp=DateTime.Now }
            };
            var mockedRepo = new Mock<IEfGenericRepository<Car>>();
            mockedRepo.Setup(m => m.All()).Returns(collectionOfCars);
            var service = new FilterService(mockedRepo.Object);

            // Act
            service.FilterExpiringAnnualCheckUp();

            // Assert
            mockedRepo.Verify(m => m.All(), Times.Exactly(1));
        }

        [Test]
        public void FilterService_GetMailsForCarsVignetteExpiration_VerifysThatMethodAllIsCalledExactlyOneTime()
        {
            // Arrange
            var collectionOfCars = new List<Car>
            {
                new Car() { Id = Guid.NewGuid(), Manufacturer="VW", Model="Golf", ValidUntilVignette=DateTime.Now,  },
                new Car() { Id = Guid.NewGuid(), Manufacturer="BMW", Model="e40", ValidUntilVignette=DateTime.Now,  },
                new Car() { Id = Guid.NewGuid(), Manufacturer="Lada", Model="2105", ValidUntilVignette=DateTime.Now, }
            };

            var mockedRepo = new Mock<IEfGenericRepository<Car>>();
            mockedRepo.Setup(m => m.All()).Returns(collectionOfCars);
            var service = new FilterService(mockedRepo.Object);

            // Act
            service.GetMailsForCarsVignetteExpiration();

            // Assert
            mockedRepo.Verify(m => m.All(), Times.Exactly(1));
        }

        [Test]
        public void FilterService_GetMailsForCarsInsuranceExpiration_VerifysThatMethodAllIsCalledExactlyOneTime()
        {
            // Arrange
            var collectionOfCars = new List<Car>
            {
                new Car() { Id = Guid.NewGuid(), Manufacturer="VW", Model="Golf", ValidUntilVignette=DateTime.Now,  },
                new Car() { Id = Guid.NewGuid(), Manufacturer="BMW", Model="e40", ValidUntilVignette=DateTime.Now,  },
                new Car() { Id = Guid.NewGuid(), Manufacturer="Lada", Model="2105", ValidUntilVignette=DateTime.Now, }
            };

            var mockedRepo = new Mock<IEfGenericRepository<Car>>();
            mockedRepo.Setup(m => m.All()).Returns(collectionOfCars);
            var service = new FilterService(mockedRepo.Object);

            // Act
            service.GetMailsForCarsInsuranceExpiration();

            // Assert
            mockedRepo.Verify(m => m.All(), Times.Exactly(1));
        }

        [Test]
        public void FilterService_GetMailsForCarsAnnualCheckUpExpiration_VerifysThatMethodAllIsCalledExactlyOneTime()
        {
            // Arrange
            var collectionOfCars = new List<Car>
            {
                new Car() { Id = Guid.NewGuid(), Manufacturer="VW", Model="Golf", ValidUntilVignette=DateTime.Now,  },
                new Car() { Id = Guid.NewGuid(), Manufacturer="BMW", Model="e40", ValidUntilVignette=DateTime.Now,  },
                new Car() { Id = Guid.NewGuid(), Manufacturer="Lada", Model="2105", ValidUntilVignette=DateTime.Now, }
            };


            var mockedRepo = new Mock<IEfGenericRepository<Car>>();
            mockedRepo.Setup(m => m.All()).Returns(collectionOfCars);
            var service = new FilterService(mockedRepo.Object);

            // Act
            service.GetMailsForCarsAnnualCheckUpExpiration();

            // Assert
            mockedRepo.Verify(m => m.All(), Times.Exactly(1));
        }
    }
}
