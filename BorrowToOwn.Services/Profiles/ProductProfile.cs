using System;
using AutoMapper;
using BorrowToOwn.Data.Models;
using BorrowToOwn.Services.Communications.RequestObject.DTO;
using BorrowToOwn.Services.Communications.ResponseObject.DTO;
using BorrowToOwn.Services.Helpers;
using static BorrowToOwn.Data.Common.AppEnum;

namespace BorrowToOwn.Services.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductRequestObject, Product>()
                .ForMember(dest => (int)dest.ProductState, src => src.MapFrom(s => s.ProductState));


            CreateMap<Product, ProductResponseObject>()
                .ForMember(dest => dest.ProductState, src => src.MapFrom(s => s.ProductState.ToString()));

            //CreateMap<PagedList<Product>, PagedList<ProductResponseObject>>();

            CreateMap<ProductImage, ProductImageResponseObject>();
            CreateMap<ProductPaymentPlan, ProductPaymentPlanResponseObject>();
        }
    }
}
