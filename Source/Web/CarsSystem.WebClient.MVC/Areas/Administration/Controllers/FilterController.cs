using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarsSystem.WebClient.MVC.Areas.Administration.Controllers
{
    public class FilterController : Controller
    {
        // GET: Administration/Filter
        public ActionResult Index()
        {
            return View();
        }

        // GET: Administration/FilterByAnnualCheckUp
        public ActionResult FilterByAnnualCheckUp()
        {
            return View();
        }

        // GET: Administration/FilterByVignette
        public ActionResult FilterByVignette()
        {
            return View();
        }

        // GET: Administration/FilterByInsurance
        public ActionResult FilterByInsurance()
        {
            return View();
        }
    }
}