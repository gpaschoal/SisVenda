using SisVenda.Domain.Entities;
using SisVenda.Shared.DTO.Filters;
using System;
using System.Linq.Expressions;

namespace SisVenda.Domain.Queries
{
    public static class ProductsQuery
    {
        public static Expression<Func<Products, bool>> GetAll(ProductsFilter filter)
        {
            filter.Normalize();
            return products => products.DtDeleted == null &&
                    (products.Name ?? "").Trim().ToUpper().Contains(filter.Name) &&
                    (products.Description ?? "").Trim().ToUpper().Contains(filter.Description);
        }
    }
}
