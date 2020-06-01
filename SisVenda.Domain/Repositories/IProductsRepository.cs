using SisVenda.Domain.Entities;
using SisVenda.Shared.DTO.Filters;
using System.Collections.Generic;

namespace SisVenda.Domain.Repositories
{
    public interface IProductsRepository
    {
        void Create(Products Products);
        void Update(Products Products);
        void Delete(string id);
        Products GetById(string id);
        IEnumerable<Products> GetAll(ProductsFilter filter);
    }
}
