using System;
using dal.models;
using Microsoft.EntityFrameworkCore;

namespace dal 
{

        public class UserContext : DbContext 
        {
            public UserContext (DbContextOptions options) : base(options){}

            protected override void OnConfiguring(DbContextOptionsBuilder builder)
            {
                base.OnConfiguring(builder);

            }
            public DbSet<User> Pets {get;set;}
            public DbSet<Role> role {get;set;}
            public DbSet<Address> address {get;set;}
            
        }
}