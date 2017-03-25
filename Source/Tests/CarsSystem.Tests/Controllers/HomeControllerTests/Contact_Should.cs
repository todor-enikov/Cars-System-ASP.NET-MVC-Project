using System;
using NUnit.Framework;
using CarsSystem.WebClient.MVC.Controllers;
using TestStack.FluentMVCTesting;

namespace CarsSystem.Tests.Controllers.HomeControllerTests
{
    [TestFixture]
    public class Contact_Should
    {
        [Test]
        public void ReturnDefaultView()
        {
            // Arrange
            var homeController = new HomeController();

            // Act & Assert
            homeController
                           .WithCallTo(c => c.Contact())
                           .ShouldRenderDefaultView();
        }
    }
}
