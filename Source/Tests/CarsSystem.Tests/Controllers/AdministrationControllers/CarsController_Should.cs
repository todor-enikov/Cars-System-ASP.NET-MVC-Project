using System;
using NUnit.Framework;
using CarsSystem.Services.Contracts;
using CarsSystem.WebClient.MVC.Areas.Administration.Controllers;
using Moq;
using TestStack.FluentMVCTesting;
using CarsSystem.WebClient.MVC.Areas.Administration.Models.Cars;
using System.Collections.Generic;

namespace CarsSystem.Tests.Controllers.AdministrationControllers
{
    [TestFixture]
    public class CarsController_Should
    {
        [Test]
        public void ThrowNullReferenceException_WhenCarsService_IsNull()
        {
            // Arrange
            ICarsService service = null;

            // Act & Assert
            Assert.Throws<NullReferenceException>(() => new CarsController(service));
        }

        [Test]
        public void ThrowNullReferenceException_WithExpectedMessage()
        {
            // Arrange
            ICarsService service = null;

            // Act
            var expectedMessage = Assert.Throws<NullReferenceException>(() => new CarsController(service));

            // Assert
            Assert.IsTrue(expectedMessage.Message.Contains("null"));
        }

        [Test]
        public void ReturnViewWithExpectedModel_OnIndexAction()
        {
            // Arrange
            var service = new Mock<ICarsService>();
            var carsController = new CarsController(service.Object);
            var model = new List<ShowAllCarsViewModel>();

            // Act & Arrange
            carsController
                           .WithCallTo(c => c.Index())
                           .ShouldRenderDefaultView();
        }
    }
}
