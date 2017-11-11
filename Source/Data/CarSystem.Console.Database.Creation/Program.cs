using CarsSystem.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSystem.Console.Database.Creation
{
    class Program
    {
        static void Main(string[] args)
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<CarsSystemDbContext, Configuration>());

            var db = new CarsSystemDbContext();
            db.Database.CreateIfNotExists();
        }
    }
}
