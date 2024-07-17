using Microsoft.EntityFrameworkCore;
using MobileMekaniko_Invoice.Models.Entities;

namespace MobileMekaniko_Invoice.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<tblCustomer> tblCustomer { get; set; }
        public DbSet<tblCar> tblCar { get; set; }
        public DbSet<tblCarMake> tblCarMake { get; set; }
        public DbSet<tblCarManufacturer> tblCarManufacturer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // one-to-many tblCustomer - tblCar
            modelBuilder.Entity<tblCustomer>()
                .HasMany(c => c.tblCar)
                .WithOne(ca => ca.tblCustomer)
                .HasForeignKey(ca => ca.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            // many-to-many tblCar - tblCarmake 
            modelBuilder.Entity<tblCarManufacturer>()
                .HasKey(cm => new {cm.CarId, cm.CarMakeId});

            modelBuilder.Entity<tblCarManufacturer>()
                .HasOne(cm => cm.tblCar)
                .WithMany(ca => ca.tblCarManufacturer)
                .HasForeignKey(cm => cm.CarId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<tblCarManufacturer>()
                .HasOne(cm => cm.tblCarMake)
                .WithMany(cmake => cmake.tblCarManufacturer)
                .HasForeignKey(cm => cm.CarMakeId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
