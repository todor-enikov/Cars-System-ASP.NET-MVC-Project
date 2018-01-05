using CarsSystem.Data.Models;
using NUnit.Framework;

namespace CarsSystem.Tests.Data.CarsSystem.Data.Models.CarTests
{
    [TestFixture]
    public class Should
    {
        [Test]
        public void CreateInstanceOfClassCorrectly()
        {
            // Arrange
            var car = new Car();

            // Act & Assert
            Assert.IsInstanceOf<Car>(car);
        }

        [Test]
        public void CreateNullManufacturerField_WhenInstantiedNewCar()
        {
            // Arrange
            var car = new Car();

            // Act & Assert
            Assert.IsNull(car.Manufacturer);
        }

        [Test]
        public void CreateNullModelField_WhenInstantiedNewCar()
        {
            // Arrange
            var car = new Car();

            // Act & Assert
            Assert.IsNull(car.Model);
        }

        [Test]
        public void CreateGasolineTypeOfEngineField_WhenInstantiedNewCar()
        {
            // Arrange
            var car = new Car();

            // Act & Assert
            Assert.AreEqual(car.TypeOfEngine, EngineType.Gasoline);
        }

        [Test]
        public void CreateNullRegistrationNumberField_WhenInstantiedNewCar()
        {
            // Arrange 
            var car = new Car();

            // Act & Assert
            Assert.IsNull(car.RegistrationNumber);
        }

        [Test]
        public void CreateNullVINNumberField_WhenInstantiedNewCar()
        {
            // Arrange
            var car = new Car();

            // Act & Assert
            Assert.IsNull(car.VINNumber);
        }

        [Test]
        public void CreateZeroCountOfTyresField_WhenInstantiedNewCar()
        {
            // Arrange
            var car = new Car();

            // Act & Assert
            Assert.Zero(car.CountOfTyres);
        }

        [Test]
        public void CreateZeroCountOfDoorsField_WhenInstantiedNewCar()
        {
            // Arrange
            var car = new Car();

            // Act & Assert
            Assert.Zero(car.CountOfDoors);
        }

        [Test]
        public void CreateOrdinaryTypeOfCarField_WhenInstantiedNewCar()
        {
            // Arrange
            var car = new Car();

            // Act & Assert
            Assert.AreEqual(car.TypeOfCar, CarType.Sedan);
        }

        [Test]
        public void CreateExpectedYearOfManufacturingField_WhenInstantiedNewCar()
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
        public void CreateExpectedValidUntilAnnualCheckUpField_WhenInstantiedNewCar()
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
        public void CreateExpectedValidUntilVignetteField_WhenInstantiedNewCar()
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
        public void CreateExpectedValidUntilInsuranceField_WhenInstantiedNewCar()
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
        public void CreateExpectedIsEmailSendedForAnnualField_WhenInstantiedNewCar()
        {
            // Arrange
            var car = new Car();

            // Act & Assert
            Assert.AreEqual(false, car.IsEmailSendedForAnnual);
        }

        [Test]
        public void CreateExpectedIsEmailSendedForVignetteField_WhenInstantiedNewCar()
        {
            // Arrange
            var car = new Car();

            // Act & Assert
            Assert.AreEqual(false, car.IsEmailSendedForVignette);
        }

        [Test]
        public void CreateExpectedIsEmailSendedForInsuranceField_WhenInstantiedNewCar()
        {
            // Arrange
            var car = new Car();

            // Act & Assert
            Assert.AreEqual(false, car.IsEmailSendedForAnnual);
        }

        [Test]
        public void SetsManufacturerField_Correctly()
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
        public void SetsModelField_Correctly()
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
        public void SetsSpecificTypeOfEngineField_Correctly()
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
        public void SetsSpecificRegistrationNumberField_Correctly()
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
        public void SetsSpecificVINNumberField_Correctly()
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
        public void SetsCountOfTyresField_Correctly()
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
        public void SetsCountOfDoorsField_Correctly()
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
        public void SetsTypeOfCarField_Correctly()
        {
            // Arrange
            var car = new Car();

            // Act
            car.TypeOfCar = CarType.Convertible;
            var expectedTypeOfCar = CarType.Convertible;

            // Assert
            Assert.AreEqual(expectedTypeOfCar, car.TypeOfCar);
        }

        [Test]
        public void SetsIsEmailSendedForAnnualField_Correctly()
        {
            // Arrange
            var car = new Car();

            // Act
            car.IsEmailSendedForAnnual = true;
            var expectedIsEmailSendedForAnnual = true;

            // Assert
            Assert.AreEqual(expectedIsEmailSendedForAnnual, car.IsEmailSendedForAnnual);
        }

        [Test]
        public void SetsIsEmailSendedForVignetteField_Correctly()
        {
            // Arrange
            var car = new Car();

            // Act
            car.IsEmailSendedForVignette = true;
            var expectedIsEmailSendedForVignette = true;

            // Assert
            Assert.AreEqual(expectedIsEmailSendedForVignette, car.IsEmailSendedForVignette);
        }

        [Test]
        public void SetsIsEmailSendedForInsuranceField_Correctly()
        {
            // Arrange
            var car = new Car();

            // Act
            car.IsEmailSendedForInsurance = true;
            var expectedIsEmailSendedForInsurance = true;

            // Assert
            Assert.AreEqual(expectedIsEmailSendedForInsurance, car.IsEmailSendedForInsurance);
        }
    }
}
