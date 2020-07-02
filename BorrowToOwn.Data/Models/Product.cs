using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NpgsqlTypes;
using static BorrowToOwn.Data.Common.AppEnum;

namespace BorrowToOwn.Data.Models
{
    public class Product
    {
        public long Id { get; set; }
        public long SubCategoryId { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
        public int  Quantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ActualPrice { get; set; }

        [MaxLength(100)]
        public string Model { get; set; }

        public List<string> AvailableSizes { get; set; }
        public List<string> AvailableColours { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }
        public ProductState ProductState { get; set; }

        public bool InStock => Quantity > 0;

        public bool IsActive { get; set; } = true;
        public bool IsModified { get; set; } = false;
        public bool IsDeleted { get; set; } = false;

        [MaxLength(20)]
        public string CreatedBy { get; set; }
        [MaxLength(20)]
        public string LastModifiedBy { get; set; }

        public DateTimeOffset TimeStampCreated { get; set; }
        public DateTimeOffset TimeStampModified { get; set; }

        public Brand ProductBrand { get; set; }
        public SubCategory ProductSubCategory { get; set; }
        public ICollection<ProductImage> ProductImages { get; set; } = new HashSet<ProductImage>();
        public ICollection<ProductPaymentPlan> AllowedPaymentPlans { get; set; } = new HashSet<ProductPaymentPlan>();
        public NpgsqlTsVector SearchVector { get; set; }
    }
    
}
