using CarsSystem.Data.Models;
using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CarsSystem.Tests.Data.CarsSystem.Data.Models
{
    [TestFixture]
    public class UserAttributesTests
    {
        [Test]
        public void User_IdProperty_ShouldHaveKeyAttribute()
        {
            // Arrange
            var user = new User();
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
        public void User_FirstNameProperty_ShouldHaveRequiredAttribute()
        {
            // Arrange
            var user = new User();
            string property = "FirstName";

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
        public void User_SecondNameProperty_ShouldHaveRequiredAttribute()
        {
            // Arrange
            var user = new User();
            string property = "SecondName";

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
        public void User_LastNameProperty_ShouldHaveRequiredAttribute()
        {
            // Arrange
            var user = new User();
            string property = "LastName";

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
        public void User_EGNProperty_ShouldHaveRequiredAttribute()
        {
            // Arrange
            var user = new User();
            string property = "EGN";

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
        public void User_NumberOfIdCardProperty_ShouldHaveRequiredAttribute()
        {
            // Arrange
            var user = new User();
            string property = "NumberOfIdCard";

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
        public void User_DateOfIssueProperty_ShouldHaveRequiredAttribute()
        {
            // Arrange
            var user = new User();
            string property = "DateOfIssue";

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
        public void User_CityProperty_ShouldHaveRequiredAttribute()
        {
            // Arrange
            var user = new User();
            string property = "City";

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
        public void User_PhoneNumberProperty_ShouldHaveRequiredAttribute()
        {
            // Arrange
            var user = new User();
            string property = "PhoneNumber";

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
