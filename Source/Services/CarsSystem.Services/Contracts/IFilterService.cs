using CarsSystem.Data.Models;
using System.Collections.Generic;

namespace CarsSystem.Services.Contracts
{
    public interface IFilterService
    {
        IEnumerable<Car> FilterExpiringVignetteCars();

        IEnumerable<Car> FilterExpiringInsurance();

        IEnumerable<Car> FilterExpiringAnnualCheckUp();

        IEnumerable<string> GetMailsForCarsVignetteExpiration();

        IEnumerable<string> GetMailsForCarsInsuranceExpiration();

        IEnumerable<string> GetMailsForCarsAnnualCheckUpExpiration();
    }
}
