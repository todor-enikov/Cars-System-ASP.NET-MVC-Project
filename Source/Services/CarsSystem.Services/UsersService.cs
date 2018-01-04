using CarsSystem.Data.Models;
using CarsSystem.Data.Repositories;
using CarsSystem.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarsSystem.Services
{
    public class UsersService : IUsersService
    {
        private readonly IEfGenericRepository<User> userRepo;

        public UsersService(IEfGenericRepository<User> userRepo)
        {
            if (userRepo == null)
            {
                throw new ArgumentException("The user repo shold not be null!");
            }

            this.userRepo = userRepo;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return this.userRepo.All();
        }

        public User GetUserById(string id)
        {
            return this.userRepo.GetById(id);
        }

        public IEnumerable<User> GetUserByEGN(long egn)
        {
            return this.userRepo.All()
                                .Where(u => u.EGN.ToString().Contains(egn.ToString()));
        }

        public string GetUserId(Car car)
        {
            var result = this.GetAllUsers()
                             .FirstOrDefault(u => u.Id == car.UserId);

            return result.Id;
        }

        public void Update(User user)
        {
            this.userRepo.Update(user);
            this.userRepo.SaveChanges();
        }
    }
}
