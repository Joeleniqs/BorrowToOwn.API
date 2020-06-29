using System;
using System.Collections.Generic;
using static BorrowToOwn.Data.Common.AppEnum;

namespace BorrowToOwn.Services.Communications.ResponseObject.DTO
{
    public class ProductResponseObject
    {
        public ProductResponseObject()
        {
        }
        public long Id { get; set; }
        public long SubCategoryId { get; set; }
        public int CategoryId { get; set; }

        public string Name { get; set; }
        public int Quantity { get; set; }

        public decimal ActualPrice { get; set; }

        public string Model { get; set; }
        public List<string> AvailableSizes { get; set; }
        public List<string> AvailableColours { get; set; }
        public string Description { get; set; }
        public string ProductState { get; set; }

        public bool InStock => Quantity > 0;

        public bool IsActive { get; set; }
        public bool IsModified { get; set; }
        public bool IsDeleted { get; set; }

        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTimeOffset TimeStampCreated { get; set; }
        public DateTimeOffset TimeStampModified { get; set; }
        public List<ProductImageResponseObject> ProductImages { get; set; }
        public List<ProductPaymentPlanResponseObject> AllowedPaymentPlans { get; set; }
    }
    public class ProductPaymentPlanResponseObject
    {
        public long ProductId { get; set; }
        public int PaymentPlanId { get; set; }
        public string ProductName { get; set; }
        public string PaymentPlanName { get; set; }
        //public double UpFrontRate { get; set; }
        //public int TenureInMonths { get; set; }
    }
}
