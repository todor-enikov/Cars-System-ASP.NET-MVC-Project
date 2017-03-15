using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarsSystem.WebClient.MVC.Areas.Error.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error/Error
        public ActionResult Index()
        {
            return View();
        }
    }
}