using CarsSystem.Data.Models;
using System.Collections.Generic;

namespace CarsSystem.Services.Contracts
{
    public interface ICarsService
    {
        IEnumerable<Car> GetAllCars();
        Car GetCarById(int id);
        void AddCar(Car carToAdd);
        int GetCarId(User user);
    }
}