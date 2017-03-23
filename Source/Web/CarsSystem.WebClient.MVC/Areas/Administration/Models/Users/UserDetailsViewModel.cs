using System;

namespace CarsSystem.WebClient.MVC.Areas.Administration.Models.Users
{
    public class UserDetailsViewModel
    {
        public string Id { get; set; }

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

        public Guid CarId { get; set; }
    }
}