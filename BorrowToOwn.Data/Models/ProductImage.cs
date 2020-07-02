using System;
using System.ComponentModel.DataAnnotations;

namespace BorrowToOwn.Data.Models
{
    public class ProductImage
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        [Required]
        [MaxLength(100)]
        public string ImageUrl { get; set; }
        public bool IsCoverImage { get; set; }
        public Product Product { get; set; }
    }
}
