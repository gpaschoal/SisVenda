using SisVenda.Domain.Entities;
using SisVenda.Domain.Repositories;
using SisVenda.Shared.DTO.Filters;
using System.Collections.Generic;

namespace SisVenda.Domain.Tests.Repositories
{
    public class PeopleRepositoryFake : IPeopleRepository
    {
        public void Create(People People) { }

        public void Delete(string id) { }

        public IEnumerable<People> GetAll(PeopleFilter filter)
        {
            return null;
        }

        public People GetById(string id)
        {
            return null;
        }

        public IEnumerable<People> GetCustomer()
        {
            return null;
        }

        public IEnumerable<People> GetSupplier()
        {
            return null;
        }

        public void Update(People People) { }
    }
}
