using CarsSystem.Data;
using CarsSystem.Data.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CarsSystem.WebClient.MVC.App_Start
{
    public class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CarsSystemDbContext, Configuration>());
            CarsSystemDbContext.Create().Database.Initialize(true);
        }
    }
}