using CarsSystem.Data.Models;
using System.Collections.Generic;

namespace CarsSystem.Services.Contracts
{
    public interface IFilterService
    {
        IEnumerable<Car> FilterExpiringVignetteCarsInTheNextSevenDays();

        IEnumerable<Car> FilterExpiringInsuranceInTheNextSevenDays();

        IEnumerable<Car> FilterExpiringAnnualCheckUpInTheNextSevenDays();

        IEnumerable<string> GetMailsForCarsVignetteExpirationInTheNextSevenDays();

        IEnumerable<string> GetMailsForCarsInsuranceExpirationInTheNextSevenDays();

        IEnumerable<string> GetMailsForCarsAnnualCheckUpExpirationInTheNextSevenDays();
    }
}
