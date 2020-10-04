using SisVenda.Domain.Entities;
using SisVenda.Domain.Repositories;
using SisVenda.Shared.DTO.Filters;
using System.Collections.Generic;

namespace SisVenda.Domain.Tests.Repositories
{
    public class ProductsRepositoryFake : IProductsRepository
    {
        public void Create(Products Products) { }

        public void Delete(string id) { }

        public IEnumerable<Products> GetAll(ProductsFilter filter)
        {
            return null;
        }

        public Products GetById(string id)
        {
            return null;
        }

        public void Update(Products Products) { }
    }
}
