
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace CapSoft.API
{
    public class UserLogin : IdentityUserLogin<int> { }
    public class UserRole : IdentityUserRole<int> { }
    public class UserClaim : IdentityUserClaim<int> { }

    public class Role : IdentityRole<int, UserRole>
    {
        public string UserTypeCode { get; set; }
        public string LongName { get; set; }
        public string RoleDesc { get; set; }
        public bool IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public Role() { }
        public Role(string name) { Name = name; }
    }

    public class UserStore : UserStore<ApplicationUser, Role, int,
        UserLogin, UserRole, UserClaim>
    {
        public UserStore(ApplicationDbContext context)
            : base(context)
        {
        }
    }

    public class RoleStore : RoleStore<Role, int, UserRole>
    {
        public RoleStore(ApplicationDbContext context)
            : base(context)
        {
        }
    }

    public class ApplicationUser : IdentityUser<int, UserLogin, UserRole, UserClaim>
    {

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser, int> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType





            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public string UserTypeCode { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public int CityId { get; set; }
        public int CountryId { get; set; }
        public string ZipCode { get; set; }
        public string Mobile { get; set; }
        public string AltMobile { get; set; }

        public int? Nationality { get; set; }
        public string Gender { get; set; }

        public bool IsSA { get; set; }
        public bool IsActive { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DOB { get; set; }
        public string DisplayName { get; set; }
        public string City { get; set; }
        
        public string State { get; set; }
        public string ImgURL { get; set; }
      
    }


    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, Role, int, UserLogin, UserRole, UserClaim>
    {
        public ApplicationDbContext()
           : base("DBModel")//, throwIfV1Schema: false)
        {

        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<User>().ToTable("Users");
            //modelBuilder.Entity<IdentityUserRole>().ToTable("UserRole");
            //modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogin");
            //modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaim");
            //modelBuilder.Entity<IdentityRole>().ToTable("Roles");


            modelBuilder.Entity<ApplicationUser>().ToTable("Users");
            modelBuilder.Entity<UserRole>().ToTable("UserRole");
            modelBuilder.Entity<UserLogin>().ToTable("UserLogin");
            modelBuilder.Entity<UserClaim>().ToTable("UserClaim");
            modelBuilder.Entity<Role>().ToTable("Roles");

        }
    }



    //public class ApplicationUser : IdentityUser
    //{
    //    public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
    //    {
    //        // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
    //        var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
    //        // Add custom user claims here
    //        return userIdentity;
    //    }
    //}

    //public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    //{
    //    public ApplicationDbContext()
    //        : base("DefaultConnection", throwIfV1Schema: false)
    //    {
    //    }

    //    public static ApplicationDbContext Create()
    //    {
    //        return new ApplicationDbContext();
    //    }
    //}
}