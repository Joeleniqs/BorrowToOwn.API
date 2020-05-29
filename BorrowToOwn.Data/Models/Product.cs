using System;
using System.Collections.Generic;

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
        public decimal ActualPrice { get; set; }
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
