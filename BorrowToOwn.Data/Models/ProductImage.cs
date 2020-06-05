using System;
namespace BorrowToOwn.Data.Models
{
    public class ProductImage
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public string ImageUrl { get; set; }
        public bool IsCoverImage { get; set; }
        public Product Product { get; set; }
    }
}
