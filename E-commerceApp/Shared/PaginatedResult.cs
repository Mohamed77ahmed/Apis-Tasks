using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class PaginatedResult<Dto>
    {
        public PaginatedResult(int pageSize, int pageIndex, int totalCount, IEnumerable<Dto> data)
        {
            PageSize = pageSize;
            PageIndex = pageIndex;
            TotalCount = totalCount;
            Data = data;
        }

        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public int TotalCount { get; set; }
        public IEnumerable<Dto> Data { get; set; }


    }
}
