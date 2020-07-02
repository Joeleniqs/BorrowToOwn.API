using System;
using System.ComponentModel.DataAnnotations;

namespace BorrowToOwn.Services.Communications.RequestObject.DTO
{
    public class PaymentPlanRequestObject
    {
        [Required]
        [MaxLength(20)]
        public string PlanName { get; set; }
        [Required]
        public double UpFrontRate { get;set;}
        [Required]
        public int TenureInMonths { get; set; }
        [Required]
        public int PlanType { get; set; }
    }
}
