using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ST.Models
{
    [Table("CollegeName")]
    public partial class CollegeName
    {
        public CollegeName()
        {
            StudentMasters = new HashSet<StudentMaster>();
        }

        [Key]
        [Required(ErrorMessage = "The id field is required")]
        [Column("ID")]
        public int Id { get; set; }
        [Column("CollegeName")]
        [StringLength(50)]
        [Required(ErrorMessage = "The collegename field is required")]
        public string CollegeName1 { get; set; }

        [InverseProperty(nameof(StudentMaster.CollegeNavigation))]
        public virtual ICollection<StudentMaster> StudentMasters { get; set; }
    }
}
