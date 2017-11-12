using CarsSystem.Data.Models;
using System.Collections.Generic;

namespace CarsSystem.Services.Contracts
{
    public interface IFilterService
    {
        IEnumerable<Car> FilterExpiringVignetteCarsInTheNextSevenDays();

        IEnumerable<Car> FilterExpiringVignetteCarsToday();

        IEnumerable<Car> FilterExpiringInsuranceInTheNextSevenDays();

        IEnumerable<Car> FilterExpiringInsuranceToday();

        IEnumerable<Car> FilterExpiringAnnualCheckUpInTheNextSevenDays();

        IEnumerable<Car> FilterExpiringAnnualCheckUpToday();

        IEnumerable<string> GetMailsForCarsVignetteExpirationInTheNextSevenDays();

        IEnumerable<string> GetMailsForCarsVignetteExpirationToday();

        IEnumerable<string> GetMailsForCarsInsuranceExpirationInTheNextSevenDays();

        IEnumerable<string> GetMailsForCarsInsuranceExpirationToday();

        IEnumerable<string> GetMailsForCarsAnnualCheckUpExpirationInTheNextSevenDays();

        IEnumerable<string> GetMailsForCarsAnnualCheckUpToday();

        void SaveChanges();
    }
}
