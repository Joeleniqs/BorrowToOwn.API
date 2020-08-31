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
    public class BrandRepository:IBrandRepository
    {
        private readonly BorrowContext _context;

        public BrandRepository(BorrowContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Brand> AddBrandAsync(Brand brand)
        {
            var result = await _context.AddAsync(brand);

            if (await SaveAsync() > 0)
            {
                return result.Entity;
            }
            return null;
        }

        public async Task<Brand> GetBrand(int id) =>
            await _context.Brands.FirstOrDefaultAsync(pay => pay.Id == id);

        public async Task<IEnumerable<Brand>> GetBrands() =>
            await _context.Brands.ToListAsync();

        private async Task<int> SaveAsync() => await _context.SaveChangesAsync();
    }
}
