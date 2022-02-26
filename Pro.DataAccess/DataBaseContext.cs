using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pro.DataAccess.Mapping;
using Pro.Entities;
using Pro.Entities.identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pro.DataAccess
{
    public class DataBaseContext : IdentityDbContext<User,Role,int,UserClaim,UserRole,IdentityUserLogin<int>,RoleClaim,IdentityUserToken<int>>
    {
        public DataBaseContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
          
            base.OnModelCreating(builder);
            builder.AddCustomIdentityMappings();
            builder.Entity<User>().Property(b => b.RegisterDateTime).HasDefaultValueSql("CONVERT(DATETIME, CONVERT(VARCHAR(20),GetDate(), 120))");
              builder.Entity<User>().Property(b => b.IsActive).HasDefaultValueSql("1");

            
        }

        public virtual DbSet<Owner> Owners { get; set; }
        public virtual DbSet<EEquipmentH> EEquipmentHs { get; set; }
        public virtual DbSet<EEquipmentCom> EEquipmentComs { get; set; }
        public virtual DbSet<PowerMeter> PowerMeters { get; set; }
        public virtual DbSet<Resident> Residents { get; set; }
        public virtual DbSet<OwnerLanguage> OwnerLanguages { get; set; }
        public virtual DbSet<OwnerTypeWarming> OwnerTypeWarmings { get; set; }

        



        public virtual DbSet<Rent> Rents { get; set; }
        public virtual DbSet<RentEEquipmentH> RentEEquipmentHs { get; set; }
        public virtual DbSet<RentEquipmentCom> RentEquipmentComs { get; set; }
        public virtual DbSet<RentPowerMeter> RentPowerMeters { get; set; }
        public virtual DbSet<RentResident> RentResidents { get; set; }
        public virtual DbSet<RentLanguage> RentLanguages { get; set; }
        public virtual DbSet<RentTypeWarming> RentTypeWarmings { get; set; }





    }
}
