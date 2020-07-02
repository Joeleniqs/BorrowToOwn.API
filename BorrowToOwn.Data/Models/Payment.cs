using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BorrowToOwn.Data.Models
{
    public class Payment
    {
        public long Id { get; set; }

        [MaxLength(30)]
        public string AppUserId { get; set; }

        public long OrderId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal AmountPaid { get; set; }

        public DateTimeOffset TimeStampRegistered { get; set; }

        public Order Order { get; set; }
    }
}
