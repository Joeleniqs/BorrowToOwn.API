using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using static BorrowToOwn.Data.Common.AppEnum;

namespace BorrowToOwn.Data.Models
{
    public class AppUser : IdentityUser
    {
        public Guid SurrogateIdentifier { get; set; } = Guid.NewGuid();
        [MaxLength(20)]
        [MinLength(2)]
        public string FirstName { get; set; }
        [MaxLength(20)]
        [MinLength(2)]
        public string LastName { get; set; }
        [MaxLength(40)]
        [MinLength(2)]
        public string FullName => LastName + " " + FirstName;
        public DateTime DOB { get; set; }

        //user image
        [MaxLength(100)]
        [MinLength(10)]
        public string UserProfilePicUrl { get; set; }

        //Guarantor details could come

        //Identity verification
        public  ICollection<IdentityDocument> IdentityDocuments { get; set; } = new HashSet<IdentityDocument>();

        //bank statements
        public  ICollection<AppUserBankStatement> BankStatements { get; set; } = new HashSet<AppUserBankStatement>();

        //Todo Voucher Object

        public bool IsOrderLevelReady { get; set; } = false;
        public Address Address { get; set; }
        public  ICollection<Card> Cards { get; set; } = new HashSet<Card>();
        public  ICollection<Payment> Payments { get; set; } = new HashSet<Payment>();
        public  ICollection<PaymentHistory> PaymentHistories { get; set; } = new HashSet<PaymentHistory>();
        public  ICollection<Order> Orders { get; set; } = new HashSet<Order>();

    }

    public class IdentityDocument
    {
        public int  Id { get; set; }

        [MaxLength(20)]
        public string AppUserId { get; set; }

        [MaxLength(25)]
        public string IdentityName { get; set; }

        [Range(1,5,ErrorMessage = "Invalid Identity Type")]
        public IdentityType IdentityType { get; set; }

        [MaxLength(100)]
        public string DocumentUrl { get; set; }

        public DateTime ExpiryDate { get; set; }
        public AppUser AppUser { get; set; }
    }
    public class AppUserBankStatement
    {
        public int Id { get; set; }

        [MaxLength(20)]
        public string AppUserId { get; set; }

        [MaxLength(100)]
        public string DocumentUrl { get; set; }

        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public AppUser AppUser { get; set; }
    }
}


//Get Users,Orders,Payments