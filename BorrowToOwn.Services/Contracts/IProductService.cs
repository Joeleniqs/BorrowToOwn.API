using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BorrowToOwn.Data.Models;
using BorrowToOwn.Services.Communications.RequestObject.DTO;
using BorrowToOwn.Services.Communications.ResponseObject.DTO;
using BorrowToOwn.Services.Helpers;

namespace BorrowToOwn.Services.Contracts
{
    public interface IProductService
    {
        Task<ProductResponseObject> AddProductAsync(ProductRequestObject product,HttpClient bucketClient);
        Task<PagedList<Product>> GetProductsAsync(Pagination pagination);
        Task<ProductResponseObject> GetProductAsync(long id);
        void UpdateProduct();
    }
}
