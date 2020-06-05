using System;
namespace BorrowToOwn.Data.Models
{
    public class SubCategory
    {
        public long Id { get; set; }
        public long CategoryId { get; set; }
        public long Name { get; set; }
        public Category Category { get; set; }
    }
}
