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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BorrowContext _context;

        public CategoryRepository(BorrowContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

        }

        public async Task<Category> AddCategoryAsync(Category category)
        {
            var result = await _context.AddAsync(category);
            if (await SaveAsync() > 0)
            {
                return result.Entity;
            }
            return null;
        }

        public async Task<bool> AddSubCategoryAsync(int categoryId, SubCategory subCategory)
        {
            await _context.SubCategories.AddAsync(subCategory);
            if (_context.SaveChanges() > 0) return true;
            return false;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await _context.Categories
                                                  .Where(cat=>cat.Id == id)
                                                  .Include(sub => sub.SubCategories)
                                                  .FirstOrDefaultAsync();
            category.IsActive = !category.IsActive;
            category.IsDeleted = !category.IsDeleted;
            category.SubCategories.ToList().ForEach(sub => {
                sub.IsActive = !sub.IsActive;
                sub.IsDeleted = !sub.IsDeleted;
            });

            if(await SaveAsync() > 0 ) return true;
            return false;
        }

        public async Task<bool> DeleteSubCategoryAsync(int categoryId, int subCategoryId)
        {
            var subCategory = await _context.SubCategories.FirstOrDefaultAsync(sub => sub.Id == categoryId && sub.Id == subCategoryId);
            if (subCategory == default) return false;

            subCategory.IsActive = !subCategory.IsActive;
            subCategory.IsDeleted = !subCategory.IsDeleted;

            if (await SaveAsync() > 0) return true;
            return false;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync() =>   await _context.Categories
                                                                                                                                        .Where(cat=>cat.IsActive)
                                                                                                                                        .OrderBy(cat => cat.CategoryName)
                                                                                                                                        .ToListAsync();


        public async Task<Category> GetCategoryAsync(int id, bool includeSubCategories = false)
        {
           if (includeSubCategories)
            {
                return await _context.Categories
                                            .Include(ent => ent.SubCategories)
                                            .FirstOrDefaultAsync(category => category.Id == id);
            }
            else
            {
                return await _context.Categories
                                        .FirstOrDefaultAsync(category => category.Id == id);
            }
        }

        public async Task<bool> IsCategoryValidAsync(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(cat => cat.Id == id);
            if (category == default(Category)) return false;
            return true;
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
