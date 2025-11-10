using AutoMapper;
using DomainLayer.Contracts;
using DomainLayer.Models.ProductModels;
using ServiceAbstraction;
using ServiceLayer.Specifications;
using Shared;
using Shared.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class ProductService(IUnitOfWork _unitOfWork,IMapper _mapper) : IProductService
    {
        public async Task<PaginatedResult<ProductDto>> GetAllProductAsync(ProductQueryParams queryParams)
        {
            var repo = _unitOfWork.GetRepository<Product, int>();
            var spec = new ProductWithBrandAndTypeSpecification(queryParams);
            var product = await repo.GetAllAsync(spec);
            var mappedProduct =_mapper.Map<IEnumerable<ProductDto>>(product);

            var countSpecs = new ProductCountSpecifications(queryParams);
            var totalCount= await repo.CountAsync(countSpecs);

            return new PaginatedResult<ProductDto>(queryParams.PageSize, queryParams.PageIndex, 0, mappedProduct);
        }

        public async Task<IEnumerable<ProductBrandDto>> GetAllProductBrandAsync()
        {
            var repo = await _unitOfWork.GetRepository<ProductBrand, int>().GetAllAsync();
            return _mapper.Map<IEnumerable<ProductBrandDto>>(repo);
        }

        public async Task<IEnumerable<ProductTypeDto>> GetAllProductTypesAsync()
        {

            var repo = await _unitOfWork.GetRepository<ProductType, int>().GetAllAsync();
            return _mapper.Map<IEnumerable<ProductTypeDto>>(repo);
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)

        {
            var spec = new ProductWithBrandAndTypeSpecification(id);
            var product = await _unitOfWork.GetRepository<Product,int>().GetByIdAsync(spec);
            return _mapper.Map<ProductDto>(product);

        }
    }
}
