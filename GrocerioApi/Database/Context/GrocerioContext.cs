using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using GrocerioApi.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace GrocerioApi.Database.Context
{
    public class GrocerioContext : DbContext
    {
        public GrocerioContext(DbContextOptions<GrocerioContext> options)
            : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<User> Users { get; set; }
        public  DbSet<Admin> Admins { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
