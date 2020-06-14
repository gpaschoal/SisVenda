using SisVenda.Domain.Entities;
using SisVenda.Shared.DTO.Filters;
using System;
using System.Linq.Expressions;

namespace SisVenda.Domain.Queries
{
    public static class ProductsPricesQuery
    {
        public static Expression<Func<ProductsPrices, bool>> GetAll(ProductsPricesFilter filter)
        {
            filter.Normalize();
            return products => products.DtDeleted == null
                    && (products.ProductsProfileId ?? "").Trim().ToUpper().Contains(filter.ProductsProfileId);
        }
    }
}
