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
            var user = new Car();
            string property = "Id";

            bool hasAttribute = user.GetType()
                                    .GetProperty(property)
                                    .GetCustomAttributes(false)
                                    .Where(p => p.GetType() == typeof(KeyAttribute))
                                    .Any();

            Assert.IsTrue(hasAttribute);
        }

        [Test]
        public void Car_ManufacturerProperty_ShouldHaveRequiredAttribute()
        {
            var user = new Car();
            string property = "Manufacturer";

            bool hasAttribute = user.GetType()
                                    .GetProperty(property)
                                    .GetCustomAttributes(false)
                                    .Where(p => p.GetType() == typeof(RequiredAttribute))
                                    .Any();

            Assert.IsTrue(hasAttribute);
        }

        [Test]
        public void Car_ModelProperty_ShouldHaveRequiredAttribute()
        {
            var user = new Car();
            string property = "Model";

            bool hasAttribute = user.GetType()
                                    .GetProperty(property)
                                    .GetCustomAttributes(false)
                                    .Where(p => p.GetType() == typeof(RequiredAttribute))
                                    .Any();

            Assert.IsTrue(hasAttribute);
        }

        [Test]
        public void Car_TypeOfEngineProperty_ShouldHaveRequiredAttribute()
        {
            var user = new Car();
            string property = "TypeOfEngine";

            bool hasAttribute = user.GetType()
                                    .GetProperty(property)
                                    .GetCustomAttributes(false)
                                    .Where(p => p.GetType() == typeof(RequiredAttribute))
                                    .Any();

            Assert.IsTrue(hasAttribute);
        }

        [Test]
        public void Car_VINProperty_ShouldHaveRequiredAttribute()
        {
            var user = new Car();
            string property = "VINNumber";

            bool hasAttribute = user.GetType()
                                    .GetProperty(property)
                                    .GetCustomAttributes(false)
                                    .Where(p => p.GetType() == typeof(RequiredAttribute))
                                    .Any();

            Assert.IsTrue(hasAttribute);
        }

        [Test]
        public void Car_VINProperty_ShouldHaveIndexAttribute()
        {
            var user = new Car();
            string property = "VINNumber";

            bool hasAttribute = user.GetType()
                                    .GetProperty(property)
                                    .GetCustomAttributes(false)
                                    .Where(p => p.GetType() == typeof(IndexAttribute))
                                    .Any();

            Assert.IsTrue(hasAttribute);
        }

        [Test]
        public void Car_TypeOfCarProperty_ShouldHaveRequiredAttribute()
        {
            var user = new Car();
            string property = "TypeOfCar";

            bool hasAttribute = user.GetType()
                                    .GetProperty(property)
                                    .GetCustomAttributes(false)
                                    .Where(p => p.GetType() == typeof(RequiredAttribute))
                                    .Any();

            Assert.IsTrue(hasAttribute);
        }

        [Test]
        public void Car_YearOfManufacturingProperty_ShouldHaveRequiredAttribute()
        {
            var user = new Car();
            string property = "YearOfManufacturing";

            bool hasAttribute = user.GetType()
                                    .GetProperty(property)
                                    .GetCustomAttributes(false)
                                    .Where(p => p.GetType() == typeof(RequiredAttribute))
                                    .Any();

            Assert.IsTrue(hasAttribute);
        }

        [Test]
        public void Car_ValidUntilAnnualCheckUpProperty_ShouldHaveRequiredAttribute()
        {
            var user = new Car();
            string property = "ValidUntilAnnualCheckUp";

            bool hasAttribute = user.GetType()
                                    .GetProperty(property)
                                    .GetCustomAttributes(false)
                                    .Where(p => p.GetType() == typeof(RequiredAttribute))
                                    .Any();

            Assert.IsTrue(hasAttribute);
        }

        [Test]
        public void Car_ValidUntilVignetteProperty_ShouldHaveRequiredAttribute()
        {
            var user = new Car();
            string property = "ValidUntilVignette";

            bool hasAttribute = user.GetType()
                                    .GetProperty(property)
                                    .GetCustomAttributes(false)
                                    .Where(p => p.GetType() == typeof(RequiredAttribute))
                                    .Any();

            Assert.IsTrue(hasAttribute);
        }

        [Test]
        public void Car_ValidUntilInsuranceProperty_ShouldHaveRequiredAttribute()
        {
            var user = new Car();
            string property = "ValidUntilInsurance";

            bool hasAttribute = user.GetType()
                                    .GetProperty(property)
                                    .GetCustomAttributes(false)
                                    .Where(p => p.GetType() == typeof(RequiredAttribute))
                                    .Any();

            Assert.IsTrue(hasAttribute);
        }
    }
}
