 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static BorrowToOwn.Data.Common.AppEnum;

namespace BorrowToOwn.Data.Models
{
    public class Order
    {
        
        public long Id { get; set; }
        public long ProductId { get; set; }
        [MaxLength(30)]
        public string AppUserId { get; set; }

        public int OrderedQuantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal OrderAmount { get; set; }
   
        [Column(TypeName = "decimal(18,2)")]
        public decimal UpFrontAmount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal MonthlyAmortizationValue { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal PenaltyFeeInduced { get; set; }

        //[Column(TypeName = "decimal(18,2)")]
        //public decimal OrderFirstPayment { get; set; }

        public bool IsAdminApproved { get; set; }
        public DateTimeOffset TimeStampApproved { get; set; }
        [MaxLength(20)]
        public string ApprovedBy { get; set; }

        public List<Comment> ApprovalComments { get; set; }

        public OrderStatus OrderState { get; set; }
        public DeliveryFee DeliveryPrice { get; set; }

        public PaymentPlan PaymentPlan { get; set; }

        public AppUser AppUser { get; set; }
        public Product Product { get; set; }
        public ICollection<Payment> Payments { get; set; } = new HashSet<Payment>();

        //Executed Orders
    }
    public class Comment
    {
        public long Id { get; set; }

        [MaxLength(500)]
        public string ApprovalComment { get; set; }
    }
}


