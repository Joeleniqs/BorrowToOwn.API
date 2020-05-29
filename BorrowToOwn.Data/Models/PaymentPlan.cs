using System;
using System.ComponentModel.DataAnnotations;

namespace BorrowToOwn.Data.Models
{
    public class PaymentPlan
    {
        public int Id { get; set; }
        [Required]
        public string PlanName { get; set; }
        [Required]
        public float UpFrontRate { get; set; }
        [Required]
        public int TenureInMonths { get; set; }
        [Required]
        public float AmortizationRate { get; set; }
    }
}
