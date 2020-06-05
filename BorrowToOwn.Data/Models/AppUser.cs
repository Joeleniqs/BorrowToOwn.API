using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using static BorrowToOwn.Data.Common.AppEnum;

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
            IdentityDocuments = new HashSet<IdentityDocument>();
            BankStatements = new HashSet<AppUserBankStatement>();
        }

        public Guid SurrogateIdentifier { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => LastName + " " + FirstName;
        public DateTime DOB { get; set; }

        //user image
        public string UserProfilePicUrl { get; set; }

        //Guarantor details could come

        //Identity verification
        public virtual ICollection<IdentityDocument> IdentityDocuments { get; set; }
       
        //bank statements
        public virtual ICollection<AppUserBankStatement> BankStatements { get; set; }
        //Voucher Object

        public bool IsOrderLevelReady { get; set; }
        public Address Address { get; set; }
        public virtual ICollection<Card> Cards { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<PaymentHistory> PaymentHistories { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

    }

    public class IdentityDocument {
        public int  Id { get; set; }
        public string AppUserId { get; set; }
        public string IdentityName { get; set; }
        public IdentityType IdentityType { get; set; }
        public string DocumentUrl { get; set; }
        public DateTime ExpiryDate { get; set; }
        public AppUser AppUser { get; set; }
    }
    public class AppUserBankStatement {
        public int Id { get; set; }
        public string AppUserId { get; set; }
        public string DocumentUrl { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public AppUser AppUser { get; set; }
    }
}


//Get Users,Orders,Payments