using SisVenda.Domain.Entities;
using SisVenda.Domain.Repositories;
using SisVenda.Infra.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SisVenda.Infra.Repositories
{
    public class PessoasRepository : IPeopleRepository
    {
        private readonly SisVendaContext _context;
        public PessoasRepository(SisVendaContext context)
        {
            _context = context;
        }
        public void Create(People pessoa)
        {
            _context.People.Add(pessoa);
        }

        public People GetById(string id)
        {
            return _context.People.FirstOrDefault(x => x.Id == id);
        }

        public void Update(People pessoa)
        {
            People person = _context.People.FirstOrDefault(x => x.Id == pessoa.Id);
            if (person != null)
            {
                person = pessoa;
                _ = _context.SaveChangesAsync();
            }
        }

        public void Delete(string id)
        {
            People person = _context.People.FirstOrDefault(x => x.Id == id);
            if (person != null)
            {
                person.Delete();
                _ = _context.SaveChangesAsync();
            }
        }

        public IEnumerable<People> GetAll()
        {
            return _context.People.Where(x => x.DtDeleted == null);
        }

        public IEnumerable<People> GetCustomer()
        {
            return _context.People.Where(x => x.IsCustomer == true && x.DtDeleted == null);
        }

        public IEnumerable<People> GetSupplier()
        {
            return _context.People.Where(x => x.IsSupplier == true && x.DtDeleted == null);
        }
    }
}
