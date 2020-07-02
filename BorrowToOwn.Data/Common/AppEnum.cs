using System;
namespace BorrowToOwn.Data.Common
{
    public class AppEnum
    {
        public enum ResourceUriType
        {
            PreviousPage,
            NextPage
        }
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
            Is_Delivered,
            In_Payment,
            Is_Executed_Completely
        }
        public enum AddressType
        {
            Home = 1,
            Office
        }
        public enum PaymentPlanType
        {
            One_Off_Purchase = 1,
            Hire_Purchase
        }

        public enum IdentityType
        {
            Work_ID = 1,
            NIMC,
            International_Passport,
            Driver_License,
            Voter_Card
        }
        public enum ProductColour
        {
            Black = 1,
            White,
            Blue,
            Green,
            Purple,
            Red,
            Grey
        }

    }
}
