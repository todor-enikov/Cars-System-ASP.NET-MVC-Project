﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarsSystem.WebClient.MVC.Areas.Administration.Controllers
{
    public class AllCarsController : Controller
    {
        // GET: Administration/AllCars
        public ActionResult Index()
        {
            return View();
        }
    }
}