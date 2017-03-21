using CarsSystem.Services.Contracts;
using CarsSystem.WebClient.MVC.Areas.Administration.Models.Cars;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace CarsSystem.WebClient.MVC.Areas.Administration.Controllers
{
    [Authorize(Roles = ApplicationConstants.AdminRole)]
    public class CarsController : Controller
    {
        private readonly ICarsService service;

        public CarsController(ICarsService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var carModel = this.service.GetAllCars().ToList();
            var viewModel = new List<ShowAllCarsViewModel>();

            foreach (var car in carModel)
            {
                var currentCar = new ShowAllCarsViewModel()
                {
                    Id = car.Id,
                    Manufacturer = car.Manufacturer,
                    Model = car.Model,
                    RegistrationNumber = car.RegistrationNumber
                };

                viewModel.Add(currentCar);
            }

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Details(Guid id)
        {
            var carModelById = this.service.GetCarById(id);
            var viewModel = new CarDetailsViewModel()
            {
                Manufacturer = carModelById.Manufacturer,
                Model = carModelById.Model,
                TypeOfEngine = carModelById.TypeOfEngine,
                RegistrationNumber = carModelById.RegistrationNumber,
                VINNumber = carModelById.VINNumber,
                CountOfTyres = carModelById.CountOfTyres,
                CountOfDoors = carModelById.CountOfDoors,
                TypeOfCar = carModelById.TypeOfCar,
                YearOfManufactoring = carModelById.YearOfManufacturing,
                ValidUntilAnnualCheckUp = carModelById.ValidUntilAnnualCheckUp,
                ValidUntilVignette = carModelById.ValidUntilVignette,
                ValidUntilInsurance = carModelById.ValidUntilVignette,
                CarOwnerId = carModelById.UserId
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Search(string vinNumber)
        {

            if (string.IsNullOrEmpty(vinNumber))
            {
                return RedirectToAction("InternalServer", "Error", new { area = "Error" });
            }

            var carModel = this.service.GetCarByVinNumber(vinNumber).ToList();
            var viewModel = new List<ShowAllCarsViewModel>();

            foreach (var car in carModel)
            {
                var currentUser = new ShowAllCarsViewModel()
                {
                    Id = car.Id,
                    Manufacturer = car.Manufacturer,
                    Model = car.Model,
                    RegistrationNumber = car.RegistrationNumber
                };

                viewModel.Add(currentUser);
            }

            return View("Index", viewModel);
        }
    }
}