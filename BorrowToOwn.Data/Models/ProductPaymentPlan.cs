using System;
using System.ComponentModel.DataAnnotations;

namespace BorrowToOwn.Data.Models
{
    public class ProductPaymentPlan
    {
        public long ProductId { get; set; }
        public int PaymentPlanId { get; set; }
        [Required]
        [MaxLength(30)]
        public string ProductName { get; set; }
        [Required]
        [MaxLength(30)]
        public string PaymentPlanName { get; set; }
        public Product Product { get; set; }
        public PaymentPlan PaymentPlan { get; set; }
    }
}
