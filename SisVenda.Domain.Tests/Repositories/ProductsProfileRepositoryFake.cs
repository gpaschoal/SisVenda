using SisVenda.Domain.Entities;
using SisVenda.Domain.Repositories;
using SisVenda.Shared.DTO.Filters;
using System.Collections.Generic;

namespace SisVenda.Domain.Tests.Repositories
{
    public class ProductsProfileRepositoryFake : IProductsProfileRepository
    {
        public void Create(ProductsProfile ProductsProfile) { }

        public void Delete(string id) { }

        public IEnumerable<ProductsProfile> GetAll(ProductsProfileFilter filter)
        {
            return null;
        }

        public ProductsProfile GetByBarCode(string barCode)
        {
            return null;
        }

        public ProductsProfile GetById(string id)
        {
            return null;
        }

        public void Update(ProductsProfile ProductsProfile) { }
    }
}
