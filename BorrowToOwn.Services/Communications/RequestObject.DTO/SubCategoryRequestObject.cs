using System.ComponentModel.DataAnnotations;

namespace BorrowToOwn.Services.Communications.RequestObject.DTO
{
    public class SubCategoryRequestObject
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        [Required]
        public string CreatedBy { get; set; }
    }
}
