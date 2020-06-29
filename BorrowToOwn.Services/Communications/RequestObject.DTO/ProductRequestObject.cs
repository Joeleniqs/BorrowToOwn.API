using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace BorrowToOwn.Services.Communications.RequestObject.DTO
{
    public class ProductRequestObject
    {
        
        [Required]
        public long SubCategoryId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal ActualPrice { get; set; }

        public string Model { get; set; }

        public List<string> AvailableSizes { get; set; }

        public List<int> AvailableProductColours { get; set; }

        [Required]
        public string Description { get; set; }
        [Required]
        public int ProductState { get; set; }

        public string CreatedBy { get; set; }
        [Required]
        public IFormFile CoverImage { get; set; }

        public virtual IFormFileCollection AlternateProductImages { get; set; }
        [Required]
        public ICollection<int> AssociatedPaymentPlans { get; set; }
    }
}
