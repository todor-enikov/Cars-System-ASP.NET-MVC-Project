using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarsSystem.Data.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string Manufacturer { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string Model { get; set; }

        [Required]
        public EngineType TypeOfEngine { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(10)]
        public string RegistrationNumber { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(17)]
        [MaxLength(17)]
        public string VINNumber { get; set; }

        [Range(2, 10)]
        public byte CountOfTyres { get; set; }

        [Range(2, 6)]
        public byte CountOfDoors { get; set; }

        [Required]
        public CarType TypeOfCar { get; set; }

        [Required]
        public DateTime YearOfManufacturing { get; set; }

        [Required]
        public DateTime ValidUntilAnnualCheckUp { get; set; }

        [Required]
        public DateTime ValidUntilVignette { get; set; }

        [Required]
        public DateTime ValidUntilInsurance { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
