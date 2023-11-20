using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ST.Models
{
    [Table("userType")]
    public partial class UserType
    {
        public UserType()
        {
            Users = new HashSet<User>();
        }

        [Key]
        
        [Required(ErrorMessage = "The id field is required")]
        [Column("ID")]
        public int Id { get; set; }
        [Column("userTypeEn")]
        [StringLength(50)]
        public string UserTypeEn { get; set; }
        [Column("userTypeAr")]
        [StringLength(50)]
        public string UserTypeAr { get; set; }

        [InverseProperty(nameof(User.UserTypeNavigation))]
        public virtual ICollection<User> Users { get; set; }
    }
}
