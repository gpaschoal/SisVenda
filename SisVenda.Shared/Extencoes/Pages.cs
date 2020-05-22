using SisVenda.Shared.DTO.Filters;
using System;
using System.Linq;

namespace SisVenda.Shared.Extencoes
{
    public static class Pages
    {
        /// <summary>
        /// Esse método é usado para criar as Paginações das Requests GetAll dos Controllers 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryable"></param>
        /// <param name="filterParam"></param>
        /// <returns>Returns FiltroPaginado, PageNumber, CountsByPage</returns>
        public static (IQueryable<T> page, int pageNumber, int pageCount) Paginator<T>(this IQueryable<T> queryable, IFilter filterParam)
        {
            int pageNumber = Math.Max(filterParam?.PageNumber ?? 0, 1),
                countsByPage = Math.Min(Math.Max(filterParam?.RowsByPage ?? 20, 10), 40) /* Range 10 ~ 40  */;
            return (queryable.Skip((pageNumber - 1) * countsByPage).Take(countsByPage),
                        pageNumber,
                        countsByPage);
        }
    }
}
