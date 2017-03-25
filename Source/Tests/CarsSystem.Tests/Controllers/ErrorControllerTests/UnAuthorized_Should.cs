using System;
using NUnit.Framework;
using CarsSystem.WebClient.MVC.Areas.Error.Controllers;
using TestStack.FluentMVCTesting;

namespace CarsSystem.Tests.Controllers.ErrorControllerTests
{
    [TestFixture]
    public class UnAuthorized_Should
    {
        [Test]
        public void ReturnViewInternalServer()
        {
            // Arrange
            var errorController = new ErrorController();

            // Act & Assert
            errorController
                           .WithCallTo(c => c.UnAuthorized())
                           .ShouldRenderView("UnAuthorized");
        }
    }
}
