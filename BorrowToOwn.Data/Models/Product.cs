using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using static BorrowToOwn.Data.Common.AppEnum;

namespace BorrowToOwn.Data.Models
{
    public class Product
    {
        public Product()
        {
            ProductImages = new HashSet<ProductImage>();
            AllowedPaymentPlans = new HashSet<ProductPaymentPlan>();
        }
        public long Id { get; set; }
        public long SubCategoryId { get; set; }

        public string Name { get; set; }
        public int  Quantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ActualPrice { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal OneOffPrice =>  ActualPrice * (decimal) OneOffRate;
        public float OneOffRate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal FinancePrice => ActualPrice * (decimal) FinanceRate;
        public float FinanceRate { get; set; }

        public ProductDetail ProductDetail { get; set; }


        public bool InStock { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTimeOffset TimeStampCreated { get; set; }
        public DateTimeOffset TimeStampModified { get; set; }


        public virtual SubCategory ProductSubCategory { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
        public ICollection<ProductPaymentPlan> AllowedPaymentPlans { get; set; }

    }
    public class ProductDetail {
        public long Id { get; set; }
        public string Model { get; set; }
        public string Size { get; set; }
        public string Description { get; set; }
        public ProductState ProductState { get; set; }
    }
    //oneOff rate -> 120%
    //hp rate -> 136%
}
