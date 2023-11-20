using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ST.Models
{
    [Table("code_universty")]
    public partial class CodeUniversty
    {
        public CodeUniversty()
        {
            Universities = new HashSet<University>();
        }

        [Key]
        [Column("ID")]
        [Required(ErrorMessage = "The id field is required")]
        public int Id { get; set; }
        [Column("nameAr")]
        [StringLength(50)]
        public string NameAr { get; set; }
        [Column("nameEn")]
        [StringLength(50)]
        public string NameEn { get; set; }

        [InverseProperty(nameof(University.UniversityTypeNavigation))]
        public virtual ICollection<University> Universities { get; set; }
    }
}
