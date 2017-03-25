using System;
using NUnit.Framework;
using CarsSystem.WebClient.MVC.Areas.Administration.Controllers;
using CarsSystem.Services.Contracts;
using Moq;
using TestStack.FluentMVCTesting;

namespace CarsSystem.Tests.Controllers.AdministrationControllers
{
    [TestFixture]
    public class FilterController_Should
    {
        [Test]
        public void ThrowNullReferenceException_WhenFilterService_IsNull()
        {
            // Arrange
            IFilterService filterService = null;
            var mockedMailService = new Mock<IMailService>();

            // Act & Assert
            Assert.Throws<NullReferenceException>(() => new FilterController(filterService, mockedMailService.Object));
        }

        [Test]
        public void ThrowNullReferenceException_WithExpectedMessage_WhenFilterService_IsNull()
        {
            // Arrange
            IFilterService filterService = null;
            var mockedMailService = new Mock<IMailService>();

            // Act
            var expectedMessage = Assert.Throws<NullReferenceException>(() => new FilterController(filterService, mockedMailService.Object));

            // Assert
            Assert.IsTrue(expectedMessage.Message.Contains("null"));
        }

        [Test]
        public void ThrowNullReferenceException_WhenMailService_IsNull()
        {
            // Arrange
            var filterService = new Mock<IFilterService>();
            IMailService mockedMailService = null;

            // Act & Assert
            Assert.Throws<NullReferenceException>(() => new FilterController(filterService.Object, mockedMailService));
        }

        [Test]
        public void ThrowNullReferenceException_WithExpectedMessage_WhenMailService_IsNull()
        {
            // Arrange
            var filterService = new Mock<IFilterService>();
            IMailService mockedMailService = null;

            // Act
            var expectedMessage = Assert.Throws<NullReferenceException>(() => new FilterController(filterService.Object, mockedMailService));

            // Assert
            Assert.IsTrue(expectedMessage.Message.Contains("null"));
        }

        [Test]
        public void ReturnViewWithExpectedModel_OnIndexAction()
        {
            // Arrange
            var filterService = new Mock<IFilterService>();
            var mailService = new Mock<IMailService>();

            var carsController = new FilterController(filterService.Object, mailService.Object);

            // Act & Arrange
            carsController
                           .WithCallTo(c => c.Index())
                           .ShouldRenderDefaultView();
        }
    }
}
