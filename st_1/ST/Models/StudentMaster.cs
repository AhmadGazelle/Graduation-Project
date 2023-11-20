using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ST.Models
{
    [Table("studentMaster")]
    public partial class StudentMaster
    {
        public StudentMaster()
        {
            Courses = new HashSet<Course>();
            Transactions = new HashSet<Transaction>();
            Users = new HashSet<User>();
        }

        [Key]
        [Column("ID")]
        [Required(ErrorMessage = "The id field is required")]
        public int Id { get; set; }
        [Column("name")]
        [StringLength(50)]
        [Required(ErrorMessage = "The User Name field is required")]
        public string Name { get; set; }
        [Column(TypeName = "date")]
        public DateTime? BirthDate { get; set; }
        [Column("university")]
        public int? University { get; set; }
        public int? College { get; set; }
        [Column("major")]
        public int? Major { get; set; }
        [Column("sex")]
        public int? Sex { get; set; }
        [Column("nationality")]
        public int? Nationality { get; set; }

        [ForeignKey(nameof(College))]
        [InverseProperty(nameof(CollegeName.StudentMasters))]
        public virtual CollegeName CollegeNavigation { get; set; }
        [ForeignKey(nameof(Major))]
        [InverseProperty(nameof(Majer.StudentMasters))]
        public virtual Majer MajorNavigation { get; set; }
        [ForeignKey(nameof(Nationality))]
        [InverseProperty(nameof(CodeNationality.StudentMasters))]
        public virtual CodeNationality NationalityNavigation { get; set; }
        [ForeignKey(nameof(Sex))]
        [InverseProperty(nameof(GenderType.StudentMasters))]
        public virtual GenderType SexNavigation { get; set; }
        [InverseProperty(nameof(Course.Sm))]
        public virtual ICollection<Course> Courses { get; set; }
        [InverseProperty(nameof(Transaction.Sm))]
        public virtual ICollection<Transaction> Transactions { get; set; }
        [InverseProperty(nameof(User.Sm))]
        public virtual ICollection<User> Users { get; set; }
    }
}
