using CarsSystem.Data.Models;
using NUnit.Framework;

namespace CarsSystem.Tests.Data.CarsSystem.Data.Models
{
    [TestFixture]
    public class CarTests
    {
        [Test]
        public void Car_ShouldCreateInstanceOfClassCorrectly()
        {
            // Arrange
            var car = new Car();

            // Act & Assert
            Assert.IsInstanceOf<Car>(car);
        }

        [Test]
        public void Car_ShouldCreateNullManufacturerField_WhenInstantiedNewCar()
        {
            // Arrange
            var car = new Car();

            // Act & Assert
            Assert.IsNull(car.Manufacturer);
        }

        [Test]
        public void Car_ShouldCreateNullModelField_WhenInstantiedNewCar()
        {
            // Arrange
            var car = new Car();

            // Act & Assert
            Assert.IsNull(car.Model);
        }

        [Test]
        public void Car_ShouldCreateGasolineTypeOfEngineField_WhenInstantiedNewCar()
        {
            // Arrange
            var car = new Car();

            // Act & Assert
            Assert.AreEqual(car.TypeOfEngine, EngineType.Gasoline);
        }

        [Test]
        public void Car_ShouldCreateNullRegistrationNumberField_WhenInstantiedNewCar()
        {
            // Arrange 
            var car = new Car();

            // Act & Assert
            Assert.IsNull(car.RegistrationNumber);
        }

        [Test]
        public void Car_ShouldCreateNullVINNumberField_WhenInstantiedNewCar()
        {
            // Arrange
            var car = new Car();

            // Act & Assert
            Assert.IsNull(car.VINNumber);
        }

        [Test]
        public void Car_ShouldCreateZeroCountOfTyresField_WhenInstantiedNewCar()
        {
            // Arrange
            var car = new Car();

            // Act & Assert
            Assert.Zero(car.CountOfTyres);
        }

        [Test]
        public void Car_ShouldCreateZeroCountOfDoorsField_WhenInstantiedNewCar()
        {
            // Arrange
            var car = new Car();

            // Act & Assert
            Assert.Zero(car.CountOfDoors);
        }

        [Test]
        public void Car_ShouldCreateOrdinaryTypeOfCarField_WhenInstantiedNewCar()
        {
            // Arrange
            var car = new Car();

            // Act & Assert
            Assert.AreEqual(car.TypeOfCar, CarType.Ordinary);
        }

        [Test]
        public void Car_ShouldCreateExpectedYearOfManufacturingField_WhenInstantiedNewCar()
        {
            // Arrange
            var car = new Car();

            // Act
            var actualYearOfManufactoring = car.YearOfManufacturing.ToString();
            var expectedYearOfMAnufactoring = "1.1.0001 г. 0:00:00";

            // Assert
            Assert.AreEqual(expectedYearOfMAnufactoring, expectedYearOfMAnufactoring);
        }

        [Test]
        public void Car_ShouldCreateExpectedValidUntilAnnualCheckUpField_WhenInstantiedNewCar()
        {
            // Arrange
            var car = new Car();

            // Act
            var actualValidUntilAnnualCheckUp = car.ValidUntilAnnualCheckUp.ToString();
            var expectedValidUntilAnnualCheckUp = "1/1/0001 12:00:00 AM";

            // Assert
            Assert.AreEqual(expectedValidUntilAnnualCheckUp, actualValidUntilAnnualCheckUp);
        }

        [Test]
        public void Car_ShouldCreateExpectedValidUntilVignetteField_WhenInstantiedNewCar()
        {
            // Arrange
            var car = new Car();

            // Act
            var actualValidUntilVignette = car.ValidUntilVignette.ToString();
            var expectedValidUntilVignette = "1/1/0001 12:00:00 AM";

            // Assert
            Assert.AreEqual(expectedValidUntilVignette, actualValidUntilVignette);
        }

        [Test]
        public void Car_ShouldCreateExpectedValidUntilInsuranceField_WhenInstantiedNewCar()
        {
            // Arrange
            var car = new Car();

            // Act
            var actualValidUntilInsurance = car.ValidUntilInsurance.ToString();
            var expectedValidUntilInsurance = "1/1/0001 12:00:00 AM";

            // Assert
            Assert.AreEqual(expectedValidUntilInsurance, actualValidUntilInsurance);
        }

        [Test]
        public void Car_ShouldSetsManufacturerField_Correctly()
        {
            // Arrange
            var car = new Car();

            // Act
            car.Manufacturer = "VW";
            var expectedManufacturer = "VW";

            // Assert
            Assert.AreEqual(expectedManufacturer, car.Manufacturer);
        }

        [Test]
        public void Car_ShouldSetsModelField_Correctly()
        {
            // Arrange
            var car = new Car();

            // Act
            car.Model = "Golf";
            var expectedModel = "Golf";

            // Assert
            Assert.AreEqual(expectedModel, car.Model);
        }

        [Test]
        public void Car_ShouldSetsSpecificTypeOfEngineField_Correctly()
        {
            // Arrange
            var car = new Car();

            // Act
            car.TypeOfEngine = EngineType.Diesel;
            var expectedEngineType = EngineType.Diesel;

            // Assert
            Assert.AreEqual(expectedEngineType, car.TypeOfEngine);
        }

        [Test]
        public void Car_ShouldSetsSpecificRegistrationNumberField_Correctly()
        {
            // Arrange
            var car = new Car();

            // Act
            car.RegistrationNumber = "Tosharata";
            var expectedRegistrationNumber = "Tosharata";

            // Assert
            Assert.AreEqual(expectedRegistrationNumber, car.RegistrationNumber);
        }

        [Test]
        public void Car_ShouldSetsSpecificVINNumberField_Correctly()
        {
            // Arrange
            var car = new Car();

            // Act
            car.VINNumber = "Tosharata12345678";
            var expectedVINNumber = "Tosharata12345678";

            // Assert
            Assert.AreEqual(expectedVINNumber, car.VINNumber);
        }

        [Test]
        public void Car_ShouldSetsCountOfTyresField_Correctly()
        {
            // Arrange
            var car = new Car();

            // Act
            car.CountOfTyres = 3;
            var expectedCountOfTyres = 3;

            // Assert
            Assert.AreEqual(expectedCountOfTyres, car.CountOfTyres);
        }

        [Test]
        public void Car_ShouldSetsCountOfDoorsField_Correctly()
        {
            // Arrange
            var car = new Car();

            // Act
            car.CountOfDoors = 4;
            var expectedCountOfDoors = 4;

            // Assert
            Assert.AreEqual(expectedCountOfDoors, car.CountOfDoors);
        }

        [Test]
        public void Car_ShouldSetsTypeOfCarField_Correctly()
        {
            // Arrange
            var car = new Car();

            // Act
            car.TypeOfCar = CarType.Taxi;
            var expectedTypeOfCar = CarType.Taxi;

            // Assert
            Assert.AreEqual(expectedTypeOfCar, car.TypeOfCar);
        }
    }
}
