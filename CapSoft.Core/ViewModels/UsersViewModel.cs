using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CapSoft.Core.Models;

namespace CapSoft.Core.ViewModels
{
  
    public class UserViewModel
    {
       public int Id { get; set; }
  
       [StringLength(256)]
       public string Email { get; set; }

        public string PhoneNumber { get; set; }
        
        [Required]
        [StringLength(256)]
        public string UserName { get; set; }

       
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
        [StringLength(255)]
        public string DisplayName { get; set; }
        [StringLength(50)]
        public string City { get; set; }
        [StringLength(50)]
        public string State { get; set; }
        public string ImgURL { get; set; }
        public int? CityId { get; set; }
        public string CityName { get; set; }

        [StringLength(50)]
        public string ZipCode { get; set; }

        public int? CountryId { get; set; }
        public string CountryName { get; set; }

        public int? Nationality { get; set; }

        [StringLength(50)]
        public string Mobile { get; set; }

        [StringLength(50)]
        public string AltMobile { get; set; }

        public bool IsActive { get; set; }

        
        public string Gender { get; set; }
        public DateTime? LastLoginDate { get; set; }

     

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }
        public string UserTypeCode { get; set; }
        public DateTime? DOB { get; set; }
    
        public ICollection<UserRole> UserRoles { get; set; }
    }
   public  class SearchUserViewModel
    {
        
        public string Email { get; set; }
        
        public string FirstName { get; set; }

        public string LastName { get; set; }
                
        public string Address { get; set; }
                
        public int? CityId { get; set; }

        public string ZipCode { get; set; }

        public int? CountyId { get; set; }
        
       public string Mobile { get; set; }
                   
    }

    public class UserSession
    {
         public ICollection<UserScreens> Screens { get; set; }

    }
    public class UserScreens
    {
        
        public int RoleID { get; set; }
        public int ScreenId { get; set; }
        public string ScreenCode { get; set; }
        public string ScreenName { get; set; }
        public string UserTypeCode { get; set; }
        public string MenuCode { get; set; }
        [StringLength(50)]
        public string ViewPath { get; set; }

        [StringLength(50)]
        public string AddPath { get; set; }

        [StringLength(50)]
        public string EditPath { get; set; }
        [StringLength(50)]
        public string DeletePath { get; set; }
        public bool CanView { get; set; }

        public bool CanAdd { get; set; }

        public bool CanEdit { get; set; }

        public bool CanDelete { get; set; }

    }
}
