using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BorrowToOwn.Data.Models;

namespace BorrowToOwn.Data.Repository.Contracts
{
    public interface IProductRepository
    {
        Task<Product> AddProductAsync(Product product);
        Task<IQueryable<Product>> GetProductsAsync();
        Task<Product> GetProductAsync(long id);
        void UpdateProduct();
        Task<int> SaveAsync();
    }
}
