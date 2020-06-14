using SisVenda.Domain.Entities;
using SisVenda.Shared.DTO.Filters;
using System;
using System.Linq.Expressions;

namespace SisVenda.Domain.Queries
{
    public static class PeopleQuery
    {
        public static Expression<Func<People, bool>> GetAll(PeopleFilter filter)
        {
            filter.Normalize();
            return people => people.DtDeleted == null &&
                    (people.IsCustomer == filter.IsCustomer || people.IsSupplier == filter.IsSupplier) &&
                    (people.Name ?? "").Trim().ToUpper().Contains(filter.Name) &&
                    (people.Contact ?? "").Trim().ToUpper().Contains(filter.Contact) &&
                    (people.CPF ?? "").Trim().ToUpper().Contains(filter.CPF) &&
                    (people.CNPJ ?? "").Trim().ToUpper().Contains(filter.CNPJ) &&
                    (people.Street ?? "").Trim().ToUpper().Contains(filter.Street) &&
                    (people.Number ?? "").Trim().ToUpper().Contains(filter.Number) &&
                    (people.Neighborhood ?? "").Trim().ToUpper().Contains(filter.Neighborhood) &&
                    (people.City ?? "").Trim().ToUpper().Contains(filter.City) &&
                    (people.State ?? "").Trim().ToUpper().Contains(filter.Street) &&
                    (people.ZipCode ?? "").Trim().ToUpper().Contains(filter.ZipCode) &&
                    (people.AdressEmail ?? "").Trim().ToUpper().Contains(filter.AdressEmail) &&
                    (people.PhoneNumber ?? "").Trim().ToUpper().Contains(filter.PhoneNumber);
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
