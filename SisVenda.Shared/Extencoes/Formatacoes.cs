using SisVenda.Shared.DTO.Filters;
using System;
using System.Linq;
using System.Text;

namespace SisVenda.Shared.Extencoes
{
    public static class Formatacoes
    {
        public static string FormatCPF(this string cpf)
        {
            return Convert.ToUInt64(cpf.RetirarCaracteresEspeciais().PadLeft(11, '0')).ToString(@"000\.000\.000\-00");
        }
        public static string FormatCNPJ(this string cnpj)
        {
            return Convert.ToUInt64(cnpj.RetirarCaracteresEspeciais().PadLeft(14, '0')).ToString(@"00\.000\.000/0000\-00");
        }
        public static string FormatCEP(this string cep)
        {
            return Convert.ToUInt64(cep.RetirarCaracteresEspeciais().PadLeft(8, '0')).ToString(@"00000\-000");
        }
        public static string RetirarCaracteresEspeciais(this string str)
        {
            if (string.IsNullOrEmpty(str)) return "";

            StringBuilder sb = new StringBuilder();

            foreach (char c in str)
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
                    sb.Append(c);

            return sb.ToString();
        }
        /// <summary>
        /// Esse método é usado para criar as Paginações das Requests GetAll dos Controllers 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryable"></param>
        /// <param name="filterParam"></param>
        /// <returns>Returns FiltroPaginado, PageNumber, CountsByPage</returns>
        public static (IQueryable<T>, int, int) Paginador<T>(this IQueryable<T> queryable, IFilter filterParam)
        {
            int pageNumber = Math.Max(filterParam?.PageNumber ?? 0, 1),
                countsByPage = Math.Min(Math.Max(filterParam?.RowsByPage ?? 20, 10), 40) /* Range 10 ~ 40  */;
            return (queryable.Skip((pageNumber - 1) * countsByPage).Take(countsByPage),
                        pageNumber,
                        countsByPage);
        }
    }
}
