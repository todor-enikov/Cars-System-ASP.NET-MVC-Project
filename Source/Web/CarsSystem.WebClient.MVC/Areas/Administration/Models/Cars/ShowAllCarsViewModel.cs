using System;

namespace CarsSystem.WebClient.MVC.Areas.Administration.Models.Cars
{
    public class ShowAllCarsViewModel
    {
        public Guid Id { get; set; }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public string RegistrationNumber { get; set; }
    }
}