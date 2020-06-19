using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BorrowToOwn.Data.Models;

namespace BorrowToOwn.Data.Repository.Contracts
{
    public interface IPaymentPlan
    {
        Task<PaymentPlan> AddPaymentPlanAsync(PaymentPlan paymentPlan);
        Task<IEnumerable<PaymentPlan>> GetPaymentPlans();
        Task<PaymentPlan> GetPaymentPlan(int id);
        Task<bool> IsPaymentPlanValidAsync(int id);
        Task<bool> DeletePaymentPlanAsync(int id);
        Task<int> SaveAsync();
    }
}
