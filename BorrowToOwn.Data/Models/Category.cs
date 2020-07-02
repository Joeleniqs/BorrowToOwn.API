using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BorrowToOwn.Data.Models
{
    public class Category
    {
        public Category()
        {
            SubCategories = new HashSet<SubCategory>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(25, ErrorMessage = "Category Name  cannot be greater than 25")]
        public string CategoryName { get; set; }

        public bool IsActive { get; set; } = true;
        public bool IsModified { get; set; } = false;
        public bool IsDeleted { get; set; } = false;

        [MaxLength(20)]
        public string CreatedBy { get; set; }
        [MaxLength(20)]
        public string LastModifiedBy { get; set; }

        public DateTimeOffset TimeStampCreated{ get; set; }
        public DateTimeOffset TimeStampModified { get; set; }
      
        public virtual IEnumerable<SubCategory> SubCategories { get; set; }
    }
}

