using System.Web.Mvc;

namespace CarsSystem.WebClient.MVC.Areas.Administration.Controllers
{
    public class SuccessController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string submit)
        {
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}