using System;
namespace BorrowToOwn.Data.Models
{
    public class ProductPaymentPlan
    {
        public long ProductId { get; set; }
        public int PaymentPlanId { get; set; }
        public string ProductName { get; set; }
        public string PaymentPlanName { get; set; }
        //public double UpFrontRate { get; set; }
        //public int TenureInMonths { get; set; }
        public Product Product { get; set; }
        public PaymentPlan PaymentPlan { get; set; }
    }
}
