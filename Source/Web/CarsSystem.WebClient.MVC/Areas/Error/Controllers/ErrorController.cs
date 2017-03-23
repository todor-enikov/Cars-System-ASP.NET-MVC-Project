using System.Web.Mvc;

namespace CarsSystem.WebClient.MVC.Areas.Error.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult NotFound()
        {
            return View("NotFound");
        }

        public ActionResult Forbidden()
        {
            return View("Forbidden");
        }

        public ActionResult InternalServer()
        {
            return View("InternalServer");
        }

        public ActionResult UnAuthorized()
        {
            return View("UnAuthorized");
        }

        public ActionResult BadRequest()
        {
            return View("BadRequest");
        }
    }
}