using System;
using System.Collections.Generic;

namespace BorrowToOwn.Data.Models
{
    public class Order
    {
        public Order()
        {
            Payments = new HashSet<Payment>();
        }
        public long Id { get; set; }
        public long ProductId { get; set; }
        public long UserId { get; set; }

        public int OrderedQuantity { get; set; }
        public decimal OrderAmount { get; set; }

        public PaymentPlan PaymentPlan { get; set; }
        public User User { get; set; }
        public Product Product { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
