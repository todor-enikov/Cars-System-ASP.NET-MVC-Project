using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarsSystem.WebClient.MVC.Areas.Error.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult NotFound()
        {
            return View();
        }

        public ActionResult Forbidden()
        {
            return View();
        }

        public ActionResult InternalServerError()
        {
            return View();
        }

        public ActionResult UnAuthorized()
        {
            return View();
        }

        public ActionResult BadRequest()
        {
            return View();
        }
    }
}