namespace CapSoft.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {

        public User()
        {      
            UserLogins = new HashSet<UserLogin>();          
            Roles = new HashSet<Roles>();
            UserRoles= new HashSet<UserRole>();
        }

        public int Id { get; set; }

        [StringLength(256)]
        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public string PasswordHash { get; set; }

        public string SecurityStamp { get; set; }

        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public bool TwoFactorEnabled { get; set; }

        public DateTime? LockoutEndDateUtc { get; set; }

        public bool LockoutEnabled { get; set; }

        public int AccessFailedCount { get; set; }

        [Required]
        [StringLength(256)]
        public string UserName { get; set; }

        [Required]
        [StringLength(10)]
        public string UserTypeCode { get; set; }

        [StringLength(10)]
        public string Title { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(100)]
        public string AddressLine1 { get; set; }

        [StringLength(100)]
        public string AddressLine2 { get; set; }

        public int? CityId { get; set; }

        [StringLength(255)]
        public string DisplayName { get; set; }
        [StringLength(50)]
        public string City { get; set; }
        [StringLength(50)]
        public string State { get; set; }
        
        [StringLength(50)]
        public string ZipCode { get; set; }

        public int? CountryId { get; set; }

        public int? Nationality { get; set; }

        [StringLength(50)]
        public string Mobile { get; set; }

        [StringLength(50)]
        public string AltMobile { get; set; }

        public bool IsSA { get; set; }

        public bool IsActive { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public DateTime? DOB { get; set; }
        public string Gender { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }
        public string ImgURL { get; set; }
      
        public virtual ICollection<UserClaim> UserClaims { get; set; }
        
        public virtual ICollection<UserLogin> UserLogins { get; set; }
        
        public virtual ICollection<Roles> Roles { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
      
    }
}
