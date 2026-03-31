using Microsoft.EntityFrameworkCore;
using SmartInventory.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SmartInventory.Infrastructure.DataConnect
{
    public class DatabaseConnection : DbContext
    {
        public DatabaseConnection(DbContextOptions<DatabaseConnection> options)
            : base(options)
        {
        }

        public DbSet<Menu> Menu { get; set; }
        public DbSet<User> User { get; set; }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Menu>().HasKey(i => i.MenuId);
            modelBuilder.Entity<User>().HasKey(i => i.UserId);          
           
            base.OnModelCreating(modelBuilder);
        }
    }
}
