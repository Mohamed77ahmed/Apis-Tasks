using AutoMapper;
using DomainLayer.Contracts;
using DomainLayer.Models.ProductModels;
using ServiceAbstraction;
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
        public async Task<IEnumerable<ProductDto>> GetAllProductAsync()
        {
            var repo = await _unitOfWork.GetRepository<Product , int>().GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(repo);
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
            var product = await _unitOfWork.GetRepository<Product,int>().GetByIdAsync(id);
            return _mapper.Map<ProductDto>(product);

        }
    }
}
