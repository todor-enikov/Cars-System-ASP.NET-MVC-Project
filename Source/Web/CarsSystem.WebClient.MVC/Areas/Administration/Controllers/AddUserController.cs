using CarsSystem.Auth;
using CarsSystem.Data.Models;
using CarsSystem.Services.Contracts;
using CarsSystem.WebClient.MVC.Areas.Administration.Models;
using Common;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarsSystem.WebClient.MVC.Areas.Administration.Controllers
{
    public class AddUserController : Controller
    {
        private SignInManager _signInManager;
        private UserManager _userManager;
        private ICarsService service;
        public AddUserController()
        {
        }

        public AddUserController(UserManager userManager, SignInManager signInManager, ICarsService service)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            this.service = service;
        }

        public SignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<SignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public UserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<UserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ICarsService Service
        {
            get
            {
                return this.service;
            }
            set
            {
                this.service = value;
            }
        }
        // GET: Administration/AddUser
        [HttpGet]
        public ActionResult AddUser()
        {
            return View();
        }

        // POST: Administration/AddUser
        [HttpPost]
        public ActionResult AddUser(AddUserViewModel receivedModel)
        {

            var userToAdd = new User()
            {
                UserName = receivedModel.Username,
                FirstName = receivedModel.FirstName,
                SecondName = receivedModel.SecondName,
                LastName = receivedModel.LastName,
                EGN = receivedModel.Egn,
                NumberOfIdCard = receivedModel.NumberOfIdCard,
                DateOfIssue = receivedModel.DateOfIssue,
                City = receivedModel.City,
                PhoneNumber = receivedModel.PhoneNumber,
                Email = receivedModel.Email
            };

            IdentityResult result = UserManager.Create(userToAdd, "123456");

            var carToAdd = new Car()
            {
                Manufacturer = receivedModel.Manufacturer,
                Model = receivedModel.Model,
                TypeOfEngine = receivedModel.TypeofEngine,
                RegistrationNumber = receivedModel.RegistrationNumber,
                VINNumber = receivedModel.VINNumber,
                CountOfTyres = receivedModel.CountOfTyres,
                CountOfDoors = receivedModel.CountOfDoors,
                TypeOfCar = receivedModel.TypeOfCar,
                YearOfManufacturing = receivedModel.YearOfManufactoring,
                ValidUntilAnnualCheckUp = receivedModel.ValidUntilAnnualCheckUp,
                ValidUntilVignette = receivedModel.ValidUntilVignette,
                ValidUntilInsurance = receivedModel.ValidUntilInsurance,
                UserId = userToAdd.Id
            };


            if (result.Succeeded)
            {
                UserManager.AddToRole(userToAdd.Id, ApplicationConstants.UserRole);
                Service.AddCar(carToAdd);
                RedirectToAction("~/Home");
            }
            return View(receivedModel);
        }
    }
}