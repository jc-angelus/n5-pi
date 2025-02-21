using Microsoft.EntityFrameworkCore;
using N5.Permissions.Domain.Entities;

namespace N5.Permissions.Infrastructure.Persistence
{
    /// <summary>
    /// Developer: Johans Cuellar
    /// Date: 02/19/2025
    /// </summary>
    public class PermissionDbContext : DbContext
    {
        public PermissionDbContext(DbContextOptions<PermissionDbContext> options) : base(options)
        {           
        }
        public DbSet<Permission> Permission { get; set; }        
        public DbSet<PermissionType> PermissionType { get; set; }       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PermissionDbContext).Assembly);            

            modelBuilder.Entity<PermissionType>().HasData(
                new PermissionType { Id = 1, Description = "Permission for marriege" },
                new PermissionType { Id = 2, Description = "Permission for healt"},
                new PermissionType { Id = 3, Description = "Permission for course"}                
            );

            modelBuilder.Entity<Permission>().HasData(
                new Permission { Id = 1, NameEmployee = "Johans", SurnameEmployee = "Cuellar Faraco", PermissionDate = DateTime.Now, PermissionTypeId = 1 }
            );

            base.OnModelCreating(modelBuilder);

        }
    }
}