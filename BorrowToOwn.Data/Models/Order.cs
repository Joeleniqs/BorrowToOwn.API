using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string AppUserId { get; set; }

        public int OrderedQuantity { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal OrderAmount { get; set; }

        public bool IsAdminApproved { get; set; }
        public DateTimeOffset TimeStampApproved { get; set; }
        public string ApprovedBy { get; set; }

        public PaymentPlan PaymentPlan { get; set; }
        public AppUser AppUser { get; set; }
        public Product Product { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
