using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        public string PlanName { get; set; }
        [Required]
        public float UpFrontRate { get; set; }
        [Required]
        public int TenureInMonths { get; set; }
        [Required]
        public float MonthlyAmortizationValue { get; set; }

        public virtual ICollection<ProductPaymentPlan> ProductsAssociatedWith { get; set; }
    }
}
