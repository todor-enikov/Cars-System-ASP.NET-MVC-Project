﻿using CarsSystem.Services.Contracts;
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
        public ActionResult FilterByAnnualCheckUpInTheNextSevenDays()
        {
            var filterModel = this.filterService
                                  .FilterExpiringAnnualCheckUpInTheNextSevenDays()
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
        [ValidateAntiForgeryToken]
        public ActionResult FilterByAnnualCheckUpInTheNextSevenDays(string emailSubjectTextBox, string emailContentBox)
        {
            var emails = this.filterService
                             .GetMailsForCarsAnnualCheckUpExpirationInTheNextSevenDays()
                             .ToList();

            this.mailService.SendEmail(emailSubjectTextBox, emailContentBox, emails);

            return RedirectToAction("Index", "Success", new { area = "Administration" });
        }

        [HttpGet]
        public ActionResult FilterByVignetteInTheNextSevenDays()
        {
            var filterModel = this.filterService
                                  .FilterExpiringVignetteCarsInTheNextSevenDays()
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
        [ValidateAntiForgeryToken]
        public ActionResult FilterByVignetteInTheNextSevenDays(string emailSubjectTextBox, string emailContentBox)
        {
            var emails = this.filterService
                             .GetMailsForCarsVignetteExpirationInTheNextSevenDays()
                             .ToList();

            this.mailService.SendEmail(emailSubjectTextBox, emailContentBox, emails);

            return RedirectToAction("Index", "Success", new { area = "Administration" });
        }

        [HttpGet]
        public ActionResult FilterByInsuranceInTheNextSevenDays()
        {
            var filterModel = this.filterService
                                  .FilterExpiringInsuranceInTheNextSevenDays()
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
        [ValidateAntiForgeryToken]
        public ActionResult FilterByInsuranceInTheNextSevenDays(string emailSubjectTextBox, string emailContentBox)
        {
            var emails = this.filterService
                             .GetMailsForCarsInsuranceExpirationInTheNextSevenDays()
                             .ToList();

            this.mailService.SendEmail(emailSubjectTextBox, emailContentBox, emails);

            return RedirectToAction("Index", "Success", new { area = "Administration" });
        }
    }
}