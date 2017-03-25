using System;
using NUnit.Framework;
using CarsSystem.WebClient.MVC.Areas.Administration.Controllers;
using CarsSystem.Services.Contracts;
using TestStack.FluentMVCTesting;
using CarsSystem.WebClient.MVC.Areas.Administration.Models;
using Moq;

namespace CarsSystem.Tests.Controllers.AdministrationControllers
{
    [TestFixture]
    public class AddUserController_Should
    {
        [Test]
        public void ThrowNullReferenceException_WhenCarsService_IsNull()
        {
            // Arrange
            ICarsService service = null;

            // Act & Assert
            Assert.Throws<NullReferenceException>(() => new AddUserController(service));
        }

        [Test]
        public void ThrowNullReferenceException_WithExpectedMessage()
        {
            // Arrange
            ICarsService service = null;

            // Act
            var expectedMessage = Assert.Throws<NullReferenceException>(() => new AddUserController(service));

            // Assert
            Assert.IsTrue(expectedMessage.Message.Contains("null"));
        }

        [Test]
        public void ReturnDefaultView()
        {
            // Arrange
            var service = new Mock<ICarsService>();
            var addUserController =  new AddUserController(service.Object);

            // Act & Assert
            addUserController
                             .WithCallTo(c => c.AddUser())
                             .ShouldRenderDefaultView();
        }
    }
}
