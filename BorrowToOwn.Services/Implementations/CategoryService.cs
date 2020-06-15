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
            subCat.ForEach(s =>
            {
                s.CreatedBy = category.CreatedBy;
            });
            var cat = _mapper.Map<Category>(category);

            cat.TimeStampCreated = date;
            cat.SubCategories = subCat;

            var res = await _catRepo.AddCategoryAsync(cat);
            if (res == null) return null;

            var result = _mapper.Map<CategoryResponseObject>(res);
            return result;
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

        public async Task<IEnumerable<CategoryResponseObject>> GetCategoriesAsync()
        {
            var cats = await _catRepo.GetCategoriesAsync();
            return _mapper.Map<IEnumerable<CategoryResponseObject>>(cats);
        }

        public async Task<CategoryResponseObject> GetCategoryAsync(int id, bool includeSubCategories)
        {
            var cats = await _catRepo.GetCategoryAsync(id, includeSubCategories);
            if (cats == null) return null;
            return _mapper.Map<CategoryResponseObject>(cats);
        }

        public Task<bool> IsCategoryValidAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
