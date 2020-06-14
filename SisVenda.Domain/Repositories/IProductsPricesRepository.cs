using SisVenda.Domain.Entities;
using SisVenda.Shared.DTO.Filters;
using System.Collections.Generic;

namespace SisVenda.Domain.Repositories
{
    public interface IProductsPricesRepository
    {
        void Create(ProductsPrices ProductsPrices);
        void Update(ProductsPrices ProductsPrices);
        void Delete(string id);
        ProductsPrices GetById(string id);
        IEnumerable<ProductsPrices> GetAll(ProductsPricesFilter filter);
    }
}
