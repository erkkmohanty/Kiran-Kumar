namespace Accounts_Management_With_ASP.NET_Identity.Migrations
{
    using Infrastructure;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Accounts_Management_With_ASP.NET_Identity.Infrastructure.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));

            var user = new ApplicationUser()
            {
                UserName = "kirankumar",
                Email = "kiran.mohanty@commdel.net",
                EmailConfirmed = true,
                FirstName = "Kiran",
                LastName = "Mohanty",
                Level = 1,
                JoinDate = DateTime.Now.AddYears(-3),
                MiddleName="Kumar"
            };

            manager.Create(user, "MySuperP@ssword!");
        }
    }
}
