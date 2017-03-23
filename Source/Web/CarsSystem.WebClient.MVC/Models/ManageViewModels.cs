using CarsSystem.Data.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace CarsSystem.WebClient.MVC.Models
{
    public class IndexViewModel
    {
        public string Username { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string LastName { get; set; }

        public string City { get; set; }

        public string Email { get; set; }

        public CarType TypeOfCar { get; set; }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public DateTime YearOfManufactoring { get; set; }

        public DateTime ValidUntilAnnualCheckUp { get; set; }

        public DateTime ValidUntilVignette { get; set; }

        public DateTime ValidUntilInsurance { get; set; }

        public EngineType TypeOfEngine { get; set; }

        public bool HasPassword { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}