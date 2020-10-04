using SisVenda.Domain.Entities;
using SisVenda.Domain.Repositories;
using SisVenda.Shared.DTO.Filters;
using System.Collections.Generic;

namespace SisVenda.Domain.Tests.Repositories
{
    public class ProductsPricesRepositoryFake : IProductsPricesRepository
    {
        public void Create(ProductsPrices ProductsPrices) { }

        public void Delete(string id) { }

        public IEnumerable<ProductsPrices> GetAll(ProductsPricesFilter filter)
        {
            return null;
        }

        public ProductsPrices GetById(string id)
        {
            return null;
        }

        public void Update(ProductsPrices ProductsPrices) { }
    }
}
