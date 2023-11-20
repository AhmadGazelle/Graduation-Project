using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ST.Models
{
    [Table("company")]
    public partial class Company
    {
        public Company()
        {
            Users = new HashSet<User>();
        }

        [Key]
        [Column("ID")]
        [Required(ErrorMessage = "The id field is required")]
        public int Id { get; set; }
        [Column("nameEn")]
        [StringLength(50)]
        [Required(ErrorMessage = "The name field is required")]
        public string NameEn { get; set; }
        [Column("nameAr")]
        [StringLength(50)]
        [Required(ErrorMessage = "The name field is required")]
        public string NameAr { get; set; }
        [StringLength(100)]
        public string Addreas { get; set; }
        [Column("companyField")]
        [StringLength(50)]
        public string CompanyField { get; set; }
        [Column("description")]
        [StringLength(300)]
        public string Description { get; set; }
        [Column("phoneNumber")]
        [StringLength(50)]
        public string PhoneNumber { get; set; }
        [Column("email")]
        [StringLength(50)]
        public string Email { get; set; }
        [Column("genralMneger")]
        [StringLength(50)]
        public string GenralMneger { get; set; }
        [Column("companyType")]
        public int? CompanyType { get; set; }

        [ForeignKey(nameof(CompanyType))]
        [InverseProperty(nameof(CodeCompany.Companies))]
        public virtual CodeCompany CompanyTypeNavigation { get; set; }
        [InverseProperty(nameof(User.CIdNavigation))]
        public virtual ICollection<User> Users { get; set; }
    }
}
