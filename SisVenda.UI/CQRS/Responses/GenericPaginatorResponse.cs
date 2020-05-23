using System.Collections.Generic;

namespace SisVenda.UI.CQRS.Filters
{
    public class GenericPaginatorResponse<T> : IFilter
    {
        public GenericPaginatorResponse()
        {
            PageNumber = 0;
            CountsInThisPage = 0;
            PageCount = 0;
            Page = new List<T>();
        }
        public int PageNumber { get; set; }
        public int CountsInThisPage { get; set; }
        public int PageCount { get; set; }
        public List<T> Page { get; set; }
        public int RowsByPage { get; set; }
    }
}