using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BorrowToOwn.Services.Communications.RequestObject.DTO;
using BorrowToOwn.Services.Communications.ResponseObject.DTO;

namespace BorrowToOwn.Services.Contracts
{
    public interface IBrandService
    {
        Task<BrandResponseObject> AddBrandAsync(BrandRequestObject brand);
        Task<IEnumerable<BrandResponseObject>> GetBrandsAsync();
        Task<BrandResponseObject> GetBrandAsync(int id);

    }
}
