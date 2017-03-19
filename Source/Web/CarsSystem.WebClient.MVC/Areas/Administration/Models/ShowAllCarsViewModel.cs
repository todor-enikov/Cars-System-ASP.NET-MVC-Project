using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarsSystem.WebClient.MVC.Areas.Administration.Models
{
    public class ShowAllCarsViewModel
    {
        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public string RegistrationNumber { get; set; }
    }
}