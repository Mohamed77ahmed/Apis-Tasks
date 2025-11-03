using Shared.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction
{
    public interface IProductService
    {
        //GetAll product 
        Task<IEnumerable<ProductDto>> GetAllProductAsync();
        //GetProductById
        Task<ProductDto> GetProductByIdAsync(int id);
        //GetAll Product Brand
        Task<IEnumerable<ProductBrandDto>> GetAllProductBrandAsync();
        //GetAll Product Types
        Task<IEnumerable<ProductTypeDto>> GetAllProductTypesAsync();




    }
}
