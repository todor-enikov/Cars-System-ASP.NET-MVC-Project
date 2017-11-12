using CarsSystem.Data.Models;
using CarsSystem.Data.Repositories;
using CarsSystem.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarsSystem.Services
{
    public class FilterService : IFilterService
    {
        private readonly IEfGenericRepository<Car> carRepo;

        public FilterService(IEfGenericRepository<Car> carRepo)
        {
            if (carRepo == null)
            {
                throw new ArgumentException("The car repo should not be null!");
            }

            this.carRepo = carRepo;
        }

        public IEnumerable<Car> FilterExpiringVignetteCarsInTheNextSevenDays()
        {
            var dateTimeNow = DateTime.Parse(DateTime.Now.ToString("yyyy.MM.dd"));
            return this.carRepo.All()
                               .Where(c => (c.ValidUntilVignette - dateTimeNow).TotalDays <= 7);
        }

        public IEnumerable<Car> FilterExpiringVignetteCarsToday()
        {
            var dateTimeNow = DateTime.Parse(DateTime.Now.ToString("yyyy.MM.dd"));
            return this.carRepo.All()
                               .Where(c => (c.ValidUntilVignette - dateTimeNow).TotalDays == 0);
        }

        public IEnumerable<Car> FilterExpiringInsuranceInTheNextSevenDays()
        {
            var dateTimeNow = DateTime.Parse(DateTime.Now.ToString("yyyy.MM.dd"));
            return this.carRepo.All()
                               .Where(c => (c.ValidUntilInsurance - dateTimeNow).TotalDays <= 7);
        }

        public IEnumerable<Car> FilterExpiringInsuranceToday()
        {
            var dateTimeNow = DateTime.Parse(DateTime.Now.ToString("yyyy.MM.dd"));
            return this.carRepo.All()
                               .Where(c => (c.ValidUntilInsurance - dateTimeNow).TotalDays == 0);
        }

        public IEnumerable<Car> FilterExpiringAnnualCheckUpInTheNextSevenDays()
        {
            var dateTimeNow = DateTime.Parse(DateTime.Now.ToString("yyyy.MM.dd"));
            return this.carRepo.All()
                       .Where(c => (c.ValidUntilAnnualCheckUp - dateTimeNow).TotalDays <= 7);
        }

        public IEnumerable<Car> FilterExpiringAnnualCheckUpToday()
        {
            var dateTimeNow = DateTime.Parse(DateTime.Now.ToString("yyyy.MM.dd"));
            return this.carRepo.All()
                       .Where(c => (c.ValidUntilAnnualCheckUp - dateTimeNow).TotalDays == 0);
        }

        public IEnumerable<string> GetMailsForCarsVignetteExpirationInTheNextSevenDays()
        {
            return this.FilterExpiringVignetteCarsInTheNextSevenDays()
                       .Select(c => c.User.Email);
        }

        public IEnumerable<string> GetMailsForCarsVignetteExpirationToday()
        {
            return this.FilterExpiringVignetteCarsToday()
                       .Select(c => c.User.Email);
        }

        public IEnumerable<string> GetMailsForCarsInsuranceExpirationInTheNextSevenDays()
        {
            return this.FilterExpiringInsuranceInTheNextSevenDays()
                       .Select(c => c.User.Email);
        }

        public IEnumerable<string> GetMailsForCarsInsuranceExpirationToday()
        {
            return this.FilterExpiringInsuranceToday()
                       .Select(c => c.User.Email);
        }

        public IEnumerable<string> GetMailsForCarsAnnualCheckUpExpirationInTheNextSevenDays()
        {
            return this.FilterExpiringAnnualCheckUpInTheNextSevenDays()
                       .Select(c => c.User.Email);
        }

        public IEnumerable<string> GetMailsForCarsAnnualCheckUpToday()
        {
            return this.FilterExpiringAnnualCheckUpToday()
                       .Select(c => c.User.Email);
        }

        public void SaveChanges()
        {
            this.carRepo.SaveChanges();
        }
    }
}
