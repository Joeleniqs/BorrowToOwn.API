using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BorrowToOwn.Services.Communications.RequestObject.DTO
{
    public class CategoryRequestObject
    {
        public CategoryRequestObject()
        {
            SubCategories = new HashSet<SubCategoryRequestObject>();
        }
        [Required]
        public string CategoryName { get; set; }
        [Required]
        public string CreatedBy { get; set; }

        public virtual IEnumerable<SubCategoryRequestObject> SubCategories { get; set; }
    }
}
