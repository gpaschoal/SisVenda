using Microsoft.EntityFrameworkCore;
using SisVenda.Domain.Entities;
using SisVenda.Domain.Queries;
using SisVenda.Domain.Repositories;
using SisVenda.Infra.Contexts;
using SisVenda.Shared.DTO.Filters;
using System.Collections.Generic;
using System.Linq;

namespace SisVenda.Infra.Repositories
{
    public class ProductsProfileRepository : IProductsProfileRepository
    {
        private readonly SisVendaContext _context;

        public ProductsProfileRepository(SisVendaContext context)
        {
            _context = context;
        }

        public void Create(ProductsProfile ProductsProfile)
        {
            _context.ProductsProfile.Add(ProductsProfile);
            _context.SaveChangesAsync();
        }

        public void Update(ProductsProfile ProductsProfile)
        {
            _context.Entry(ProductsProfile).State = EntityState.Modified;
            _context.SaveChangesAsync();
        }

        public void Delete(string id)
        {
            ProductsProfile productsProfile = _context.ProductsProfile.FirstOrDefault(x => x.Id == id);
            if (productsProfile != null)
            {
                productsProfile.Delete();
                _context.SaveChangesAsync();
            }
        }

        public ProductsProfile GetById(string id)
        {
            return _context.ProductsProfile.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<ProductsProfile> GetAll(ProductsProfileFilter filter)
        {
            return _context.ProductsProfile.AsNoTracking().Where(ProductsProfileQuery.GetAll(filter));
        }

        public ProductsProfile GetByBarCode(string barCode)
        {
            return _context.ProductsProfile.AsNoTracking().FirstOrDefault(x => x.BarCode == barCode && x.DtDeleted == null);
        }
    }
}
