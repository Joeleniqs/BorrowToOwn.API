using System;
namespace BorrowToOwn.Data.Models
{
    public class Payment
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long OrderId { get; set; }

        public decimal AmountPaid { get; set; }
        public DateTimeOffset TimeStampRegistered { get; set; }

        public Order Order { get; set; }

    }
}
