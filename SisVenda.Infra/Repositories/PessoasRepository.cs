using SisVenda.Domain.Entities;
using SisVenda.Domain.Repositories;
using System;
using System.Collections.Generic;

namespace SisVenda.Infra.Repositories
{
    public class PessoasRepository : IPessoasRepository
    {
        public void Create(People pessoa)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<People> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<People> GetCustomer()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<People> GetSupplier()
        {
            throw new NotImplementedException();
        }

        public People GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(People pessoa)
        {
            throw new NotImplementedException();
        }
    }
}
