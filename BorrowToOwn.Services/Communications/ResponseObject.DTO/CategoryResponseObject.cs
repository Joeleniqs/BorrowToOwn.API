using System;
using System.Collections.Generic;

namespace BorrowToOwn.Services.Communications.ResponseObject.DTO
{
    public class CategoryResponseObject
    {
        public CategoryResponseObject()
        {
            SubCategories = new HashSet<SubCategoryResponseObject>();
        }
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public bool IsActive { get; set; }
        public bool IsModified { get; set; }
        public bool IsDeleted { get; set; }

        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTimeOffset TimeStampCreated { get; set; }
        public DateTimeOffset TimeStampModified { get; set; }

        public virtual IEnumerable<SubCategoryResponseObject> SubCategories { get; set; }
    }
}
