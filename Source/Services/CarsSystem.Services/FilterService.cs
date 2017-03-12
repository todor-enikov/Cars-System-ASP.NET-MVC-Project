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
        private readonly IRepository<Car> carRepo;

        public FilterService(IRepository<Car> carRepo)
        {
            if (carRepo == null)
            {
                throw new ArgumentException("The car repo should not be null!");
            }

            this.carRepo = carRepo;
        }

        public IEnumerable<Car> FilterExpiringVignetteCars()
        {
            var dateTimeNow = DateTime.Parse(DateTime.Now.ToString("yyyy.MM.dd"));
            return this.carRepo.All()
                               .Where(c => (c.ValidUntilVignette - dateTimeNow).TotalDays <= 7);
        }

        public IEnumerable<Car> FilterExpiringInsurance()
        {
            var dateTimeNow = DateTime.Parse(DateTime.Now.ToString("yyyy.MM.dd"));
            return this.carRepo.All()
                               .Where(c => (c.ValidUntilInsurance - dateTimeNow).TotalDays <= 7);
        }

        public IEnumerable<Car> FilterExpiringAnnualCheckUp()
        {
            var dateTimeNow = DateTime.Parse(DateTime.Now.ToString("yyyy.MM.dd"));
            return this.carRepo.All()
                       .Where(c => (c.ValidUntilAnnualCheckUp - dateTimeNow).TotalDays <= 7);
        }

        public IEnumerable<string> GetMailsForCarsVignetteExpiration()
        {
            return this.FilterExpiringVignetteCars()
                       .Select(c => c.User.Email);
        }

        public IEnumerable<string> GetMailsForCarsInsuranceExpiration()
        {
            return this.FilterExpiringInsurance()
                       .Select(c => c.User.Email);
        }

        public IEnumerable<string> GetMailsForCarsAnnualCheckUpExpiration()
        {
            return this.FilterExpiringAnnualCheckUp()
                       .Select(c => c.User.Email);
        }
    }
}
