using CarsSystem.Data.Models;
using System;
using System.Collections.Generic;

namespace CarsSystem.Services.Contracts
{
    public interface ICarsService
    {
        IEnumerable<Car> GetAllCars();
        Car GetCarById(int id);
        void AddCar(Car carToAdd);
        Guid GetCarId(User user);
    }
}