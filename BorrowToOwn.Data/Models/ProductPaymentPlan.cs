using System;
namespace BorrowToOwn.Data.Models
{
    public class ProductPaymentPlan
    {
        public long ProductId { get; set; }
        public int PaymentPlan { get; set; }
        public string ProductName { get; set; }
        public string PaymentPlanName { get; set; }
    }
}
