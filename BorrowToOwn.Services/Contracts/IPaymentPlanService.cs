using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BorrowToOwn.Services.Communications.RequestObject.DTO;
using BorrowToOwn.Services.Communications.ResponseObject.DTO;

namespace BorrowToOwn.Services.Contracts
{
    public interface IPaymentPlanService
    {
        Task<PaymentPlanResponseObject> AddPaymentPlanAsync(PaymentPlanRequestObject category);
        Task<IEnumerable<PaymentPlanResponseObject>> GetPaymentPlansAsync();
        Task<PaymentPlanResponseObject> GetPaymentPlanAsync(int id);
        Task<bool> IsPaymentPlanValidAsync(int id);
        Task<bool> DeletePaymentPlanAsync(int id);
    }
}
