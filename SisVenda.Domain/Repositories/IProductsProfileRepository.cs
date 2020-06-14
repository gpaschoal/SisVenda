using SisVenda.Domain.Entities;
using SisVenda.Shared.DTO.Filters;
using System.Collections.Generic;

namespace SisVenda.Domain.Repositories
{
    public interface IProductsProfileRepository
    {
        void Create(ProductsProfile ProductsProfile);
        void Update(ProductsProfile ProductsProfile);
        void Delete(string id);
        ProductsProfile GetById(string id);
        ProductsProfile GetByBarCode(string barCode);
        IEnumerable<ProductsProfile> GetAll(ProductsProfileFilter filter);
    }
}
