using CarsSystem.Data.Models;
using System;
using System.Collections.Generic;

namespace CarsSystem.Services.Contracts
{
    public interface ICarsService
    {
        IEnumerable<Car> GetAllCars();

        Car GetCarById(Guid id);

        void AddCar(Car carToAdd);

        Guid GetCarId(User user);

        IEnumerable<Car> GetCarByVinNumber(string vinNumber);

        void Update(Car car);
    }
}