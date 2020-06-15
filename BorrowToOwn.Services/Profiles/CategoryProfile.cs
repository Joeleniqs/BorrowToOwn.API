
using System;
using AutoMapper;
using BorrowToOwn.Data.Models;
using BorrowToOwn.Services.Communications.RequestObject.DTO;
using BorrowToOwn.Services.Communications.ResponseObject.DTO;

namespace BorrowToOwn.Services.Profiles
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryRequestObject, Category>();
            CreateMap<Category, CategoryResponseObject>();

        }
        
    }
    public class SubCategoryProfile : Profile
    {
        public SubCategoryProfile()
        {
            CreateMap<SubCategoryRequestObject, SubCategory>()
                                                          .ReverseMap();
            CreateMap<SubCategory, SubCategoryResponseObject>();
        }

    }
}
