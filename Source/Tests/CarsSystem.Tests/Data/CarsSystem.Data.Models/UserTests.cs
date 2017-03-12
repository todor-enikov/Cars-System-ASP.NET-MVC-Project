using CarsSystem.Data.Models;
using NUnit.Framework;

namespace CarsSystem.Tests.Data.CarsSystem.Data.Models
{
    [TestFixture]
    public class UserTests
    {
        [Test]
        public void User_ShouldCreateInstanceOfClassCorrectly()
        {
            var user = new User();

            Assert.IsInstanceOf<User>(user);
        }

        [Test]
        public void User_ShouldCreateNullFirstnameField_WhenInstantiedNewUser()
        {
            var user = new User();

            Assert.IsNull(user.FirstName);
        }

        [Test]
        public void User_ShouldCreateNullSecondNameField_WhenInstantiedNewUser()
        {
            var user = new User();

            Assert.IsNull(user.SecondName);
        }

        [Test]
        public void User_ShouldCreateNullLastnameField_WhenInstantiedNewUser()
        {
            var user = new User();

            Assert.IsNull(user.LastName);
        }

        [Test]
        public void User_ShouldCreateZeroValueOfEGNField_WhenInstantiedNewUser()
        {
            var user = new User();

            Assert.Zero(user.EGN);
        }

        [Test]
        public void User_ShouldCreateZeroValueOfNumberOfIdCardField_WhenInstantiedNewUser()
        {
            var user = new User();

            Assert.Zero(user.NumberOfIdCard);
        }

        [Test]
        public void User_ShouldCreateExpectedDateOfIssueField_WhenInstantiedNewUser()
        {
            var user = new User();

            var actualDateOfIssue = user.DateOfIssue.ToString();
            var expectedDateOfIssue = "1/1/0001 12:00:00 AM";

            Assert.AreEqual(expectedDateOfIssue, actualDateOfIssue);
        }

        [Test]
        public void User_ShouldCreateNullCityField_WhenInstantiedNewUser()
        {
            var user = new User();

            Assert.IsNull(user.City);
        }

        [Test]
        public void User_ShouldCreateNullPhoneNumberField_WhenInstantiedNewUser()
        {
            var user = new User();

            Assert.IsNull(user.PhoneNumber);
        }

        [Test]
        public void User_ShouldSetsFirstNameField_Correctly()
        {
            var user = new User();

            user.FirstName = "Pesho";
            var expectedFirstName = "Pesho";

            Assert.AreEqual(expectedFirstName, user.FirstName);
        }

        [Test]
        public void User_ShouldSetsSecondNameField_Correctly()
        {
            var user = new User();

            user.SecondName = "Peshev";
            var expectedSecondName = "Peshev";

            Assert.AreEqual(expectedSecondName, user.SecondName);
        }

        [Test]
        public void User_ShouldSetsLastNameField_Correctly()
        {
            var user = new User();

            user.LastName = "Georgiev";     
            var expectedLastName = "Georgiev";

            Assert.AreEqual(expectedLastName, user.LastName);
        }

        [Test]
        public void User_ShouldSetsSpecificEGNField_Correctly()
        {
            var user = new User();

            user.EGN = 9307164323;
            var expectedEGN = 9307164323;

            Assert.AreEqual(expectedEGN, user.EGN);
        }

        [Test]
        public void User_ShouldSetsSpecificNumberOfIdCardField_Correctly()
        {
            var user = new User();

            user.NumberOfIdCard = 123456;
            var expectedNumberOfIdCard = 123456;

            Assert.AreEqual(expectedNumberOfIdCard, user.NumberOfIdCard);
        }

        [Test]
        public void User_ShouldSetsCityField_Correctly()
        {
            var user = new User();

            user.City = "Silsitra";
            var expectedCity = "Silsitra";

            Assert.AreEqual(expectedCity, user.City);
        }

        [Test]
        public void User_ShouldSetsPhoneNumberField_Correctly()
        {
            var user = new User();

            user.PhoneNumber = "0888321321";
            var expectedPhoneNumber = "0888321321";

            Assert.AreEqual(expectedPhoneNumber, user.PhoneNumber);
        }
    }
}
