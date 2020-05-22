using SisVenda.Shared.DTO.Filters;
using System;
using System.Linq;

namespace SisVenda.Shared.Extencoes
{
    public static class Pages
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">This type is my entity type</typeparam>
        /// <param name="queryable"></param>
        /// <param name="filterParam"></param>
        /// <returns></returns>
        public static (IQueryable<T> page, int pageNumber, int countsInThisPage, int pageCount) Paginator<T>(this IQueryable<T> queryable, IFilter filterParam)
        {
            int pageNumber = Math.Max(filterParam?.PageNumber ?? 0, 1),
                countsByPage = Math.Min(Math.Max(filterParam?.RowsByPage ?? 20, 10), 40) /* Range 10 ~ 40  */;
            double pageCount = Convert.ToDouble(queryable.AsEnumerable().Count()) / countsByPage;

            return (queryable.Skip((pageNumber - 1) * countsByPage).Take(countsByPage),
                        pageNumber,
                        countsByPage,
                        Convert.ToInt32(Math.Floor(pageCount) + (pageCount % 1 == 0 ? 0 : 1)));
        }
    }
}
