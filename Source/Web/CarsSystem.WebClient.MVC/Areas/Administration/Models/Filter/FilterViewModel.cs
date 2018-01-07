using System;

namespace CarsSystem.WebClient.MVC.Areas.Administration.Models.Filter
{
    public class FilterViewModel
    {
        public Guid CarId { get; set; }

        public string CustomerId { get; set; }

        public string CustomerOfVehicle { get; set; }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public string RegistrationNumber { get; set; }

        public string VINNumber { get; set; }

        public DateTime ExpirationDate { get; set; }

        public string UserNotificationMessage { get; set; }
    }
}