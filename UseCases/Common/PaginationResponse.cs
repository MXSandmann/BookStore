using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.Common
{
    public class PaginationResponse<T>
    {
        public PaginationResponse(IEnumerable<T> data, int count)
        {
            Data = data;
            Count = count;
        }

        public IEnumerable<T> Data { get; set; }
        public int Count { get; set; }
    }
}
