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
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public BrandService(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository ?? throw new ArgumentNullException(nameof(brandRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<BrandResponseObject> AddBrandAsync(BrandRequestObject brand)
        {
            var result = await _brandRepository.AddBrandAsync(_mapper.Map<Brand>(brand));
            return result != null ?_mapper.Map<BrandResponseObject>(result) : null;
        }

        public async Task<BrandResponseObject> GetBrandAsync(int id)
        {
            var brand = await _brandRepository.GetBrand(id);
            return brand == null ? null :_mapper.Map<BrandResponseObject>(brand);
        }

        public async Task<IEnumerable<BrandResponseObject>> GetBrandsAsync()
        {
            var brands = await _brandRepository.GetBrands();
            return _mapper.Map<IEnumerable<BrandResponseObject>>(brands);
        }
    }
}
