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
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public bool IsActive { get; set; } = true;
        public bool IsModified { get; set; } = false;
        public bool IsDeleted { get; set; } = false;

        public string CreatedBy { get; set; }

        public Category Category { get; set; }
        public virtual IEnumerable<Product> Products { get; set; }
    }
}
