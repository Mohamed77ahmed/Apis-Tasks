using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class ProductQueryParams
    {
        public int? BrandId { get; set; }
        public int? TypeId { get; set; }
        public ProductSortingOption SortingOption { get; set; }
        public string? SearchValue { get; set; }

        private const int DefultPageSize = 5;
        private const int MaxPageSize = 5;
        private int pageSize;

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value>MaxPageSize ? MaxPageSize : DefultPageSize; }
        }

        public int PageIndex { get; set; }
    }
}
