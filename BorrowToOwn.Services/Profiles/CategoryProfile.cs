
using AutoMapper;
using BorrowToOwn.Data.Models;
using BorrowToOwn.Services.Communications.RequestObject.DTO;

namespace BorrowToOwn.Services.Profiles
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryRequestObject, Category>();
        }
        
    }
}
