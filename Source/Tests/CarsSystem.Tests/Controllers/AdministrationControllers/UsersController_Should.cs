using System;
using NUnit.Framework;
using CarsSystem.Services.Contracts;
using CarsSystem.WebClient.MVC.Areas.Administration.Controllers;
using Moq;

namespace CarsSystem.Tests.Controllers.AdministrationControllers
{
    [TestFixture]
    public class UsersController_Should
    {
        [Test]
        public void ThrowNullReferenceException_WhenUsersService_IsNull()
        {
            // Arrange
            IUsersService usersService = null;
            var mockedcarsService = new Mock<ICarsService>();

            // Act & Assert
            Assert.Throws<NullReferenceException>(() => new UsersController(usersService, mockedcarsService.Object));
        }

        [Test]
        public void ThrowNullReferenceException_WithExpectedMessage_WhenUsersService_IsNull()
        {
            // Arrange
            IUsersService usersService = null;
            var mockedCarsService = new Mock<ICarsService>();

            // Act
            var expectedMessage = Assert.Throws<NullReferenceException>(() => new UsersController(usersService, mockedCarsService.Object));

            // Assert
            Assert.IsTrue(expectedMessage.Message.Contains("null"));
        }

        [Test]
        public void ThrowNullReferenceException_WhenCarsService_IsNull()
        {
            // Arrange
            var usersService = new Mock<IUsersService>();
            ICarsService mockedCarsService = null;

            // Act & Assert
            Assert.Throws<NullReferenceException>(() => new UsersController(usersService.Object, mockedCarsService));
        }

        [Test]
        public void ThrowNullReferenceException_WithExpectedMessage_WhenCarsService_IsNull()
        {
            // Arrange
            var usersService = new Mock<IUsersService>();
            ICarsService mockedCarsService = null;

            // Act
            var expectedMessage = Assert.Throws<NullReferenceException>(() => new UsersController(usersService.Object, mockedCarsService));

            // Assert
            Assert.IsTrue(expectedMessage.Message.Contains("null"));
        }
    }
}
