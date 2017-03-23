using CarsSystem.Data.Models;
using System.Collections.Generic;

namespace CarsSystem.Services.Contracts
{
    public interface IUsersService
    {
        IEnumerable<User> GetAllUsers();

        User GetUserById(string id);

        IEnumerable<User> GetUserByEGN(long egn);

        string GetUserId(Car car);

        void Update(User user);
    }
}
