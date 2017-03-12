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
            var user = new User();
            string property = "Id";

            bool hasAttribute = user.GetType()
                                    .GetProperty(property)
                                    .GetCustomAttributes(false)
                                    .Where(p => p.GetType() == typeof(KeyAttribute))
                                    .Any();

            Assert.IsTrue(hasAttribute);
        }

        [Test]
        public void User_FirstNameProperty_ShouldHaveRequiredAttribute()
        {
            var user = new User();
            string property = "FirstName";

            bool hasAttribute = user.GetType()
                                    .GetProperty(property)
                                    .GetCustomAttributes(false)
                                    .Where(p => p.GetType() == typeof(RequiredAttribute))
                                    .Any();

            Assert.IsTrue(hasAttribute);
        }

        [Test]
        public void User_SecondNameProperty_ShouldHaveRequiredAttribute()
        {
            var user = new User();
            string property = "SecondName";

            bool hasAttribute = user.GetType()
                                    .GetProperty(property)
                                    .GetCustomAttributes(false)
                                    .Where(p => p.GetType() == typeof(RequiredAttribute))
                                    .Any();

            Assert.IsTrue(hasAttribute);
        }

        [Test]
        public void User_LastNameProperty_ShouldHaveRequiredAttribute()
        {
            var user = new User();
            string property = "LastName";

            bool hasAttribute = user.GetType()
                                    .GetProperty(property)
                                    .GetCustomAttributes(false)
                                    .Where(p => p.GetType() == typeof(RequiredAttribute))
                                    .Any();

            Assert.IsTrue(hasAttribute);
        }

        [Test]
        public void User_EGNProperty_ShouldHaveRequiredAttribute()
        {
            var user = new User();
            string property = "EGN";

            bool hasAttribute = user.GetType()
                                    .GetProperty(property)
                                    .GetCustomAttributes(false)
                                    .Where(p => p.GetType() == typeof(RequiredAttribute))
                                    .Any();

            Assert.IsTrue(hasAttribute);
        }

        [Test]
        public void User_NumberOfIdCardProperty_ShouldHaveRequiredAttribute()
        {
            var user = new User();
            string property = "NumberOfIdCard";

            bool hasAttribute = user.GetType()
                                    .GetProperty(property)
                                    .GetCustomAttributes(false)
                                    .Where(p => p.GetType() == typeof(RequiredAttribute))
                                    .Any();

            Assert.IsTrue(hasAttribute);
        }

        [Test]
        public void User_DateOfIssueProperty_ShouldHaveRequiredAttribute()
        {
            var user = new User();
            string property = "DateOfIssue";

            bool hasAttribute = user.GetType()
                                    .GetProperty(property)
                                    .GetCustomAttributes(false)
                                    .Where(p => p.GetType() == typeof(RequiredAttribute))
                                    .Any();

            Assert.IsTrue(hasAttribute);
        }

        [Test]
        public void User_CityProperty_ShouldHaveRequiredAttribute()
        {
            var user = new User();
            string property = "City";

            bool hasAttribute = user.GetType()
                                    .GetProperty(property)
                                    .GetCustomAttributes(false)
                                    .Where(p => p.GetType() == typeof(RequiredAttribute))
                                    .Any();

            Assert.IsTrue(hasAttribute);
        }

        [Test]
        public void User_PhoneNumberProperty_ShouldHaveRequiredAttribute()
        {
            var user = new User();
            string property = "PhoneNumber";

            bool hasAttribute = user.GetType()
                                    .GetProperty(property)
                                    .GetCustomAttributes(false)
                                    .Where(p => p.GetType() == typeof(RequiredAttribute))
                                    .Any();

            Assert.IsTrue(hasAttribute);
        }
    }
}
