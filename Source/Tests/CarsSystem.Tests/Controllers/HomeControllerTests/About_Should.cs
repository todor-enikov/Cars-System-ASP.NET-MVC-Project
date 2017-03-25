using System;
using NUnit.Framework;
using CarsSystem.WebClient.MVC.Controllers;
using TestStack.FluentMVCTesting;

namespace CarsSystem.Tests.Controllers.HomeControllerTests
{
    [TestFixture]
    public class About_Should
    {
        [Test]
        public void ReturnDefaulView()
        {
            // Arrange
            var homeController = new HomeController();

            // Act & Assert
            homeController
                          .WithCallTo(c => c.About())
                          .ShouldRenderDefaultView();
        }
    }
}
