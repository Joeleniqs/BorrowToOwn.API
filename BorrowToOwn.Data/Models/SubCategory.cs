using System;
using System.Collections.Generic;

namespace BorrowToOwn.Data.Models
{
    public class SubCategory
    {
        public SubCategory()
        {
            Products = new HashSet<Product>();
        }
        public long Id { get; set; }
        public long CategoryId { get; set; }
        public long Name { get; set; }

        public bool IsActive { get; set; }
        public bool IsModified { get; set; }
        public bool IsDeleted { get; set; }

        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTimeOffset TimeStampCreated { get; set; }
        public DateTimeOffset TimeStampModified { get; set; }

        public Category Category { get; set; }
        public virtual IEnumerable<Product> Products { get; set; }
    }
}
