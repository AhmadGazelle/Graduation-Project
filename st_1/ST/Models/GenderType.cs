using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ST.Models
{
    [Table("GenderType")]
    public partial class GenderType
    {
        public GenderType()
        {
            StudentMasters = new HashSet<StudentMaster>();
        }

        [Key]
        [Required(ErrorMessage = "The id field is required")]
        [Column("ID")]
        public int Id { get; set; }
        [Column("GenderType")]
        [StringLength(50)]
        public string GenderType1 { get; set; }

        [InverseProperty(nameof(StudentMaster.SexNavigation))]
        public virtual ICollection<StudentMaster> StudentMasters { get; set; }
    }
}
