using System;
using System.Collections.Generic;

namespace Limoee.Infrastructure.Domain
{
    public class PagedResult<T>
    {
        public IList<T> Results { get; set; }

        public int CurrentPage { get; set; }

        /// <summary>
        /// تعداد صفحات
        /// </summary>
        public int TotalPages
        {
            get { return (int)Math.Ceiling((double)TotalCount / (double)PageSize); }
        }
        public int PageSize { get; set; }

        /// <summary>
        /// تعداد کل رکوردها
        /// </summary>
        public int TotalCount { get; set; }

        public bool HasMoreResults
        {
            get { return TotalCount > (TotalPages * PageSize); }
        }
    }
}