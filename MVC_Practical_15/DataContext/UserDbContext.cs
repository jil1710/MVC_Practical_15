using MVC_Practical_15.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_Practical_15.DataContext
{
    public class UserDbContext : DbContext
    {
        public UserDbContext() : base("name=AUTH")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<UserDbContext>());
        }

        public DbSet<User> Users { get; set; }
    }
}