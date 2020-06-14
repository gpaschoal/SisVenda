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
    public class ProductsPricesRepository : IProductsPricesRepository
    {
        private readonly SisVendaContext _context;
        public ProductsPricesRepository(SisVendaContext context)
        {
            _context = context;
        }

        public void Create(ProductsPrices ProductsPrices)
        {
            _context.ProductsPrices.Add(ProductsPrices);
            _context.SaveChangesAsync();
        }

        public void Update(ProductsPrices ProductsPrices)
        {
            _context.Entry(ProductsPrices).State = EntityState.Modified;
            _context.SaveChangesAsync();
        }

        public void Delete(string id)
        {
            ProductsPrices ProductsPrices = _context.ProductsPrices.FirstOrDefault(x => x.Id == id);
            if (ProductsPrices != null)
            {
                ProductsPrices.Delete();
                _context.SaveChangesAsync();
            }
        }

        public ProductsPrices GetById(string id)
        {
            return _context.ProductsPrices.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<ProductsPrices> GetAll(ProductsPricesFilter filter)
        {
            return _context.ProductsPrices.AsNoTracking().Where(ProductsPricesQuery.GetAll(filter));
        }
    }
}
