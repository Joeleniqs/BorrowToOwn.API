using System;
using System.Collections.Generic;

namespace BorrowToOwn.Services.Communications.ResponseObject.DTO
{
    public class CategoryResponseObject
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public IEnumerable<SubCategoryResponseObject> SubCategories { get; set; } = new HashSet<SubCategoryResponseObject>();
    }
}
