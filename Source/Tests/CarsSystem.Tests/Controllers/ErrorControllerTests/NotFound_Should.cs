using System;
using NUnit.Framework;
using CarsSystem.WebClient.MVC.Areas.Error.Controllers;
using TestStack.FluentMVCTesting;

namespace CarsSystem.Tests.Controllers.ErrorControllerTests
{
    [TestFixture]
    public class NotFound_Should
    {
        [Test]
        public void ReturnViewNotFound()
        {
            // Arrange
            var errorController = new ErrorController();

            // Act & Assert
            errorController
                           .WithCallTo(c => c.NotFound())
                           .ShouldRenderView("NotFound");
        }
    }
}
