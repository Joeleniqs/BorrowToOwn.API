using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BorrowToOwn.Data.Models;
using BorrowToOwn.Data.Repository.Contracts;
using BorrowToOwn.Data.Repository.Implementations;
using BorrowToOwn.Services.Communications.RequestObject.DTO;
using BorrowToOwn.Services.Communications.ResponseObject.DTO;
using BorrowToOwn.Services.Contracts;

namespace BorrowToOwn.Services.Implementations
{
    public class PaymentPlanService : IPaymentPlanService
    {
        private readonly IPaymentPlan _paymentPlanRepo;
        private readonly IMapper _mapper;

        public PaymentPlanService(IPaymentPlan paymentPlanRepository,IMapper mapper)
        {
            _paymentPlanRepo = paymentPlanRepository ?? throw new ArgumentNullException(nameof(paymentPlanRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<PaymentPlanResponseObject> AddPaymentPlanAsync(PaymentPlanRequestObject paymentPlanRequestObject)
        {
            paymentPlanRequestObject.UpFrontRate = Math.Round(paymentPlanRequestObject.UpFrontRate, 2);
            var paymentPlan = _mapper.Map<PaymentPlan>(paymentPlanRequestObject);

            var result  = await _paymentPlanRepo.AddPaymentPlanAsync(paymentPlan);
            if (result == null) return null;

            return _mapper.Map<PaymentPlanResponseObject>(result);

        }

        public async Task<bool> DeletePaymentPlanAsync(int id)
        {
            var deleted = await _paymentPlanRepo.DeletePaymentPlanAsync(id);
            if (!deleted) return false;
            return true;
        }

        public async Task<IEnumerable<PaymentPlanResponseObject>> GetPaymentPlansAsync()
        {
            var plans = await _paymentPlanRepo.GetPaymentPlans();
            return _mapper.Map<IEnumerable<PaymentPlanResponseObject>>(plans);
        }

        public async Task<PaymentPlanResponseObject> GetPaymentPlanAsync(int id)
        {
            var cats = await _paymentPlanRepo.GetPaymentPlan(id);
            if (cats == null) return null;
            return _mapper.Map<PaymentPlanResponseObject>(cats);
        }

        public async Task<bool> IsPaymentPlanValidAsync(int id)
        {
            var check = await _paymentPlanRepo.IsPaymentPlanValidAsync(id);
            if (!check) return false;
            return true;
        }
    }
}
