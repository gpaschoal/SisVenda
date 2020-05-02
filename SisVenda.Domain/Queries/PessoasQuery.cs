using SisVenda.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace SisVenda.Domain.Queries
{
    public static class PessoasQuery
    {
        public static Expression<Func<People, bool>> GetAll()
        {
            return x => x.DtDeleted == null;
        }
        public static Expression<Func<People, bool>> GetClientes()
        {
            return x => x.IsCustomer == true && x.DtDeleted == null;
        }
        public static Expression<Func<People, bool>> GetFornecedores()
        {
            return x => x.IsSupplier == true && x.DtDeleted == null;
        }
    }
}
