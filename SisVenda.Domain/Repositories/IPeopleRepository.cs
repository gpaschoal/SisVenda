using SisVenda.Domain.Entities;
using System.Collections.Generic;

namespace SisVenda.Domain.Repositories
{
    public interface IPeopleRepository
    {
        void Create(People People);
        void Update(People People);
        void Delete(string id);
        People GetById(string id);
        IEnumerable<People> GetAll();
        IEnumerable<People> GetCustomer();
        IEnumerable<People> GetSupplier();
    }
}
