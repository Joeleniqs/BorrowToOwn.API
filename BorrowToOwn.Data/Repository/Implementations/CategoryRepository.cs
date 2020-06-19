using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BorrowToOwn.Data.Data;
using BorrowToOwn.Data.Models;
using BorrowToOwn.Data.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BorrowToOwn.Data.Repository.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BorrowContext _context;
        private readonly ILogger<CategoryRepository> _logger;

        public CategoryRepository(BorrowContext context,ILogger<CategoryRepository> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger;
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
            subCategory.CategoryId = categoryId;
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
            var subCategory = await _context.SubCategories.FirstOrDefaultAsync(sub => sub.Id == subCategoryId && sub.CategoryId == categoryId);
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
                                            .Where(category => category.Id == id && category.IsActive)
                                            .Include(ent => ent.SubCategories)
                                            .Select(c => new Category{
                                                Id = c.Id,
                                                CategoryName = c.CategoryName,
                                                IsActive = c.IsActive,
                                                IsDeleted = c.IsDeleted,
                                                IsModified = c.IsModified,
                                                CreatedBy = c.CreatedBy,
                                                LastModifiedBy = c.LastModifiedBy,
                                                TimeStampCreated = c.TimeStampCreated,
                                                TimeStampModified =c.TimeStampModified,
                                                SubCategories = c.SubCategories.Where(i => i.IsActive)
                                            })
                                            .FirstOrDefaultAsync() ;
               
            }
            else
            {
                return await _context.Categories
                                        .FirstOrDefaultAsync(category => category.Id == id && category.IsActive);
            }
        }

        public async Task<bool> IsCategoryValidAsync(int id,int subCategoryid = -1,bool toggleDeleteCheck = false)
        {
            Category category = new Category();
            if (subCategoryid > 0)
            {
                category = await _context.Categories
                                                .Include(cat => cat.SubCategories)
                                                .FirstOrDefaultAsync(cat => cat.Id == id && toggleDeleteCheck ? cat.IsActive || !cat.IsActive : cat.IsActive );

                if (category == default(Category)) return false;

                var subCat = category.SubCategories.FirstOrDefault(subCategory => subCategory.CategoryId == subCategoryid && toggleDeleteCheck ? subCategory.IsActive || !subCategory.IsActive : subCategory.IsActive);

                if (subCat == default(SubCategory)) return false;

                return true;
            }
            else
            {
                category = await _context.Categories.FirstOrDefaultAsync(cat => cat.Id == id && toggleDeleteCheck ? cat.IsActive || !cat.IsActive : cat.IsActive);

                if (category == default(Category)) return false;
                return true;
            }
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
