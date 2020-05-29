using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BorrowToOwn.Data.Models
{
    public class User
    {
        public User()
        {
            Cards = new HashSet<Card>();
        }
        [Required]
        public long Id { get; set; }
        
        public Guid SurrogateIdentifier { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => LastName + " " + FirstName;
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Address Address { get; set; }
        public ICollection<Card> Cards { get; set; }

    }
}
