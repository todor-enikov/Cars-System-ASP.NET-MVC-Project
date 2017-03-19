using CarsSystem.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace CarsSystem.WebClient.MVC.Areas.Administration.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarsService service;

        public CarsController(ICarsService service)
        {
            this.service = service;
        }

        // GET: Administration/Cars
        public ActionResult Index()
        {
            var carModel = this.service.GetAllCars().ToList();

            return View(carModel);
        }
    }
}