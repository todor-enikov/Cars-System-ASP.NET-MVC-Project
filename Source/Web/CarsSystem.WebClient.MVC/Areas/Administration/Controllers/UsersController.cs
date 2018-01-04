using CarsSystem.Services.Contracts;
using CarsSystem.WebClient.MVC.Areas.Administration.Models;
using CarsSystem.WebClient.MVC.Areas.Administration.Models.Users;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CarsSystem.WebClient.MVC.Areas.Administration.Controllers
{
    [Authorize(Roles = ApplicationConstants.AdminRole)]
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;
        private readonly ICarsService carsService;

        public UsersController(IUsersService usersService, ICarsService carsService)
        {
            if (usersService == null)
            {
                throw new NullReferenceException(ApplicationConstants.UsersServiceErrorMessage);
            }

            if (carsService == null)
            {
                throw new NullReferenceException(ApplicationConstants.CarssServiceErrorMessage);
            }

            this.usersService = usersService;
            this.carsService = carsService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var userModel = this.usersService
                                .GetAllUsers()
                                .ToList();
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
            var userModelById = this.usersService
                                    .GetUserById(id);
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
        [ValidateAntiForgeryToken]
        public ActionResult Search(string search)
        {
            long result;
            bool isParsed = long.TryParse(search, out result);

            if (string.IsNullOrEmpty(search) || isParsed == false)
            {
                return PartialView("_NoResults");
            }

            var userModel = this.usersService
                                .GetUserByEGN(long.Parse(search))
                                .ToList();
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

            if (viewModel.Count < 1)
            {
                return PartialView("_NoResults", viewModel);
            }

            return PartialView("_AllUsers", viewModel);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            var userModelById = this.usersService
                                    .GetUserById(id);
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
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserViewModel user, string id)
        {
            var userToUpdate = this.usersService
                                   .GetUserById(id);
            userToUpdate.UserName = user.Username;
            userToUpdate.FirstName = user.FirstName;
            userToUpdate.SecondName = user.SecondName;
            userToUpdate.LastName = user.LastName;
            userToUpdate.EGN = user.Egn;
            userToUpdate.NumberOfIdCard = user.NumberOfIdCard;
            userToUpdate.DateOfIssue = user.DateOfIssue;
            userToUpdate.City = user.City;
            userToUpdate.PhoneNumber = user.PhoneNumber;
            userToUpdate.Email = user.Email;

            this.usersService.Update(userToUpdate);

            return RedirectToAction("Details", "Users", new { area = "Administration", id = user.Id });
        }
    }
}