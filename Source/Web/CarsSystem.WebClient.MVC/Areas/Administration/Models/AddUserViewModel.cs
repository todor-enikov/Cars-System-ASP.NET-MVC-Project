using CarsSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CarsSystem.WebClient.MVC.Areas.Administration.Models
{
    public class AddUserViewModel
    {
        public UserViewModel User { get; set; }

        public CarViewModel Car { get; set; }
    }
}