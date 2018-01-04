using CarsSystem.Data;
using CarsSystem.Data.Models;
using CarsSystem.Data.Repositories;
using CarsSystem.Services;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarsSystemConsoleApp
{
    // This console application is created  for the automate sending of e-mails via Task Scheduler.
    // It sends e-mails to the users which annual check up, insurance or vignette tax expires in the next seven days.
    public class Startup
    {
        public static void Main()
        {
            try
            {
                FilterService filterService = new FilterService(new EfGenericRepository<Car>(new CarsSystemDbContext()));
                MailService mailService = new MailService();

                SendAutomationEmailToAllUsersWithExpiringOfAnnualCheckUp(filterService, mailService);
                SendAutomationEmailToAllUsersWithExpiringOfInsurance(filterService, mailService);
                SendAutomationEmailToAllUsersWithExpiringOfVignette(filterService, mailService);
            }
            catch (Exception message)
            {
                Console.WriteLine(message);
            }
        }

        public static void SendAutomationEmailToAllUsersWithExpiringOfAnnualCheckUp(FilterService filterService, MailService mailService)
        {
            List<string> emailsForAnnualCheckUp = filterService.GetMailsForCarsAnnualCheckUpToday().ToList();
            mailService.SendEmail(ApplicationConstants.SubjectExpiringAnnualCheckUp, ApplicationConstants.ContentExpiringAnnualCheckUp, emailsForAnnualCheckUp);

            List<Car> cars = filterService.FilterExpiringAnnualCheckUpToday().ToList();

            foreach (var car in cars)
            {
                car.IsEmailSendedForAnnual = true;
            }

            filterService.SaveChanges();

            Console.WriteLine(ApplicationConstants.SuccessOfAutomationSendingOnEmailsForAnnualCheckUp);
        }

        public static void SendAutomationEmailToAllUsersWithExpiringOfInsurance(FilterService filterService, MailService mailService)
        {
            List<string> emailsForInsurance = filterService.GetMailsForCarsInsuranceExpirationToday().ToList();
            mailService.SendEmail(ApplicationConstants.SubjectExpiringInsurance, ApplicationConstants.ContentExpiringInsurance, emailsForInsurance);

            List<Car> cars = filterService.FilterExpiringInsuranceToday().ToList();

            foreach (var car in cars)
            {
                car.IsEmailSendedForInsurance = true;
            }

            filterService.SaveChanges();

            Console.WriteLine(ApplicationConstants.SuccessOfAutomationSendingOnEmailsForInsurance);
        }

        public static void SendAutomationEmailToAllUsersWithExpiringOfVignette(FilterService filterService, MailService mailService)
        {
            List<string> emailsForVignette = filterService.GetMailsForCarsVignetteExpirationToday().ToList();
            mailService.SendEmail(ApplicationConstants.SubjectExpiringVignette, ApplicationConstants.ContentExpiringVignette, emailsForVignette);

            List<Car> cars = filterService.FilterExpiringVignetteCarsToday().ToList();

            foreach (var car in cars)
            {
                car.IsEmailSendedForVignette = true;
            }

            filterService.SaveChanges();

            Console.WriteLine(ApplicationConstants.SuccessOfAutomationSendingOnEmailsForVignette);
        }
    }
}
