using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ST.Models
{
    [Table("code_Majer")]
    public partial class Majer
    {
        public Majer()
        {
            StudentMasters = new HashSet<StudentMaster>();
        }

        [Key]
        [Required(ErrorMessage = "The id field is required")]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(10)]
        [Required(ErrorMessage = "The name field is required")]
        [Column("Name")]
        public string Name { get; set; }

        [InverseProperty(nameof(StudentMaster.MajorNavigation))]
        public virtual ICollection<StudentMaster> StudentMasters { get; set; }
    }
}
