using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BorrowToOwn.Data.Models
{
    public class PaymentHistory
    {
        public long Id { get; set; }
        public long PaymentId { get; set; }

        public long OrderId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal AmountPaid { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal PreviousBalance { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal NewBalnce { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        public DateTimeOffset TimeStampRegistered { get; set; }

        public Payment Payment { get; set; }
    }
}
