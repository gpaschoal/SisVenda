﻿using Microsoft.EntityFrameworkCore;
using SisVenda.Domain.Entities;
using SisVenda.Domain.Queries;
using SisVenda.Domain.Repositories;
using SisVenda.Infra.Contexts;
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
        public void Create(People people)
        {
            _context.People.Add(people);
            _context.SaveChangesAsync();
        }

        public People GetById(string id)
        {
            return _context.People.FirstOrDefault(x => x.Id == id);
        }

        public void Update(People people)
        {
            _context.Entry(people).State = EntityState.Modified;
            _context.SaveChangesAsync();
        }

        public void Delete(string id)
        {
            People person = _context.People.FirstOrDefault(x => x.Id == id);
            if (person != null)
            {
                person.Delete();
                _context.SaveChangesAsync();
            }
        }

        public IEnumerable<People> GetAll()
        {
            return _context.People.AsNoTracking().Where(PeopleQuery.GetAll());
        }

        public IEnumerable<People> GetCustomer()
        {
            return _context.People.AsNoTracking().Where(PeopleQuery.GetCustomer());
        }

        public IEnumerable<People> GetSupplier()
        {
            return _context.People.AsNoTracking().Where(PeopleQuery.GetSupplier());
        }
    }
}
