using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarsSystem.WebClient.MVC.Areas.Administration.Models
{
    public class UserViewModel
    {
        public string Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "{0} should be between {2} and {1} symbols long!", MinimumLength = 2)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "{0} should be between {2} and {1} symbols long!", MinimumLength = 2)]
        [Display(Name = "Second name")]
        public string SecondName { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "{0} should be between {2} and {1} symbols long!", MinimumLength = 2)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required]
        [Index(IsUnique = true)]
        public long Egn { get; set; }

        [Required]
        [Index(IsUnique = true)]
        public int NumberOfIdCard { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateOfIssue { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "{0} should be between {2} and {1} symbols long!", MinimumLength = 0)]
        public string City { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}