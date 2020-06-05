using System;
namespace BorrowToOwn.Data.Common
{
    public class AppEnum
    {
        public enum ProductState {
            New = 1,
            Open_Box,
            Used
        }
        public enum DeliveryFee {
            Abuja = 5000
        }
        public enum OrderStatus
        {
            To_Review = 1,
            In_Review,
            Is_Approved,
            Is_Declined,
            Is_In_Transit,
            Is_Delivered
        }
        public enum IdentityType
        {
            Work_ID = 1,
            NIMC,
            International_Passport,
            Driver_License,
            Voter_Card
        }

    }
}
