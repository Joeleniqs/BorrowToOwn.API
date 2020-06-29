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
    public class ProductRepository : IProductRepository
    {
        private BorrowContext _context;

        public ProductRepository(BorrowContext productContext)
        {
            _context = productContext ?? throw new ArgumentNullException(nameof(productContext));
        }

        public async Task<Product> AddProductAsync(Product product)
        {
            var result = await _context.AddAsync(product);
            if (await SaveAsync() > 0)
            {
                return result.Entity;
            }
            return null;
        }



        public async Task<Product> GetProductAsync(long id) => await _context.Products
                                                                                                                           .Where(product => product.Id == id && product.IsActive)
                                                                                                                           .Include(product => product.AllowedPaymentPlans)
                                                                                                                           .Include(product => product.ProductImages)
                                                                                                                           .FirstOrDefaultAsync();


        public async Task<IQueryable<Product>> GetProductsAsync() => await Task.Run(() =>
        {
            var query = _context.Products.FromSqlRaw(@"Select * From ""Products""  ")
            ;
            return _context.Products
                                    .Include(product => product.AllowedPaymentPlans)
                                    .Include(product => product.ProductImages) as IQueryable<Product>;
        });


        public void UpdateProduct()
        {
            //for extensibilty
        }
        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();
    }
}
