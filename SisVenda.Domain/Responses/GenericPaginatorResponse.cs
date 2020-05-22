using System.Collections.Generic;

namespace SisVenda.Domain.Responses
{
    public class GenericPaginatorResponse<T> where T : IResponse
    {
        public GenericPaginatorResponse(IEnumerable<T> page, int pageNumber)
        {
            Page = page;
            PageNumber = pageNumber;
        }
        public IEnumerable<T> Page { get; private set; }
        public int PageNumber { get; private set; }
    }
}
