using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BorrowToOwn.Data.Models;

namespace BorrowToOwn.Data.Repository.Contracts
{
    public interface IBrandRepository
    {
        Task<Brand> AddBrandAsync(Brand brand);
        Task<IEnumerable<Brand>> GetBrands();
        Task<Brand> GetBrand(int id);
    }
}
