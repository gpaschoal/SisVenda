using SisVenda.Domain.Entities;
using SisVenda.Shared.DTO.Filters;
using System.Collections.Generic;

namespace SisVenda.Domain.Repositories
{
    public interface IPeopleRepository
    {
        void Create(People People);
        void Update(People People);
        void Delete(string id);
        People GetById(string id);
        IEnumerable<People> GetAll(PeopleFilter filter);
        IEnumerable<People> GetCustomer();
        IEnumerable<People> GetSupplier();
    }
}
