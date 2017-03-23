using CarsSystem.Data.Models;
using System;

namespace CarsSystem.WebClient.MVC.Areas.Administration.Models.Cars
{
    public class CarDetailsViewModel
    {
        public Guid Id { get; set; }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public EngineType TypeOfEngine { get; set; }

        public string RegistrationNumber { get; set; }

        public string VINNumber { get; set; }

        public byte CountOfTyres { get; set; }

        public byte CountOfDoors { get; set; }

        public CarType TypeOfCar { get; set; }

        public DateTime YearOfManufactoring { get; set; }

        public DateTime ValidUntilAnnualCheckUp { get; set; }

        public DateTime ValidUntilVignette { get; set; }

        public DateTime ValidUntilInsurance { get; set; }

        public string CarOwnerId { get; set; }
    }
}