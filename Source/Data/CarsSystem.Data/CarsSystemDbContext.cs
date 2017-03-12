using CarsSystem.Data.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace CarsSystem.Data
{
    public class CarsSystemDbContext : IdentityDbContext<User>, ICarsSystemDbContext
    {
        public CarsSystemDbContext()
            : base("CarsSystem")
        {

        }

        public virtual IDbSet<Car> Cars { get; set; }

        public static CarsSystemDbContext Create()
        {
            return new CarsSystemDbContext();
        }
    }
}
