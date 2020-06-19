using System.Collections.Generic;
using System.Threading.Tasks;
using BorrowToOwn.Data.Models;
using BorrowToOwn.Services.Communications.RequestObject.DTO;
using BorrowToOwn.Services.Communications.ResponseObject.DTO;

namespace BorrowToOwn.Services.Contracts
{
    public interface ICategoryService
    {
        Task<CategoryResponseObject> AddCategoryAsync(CategoryRequestObject category);
        Task<IEnumerable<CategoryResponseObject>> GetCategoriesAsync();
        Task<CategoryResponseObject> GetCategoryAsync(int id, bool includeSubCategories = false);
        Task<bool> DeleteCategoryAsync(int id);
        Task<bool> IsCategoryValidAsync(int id, int subCategoryId = -1, bool isDeleteToggle = false);
        Task<bool> AddSubCategoryAsync(int categoryId, SubCategoryRequestObject subCategory);
        Task<bool> DeleteSubCategoryAsync(int categoryId, int subCategoryId);

    }
}
