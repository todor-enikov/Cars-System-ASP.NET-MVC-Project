using CarsSystem.Data.Models;
using NUnit.Framework;

namespace CarsSystem.Tests.Data.CarsSystem.Data.Models.UserTests
{
    [TestFixture]
    public class Should
    {
        [Test]
        public void CreateInstanceOfClassCorrectly()
        {
            // Arrange
            var user = new User();

            // Act & Assert
            Assert.IsInstanceOf<User>(user);
        }

        [Test]
        public void CreateNullFirstnameField_WhenInstantiedNewUser()
        {
            // Arrange
            var user = new User();

            // Act & Assert
            Assert.IsNull(user.FirstName);
        }

        [Test]
        public void CreateNullSecondNameField_WhenInstantiedNewUser()
        {
            // Arrange
            var user = new User();

            // Act & Assert
            Assert.IsNull(user.SecondName);
        }

        [Test]
        public void CreateNullLastnameField_WhenInstantiedNewUser()
        {
            // Arrange
            var user = new User();

            // Act & Assert
            Assert.IsNull(user.LastName);
        }

        [Test]
        public void CreateZeroValueOfEGNField_WhenInstantiedNewUser()
        {
            // Arrange
            var user = new User();

            // Act & Assert
            Assert.Zero(user.EGN);
        }

        [Test]
        public void CreateZeroValueOfNumberOfIdCardField_WhenInstantiedNewUser()
        {
            // Arrange
            var user = new User();

            // Act & Assert
            Assert.Zero(user.NumberOfIdCard);
        }

        [Test]
        public void CreateExpectedDateOfIssueField_WhenInstantiedNewUser()
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
        public void CreateNullCityField_WhenInstantiedNewUser()
        {
            // Arrange
            var user = new User();

            // Act & Assert
            Assert.IsNull(user.City);
        }

        [Test]
        public void CreateNullPhoneNumberField_WhenInstantiedNewUser()
        {
            // Arrange
            var user = new User();

            // Act & Assert
            Assert.IsNull(user.PhoneNumber);
        }

        [Test]
        public void SetsFirstNameField_Correctly()
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
        public void SetsSecondNameField_Correctly()
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
        public void SetsLastNameField_Correctly()
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
        public void SetsSpecificEGNField_Correctly()
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
        public void SetsSpecificNumberOfIdCardField_Correctly()
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
        public void SetsCityField_Correctly()
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
        public void SetsPhoneNumberField_Correctly()
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
