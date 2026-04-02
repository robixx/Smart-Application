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
        public DbSet<UserDetails> UserDetails { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<UserWiseRolePermission> UserWiseRolePermission { get; set; }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Menu>().HasKey(i => i.MenuId);
            modelBuilder.Entity<User>().HasKey(i => i.UserId);          
            modelBuilder.Entity<UserDetails>().HasKey(i => i.Id);          
            modelBuilder.Entity<Role>().HasKey(i => i.Id);          
            modelBuilder.Entity<UserWiseRolePermission>().HasKey(i => i.Id);          
           
            base.OnModelCreating(modelBuilder);
        }
    }
}
