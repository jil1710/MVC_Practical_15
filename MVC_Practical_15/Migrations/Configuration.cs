namespace MVC_Practical_15.Migrations
{
    using MVC_Practical_15.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVC_Practical_15.DataContext.UserDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "MVC_Practical_15.DataContext.UserDbContext";
        }

        protected override void Seed(MVC_Practical_15.DataContext.UserDbContext context)
        {
            // Initial seeding for implementation or practice purpose

            context.Users.AddOrUpdate(user => user.Id , new Models.User() { Name = "Jil",Email = "Jil@gmail.com",Password="123123123",Role = "Admin"}, new User() { Name ="Jay",Email="Jay@gmail.com", Password = "1212121212",Role= "User"});
            context.SaveChanges();
        }
    }
}
