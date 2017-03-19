using CarsSystem.Services.Contracts;
using CarsSystem.WebClient.MVC.Areas.Administration.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarsSystem.WebClient.MVC.Areas.Administration.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService userService;
        private readonly ICarsService carsService;

        public UsersController(IUsersService userService, ICarsService carsService)
        {
            this.userService = userService;
            this.carsService = carsService;
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
    }
}