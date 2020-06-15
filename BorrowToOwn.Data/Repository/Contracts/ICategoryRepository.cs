using System.Collections.Generic;
using System.Threading.Tasks;
using BorrowToOwn.Data.Models;

namespace BorrowToOwn.Data.Repository.Contracts
{
    public interface ICategoryRepository
    {
        Task<Category> AddCategoryAsync(Category category);
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<Category> GetCategoryAsync(int id, bool includeSubCategories);
        Task<bool> DeleteCategoryAsync(int id);
        Task<bool> IsCategoryValidAsync(int id);
        Task<bool> AddSubCategoryAsync(int categoryId,SubCategory subCategory);
        Task<bool> DeleteSubCategoryAsync(int categoryId, int subCategoryId);
        Task<int> SaveAsync();
    }
}
