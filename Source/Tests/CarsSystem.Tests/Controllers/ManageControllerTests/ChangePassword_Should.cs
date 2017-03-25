using System;
using NUnit.Framework;
using CarsSystem.WebClient.MVC.Controllers;
using TestStack.FluentMVCTesting;
using CarsSystem.WebClient.MVC.Models;

namespace CarsSystem.Tests.Controllers.ManageControllerTests
{
    [TestFixture]
    public class ChangePassword_Should
    {
        [Test]
        public void ReturnDefaultView()
        {
            // Arrange
            var manageController = new ManageController();

            // Act & Assert
            manageController
                            .WithCallTo(c => c.ChangePassword())
                            .ShouldRenderDefaultView();
        }

        [Test]
        public void ReturnExpectedViewModel()
        {
            // Arrange
            var model = new ChangePasswordViewModel();
            var manageController = new ManageController();

            // Act & Assert
            manageController
                            .WithModelErrors()
                            .WithCallTo(c => c.ChangePassword(model))
                            .ShouldRenderDefaultView()
                            .WithModel(model);
        }
    }
}
