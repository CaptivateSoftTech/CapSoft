using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System;
using System.Data.Entity.Core.Objects;
using CapSoft.Core.Models;

namespace CapSoft.Core
{
    public class DBModel : DbContext
    {

        public DBModel() : base("DBModel")
        {

            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public virtual void Commit() 
        {
            base.SaveChanges();
        }
      

        public virtual DbSet<UserClaim> UserClaims { get; set; }
        public virtual DbSet<UserLogin> UserLogins { get; set; }      
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<User> Users { get; set; }     
        public virtual DbSet<Roles> Roles { get; set; }     

     
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


        }
    }
}
