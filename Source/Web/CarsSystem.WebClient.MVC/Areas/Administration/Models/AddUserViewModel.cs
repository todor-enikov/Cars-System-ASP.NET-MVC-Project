using CarsSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarsSystem.WebClient.MVC.Areas.Administration.Models
{
    public class AddUserViewModel
    {
        [Required]
        public string Username { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string LastName { get; set; }

        public long Egn { get; set; }

        public int NumberOfIdCard { get; set; }

        public DateTime DateOfIssue { get; set; }

        public string City { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public EngineType TypeofEngine { get; set; }

        public string RegistrationNumber { get; set; }

        public string VINNumber { get; set; }

        public byte CountOfTyres { get; set; }

        public byte CountOfDoors { get; set; }

        public CarType TypeOfCar { get; set; }

        public DateTime YearOfManufactoring { get; set; }

        public DateTime ValidUntilAnnualCheckUp { get; set; }

        public DateTime ValidUntilVignette { get; set; }

        public DateTime ValidUntilInsurance { get; set; }

    }
}