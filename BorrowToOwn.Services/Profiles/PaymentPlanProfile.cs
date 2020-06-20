using AutoMapper;
using BorrowToOwn.Data.Models;
using BorrowToOwn.Services.Communications.RequestObject.DTO;
using BorrowToOwn.Services.Communications.ResponseObject.DTO;

namespace BorrowToOwn.Services.Profiles
{
    public class PaymentPlanProfile:Profile
    {
        public PaymentPlanProfile()
        {
            CreateMap<PaymentPlan, PaymentPlanResponseObject>()
                .ForMember(dest => dest.PlanType, src => src.MapFrom(s => s.PlanType.ToString().Replace("_", " ")));
            CreateMap<PaymentPlanRequestObject, PaymentPlan>();

        }
    }
}
