using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ST.Models
{
    [Table("user")]
    public partial class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Required]
        //[Range(1, 10000, ErrorMessage = "This field is Number Data type")]
        [Column("ID")]
        public int Id { get; set; }
        [Column("SM_ID")]    
        public int? SmId { get; set; }
        [Column("U_ID")]
        public int? UId { get; set; }
        [Column("C_ID")]
        public int? CId { get; set; }
        [Column("userName")]
        [StringLength(50)]
        [Required (ErrorMessage = "The User Name field is required")]
        public string UserName { get; set; }
        [Column("password")]
        [DataType(DataType.Password)]
        [StringLength(50)]
        [Required(ErrorMessage = "The password field is required")]
        public string Password { get; set; }
        [Column("phon")]
        [StringLength(10)]
        public string Phon { get; set; }
        [Column("email")]
        [Required(ErrorMessage = "enter the email")]
        [StringLength(70)]
        public string Email { get; set; }
        [Column("userType")]
        public int? UserType { get; set; }

        [ForeignKey(nameof(CId))]
        [InverseProperty(nameof(Company.Users))]
        public virtual Company CIdNavigation { get; set; }
        [ForeignKey(nameof(SmId))]
        [InverseProperty(nameof(StudentMaster.Users))]
        public virtual StudentMaster Sm { get; set; }
        [ForeignKey(nameof(UId))]
        [InverseProperty(nameof(University.Users))]
        public virtual University UIdNavigation { get; set; }
        [ForeignKey(nameof(UserType))]
        [InverseProperty("Users")]
        public virtual UserType UserTypeNavigation { get; set; }
    }
}
