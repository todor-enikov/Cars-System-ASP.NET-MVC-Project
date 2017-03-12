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
            IRepository<Car> mockedRepository = null;

            Assert.Throws<ArgumentException>(() => new FilterService(mockedRepository));
        }

        [Test]
        public void FilterService_ShouldThrowArgumentNullExceptionWithExpectedMessage_WhenPassedRepositoryIsNull()
        {
            IRepository<Car> mockedRepository = null;

            var expectedMessage = Assert.Throws<ArgumentException>(() => new FilterService(mockedRepository));

            Assert.IsTrue(expectedMessage.Message.Contains("null"));
        }

        [Test]
        public void FilterService_ShouldCreateInstanceOfFilterService_WhenPassedRepositoryIsCorrectly()
        {
            var mockedRepository = new Mock<IRepository<Car>>();

            var service = new FilterService(mockedRepository.Object);

            Assert.IsInstanceOf<FilterService>(service);
        }

        [Test]
        public void FilterService_ShouldImplementsInterfaceIFilterService_WhenPassedRepositoryIsCorrectly()
        {
            var mockedRepository = new Mock<IRepository<Car>>();

            var service = new FilterService(mockedRepository.Object);

            Assert.IsInstanceOf<IFilterService>(service);
        }

        [Test]
        public void FilterService_FilterExpiringVignetteCars_ShouldReturnIEnumerableCollection_WhenPassedParametersAreCorrect()
        {
            var collectionOfCars = new List<Car>
            {
                new Car() { Id=1, Manufacturer="VW", Model="Golf", ValidUntilVignette=DateTime.Now },
                new Car() { Id=2, Manufacturer="BMW", Model="e40", ValidUntilVignette=DateTime.Now },
                new Car() { Id=3, Manufacturer="Lada", Model="2105", ValidUntilVignette=DateTime.Now }
            };
            var mockedRepo = new Mock<IRepository<Car>>();
            mockedRepo.Setup(m => m.All()).Returns(collectionOfCars);
            var service = new FilterService(mockedRepo.Object);

            var result = service.FilterExpiringVignetteCars().ToList();

            Assert.AreEqual(collectionOfCars.Count, result.Count);
        }

        [Test]
        public void FilterService_FilterExpiringVignetteCars_VerifyThatTheMethodIsCalledExactOneTime_WhenPassedParametersAreCorrect()
        {
            var collectionOfCars = new List<Car>
            {
                new Car() { Id=1, Manufacturer="VW", Model="Golf", ValidUntilVignette=DateTime.Now },
                new Car() { Id=2, Manufacturer="BMW", Model="e40", ValidUntilVignette=DateTime.Now },
                new Car() { Id=3, Manufacturer="Lada", Model="2105", ValidUntilVignette=DateTime.Now }
            };
            var mockedRepo = new Mock<IRepository<Car>>();
            mockedRepo.Setup(m => m.All()).Returns(collectionOfCars);
            var service = new FilterService(mockedRepo.Object);

            service.FilterExpiringVignetteCars();

            mockedRepo.Verify(m => m.All(), Times.Exactly(1));
        }

        [Test]
        public void FilterService_FilterExpiringInsurance_ShouldReturnIEnumerableCollection_WhenPassedParametersAreCorrect()
        {
            var collectionOfCars = new List<Car>
            {
                new Car() { Id=1, Manufacturer="VW", Model="Golf", ValidUntilInsurance=DateTime.Now },
                new Car() { Id=2, Manufacturer="BMW", Model="e40", ValidUntilInsurance=DateTime.Now },
                new Car() { Id=3, Manufacturer="Lada", Model="2105", ValidUntilInsurance=DateTime.Now }
            };
            var mockedRepo = new Mock<IRepository<Car>>();
            mockedRepo.Setup(m => m.All()).Returns(collectionOfCars);
            var service = new FilterService(mockedRepo.Object);

            var result = service.FilterExpiringInsurance().ToList();

            Assert.AreEqual(collectionOfCars.Count, result.Count);
        }

        [Test]
        public void FilterService_FilterExpiringInsurance_VerifyThatTheMethodIsCalledExactOneTime_WhenPassedParametersAreCorrect()
        {
            var collectionOfCars = new List<Car>
            {
                new Car() { Id=1, Manufacturer="VW", Model="Golf", ValidUntilInsurance=DateTime.Now },
                new Car() { Id=2, Manufacturer="BMW", Model="e40", ValidUntilInsurance=DateTime.Now },
                new Car() { Id=3, Manufacturer="Lada", Model="2105", ValidUntilInsurance=DateTime.Now }
            };
            var mockedRepo = new Mock<IRepository<Car>>();
            mockedRepo.Setup(m => m.All()).Returns(collectionOfCars);
            var service = new FilterService(mockedRepo.Object);

            service.FilterExpiringInsurance();

            mockedRepo.Verify(m => m.All(), Times.Exactly(1));
        }

        [Test]
        public void FilterService_FilterExpiringAnnualCheckUp_ShouldReturnIEnumerableCollection_WhenPassedParametersAreCorrect()
        {
            var collectionOfCars = new List<Car>
            {
                new Car() { Id=1, Manufacturer="VW", Model="Golf", ValidUntilAnnualCheckUp=DateTime.Now },
                new Car() { Id=2, Manufacturer="BMW", Model="e40", ValidUntilAnnualCheckUp=DateTime.Now },
                new Car() { Id=3, Manufacturer="Lada", Model="2105", ValidUntilAnnualCheckUp=DateTime.Now }
            };
            var mockedRepo = new Mock<IRepository<Car>>();
            mockedRepo.Setup(s => s.All()).Returns(collectionOfCars);
            var service = new FilterService(mockedRepo.Object);

            var result = service.FilterExpiringAnnualCheckUp().ToList();

            Assert.AreEqual(collectionOfCars.Count, result.Count);
        }

        [Test]
        public void FilterService_FilterExpiringAnnualCheckUp_VerifyThatTheMethodIsCalledExactOneTime_WhenPassedParametersAreCorrect()
        {
            var collectionOfCars = new List<Car>
            {
                new Car() { Id=1, Manufacturer="VW", Model="Golf", ValidUntilAnnualCheckUp=DateTime.Now },
                new Car() { Id=2, Manufacturer="BMW", Model="e40", ValidUntilAnnualCheckUp=DateTime.Now },
                new Car() { Id=3, Manufacturer="Lada", Model="2105", ValidUntilAnnualCheckUp=DateTime.Now }
            };
            var mockedRepo = new Mock<IRepository<Car>>();
            mockedRepo.Setup(m => m.All()).Returns(collectionOfCars);
            var service = new FilterService(mockedRepo.Object);

            service.FilterExpiringAnnualCheckUp();

            mockedRepo.Verify(m => m.All(), Times.Exactly(1));
        }

        [Test]
        public void FilterService_GetMailsForCarsVignetteExpiration_VerifysThatMethodAllIsCalledExactlyOneTime()
        {
            var collectionOfCars = new List<Car>
            {
                new Car() { Id=1, Manufacturer="VW", Model="Golf", ValidUntilVignette=DateTime.Now,  },
                new Car() { Id=2, Manufacturer="BMW", Model="e40", ValidUntilVignette=DateTime.Now,  },
                new Car() { Id=3, Manufacturer="Lada", Model="2105", ValidUntilVignette=DateTime.Now, }
            };

            var mockedRepo = new Mock<IRepository<Car>>();
            mockedRepo.Setup(m => m.All()).Returns(collectionOfCars);
            var service = new FilterService(mockedRepo.Object);

            service.GetMailsForCarsVignetteExpiration();

            mockedRepo.Verify(m => m.All(), Times.Exactly(1));
        }

        [Test]
        public void FilterService_GetMailsForCarsInsuranceExpiration_VerifysThatMethodAllIsCalledExactlyOneTime()
        {
            var collectionOfCars = new List<Car>
            {
                new Car() { Id=1, Manufacturer="VW", Model="Golf", ValidUntilVignette=DateTime.Now,  },
                new Car() { Id=2, Manufacturer="BMW", Model="e40", ValidUntilVignette=DateTime.Now,  },
                new Car() { Id=3, Manufacturer="Lada", Model="2105", ValidUntilVignette=DateTime.Now, }
            };

            var mockedRepo = new Mock<IRepository<Car>>();
            mockedRepo.Setup(m => m.All()).Returns(collectionOfCars);
            var service = new FilterService(mockedRepo.Object);

            service.GetMailsForCarsInsuranceExpiration();

            mockedRepo.Verify(m => m.All(), Times.Exactly(1));
        }

        [Test]
        public void FilterService_GetMailsForCarsAnnualCheckUpExpiration_VerifysThatMethodAllIsCalledExactlyOneTime()
        {
            var collectionOfCars = new List<Car>
            {
                new Car() { Id=1, Manufacturer="VW", Model="Golf", ValidUntilVignette=DateTime.Now,  },
                new Car() { Id=2, Manufacturer="BMW", Model="e40", ValidUntilVignette=DateTime.Now,  },
                new Car() { Id=3, Manufacturer="Lada", Model="2105", ValidUntilVignette=DateTime.Now, }
            };

            var mockedRepo = new Mock<IRepository<Car>>();
            mockedRepo.Setup(m => m.All()).Returns(collectionOfCars);
            var service = new FilterService(mockedRepo.Object);

            service.GetMailsForCarsAnnualCheckUpExpiration();

            mockedRepo.Verify(m => m.All(), Times.Exactly(1));
        }
    }
}
