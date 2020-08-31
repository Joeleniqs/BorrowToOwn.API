using System;
using AutoMapper;
using BorrowToOwn.Data.Models;
using BorrowToOwn.Services.Communications.RequestObject.DTO;
using BorrowToOwn.Services.Communications.ResponseObject.DTO;

namespace BorrowToOwn.Services.Profiles
{
    public class BrandProfile:Profile
    {
        public BrandProfile()
        {
            CreateMap<Brand, BrandResponseObject>();
            CreateMap<BrandRequestObject, Brand>();
        }
    }
}
