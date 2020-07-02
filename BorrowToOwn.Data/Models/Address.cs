using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static BorrowToOwn.Data.Common.AppEnum;

namespace BorrowToOwn.Data.Models
{
    public class Address
    {
        public long Id { get; set; }
        public List<AddressDetails> Addresses { get; set; } = new List<AddressDetails>();
    }

    public class AddressDetails
    {
        public long Id { get; set; }
        [Range(1, 9999, ErrorMessage = "Street Number must be between 1 and 9999")]
        public int StreetNumber { get; set; }
        [MaxLength(200)]
        public string StreetName { get; set; }
        [MaxLength(50)]
        public string City { get; set; }
        [MaxLength(50)]
        public string State { get; set; }
        [MaxLength(50)]
        public string Country { get; set; } = "Nigeria";
        [Range(1,2,ErrorMessage = "Invalid Address Type")]
        public AddressType AddressType { get; set; }
    }

}
