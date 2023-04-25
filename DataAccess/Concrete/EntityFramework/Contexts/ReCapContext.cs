using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;

namespace DataAccess.Concrete
{
    public class ReCapContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LPTNET2116\SQLEXPRESS;Database=ReCap;Trusted_Connection=True;");
        }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Color>  Colors { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Rental> Rentals { get; set; }
        public virtual DbSet<CarImage> CarImages { get; set; }
        public virtual DbSet<OperationClaim> OperationClaims { get; set; }
        public virtual DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<CreditCard> CreditCards { get; set; }
        public virtual DbSet<MailSubscribe> MailSubscribes { get; set; }
        public virtual DbSet<Translation> Translations { get; set; }
        public virtual DbSet<Page> Pages { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<CarType> CarTypes { get; set; }
        public virtual DbSet<FuelType> FuelTypes { get; set; }
        public virtual DbSet<GearType> GearTypes { get; set; }
        public virtual DbSet<InsuranceType> InsuranceTypes { get; set; }






    }
}
