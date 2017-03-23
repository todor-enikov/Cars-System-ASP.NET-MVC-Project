using CarsSystem.Services.Contracts;
using CarsSystem.WebClient.MVC.Areas.Administration.Models.Filter;
using Common;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CarsSystem.WebClient.MVC.Areas.Administration.Controllers
{
    [Authorize(Roles = ApplicationConstants.AdminRole)]
    public class FilterController : Controller
    {
        private readonly IFilterService filterService;
        private readonly IMailService mailService;

        public FilterController(IFilterService filterService, IMailService mailService)
        {
            this.filterService = filterService;
            this.mailService = mailService;
        }

        [HttpGet]
        [OutputCache(Duration = 60 * 60)]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult FilterByAnnualCheckUp()
        {
            var filterModel = this.filterService
                                  .FilterExpiringAnnualCheckUp()
                                  .ToList();
            var viewModel = new List<FilterViewModel>();

            foreach (var filter in filterModel)
            {
                var currentFilter = new FilterViewModel()
                {
                    Manufacturer = filter.Manufacturer,
                    Model = filter.Model,
                    RegistrationNumber = filter.RegistrationNumber,
                    VINNumber = filter.VINNumber,
                    ExpirationDate = filter.ValidUntilAnnualCheckUp
                };

                viewModel.Add(currentFilter);
            }

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult FilterByAnnualCheckUp(string emailSubjectTextBox, string emailContentBox)
        {
            var emails = this.filterService
                             .GetMailsForCarsAnnualCheckUpExpiration()
                             .ToList();

            this.mailService.SendEmail(emailSubjectTextBox, emailContentBox, emails);

            return RedirectToAction("Index", "Home", new { area = "" });
        }

        [HttpGet]
        public ActionResult FilterByVignette()
        {
            var filterModel = this.filterService
                                  .FilterExpiringVignetteCars()
                                  .ToList();
            var viewModel = new List<FilterViewModel>();

            foreach (var filter in filterModel)
            {
                var currentFilter = new FilterViewModel()
                {
                    Manufacturer = filter.Manufacturer,
                    Model = filter.Model,
                    RegistrationNumber = filter.RegistrationNumber,
                    VINNumber = filter.VINNumber,
                    ExpirationDate = filter.ValidUntilAnnualCheckUp
                };

                viewModel.Add(currentFilter);
            }

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult FilterByVignette(string emailSubjectTextBox, string emailContentBox)
        {
            var emails = this.filterService
                             .GetMailsForCarsVignetteExpiration()
                             .ToList();

            this.mailService.SendEmail(emailSubjectTextBox, emailContentBox, emails);

            return RedirectToAction("Index", "Home", new { area = "" });
        }

        [HttpGet]
        public ActionResult FilterByInsurance()
        {
            var filterModel = this.filterService
                                  .FilterExpiringInsurance()
                                  .ToList();
            var viewModel = new List<FilterViewModel>();

            foreach (var filter in filterModel)
            {
                var currentFilter = new FilterViewModel()
                {
                    Manufacturer = filter.Manufacturer,
                    Model = filter.Model,
                    RegistrationNumber = filter.RegistrationNumber,
                    VINNumber = filter.VINNumber,
                    ExpirationDate = filter.ValidUntilAnnualCheckUp
                };

                viewModel.Add(currentFilter);
            }

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult FilterByInsurance(string emailSubjectTextBox, string emailContentBox)
        {
            var emails = this.filterService
                             .GetMailsForCarsInsuranceExpiration()
                             .ToList();

            this.mailService.SendEmail(emailSubjectTextBox, emailContentBox, emails);

            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}