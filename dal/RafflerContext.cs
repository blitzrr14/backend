using System;
using dal.models;
using Microsoft.EntityFrameworkCore;


namespace dal 
{

        public class RafflerContext : DbContext 
        {
            public RafflerContext (DbContextOptions options) : base(options){}

            protected override void OnConfiguring(DbContextOptionsBuilder builder)
            {
                base.OnConfiguring(builder);
        
            }
            // protected override void OnModelCreating(ModelBuilder modelBuilder)
            // {

            //     // modelBuilder.Entity<UserRole>()
            //     // .HasKey(t => new { t.UserID, t.RoleID });

            //     // modelBuilder.Entity<UserRole>()
            //     // .HasOne(x => x.User)
            //     // .WithMany(x=> x.UserRoles)
            //     // .HasForeignKey(x=> x.UserID);

            //     // modelBuilder.Entity<UserRole>()
            //     // .HasOne(x => x.Role)
            //     // .WithMany(x=> x.UserRoles)
            //     // .HasForeignKey(x=> x.RoleID);

            //     // modelBuilder.Entity<SysUser>()
            //     //     .HasMany(x => x.Roles);
                

            // }

            public DbSet<SysUser> Users {get;set;}
            public DbSet<Balance> Balance {get;set;}
            public DbSet<Role> Roles {get;set;}
            public DbSet<Address> Address {get;set;}
             public DbSet<Person> Persons {get;set;}
            public DbSet<Raffle> Raffles {get;set;}
            public DbSet<RaffleEntry> RaffleEntries {get;set;}
            public DbSet<RaffleType> RaffleTypes {get;set;}
            public DbSet<Transaction> Transactions {get;set;}
            public DbSet<TransType> TransTypes {get;set;}
            public DbSet<UserRole> UserRoles {get;set;}
            
        }
}