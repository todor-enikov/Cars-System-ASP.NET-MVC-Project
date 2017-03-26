using CarsSystem.Data;
using CarsSystem.Data.Models;
using CarsSystem.Data.Repositories;
using CarsSystem.Services;
using CarsSystem.Services.Contracts;
using NUnit.Framework;
using System;

namespace CarsSystem.IntegrationTests.UsersServiceTests
{
    [TestFixture]
    public class Instantiation_Should
    {
        [Test]
        public void ThrowArgumentException_IfEfRepositoyryIsNull()
        {
            EfGenericRepository<User> carRepo = null;

            Assert.Throws<ArgumentException>(() => new UsersService(carRepo));
            Assert.IsNull(carRepo);
        }

        [Test]
        public void CreateCorrectlyUsersService_IfEfRepositoyryIsNotNull()
        {
            CarsSystemDbContext context = new CarsSystemDbContext();
            EfGenericRepository<User> carRepo = new EfGenericRepository<User>(context);

            Assert.DoesNotThrow(() => new UsersService(carRepo));
            Assert.IsNotNull(carRepo);
        }

        [Test]
        public void CreateInstance_OfTypeIUsersService()
        {
            CarsSystemDbContext context = new CarsSystemDbContext();
            EfGenericRepository<User> carRepo = new EfGenericRepository<User>(context);

            var usersService = new UsersService(carRepo);

            Assert.IsInstanceOf<IUsersService>(usersService);
        }
    }
}
