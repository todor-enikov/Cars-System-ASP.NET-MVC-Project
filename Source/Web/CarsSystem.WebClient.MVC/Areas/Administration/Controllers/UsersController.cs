using CarsSystem.Auth;
using CarsSystem.Data.Models;
using CarsSystem.Services.Contracts;
using CarsSystem.WebClient.MVC.Areas.Administration.Models;
using CarsSystem.WebClient.MVC.Areas.Administration.Models.Users;
using Common;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarsSystem.WebClient.MVC.Areas.Administration.Controllers
{
    [Authorize(Roles = ApplicationConstants.AdminRole)]
    public class UsersController : Controller
    {
        private readonly IUsersService userService;
        private readonly ICarsService carsService;
        private UserManager _userManager;

        public UsersController(IUsersService userService, ICarsService carsService)
        {
            this.userService = userService;
            this.carsService = carsService;
        }

        public UsersController(UserManager userManager)
        {
            UserManager = userManager;
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

        [HttpGet]
        public ActionResult Index()
        {
            var userModel = this.userService.GetAllUsers().ToList();
            var viewModel = new List<ShowAllUsersViewModel>();

            foreach (var user in userModel)
            {
                var currentUser = new ShowAllUsersViewModel()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Username = user.UserName
                };

                viewModel.Add(currentUser);
            }

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Details(string id)
        {
            var userModelById = this.userService.GetUserById(id);
            var caridd = userModelById.Cars.FirstOrDefault().Id;

            var viewModel = new UserDetailsViewModel()
            {
                Id = userModelById.Id,
                Username = userModelById.UserName,
                FirstName = userModelById.FirstName,
                SecondName = userModelById.SecondName,
                LastName = userModelById.LastName,
                Egn = userModelById.EGN,
                NumberOfIdCard = userModelById.NumberOfIdCard,
                DateOfIssue = userModelById.DateOfIssue,
                City = userModelById.City,
                PhoneNumber = userModelById.PhoneNumber,
                Email = userModelById.Email,
                CarId = this.carsService.GetCarId(userModelById)
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Search(string search)
        {
            long result;
            var parsed = long.TryParse(search, out result);

            if (string.IsNullOrEmpty(search) || parsed == false)
            {
                return RedirectToAction("InternalServer", "Error", new { area = "Error" });
            }

            var userModel = this.userService.GetUserByEGN(long.Parse(search)).ToList();
            var viewModel = new List<ShowAllUsersViewModel>();

            foreach (var user in userModel)
            {
                var currentUser = new ShowAllUsersViewModel()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Username = user.UserName
                };

                viewModel.Add(currentUser);
            }

            return View("Index", viewModel);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            var userModelById = this.userService.GetUserById(id);
            var viewModel = new UserViewModel()
            {
                Id = userModelById.Id,
                Username = userModelById.UserName,
                FirstName = userModelById.FirstName,
                SecondName = userModelById.SecondName,
                LastName = userModelById.LastName,
                Egn = userModelById.EGN,
                NumberOfIdCard = userModelById.NumberOfIdCard,
                DateOfIssue = userModelById.DateOfIssue,
                City = userModelById.City,
                PhoneNumber = userModelById.PhoneNumber,
                Email = userModelById.Email
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(UserViewModel user)
        {
            var userToUpdate = new User()
            {
                Id = user.Id,
                UserName = user.Username,
                FirstName = user.FirstName,
                SecondName = user.SecondName,
                LastName = user.LastName,
                EGN = user.Egn,
                NumberOfIdCard = user.NumberOfIdCard,
                DateOfIssue = user.DateOfIssue,
                City = user.City,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
            };

            this.userService.Update(userToUpdate);
            UserManager.AddPassword(userToUpdate.Id, "123456");

            return RedirectToAction("Details", "Users", new { area = "Administration", id = user.Id });
        }
    }
}