using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ST.Models
{
    [Table("code_nationality")]
    public partial class CodeNationality
    {
        public CodeNationality()
        {
            StudentMasters = new HashSet<StudentMaster>();
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

        [InverseProperty(nameof(StudentMaster.NationalityNavigation))]
        public virtual ICollection<StudentMaster> StudentMasters { get; set; }
    }
}
