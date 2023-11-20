using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ST.Models
{
    [Table("University")]
    public partial class University
    {
        public University()
        {
            Users = new HashSet<User>();
        }

        [Key]
        [Required(ErrorMessage = "The id field is required")]
        [Column("ID")]
        public int Id { get; set; }
        [Column("nameEn")]
        [StringLength(50)]
        public string NameEn { get; set; }
        [Column("nameAr")]
        [StringLength(50)]
        public string NameAr { get; set; }
        [Column("address")]
        [StringLength(300)]
        public string Address { get; set; }
        [Column("universityType")]
        public int? UniversityType { get; set; }

        [ForeignKey(nameof(UniversityType))]
        [InverseProperty(nameof(CodeUniversty.Universities))]
        public virtual CodeUniversty UniversityTypeNavigation { get; set; }
        [InverseProperty(nameof(User.UIdNavigation))]
        public virtual ICollection<User> Users { get; set; }
    }
}
