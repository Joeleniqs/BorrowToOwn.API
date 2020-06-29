namespace BorrowToOwn.Services.Communications.ResponseObject.DTO
{
    public class PaymentPlanResponseObject
    {
        public int Id { get; set; }
        public string PlanName { get; set; }
        public float UpFrontRate { get; set; }
        public int TenureInMonths { get; set; }
        public string PlanType { get; set; }
        public bool IsActive { get; set; }
    }
}
