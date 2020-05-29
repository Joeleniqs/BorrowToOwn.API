using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BorrowToOwn.Data.Models
{
    public class Product
    {
        public Product()
        {
            ProductImages = new HashSet<ProductImage>();
        }
        public long Id { get; set; }
        public int CategoryId { get; set; }

        public string Name { get; set; }
        public int  Quantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ActualPrice { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal SellingPrice { get; set; }

        public bool InStock { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTimeOffset TimeStampCreated { get; set; }
        public DateTimeOffset TimeStampModified { get; set; }

        public virtual Category ProductCategory { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
    }
}
