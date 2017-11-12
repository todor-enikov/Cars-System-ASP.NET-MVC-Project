using CarsSystem.Auth;
using CarsSystem.Data.Models;
using CarsSystem.Services.Contracts;
using CarsSystem.WebClient.MVC.Areas.Administration.Models;
using Common;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Ninject;
using System;
using System.Web;
using System.Web.Mvc;

namespace CarsSystem.WebClient.MVC.Areas.Administration.Controllers
{
    [Authorize(Roles = ApplicationConstants.AdminRole)]
    public class AddUserController : Controller
    {
        private SignInManager _signInManager;
        private UserManager _userManager;
        private readonly ICarsService service;

        public AddUserController(ICarsService service)
        {
            if (service == null)
            {
                throw new NullReferenceException(ApplicationConstants.CarssServiceErrorMessage);
            }

            this.service = service;
        }

        public AddUserController(UserManager userManager, SignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
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

        // GET: Administration/AddUser
        [HttpGet]
        [OutputCache(Duration = 10)]
        public ActionResult AddUser()
        {
            return View();
        }

        // POST: Administration/AddUser
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddUser(AddUserViewModel receivedModel)
        {

            var userToAdd = new User()
            {
                UserName = receivedModel.User.Username,
                FirstName = receivedModel.User.FirstName,
                SecondName = receivedModel.User.SecondName,
                LastName = receivedModel.User.LastName,
                EGN = receivedModel.User.Egn,
                NumberOfIdCard = receivedModel.User.NumberOfIdCard,
                DateOfIssue = receivedModel.User.DateOfIssue,
                City = receivedModel.User.City,
                PhoneNumber = receivedModel.User.PhoneNumber,
                Email = receivedModel.User.Email
            };

            IdentityResult result = UserManager.Create(userToAdd, "123456");

            var carToAdd = new Car()
            {
                Manufacturer = receivedModel.Car.Manufacturer,
                Model = receivedModel.Car.Model,
                TypeOfEngine = receivedModel.Car.TypeOfEngine,
                RegistrationNumber = receivedModel.Car.RegistrationNumber,
                VINNumber = receivedModel.Car.VINNumber,
                CountOfTyres = receivedModel.Car.CountOfTyres,
                CountOfDoors = receivedModel.Car.CountOfDoors,
                TypeOfCar = receivedModel.Car.TypeOfCar,
                YearOfManufacturing = receivedModel.Car.YearOfManufactoring,
                ValidUntilAnnualCheckUp = receivedModel.Car.ValidUntilAnnualCheckUp,
                ValidUntilVignette = receivedModel.Car.ValidUntilVignette,
                ValidUntilInsurance = receivedModel.Car.ValidUntilInsurance,
                IsEmailSendedForAnnual = false,
                IsEmailSendedForInsurance = false,
                IsEmailSendedForVignette = false,
                UserId = userToAdd.Id,
                Id = Guid.NewGuid()
            };


            if (result.Succeeded)
            {
                UserManager.AddToRole(userToAdd.Id, ApplicationConstants.UserRole);
                this.service.AddCar(carToAdd);
                return RedirectToAction("Index", "Success", new { area = "Administration" });
            }

            return View(receivedModel);
        }
    }
}