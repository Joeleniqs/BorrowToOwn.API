using System;
namespace BorrowToOwn.Data.Models
{
    public class PaymentHistory
    {
        public long Id { get; set; }
        public long PaymentId { get; set; }

        public long OrderId { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal PreviousBalance { get; set; }
        public decimal NewBalnce { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTimeOffset TimeStampRegistered { get; set; }
        public Payment Payment { get; set; }
    }
}
