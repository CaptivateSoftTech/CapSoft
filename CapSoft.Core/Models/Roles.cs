namespace CapSoft.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("Roles")]
    public partial class Roles
    {
    
       [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Name { get; set; }

        [Required]
        [StringLength(10)]
        public string UserTypeCode { get; set; }

        [Required]
        [StringLength(256)]
        public string LongName { get; set; }

        [StringLength(500)]
        public string RoleDesc { get; set; }

        public bool IsActive { get; set; }

        public int CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
