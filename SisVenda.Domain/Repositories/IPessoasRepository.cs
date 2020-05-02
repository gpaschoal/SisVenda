using SisVenda.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SisVenda.Domain.Repositories
{
    public interface IPessoasRepository
    {
        void Create(People People);
        void Update(People People);
        People GetById(Guid id);
        IEnumerable<People> GetAll();
        IEnumerable<People> GetCustomer();
        IEnumerable<People> GetSupplier();
    }
}
