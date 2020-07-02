using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BorrowToOwn.Services.Communications.RequestObject.DTO
{
    public class CategoryRequestObject
    {
        [Required]
        [MaxLength(20)]
        public string CategoryName { get; set; }
        [Required]
        [MaxLength(20)]
        public string CreatedBy { get; set; }

        public IEnumerable<SubCategoryRequestObject> SubCategories { get; set; } = new List<SubCategoryRequestObject>();
    }
}
