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
    public class ProductsRepository : IProductsRepository
    {
        private readonly SisVendaContext _context;
        public ProductsRepository(SisVendaContext context)
        {
            _context = context;
        }

        public void Create(Products Products)
        {
            _context.Products.Add(Products);
            _context.SaveChangesAsync();
        }

        public void Update(Products Products)
        {
            _context.Entry(Products).State = EntityState.Modified;
            _context.SaveChangesAsync();
        }

        public void Delete(string id)
        {
            Products products = _context.Products.FirstOrDefault(x => x.Id == id);
            if (products != null)
            {
                products.Delete();
                _context.SaveChangesAsync();
            }
        }

        public Products GetById(string id)
        {
            return _context.Products.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Products> GetAll(ProductsFilter filter)
        {
            return _context.Products.AsNoTracking().Where(ProductsQuery.GetAll(filter));
        }
    }
}
