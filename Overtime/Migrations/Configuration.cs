using System;
using System.Data.Entity.Migrations;
using Overtime.Models;

namespace Overtime.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<OvertimeDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(OvertimeDbContext context)
        {
            var user = new User();
            user.Id = 1;
            user.Name = "admin";
            user.Passwordhash = user.SetPassword("admin");
            user.CreatedBy = "admin";
            user.CreatedTime = DateTime.UtcNow.AddHours(2);
            user.Roles = new[]
            {
                new Role
                {
                    Id = 1,
                    Name = "admin",
                    CreatedBy = "admin",
                    CreatedTime = DateTime.UtcNow.AddHours(2)
                }
                ,
                new Role
                {
                    Id = 2,
                    Name = "moderator",
                    CreatedBy = "admin",
                    CreatedTime = DateTime.UtcNow.AddHours(2)
                }
                ,
                new Role
                {
                    Id = 3,
                    Name = "Manager",
                    CreatedBy = "admin",
                    CreatedTime = DateTime.UtcNow.AddHours(2)
                }
                ,
                new Role
                {
                    Id = 4,
                    Name = "poweruser",
                    CreatedBy = "admin",
                    CreatedTime = DateTime.UtcNow.AddHours(2)
                }
                ,
                new Role
                {
                    Id = 5,
                    Name = "user",
                    CreatedBy = "admin",
                    CreatedTime = DateTime.UtcNow.AddHours(2)
                }
            };

            //Create Default Admin
            context.Users.AddOrUpdate(t => t.Id, user
                );
        }
    }
}