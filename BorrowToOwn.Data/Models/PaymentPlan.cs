using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static BorrowToOwn.Data.Common.AppEnum;

namespace BorrowToOwn.Data.Models
{
    public class PaymentPlan
    {
        public PaymentPlan()
        {
           ProductsAssociatedWith = new HashSet<ProductPaymentPlan>();
        }
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string PlanName { get; set; }
        [Required]
        public double UpFrontRate { get; set; }
        [Required]
        public int TenureInMonths { get; set; }
        [Required]
        public PaymentPlanType PlanType { get; set; }

        public bool IsActive { get; set; } = true;

        public ICollection<ProductPaymentPlan> ProductsAssociatedWith { get; set; }
    }
}
