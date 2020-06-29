using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using NpgsqlTypes;
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
        public int CategoryId { get; set; }

        public string Name { get; set; }
        public int  Quantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ActualPrice { get; set; }


        public string Model { get; set; }
        public List<string> AvailableSizes { get; set; }
        public List<string> AvailableColours { get; set; }
        public string Description { get; set; }
        public ProductState ProductState { get; set; }

        public bool InStock => Quantity > 0;

        public bool IsActive { get; set; } = true;
        public bool IsModified { get; set; } = false;
        public bool IsDeleted { get; set; } = false;

        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTimeOffset TimeStampCreated { get; set; }
        public DateTimeOffset TimeStampModified { get; set; }


        public virtual SubCategory ProductSubCategory { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
        public ICollection<ProductPaymentPlan> AllowedPaymentPlans { get; set; }
        public NpgsqlTsVector SearchVector { get; set; }
    }
    
}
