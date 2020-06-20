using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BorrowToOwn.Data.Models;
using BorrowToOwn.Data.Repository.Contracts;
using BorrowToOwn.Services.Communications.RequestObject.DTO;
using BorrowToOwn.Services.Communications.ResponseObject.DTO;
using BorrowToOwn.Services.Contracts;

namespace BorrowToOwn.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _catRepo;

        public CategoryService(IMapper mapper, ICategoryRepository categoryRepo)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(categoryRepo));
            _catRepo = categoryRepo ?? throw new ArgumentNullException(nameof(categoryRepo));

        }
        public async Task<CategoryResponseObject> AddCategoryAsync(CategoryRequestObject category)
        {
            var date = DateTimeOffset.Now;
            var subCat = _mapper.Map<List<SubCategory>>(category.SubCategories);
            subCat.ForEach(s =>  s.CreatedBy = category.CreatedBy);
            var cat = _mapper.Map<Category>(category);

            cat.TimeStampCreated = date;
            cat.SubCategories = subCat;

            var res = await _catRepo.AddCategoryAsync(cat);
            if (res == null) return null;

            var result = _mapper.Map<CategoryResponseObject>(res);
            return result;
        }

        public async Task<bool> AddSubCategoryAsync(int categoryId, SubCategoryRequestObject subCategory)
        {
            var sub = _mapper.Map<SubCategory>(subCategory);
            var added = await _catRepo.AddSubCategoryAsync(categoryId, sub);
            if (!added) return false;
            return true;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var deleted = await _catRepo.DeleteCategoryAsync(id);
            if (!deleted) return false;
            return true;
        }

        public async  Task<bool> DeleteSubCategoryAsync(int categoryId, int subCategoryId)
        {
            var deleted = await _catRepo.DeleteSubCategoryAsync(categoryId, subCategoryId);
            if (!deleted) return false;
            return true;
        }

        public async Task<IEnumerable<CategoryResponseObject>> GetCategoriesAsync()
        {
            var cats = await _catRepo.GetCategoriesAsync();
            return _mapper.Map<IEnumerable<CategoryResponseObject>>(cats);
        }

        public async Task<CategoryResponseObject> GetCategoryAsync(int id, bool includeSubCategories = false)
        {
            var cats = await _catRepo.GetCategoryAsync(id, includeSubCategories);
            if (cats == null) return null;
            return _mapper.Map<CategoryResponseObject>(cats);
        }

        public async Task<bool> IsCategoryValidAsync(int id,int subCategoryId = -1,bool isDeleteToggle = false)
        {
            var check = await _catRepo.IsCategoryValidAsync(id, subCategoryId);
            if (!check) return false;
            return true;
        }
    }
}
