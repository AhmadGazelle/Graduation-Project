using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ST.Models
{
    [Table("courses")]
    public partial class Course
    {
        [Key]
        [Required(ErrorMessage = "The id field is required")]
        [Column("ID")]
        public int Id { get; set; }
        [Column("corusNameEn")]
        [StringLength(100)]
        public string CorusNameEn { get; set; }
        [Column("corusNameAr")]
        [StringLength(100)]
        public string CorusNameAr { get; set; }
        [Column("fromDate", TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime? FromDate { get; set; }
        [Column("toDate", TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime? ToDate { get; set; }
        [Column("hours")]
        public int? Hours { get; set; }
        [Column("SM_ID")]
        public int? SmId { get; set; }

        [ForeignKey(nameof(SmId))]
        [InverseProperty(nameof(StudentMaster.Courses))]
        public virtual StudentMaster Sm { get; set; }
    }
}
