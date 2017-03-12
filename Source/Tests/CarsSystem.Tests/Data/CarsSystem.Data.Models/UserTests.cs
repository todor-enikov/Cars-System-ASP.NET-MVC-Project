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
            // Arrange
            var user = new User();

            // Act & Assert
            Assert.IsInstanceOf<User>(user);
        }

        [Test]
        public void User_ShouldCreateNullFirstnameField_WhenInstantiedNewUser()
        {
            // Arrange
            var user = new User();

            // Act & Assert
            Assert.IsNull(user.FirstName);
        }

        [Test]
        public void User_ShouldCreateNullSecondNameField_WhenInstantiedNewUser()
        {
            // Arrange
            var user = new User();

            // Act & Assert
            Assert.IsNull(user.SecondName);
        }

        [Test]
        public void User_ShouldCreateNullLastnameField_WhenInstantiedNewUser()
        {
            // Arrange
            var user = new User();

            // Act & Assert
            Assert.IsNull(user.LastName);
        }

        [Test]
        public void User_ShouldCreateZeroValueOfEGNField_WhenInstantiedNewUser()
        {
            // Arrange
            var user = new User();

            // Act & Assert
            Assert.Zero(user.EGN);
        }

        [Test]
        public void User_ShouldCreateZeroValueOfNumberOfIdCardField_WhenInstantiedNewUser()
        {
            // Arrange
            var user = new User();

            // Act & Assert
            Assert.Zero(user.NumberOfIdCard);
        }

        [Test]
        public void User_ShouldCreateExpectedDateOfIssueField_WhenInstantiedNewUser()
        {
            // Arrange
            var user = new User();

            // Act
            var actualDateOfIssue = user.DateOfIssue.ToString();
            var expectedDateOfIssue = "1/1/0001 12:00:00 AM";

            // Assert
            Assert.AreEqual(expectedDateOfIssue, actualDateOfIssue);
        }

        [Test]
        public void User_ShouldCreateNullCityField_WhenInstantiedNewUser()
        {
            // Arrange
            var user = new User();

            // Act & Assert
            Assert.IsNull(user.City);
        }

        [Test]
        public void User_ShouldCreateNullPhoneNumberField_WhenInstantiedNewUser()
        {
            // Arrange
            var user = new User();

            // Act & Assert
            Assert.IsNull(user.PhoneNumber);
        }

        [Test]
        public void User_ShouldSetsFirstNameField_Correctly()
        {
            // Arrange
            var user = new User();

            // Act
            user.FirstName = "Pesho";
            var expectedFirstName = "Pesho";

            // Assert
            Assert.AreEqual(expectedFirstName, user.FirstName);
        }

        [Test]
        public void User_ShouldSetsSecondNameField_Correctly()
        {
            // Arrange
            var user = new User();

            // Act
            user.SecondName = "Peshev";
            var expectedSecondName = "Peshev";

            // Assert
            Assert.AreEqual(expectedSecondName, user.SecondName);
        }

        [Test]
        public void User_ShouldSetsLastNameField_Correctly()
        {
            // Arrange
            var user = new User();

            // Act
            user.LastName = "Georgiev";     
            var expectedLastName = "Georgiev";

            // Assert
            Assert.AreEqual(expectedLastName, user.LastName);
        }

        [Test]
        public void User_ShouldSetsSpecificEGNField_Correctly()
        {
            // Arrange
            var user = new User();

            // Act
            user.EGN = 9307164323;
            var expectedEGN = 9307164323;

            // Assert
            Assert.AreEqual(expectedEGN, user.EGN);
        }

        [Test]
        public void User_ShouldSetsSpecificNumberOfIdCardField_Correctly()
        {
            // Arrange
            var user = new User();

            // Act
            user.NumberOfIdCard = 123456;
            var expectedNumberOfIdCard = 123456;

            // Assert
            Assert.AreEqual(expectedNumberOfIdCard, user.NumberOfIdCard);
        }

        [Test]
        public void User_ShouldSetsCityField_Correctly()
        {
            // Arrange
            var user = new User();

            // Act
            user.City = "Silistra";
            var expectedCity = "Silistra";

            // Assert
            Assert.AreEqual(expectedCity, user.City);
        }

        [Test]
        public void User_ShouldSetsPhoneNumberField_Correctly()
        {
            // Arrange
            var user = new User();

            // Act
            user.PhoneNumber = "0888321321";
            var expectedPhoneNumber = "0888321321";

            // Assert
            Assert.AreEqual(expectedPhoneNumber, user.PhoneNumber);
        }
    }
}
