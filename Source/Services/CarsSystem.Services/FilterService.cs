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

        public IEnumerable<Car> FilterExpiringInsuranceInTheNextSevenDays()
        {
            var dateTimeNow = DateTime.Parse(DateTime.Now.ToString("yyyy.MM.dd"));
            return this.carRepo.All()
                               .Where(c => (c.ValidUntilInsurance - dateTimeNow).TotalDays <= 7);
        }

        public IEnumerable<Car> FilterExpiringAnnualCheckUpInTheNextSevenDays()
        {
            var dateTimeNow = DateTime.Parse(DateTime.Now.ToString("yyyy.MM.dd"));
            return this.carRepo.All()
                       .Where(c => (c.ValidUntilAnnualCheckUp - dateTimeNow).TotalDays <= 7);
        }

        public IEnumerable<string> GetMailsForCarsVignetteExpirationInTheNextSevenDays()
        {
            return this.FilterExpiringVignetteCarsInTheNextSevenDays()
                       .Select(c => c.User.Email);
        }

        public IEnumerable<string> GetMailsForCarsInsuranceExpirationInTheNextSevenDays()
        {
            return this.FilterExpiringInsuranceInTheNextSevenDays()
                       .Select(c => c.User.Email);
        }

        public IEnumerable<string> GetMailsForCarsAnnualCheckUpExpirationInTheNextSevenDays()
        {
            return this.FilterExpiringAnnualCheckUpInTheNextSevenDays()
                       .Select(c => c.User.Email);
        }
    }
}
