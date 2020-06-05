using System;
namespace BorrowToOwn.Data.Models
{
    public class Address
    {
        public long Id { get; set; }
        public AddressDetails HomeAddress { get; set; }
        public AddressDetails OfficeAddress { get; set; }
        //public string Country { get; set; } -- we are defaulting to nigeria
    }

    public class AddressDetails
    {
            public int StreetNumber { get; set; }
            public string StreetName { get; set; }
            public string City { get; set; }
            public string State { get; set; }
    }
    
}
