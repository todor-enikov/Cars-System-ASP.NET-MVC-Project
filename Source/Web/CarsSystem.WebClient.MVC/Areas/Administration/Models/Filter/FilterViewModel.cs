using System;

namespace CarsSystem.WebClient.MVC.Areas.Administration.Models.Filter
{
    public class FilterViewModel
    {
        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public string RegistrationNumber { get; set; }

        public string VINNumber { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}