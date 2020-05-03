using SisVenda.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace SisVenda.Domain.Queries
{
    public static class PeopleQuery
    {
        public static Expression<Func<People, bool>> GetAll()
        {
            return x => x.DtDeleted == null;
        }
        public static Expression<Func<People, bool>> GetCustomer()
        {
            return x => x.IsCustomer == true && x.DtDeleted == null;
        }
        public static Expression<Func<People, bool>> GetSupplier()
        {
            return x => x.IsSupplier == true && x.DtDeleted == null;
        }
    }
}
