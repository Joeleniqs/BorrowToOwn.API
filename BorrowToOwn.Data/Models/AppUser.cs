using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace BorrowToOwn.Data.Models
{
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
            Cards = new HashSet<Card>();
            Payments = new HashSet<Payment>();
            Orders = new HashSet<Order>();
            PaymentHistories = new HashSet<PaymentHistory>();
        }
        
        public Guid SurrogateIdentifier { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => LastName + " " + FirstName;

        //Guarantor details could come

        public Address Address { get; set; }
        public virtual ICollection<Card> Cards { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public ICollection<PaymentHistory> PaymentHistories { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

    }
}
