using DomainLayer.Models.ProductModels;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Specifications
{
    public class ProductWithBrandAndTypeSpecification: BaseSpecifications<Product,int>
    {
        //GetAll
        public ProductWithBrandAndTypeSpecification(ProductQueryParams queryParams) :
            base(p=> (!queryParams.BrandId.HasValue || p.BrandId== queryParams.BrandId) && (!queryParams.TypeId.HasValue || p.TypeId == queryParams.TypeId) && (string.IsNullOrWhiteSpace(queryParams.SearchValue)||p.Name.ToLower().Contains(queryParams.SearchValue.ToLower())))
        {  
            AddInclude(p =>p.ProductBrand);
            AddInclude(p =>p.ProductType);

            switch (queryParams.SortingOption)
            {
                case ProductSortingOption.NameAsc:
                    AddOrderBy(p => p.Name);
                    break;
                case ProductSortingOption.NameDesc:
                    AddOrderByDescending(p => p.Name);
                    break;
                 
                case ProductSortingOption.Price:
                    AddOrderBy(p => p.Price);
                    break;
                case ProductSortingOption.PriceDesc:
                    AddOrderByDescending(p => p.Price);
                    break;
                default:
                    break;
            }

            ApplyPagination(queryParams.PageSize, queryParams.PageIndex);
        }
        public ProductWithBrandAndTypeSpecification(int id) : base(p=>p.Id==id)
        {
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);

        }
    }
}
