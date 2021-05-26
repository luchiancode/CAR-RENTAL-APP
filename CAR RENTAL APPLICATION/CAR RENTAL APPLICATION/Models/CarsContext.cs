using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CAR_RENTAL_APPLICATION.Models;

namespace CAR_RENTAL_APPLICATION.Models
{
    public class CarsContext : DbContext
    {
        public CarsContext()
        {
        }

        public CarsContext(DbContextOptions<CarsContext> options)
            : base(options)
        { }
        
        public DbSet<Car> Cars { get; set; }

        public DbSet<CarRecord> CarRecords { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<mailingList> mailingListlogs { get; set; }

        public DbSet<contact> contactlogs { get; set; }

        public DbSet<newsletter> newsletterlogs { get; set; }

        public DbSet<CAR_RENTAL_APPLICATION.Models.User> User { get; set; }
    }
}
