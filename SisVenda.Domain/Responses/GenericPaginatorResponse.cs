using System.Collections.Generic;

namespace SisVenda.Domain.Responses
{
    public class GenericPaginatorResponse<T> where T : IResponse
    {
        public GenericPaginatorResponse(int pageNumber, int countsInThisPage, int pageCount, IEnumerable<T> page)
        {
            PageNumber = pageNumber;
            CountsInThisPage = countsInThisPage;
            PageCount = pageCount;
            Page = page;
        }

        public int PageNumber { get; private set; }
        public int CountsInThisPage { get; private set; }
        public int PageCount { get; private set; }
        public IEnumerable<T> Page { get; private set; }
    }
}
