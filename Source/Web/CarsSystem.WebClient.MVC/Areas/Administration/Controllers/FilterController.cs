using CarsSystem.Data.Models;
using CarsSystem.Services.Contracts;
using CarsSystem.WebClient.MVC.Areas.Administration.Models.Filter;
using Common;
using System;
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
            if (filterService == null)
            {
                throw new NullReferenceException(ApplicationConstants.FilterServiceErrorMessage);
            }

            if (mailService == null)
            {
                throw new NullReferenceException(ApplicationConstants.MailServiceErrorMessage);
            }

            this.filterService = filterService;
            this.mailService = mailService;
        }

        [HttpGet]
        //[OutputCache(Duration = 60 * 60)]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult FilterExpiringByAnnualCheckUpInTheNextSevenDays()
        {
            var filterModel = this.filterService
                                  .FilterExpiringAnnualCheckUpInTheNextSevenDays()
                                  .ToList();

            var viewModel = this.LoadModelsInfomationFromTheDatabase(filterModel);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FilterExpiringByAnnualCheckUpInTheNextSevenDays(string emailSubjectTextBox, string emailContentBox)
        {
            var emails = this.filterService
                             .GetMailsForCarsAnnualCheckUpExpirationInTheNextSevenDays()
                             .ToList();

            this.mailService.SendEmail(emailSubjectTextBox, emailContentBox, emails);

            return RedirectToAction("Index", "Success", new { area = "Administration" });
        }

        [HttpGet]
        public ActionResult FilterExpiringByAnnualCheckUpToday()
        {
            var filterModel = this.filterService
                                  .FilterExpiringAnnualCheckUpToday()
                                  .ToList();

            var viewModel = this.LoadModelsInfomationFromTheDatabase(filterModel);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FilterExpiringByAnnualCheckUpToday(string emailSubjectTextBox, string emailContentBox)
        {
            var emails = this.filterService
                             .GetMailsForCarsAnnualCheckUpToday()
                             .ToList();

            this.mailService.SendEmail(emailSubjectTextBox, emailContentBox, emails);

            return RedirectToAction("Index", "Success", new { area = "Administration" });
        }

        [HttpGet]
        public ActionResult FilterExpiringByVignetteInTheNextSevenDays()
        {
            var filterModel = this.filterService
                                  .FilterExpiringVignetteCarsInTheNextSevenDays()
                                  .ToList();

            var viewModel = this.LoadModelsInfomationFromTheDatabase(filterModel);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FilterExpiringByVignetteInTheNextSevenDays(string emailSubjectTextBox, string emailContentBox)
        {
            var emails = this.filterService
                             .GetMailsForCarsVignetteExpirationInTheNextSevenDays()
                             .ToList();

            this.mailService.SendEmail(emailSubjectTextBox, emailContentBox, emails);

            return RedirectToAction("Index", "Success", new { area = "Administration" });
        }

        [HttpGet]
        public ActionResult FilterExpiringByVignetteToday()
        {
            var filterModel = this.filterService
                                  .FilterExpiringVignetteCarsToday()
                                  .ToList();

            var viewModel = this.LoadModelsInfomationFromTheDatabase(filterModel);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FilterExpiringByVignetteToday(string emailSubjectTextBox, string emailContentBox)
        {
            var emails = this.filterService
                             .GetMailsForCarsVignetteExpirationToday()
                             .ToList();

            this.mailService.SendEmail(emailSubjectTextBox, emailContentBox, emails);

            return RedirectToAction("Index", "Success", new { area = "Administration" });
        }

        [HttpGet]
        public ActionResult FilterExpiringByInsuranceInTheNextSevenDays()
        {
            var filterModel = this.filterService
                                  .FilterExpiringInsuranceInTheNextSevenDays()
                                  .ToList();

            var viewModel = this.LoadModelsInfomationFromTheDatabase(filterModel);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FilterExpiringByInsuranceInTheNextSevenDays(string emailSubjectTextBox, string emailContentBox)
        {
            var emails = this.filterService
                             .GetMailsForCarsInsuranceExpirationInTheNextSevenDays()
                             .ToList();

            this.mailService.SendEmail(emailSubjectTextBox, emailContentBox, emails);

            return RedirectToAction("Index", "Success", new { area = "Administration" });
        }

        [HttpGet]
        public ActionResult FilterExpiringByInsuranceToday()
        {
            var filterModel = this.filterService
                                  .FilterExpiringInsuranceToday()
                                  .ToList();

            var viewModel = this.LoadModelsInfomationFromTheDatabase(filterModel);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FilterExpiringByInsuranceToday(string emailSubjectTextBox, string emailContentBox)
        {
            var emails = this.filterService
                             .GetMailsForCarsInsuranceExpirationToday()
                             .ToList();

            this.mailService.SendEmail(emailSubjectTextBox, emailContentBox, emails);

            return RedirectToAction("Index", "Success", new { area = "Administration" });
        }

        #region Loading information for filter view model from the database

        public List<FilterViewModel> LoadModelsInfomationFromTheDatabase(List<Car> filterModel)
        {
            var viewModel = new List<FilterViewModel>();

            foreach (var filter in filterModel)
            {
                string currentUserNotificationMessage = string.Empty;
                if (filter.User.IsEmailSended == false)
                    currentUserNotificationMessage = "The user isn't notified for the expiration yet.";
                else
                    currentUserNotificationMessage = "The user is notified for the expiration.";

                var currentFilter = new FilterViewModel()
                {
                    OwnerOfVehicle = filter.User.FirstName + " " + filter.User.LastName,
                    Manufacturer = filter.Manufacturer,
                    Model = filter.Model,
                    RegistrationNumber = filter.RegistrationNumber,
                    VINNumber = filter.VINNumber,
                    ExpirationDate = filter.ValidUntilAnnualCheckUp,
                    UserNotificationMessage = currentUserNotificationMessage
                };

                viewModel.Add(currentFilter);
            }

            return viewModel;
        }

        #endregion
    }
}