using CarsSystem.Data.Models;
using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CarsSystem.Tests.Data.CarsSystem.Data.Models
{
    [TestFixture]
    public class CarAttributesTests
    {
        [Test]
        public void Car_IdProperty_ShouldHaveKeyAttribute()
        {
            // Arrange
            var user = new Car();
            string property = "Id";

            // Act
            bool hasAttribute = user.GetType()
                                    .GetProperty(property)
                                    .GetCustomAttributes(false)
                                    .Where(p => p.GetType() == typeof(KeyAttribute))
                                    .Any();

            // Assert
            Assert.IsTrue(hasAttribute);
        }

        [Test]
        public void Car_ManufacturerProperty_ShouldHaveRequiredAttribute()
        {
            // Arrange
            var user = new Car();
            string property = "Manufacturer";

            // Act
            bool hasAttribute = user.GetType()
                                    .GetProperty(property)
                                    .GetCustomAttributes(false)
                                    .Where(p => p.GetType() == typeof(RequiredAttribute))
                                    .Any();

            // Assert
            Assert.IsTrue(hasAttribute);
        }

        [Test]
        public void Car_ModelProperty_ShouldHaveRequiredAttribute()
        {
            // Arrange
            var user = new Car();
            string property = "Model";

            // Act
            bool hasAttribute = user.GetType()
                                    .GetProperty(property)
                                    .GetCustomAttributes(false)
                                    .Where(p => p.GetType() == typeof(RequiredAttribute))
                                    .Any();

            // Assert
            Assert.IsTrue(hasAttribute);
        }

        [Test]
        public void Car_TypeOfEngineProperty_ShouldHaveRequiredAttribute()
        {
            // Arrange
            var user = new Car();
            string property = "TypeOfEngine";

            // Act
            bool hasAttribute = user.GetType()
                                    .GetProperty(property)
                                    .GetCustomAttributes(false)
                                    .Where(p => p.GetType() == typeof(RequiredAttribute))
                                    .Any();

            // Assert
            Assert.IsTrue(hasAttribute);
        }

        [Test]
        public void Car_VINProperty_ShouldHaveRequiredAttribute()
        {
            // Arrange
            var user = new Car();
            string property = "VINNumber";

            // Act
            bool hasAttribute = user.GetType()
                                    .GetProperty(property)
                                    .GetCustomAttributes(false)
                                    .Where(p => p.GetType() == typeof(RequiredAttribute))
                                    .Any();

            // Assert
            Assert.IsTrue(hasAttribute);
        }

        [Test]
        public void Car_VINProperty_ShouldHaveIndexAttribute()
        {
            // Arrange
            var user = new Car();
            string property = "VINNumber";

            // Act
            bool hasAttribute = user.GetType()
                                    .GetProperty(property)
                                    .GetCustomAttributes(false)
                                    .Where(p => p.GetType() == typeof(IndexAttribute))
                                    .Any();

            // Assert
            Assert.IsTrue(hasAttribute);
        }

        [Test]
        public void Car_TypeOfCarProperty_ShouldHaveRequiredAttribute()
        {
            // Arrange
            var user = new Car();
            string property = "TypeOfCar";

            // Act
            bool hasAttribute = user.GetType()
                                    .GetProperty(property)
                                    .GetCustomAttributes(false)
                                    .Where(p => p.GetType() == typeof(RequiredAttribute))
                                    .Any();

            // Assert
            Assert.IsTrue(hasAttribute);
        }

        [Test]
        public void Car_YearOfManufacturingProperty_ShouldHaveRequiredAttribute()
        {
            // Arrange
            var user = new Car();
            string property = "YearOfManufacturing";

            // Act 
            bool hasAttribute = user.GetType()
                                    .GetProperty(property)
                                    .GetCustomAttributes(false)
                                    .Where(p => p.GetType() == typeof(RequiredAttribute))
                                    .Any();

            // Assert
            Assert.IsTrue(hasAttribute);
        }

        [Test]
        public void Car_ValidUntilAnnualCheckUpProperty_ShouldHaveRequiredAttribute()
        {
            // Arrange
            var user = new Car();
            string property = "ValidUntilAnnualCheckUp";

            // Act
            bool hasAttribute = user.GetType()
                                    .GetProperty(property)
                                    .GetCustomAttributes(false)
                                    .Where(p => p.GetType() == typeof(RequiredAttribute))
                                    .Any();

            // Assert
            Assert.IsTrue(hasAttribute);
        }

        [Test]
        public void Car_ValidUntilVignetteProperty_ShouldHaveRequiredAttribute()
        {
            // Arrange
            var user = new Car();
            string property = "ValidUntilVignette";

            // Act
            bool hasAttribute = user.GetType()
                                    .GetProperty(property)
                                    .GetCustomAttributes(false)
                                    .Where(p => p.GetType() == typeof(RequiredAttribute))
                                    .Any();

            // Assert
            Assert.IsTrue(hasAttribute);
        }

        [Test]
        public void Car_ValidUntilInsuranceProperty_ShouldHaveRequiredAttribute()
        {
            // Arrange
            var user = new Car();
            string property = "ValidUntilInsurance";

            // Act
            bool hasAttribute = user.GetType()
                                    .GetProperty(property)
                                    .GetCustomAttributes(false)
                                    .Where(p => p.GetType() == typeof(RequiredAttribute))
                                    .Any();

            // Assert
            Assert.IsTrue(hasAttribute);
        }
    }
}
