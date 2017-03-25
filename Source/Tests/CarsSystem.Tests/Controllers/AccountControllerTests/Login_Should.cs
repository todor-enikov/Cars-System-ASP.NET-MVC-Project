using System;
using NUnit.Framework;
using CarsSystem.WebClient.MVC.Controllers;
using TestStack.FluentMVCTesting;

namespace CarsSystem.Tests.Controllers.AccountControllerTests
{
    [TestFixture]
    public class Login_Should
    {
        [Test]
        public void ReturnViewWithReturnUrlInViewBag()
        {
            // Arrange
            var accountController = new AccountController();
            string returnUrl = "url";

            // Act
            accountController
                            .WithCallTo(c => c.Login(returnUrl))
                            .ShouldRenderDefaultView();

            // Assert
            Assert.AreEqual(returnUrl, accountController.ViewBag.ReturnUrl);
        }
    }
}
