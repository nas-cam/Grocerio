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
        public DbSet<Product> Products { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<StoreProducts> StoreProducts { get; set; }
        public DbSet<ShoppingCart> ShoppingCart { get; set; }
        public DbSet<Tracking> Trackings { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<PurchaseLog> PurchaseLogs { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
    }
}
