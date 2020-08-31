using System;
using System.ComponentModel.DataAnnotations;

namespace BorrowToOwn.Services.Communications.RequestObject.DTO
{
    public class BrandRequestObject
    {
        [Required]
        [MaxLength(40)]
        public string BrandName { get; set; }
    }
}
