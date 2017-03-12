namespace CarsSystem.Data.Migrations
{
    using Common;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<CarsSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(CarsSystemDbContext context)
        {
            this.SeedRoles(context);
            this.SeedAdmin(context);
        }

        private void SeedRoles(CarsSystemDbContext context)
        {
            if (!context.Roles.Any())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                var adminRole = new IdentityRole { Name = ApplicationConstants.AdminRole };
                roleManager.Create(adminRole);

                var userRole = new IdentityRole { Name = ApplicationConstants.UserRole };
                roleManager.Create(userRole);

                context.SaveChanges();
            }
        }

        private void SeedAdmin(CarsSystemDbContext context)
        {
            if (!context.Users.Any())
            {
                var userManager = new UserManager<User>(new UserStore<User>(context));

                var defaultAdmin = new User()
                {
                    FirstName = "Admin",
                    SecondName = "Admin",
                    LastName = "Admin",
                    UserName = "Admin",
                    EGN = 1111111,
                    NumberOfIdCard = 1111111,
                    DateOfIssue = DateTime.Now,
                    City = "No where",
                    PhoneNumber = "1111111",
                    Email="Admin@abv.bg"
                };

                userManager.Create(defaultAdmin, "123456");
                userManager.AddToRole(defaultAdmin.Id, ApplicationConstants.AdminRole);
                context.SaveChanges();
            }
        }
    }
}
