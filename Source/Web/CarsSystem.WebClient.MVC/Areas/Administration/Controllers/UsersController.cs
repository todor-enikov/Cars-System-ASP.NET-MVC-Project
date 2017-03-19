using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarsSystem.WebClient.MVC.Areas.Administration.Controllers
{
    public class UsersController : Controller
    {
        // GET: Administration/AllUsers
        public ActionResult Index()
        {
            return View();
        }
    }
}