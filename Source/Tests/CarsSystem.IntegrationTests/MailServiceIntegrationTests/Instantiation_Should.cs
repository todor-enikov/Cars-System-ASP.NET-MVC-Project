using CarsSystem.Services;
using CarsSystem.Services.Contracts;
using NUnit.Framework;
using System;

namespace CarsSystem.IntegrationTests.MailServiceTests
{
    [TestFixture]
    public class Instantiation_Should
    {
        [Test]
        public void CreateInstance_OfTypeIMailService()
        {
            var mailService = new MailService();

            Assert.IsInstanceOf<IMailService>(mailService);
        }
    }
}
