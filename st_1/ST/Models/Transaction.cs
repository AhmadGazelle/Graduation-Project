using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ST.Models
{
    [Table("Transaction")]
    public partial class Transaction
    {
        [Key]
        [Required(ErrorMessage = "The id field is required")]
        [Column("ID")]
        public int Id { get; set; }
        [Column("SM_ID")]
        public int? SmId { get; set; }
        [Column("fromDate", TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime? FromDate { get; set; }
        [Column("toDate", TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime? ToDate { get; set; }
        [Column("status")]
        public int? Status { get; set; }

        [ForeignKey(nameof(SmId))]
        [InverseProperty(nameof(StudentMaster.Transactions))]
        public virtual StudentMaster Sm { get; set; }
    }
}
