using CarsSystem.Data.Models;
using CarsSystem.Data.Repositories;
using CarsSystem.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarsSystem.Services
{
    public class CarsService : ICarsService
    {
        private readonly IEfGenericRepository<Car> carRepo;

        public CarsService(IEfGenericRepository<Car> carRepo)
        {
            if (carRepo == null)
            {
                throw new ArgumentException("The car repo should not be null!");
            }

            this.carRepo = carRepo;
        }

        public IEnumerable<Car> GetAllCars()
        {
            return this.carRepo.All();
        }

        public Car GetCarById(int id)
        {
            return this.carRepo.GetById(id);
        }

        public void AddCar(Car carToAdd)
        {
            this.carRepo.Add(carToAdd);
            this.carRepo.SaveChanges();
        }

        public Guid GetCarId(User user)
        {
            var result = this.GetAllCars()
                             .FirstOrDefault(c => c.UserId == user.Id);

            return result.Id;
        }
    }
}
