using SisVenda.Domain.Entities;
using SisVenda.Shared.DTO.Filters;
using System;
using System.Linq.Expressions;

namespace SisVenda.Domain.Queries
{
    public static class ProductsProfileQuery
    {
        public static Expression<Func<ProductsProfile, bool>> GetAll(ProductsProfileFilter filter)
        {
            filter.Normalize();
            return products => products.DtDeleted == null
                    && (products.ProductsId ?? "").Trim().ToUpper().Contains(filter.ProductsId)
                    && (products.BarCode ?? "").Trim().ToUpper().Contains(filter.BarCode);
        }
    }
}
