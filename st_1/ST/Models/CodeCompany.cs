using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ST.Models
{
    [Table("code_company")]
    public partial class CodeCompany
    {
        public CodeCompany()
        {
            Companies = new HashSet<Company>();
        }

        [Key]
        [Required(ErrorMessage = "The id field is required")]
        [Column("ID")]
        public int Id { get; set; }
        [Column("nameAr")]
        [StringLength(50)]
        public string NameAr { get; set; }
        [Column("nameEn")]
        [StringLength(50)]
        public string NameEn { get; set; }

        [InverseProperty(nameof(Company.CompanyTypeNavigation))]
        public virtual ICollection<Company> Companies { get; set; }
    }
}
