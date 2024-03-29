﻿using System.Collections.Generic;

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
