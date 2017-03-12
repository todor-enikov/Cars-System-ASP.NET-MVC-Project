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
            var car = new Car();

            Assert.IsInstanceOf<Car>(car);
        }

        [Test]
        public void Car_ShouldCreateNullManufacturerField_WhenInstantiedNewCar()
        {
            var car = new Car();

            Assert.IsNull(car.Manufacturer);
        }

        [Test]
        public void Car_ShouldCreateNullModelField_WhenInstantiedNewCar()
        {
            var car = new Car();

            Assert.IsNull(car.Model);
        }

        [Test]
        public void Car_ShouldCreateGasolineTypeOfEngineField_WhenInstantiedNewCar()
        {
            var car = new Car();

            Assert.AreEqual(car.TypeOfEngine, EngineType.Gasoline);
        }

        [Test]
        public void Car_ShouldCreateNullRegistrationNumberField_WhenInstantiedNewCar()
        {
            var car = new Car();

            Assert.IsNull(car.RegistrationNumber);
        }

        [Test]
        public void Car_ShouldCreateNullVINNumberField_WhenInstantiedNewCar()
        {
            var car = new Car();

            Assert.IsNull(car.VINNumber);
        }

        [Test]
        public void Car_ShouldCreateZeroCountOfTyresField_WhenInstantiedNewCar()
        {
            var car = new Car();

            Assert.Zero(car.CountOfTyres);
        }

        [Test]
        public void Car_ShouldCreateZeroCountOfDoorsField_WhenInstantiedNewCar()
        {
            var car = new Car();

            Assert.Zero(car.CountOfDoors);
        }

        [Test]
        public void Car_ShouldCreateOrdinaryTypeOfCarField_WhenInstantiedNewCar()
        {
            var car = new Car();

            Assert.AreEqual(car.TypeOfCar, CarType.Ordinary);
        }

        [Test]
        public void Car_ShouldCreateExpectedYearOfManufacturingField_WhenInstantiedNewCar()
        {
            var car = new Car();

            var actualYearOfManufactoring = car.YearOfManufacturing.ToString();
            var expectedYearOfMAnufactoring = "1.1.0001 г. 0:00:00";

            Assert.AreEqual(expectedYearOfMAnufactoring, expectedYearOfMAnufactoring);
        }

        [Test]
        public void Car_ShouldCreateExpectedValidUntilAnnualCheckUpField_WhenInstantiedNewCar()
        {
            var car = new Car();

            var actualValidUntilAnnualCheckUp = car.ValidUntilAnnualCheckUp.ToString();
            var expectedValidUntilAnnualCheckUp = "1/1/0001 12:00:00 AM";

            Assert.AreEqual(expectedValidUntilAnnualCheckUp, actualValidUntilAnnualCheckUp);
        }

        [Test]
        public void Car_ShouldCreateExpectedValidUntilVignetteField_WhenInstantiedNewCar()
        {
            var car = new Car();

            var actualValidUntilVignette = car.ValidUntilVignette.ToString();
            var expectedValidUntilVignette = "1/1/0001 12:00:00 AM";

            Assert.AreEqual(expectedValidUntilVignette, actualValidUntilVignette);
        }

        [Test]
        public void Car_ShouldCreateExpectedValidUntilInsuranceField_WhenInstantiedNewCar()
        {
            var car = new Car();

            var actualValidUntilInsurance = car.ValidUntilInsurance.ToString();
            var expectedValidUntilInsurance = "1/1/0001 12:00:00 AM";

            Assert.AreEqual(expectedValidUntilInsurance, actualValidUntilInsurance);
        }

        [Test]
        public void Car_ShouldSetsManufacturerField_Correctly()
        {
            var car = new Car();

            car.Manufacturer = "VW";
            var expectedManufacturer = "VW";

            Assert.AreEqual(expectedManufacturer, car.Manufacturer);
        }

        [Test]
        public void Car_ShouldSetsModelField_Correctly()
        {
            var car = new Car();

            car.Model = "Golf";
            var expectedModel = "Golf";

            Assert.AreEqual(expectedModel, car.Model);
        }

        [Test]
        public void Car_ShouldSetsSpecificTypeOfEngineField_Correctly()
        {
            var car = new Car();

            car.TypeOfEngine = EngineType.Diesel;
            var expectedEngineType = EngineType.Diesel;

            Assert.AreEqual(expectedEngineType, car.TypeOfEngine);
        }

        [Test]
        public void Car_ShouldSetsSpecificRegistrationNumberField_Correctly()
        {
            var car = new Car();

            car.RegistrationNumber = "Tosharata";
            var expectedRegistrationNumber = "Tosharata";

            Assert.AreEqual(expectedRegistrationNumber, car.RegistrationNumber);
        }

        [Test]
        public void Car_ShouldSetsSpecificVINNumberField_Correctly()
        {
            var car = new Car();

            car.VINNumber = "Tosharata12345678";
            var expectedVINNumber = "Tosharata12345678";

            Assert.AreEqual(expectedVINNumber, car.VINNumber);
        }

        [Test]
        public void Car_ShouldSetsCountOfTyresField_Correctly()
        {
            var car = new Car();

            car.CountOfTyres = 3;
            var expectedCountOfTyres = 3;

            Assert.AreEqual(expectedCountOfTyres, car.CountOfTyres);
        }

        [Test]
        public void Car_ShouldSetsCountOfDoorsField_Correctly()
        {
            var car = new Car();

            car.CountOfDoors = 4;
            var expectedCountOfDoors = 4;

            Assert.AreEqual(expectedCountOfDoors, car.CountOfDoors);
        }

        [Test]
        public void Car_ShouldSetsTypeOfCarField_Correctly()
        {
            var car = new Car();

            car.TypeOfCar = CarType.Taxi;
            var expectedTypeOfCar = CarType.Taxi;

            Assert.AreEqual(expectedTypeOfCar, car.TypeOfCar);
        }
    }
}
