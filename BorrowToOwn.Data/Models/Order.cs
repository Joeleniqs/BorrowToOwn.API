using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using static BorrowToOwn.Data.Common.AppEnum;

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

        //required
        public bool IsOneOffPurchase { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal PenaltyFeeInduced { get; set; }
     

        public bool IsAdminApproved { get; set; }
        public DateTimeOffset TimeStampApproved { get; set; }
        public string ApprovedBy { get; set; }
        public List<Comment> ApprovalComments { get; set; }


        public OrderStatus OrderState { get; set; }
        public DeliveryFee DeliveryPrice { get; set; }

        public PaymentPlan PaymentPlan { get; set; }
        public AppUser AppUser { get; set; }
        public Product Product { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }

        //Executed Orders
    }
    public class Comment
    {
        public string ApprovalComment { get; set; }
    }
}


