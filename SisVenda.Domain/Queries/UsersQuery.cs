using SisVenda.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace SisVenda.Domain.Queries
{
    public static class UsersQuery
    {
        public static Expression<Func<Users, bool>> Login()
        {
            return x => x.User.ToLower() == x.User.ToLower() && x.Password == x.Password && x.DtDeleted == null;
        }
    }
}
