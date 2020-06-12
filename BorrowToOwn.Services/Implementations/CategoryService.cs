using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BorrowToOwn.Services.Communications.RequestObject.DTO;
using BorrowToOwn.Services.Communications.ResponseObject.DTO;
using BorrowToOwn.Services.Contracts;

namespace BorrowToOwn.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        public Task<CategoryResponseObject> AddCategoryAsync(CategoryRequestObject category)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddSubCategoryAsync(int categoryId, SubCategoryRequestObject subCategory)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteSubCategoryAsync(int categoryId, int subCategoryId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CategoryResponseObject>> GetCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CategoryResponseObject> GetCategoryAsync(int id, bool includeSubCategories, bool includeProducts, int start, int end)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsCategoryValidAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
