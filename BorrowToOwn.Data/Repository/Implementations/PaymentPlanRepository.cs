using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BorrowToOwn.Data.Data;
using BorrowToOwn.Data.Models;
using BorrowToOwn.Data.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BorrowToOwn.Data.Repository.Implementations
{
    public class PaymentPlanRepository : IPaymentPlan
    {
        private readonly BorrowContext _context;

        public PaymentPlanRepository(BorrowContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<PaymentPlan> AddPaymentPlanAsync(PaymentPlan paymentPlan)
        {
            var result = await _context.AddAsync(paymentPlan);

            if (await SaveAsync() > 0)
            {
                return result.Entity;
            }
            return null;
        }

        public async Task<PaymentPlan> GetPaymentPlan(int id) => await _context.PaymentPlans
                                                                                                                                 .FirstOrDefaultAsync(pay => pay.Id == id && pay.IsActive);


        public async Task<IEnumerable<PaymentPlan>> GetPaymentPlans() => await _context.PaymentPlans
                                                                                                                                        .Where(p => p.IsActive)
                                                                                                                                        .ToListAsync();
        public async Task<bool> DeletePaymentPlanAsync(int id)
        {
            var category = await _context.PaymentPlans
                                                  .Where(pay => pay.Id == id)
                                                  .FirstOrDefaultAsync();
            category.IsActive = !category.IsActive;

            if (await SaveAsync() > 0) return true;

            return false;
        }

        public async Task<int> SaveAsync() =>  await _context.SaveChangesAsync();

        public async Task<bool> IsPaymentPlanValidAsync(int id)
        {
                var paymentPlans = await _context.PaymentPlans.FirstOrDefaultAsync(cat => cat.Id == id);

                if (paymentPlans == default(PaymentPlan)) return false;
                return true;
        }
    }
}
