using CarsSystem.Services.Contracts;
using CarsSystem.WebClient.MVC.Areas.Administration.Models;
using CarsSystem.WebClient.MVC.Areas.Administration.Models.Cars;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CarsSystem.WebClient.MVC.Areas.Administration.Controllers
{
    [Authorize(Roles = ApplicationConstants.AdminRole)]
    public class CarsController : Controller
    {
        private readonly ICarsService service;

        public CarsController(ICarsService service)
        {
            if (service == null)
            {
                throw new NullReferenceException(ApplicationConstants.CarssServiceErrorMessage);
            }

            this.service = service;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var carModel = this.service
                               .GetAllCars()
                               .ToList();
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
            var carModelById = this.service
                                   .GetCarById(id);
            var viewModel = new CarDetailsViewModel()
            {
                Id = carModelById.Id,
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
                ValidUntilInsurance = carModelById.ValidUntilInsurance,
                CarOwnerId = carModelById.UserId
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(string vinNumber)
        {
            if (string.IsNullOrEmpty(vinNumber))
            {
                return RedirectToAction("InternalServer", "Error", new { area = "Error" });
            }

            var carModel = this.service
                               .GetCarByVinNumber(vinNumber)
                               .ToList();
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

            if (viewModel.Count < 1)
            {
                return PartialView("_NoResults", viewModel);
            }

            return PartialView("_AllCars", viewModel);
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var carModelById = this.service
                                   .GetCarById(id);
            var viewModel = new CarViewModel()
            {
                Id = carModelById.Id,
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
                ValidUntilInsurance = carModelById.ValidUntilInsurance,
                CarOwnerId = carModelById.UserId
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CarViewModel car, Guid id)
        {
            var carToUpdate = this.service
                                  .GetCarById(id);
            carToUpdate.Id = car.Id;
            carToUpdate.Manufacturer = car.Manufacturer;
            carToUpdate.Model = car.Model;
            carToUpdate.TypeOfEngine = car.TypeOfEngine;
            carToUpdate.RegistrationNumber = car.RegistrationNumber;
            carToUpdate.VINNumber = car.VINNumber;
            carToUpdate.CountOfTyres = car.CountOfTyres;
            carToUpdate.CountOfDoors = car.CountOfDoors;
            carToUpdate.TypeOfCar = car.TypeOfCar;
            carToUpdate.YearOfManufacturing = car.YearOfManufactoring;
            carToUpdate.ValidUntilAnnualCheckUp = car.ValidUntilAnnualCheckUp;
            carToUpdate.ValidUntilInsurance = car.ValidUntilInsurance;
            carToUpdate.ValidUntilVignette = car.ValidUntilVignette;
            carToUpdate.IsEmailSendedForAnnual = false;
            carToUpdate.IsEmailSendedForInsurance = false;
            carToUpdate.IsEmailSendedForVignette = false;

            this.service.Update(carToUpdate);

            return RedirectToAction("Details", "Cars", new { area = "Administration", id = car.Id });
        }
    }
}