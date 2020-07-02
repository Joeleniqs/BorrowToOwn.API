 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BorrowToOwn.Data.Models
{
    public class SubCategory
    {
        public long Id { get; set; }
        public int CategoryId { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        public bool IsActive { get; set; } = true;
        public bool IsModified { get; set; } = false;
        public bool IsDeleted { get; set; } = false;

        [MaxLength(20)]
        public string CreatedBy { get; set; }

        public Category Category { get; set; }
        public IEnumerable<Product> Products { get; set; } = new HashSet<Product>();
    }
}
