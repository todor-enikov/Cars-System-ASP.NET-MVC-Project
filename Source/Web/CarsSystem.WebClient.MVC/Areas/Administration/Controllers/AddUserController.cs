using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarsSystem.WebClient.MVC.Areas.Administration.Controllers
{
    public class AddUserController : Controller
    {
        // GET: Administration/AddUser
        public ActionResult AddUser()
        {
            return View();
        }
    }
}