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

            var viewModel = this.LoadModelsInfomationFromTheDatabase(filterModel, "annual");

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

            var cars = this.filterService
                           .FilterExpiringAnnualCheckUpInTheNextSevenDays()
                           .ToList();
            this.UpdateIsEmailSendedForAnnualPropertyAfterSendingEmails(cars);

            return RedirectToAction("Index", "Success", new { area = "Administration" });
        }

        [HttpGet]
        public ActionResult FilterExpiringByAnnualCheckUpToday()
        {
            var filterModel = this.filterService
                                  .FilterExpiringAnnualCheckUpToday()
                                  .ToList();

            var viewModel = this.LoadModelsInfomationFromTheDatabase(filterModel, "annual");

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

            var cars = this.filterService
                           .FilterExpiringAnnualCheckUpToday()
                           .ToList();
            this.UpdateIsEmailSendedForAnnualPropertyAfterSendingEmails(cars);

            return RedirectToAction("Index", "Success", new { area = "Administration" });
        }

        [HttpGet]
        public ActionResult FilterExpiringByVignetteInTheNextSevenDays()
        {
            var filterModel = this.filterService
                                  .FilterExpiringVignetteCarsInTheNextSevenDays()
                                  .ToList();

            var viewModel = this.LoadModelsInfomationFromTheDatabase(filterModel, "vignette");

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

            var cars = this.filterService
                           .FilterExpiringVignetteCarsInTheNextSevenDays()
                           .ToList();
            this.UpdateIsEmailSendedForVignettePropertyAfterSendingEmails(cars);

            return RedirectToAction("Index", "Success", new { area = "Administration" });
        }

        [HttpGet]
        public ActionResult FilterExpiringByVignetteToday()
        {
            var filterModel = this.filterService
                                  .FilterExpiringVignetteCarsToday()
                                  .ToList();

            var viewModel = this.LoadModelsInfomationFromTheDatabase(filterModel, "vignette");

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

            var cars = this.filterService
                           .FilterExpiringVignetteCarsToday()
                           .ToList();
            this.UpdateIsEmailSendedForVignettePropertyAfterSendingEmails(cars);

            return RedirectToAction("Index", "Success", new { area = "Administration" });
        }

        [HttpGet]
        public ActionResult FilterExpiringByInsuranceInTheNextSevenDays()
        {
            var filterModel = this.filterService
                                  .FilterExpiringInsuranceInTheNextSevenDays()
                                  .ToList();

            var viewModel = this.LoadModelsInfomationFromTheDatabase(filterModel, "insurance");

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

            var cars = this.filterService
                           .FilterExpiringInsuranceInTheNextSevenDays()
                           .ToList();
            this.UpdateIsEmailSendedForInsurancePropertyAfterSendingEmails(cars);

            return RedirectToAction("Index", "Success", new { area = "Administration" });
        }

        [HttpGet]
        public ActionResult FilterExpiringByInsuranceToday()
        {
            var filterModel = this.filterService
                                  .FilterExpiringInsuranceToday()
                                  .ToList();

            var viewModel = this.LoadModelsInfomationFromTheDatabase(filterModel, "insurance");

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

            var cars = this.filterService
                           .FilterExpiringInsuranceToday()
                           .ToList();
            this.UpdateIsEmailSendedForInsurancePropertyAfterSendingEmails(cars);

            return RedirectToAction("Index", "Success", new { area = "Administration" });
        }

        #region Help methods for Filter Controller

        public List<FilterViewModel> LoadModelsInfomationFromTheDatabase(List<Car> filterModel, string forTax)
        {
            var viewModel = new List<FilterViewModel>();

            foreach (var filter in filterModel)
            {
                string currentUserNotificationMessage = this.GetCurrentNotificationMessage(filter, forTax);

                var currentFilter = new FilterViewModel()
                {
                    CarId = filter.Id,
                    CustomerId = filter.User.Id,
                    CustomerOfVehicle = filter.User.FirstName + " " + filter.User.LastName,
                    Manufacturer = filter.Manufacturer,
                    Model = filter.Model,
                    RegistrationNumber = filter.RegistrationNumber,
                    VINNumber = filter.VINNumber,
                    ExpirationDate = filter.ValidUntilAnnualCheckUp,
                    UserNotificationMessage = currentUserNotificationMessage,
                };

                viewModel.Add(currentFilter);
            }

            return viewModel;
        }

        public string GetCurrentNotificationMessage(Car filter, string forTax)
        {
            string currentUserNotificationMessage = string.Empty;
            if (forTax == "annual")
            {
                if (filter.IsEmailSendedForAnnual == false)
                    currentUserNotificationMessage = "The user isn't notified for the expiration yet.";
                else
                    currentUserNotificationMessage = "The user is notified for the expiration.";
            }
            else if (forTax == "vignette")
            {
                if (filter.IsEmailSendedForVignette == false)
                    currentUserNotificationMessage = "The user isn't notified for the expiration yet.";
                else
                    currentUserNotificationMessage = "The user is notified for the expiration.";
            }
            else if (forTax == "insurance")
            {
                if (filter.IsEmailSendedForInsurance == false)
                    currentUserNotificationMessage = "The user isn't notified for the expiration yet.";
                else
                    currentUserNotificationMessage = "The user is notified for the expiration.";
            }

            return currentUserNotificationMessage;
        }

        public void UpdateIsEmailSendedForAnnualPropertyAfterSendingEmails(List<Car> filteredCars)
        {
            foreach (var car in filteredCars)
            {
                car.IsEmailSendedForAnnual = true;
            }

            this.filterService.SaveChanges();
        }

        public void UpdateIsEmailSendedForVignettePropertyAfterSendingEmails(List<Car> filteredCars)
        {
            foreach (var car in filteredCars)
            {
                car.IsEmailSendedForVignette = true;
            }

            this.filterService.SaveChanges();
        }

        public void UpdateIsEmailSendedForInsurancePropertyAfterSendingEmails(List<Car> filteredCars)
        {
            foreach (var car in filteredCars)
            {
                car.IsEmailSendedForInsurance = true;
            }

            this.filterService.SaveChanges();
        }

        #endregion
    }
}