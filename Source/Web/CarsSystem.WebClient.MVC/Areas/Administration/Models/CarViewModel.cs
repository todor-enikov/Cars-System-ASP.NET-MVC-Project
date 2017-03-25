using CarsSystem.Data.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarsSystem.WebClient.MVC.Areas.Administration.Models
{
    public class CarViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "{0} should be between {2} and {1} symbols long!", MinimumLength = 2)]
        public string Manufacturer { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "{0} should be between {2} and {1} symbols long!", MinimumLength = 0)]
        public string Model { get; set; }

        [Required]
        public EngineType TypeOfEngine { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "{0} should be between {2} and {1} symbols long!", MinimumLength = 4)]
        [Display(Name = "Registration number")]
        public string RegistrationNumber { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [StringLength(17, ErrorMessage = "{0} should be between exactly {1} symbols long!", MinimumLength = 17)]
        [Display(Name = "VIN number")]
        public string VINNumber { get; set; }

        [Required]
        [Range(2, 10, ErrorMessage = "{0} should be between {1} and {2} symbols long!")]
        [Display(Name = "Count of tyres")]
        public byte CountOfTyres { get; set; }

        [Required]
        [Range(2, 6, ErrorMessage = "{0} should be between {1} and {2} symbols long!")]
        [Display(Name = "Count of doors")]
        public byte CountOfDoors { get; set; }

        [Required]
        public CarType TypeOfCar { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime YearOfManufactoring { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime ValidUntilAnnualCheckUp { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime ValidUntilVignette { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime ValidUntilInsurance { get; set; }

        public string CarOwnerId { get; set; }
    }
}