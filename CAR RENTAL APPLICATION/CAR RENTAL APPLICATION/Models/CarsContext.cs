using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAR_RENTAL_APPLICATION.Models
{
    public class CarsContext : DbContext
    {
        public CarsContext(DbContextOptions<CarsContext> options)
            : base(options)
        { }
        public DbSet<Car> Cars { get; set; }
        //public DbSet<CarOwner> CarOwners { get; set; }
        public DbSet<CarRecord> CarRecords { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>()
                .HasKey(o => new { o.UserId, o.TransactionId });
            //modelBuilder.Entity<Route_Stop>()
            //.HasKey(o => new { o.StopId, o.RouteId });
        }*/


    }
}
