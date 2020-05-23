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

        private static bool Filter(People people, PeopleFilter filter)
        {
            return people.IsCustomer == (filter.IsCustomer ?? false) && people.IsSupplier == (filter.IsSupplier ?? false) &&
                    (people.Name ?? "").Trim().ToUpper().Contains(filter.Name == null ? "" : filter.Name.Trim().ToUpper()) &&
                    (people.Contact ?? "").Trim().ToUpper().Contains(filter.Contact == null ? "" : filter.Contact.Trim().ToUpper()) &&
                    (people.CPF ?? "").Trim().ToUpper().Contains(filter.CPF == null ? "" : filter.CPF.Trim().ToUpper()) &&
                    (people.CNPJ ?? "").Trim().ToUpper().Contains(filter.CNPJ == null ? "" : filter.CNPJ.Trim().ToUpper()) &&
                    (people.Street ?? "").Trim().ToUpper().Contains(filter.Street == null ? "" : filter.Street.Trim().ToUpper()) &&
                    (people.Number ?? "").Trim().ToUpper().Contains(filter.Number == null ? "" : filter.Number.Trim().ToUpper()) &&
                    (people.Neighborhood ?? "").Trim().ToUpper().Contains(filter.Neighborhood == null ? "" : filter.Neighborhood.Trim().ToUpper()) &&
                    (people.City ?? "").Trim().ToUpper().Contains(filter.City == null ? "" : filter.City.Trim().ToUpper()) &&
                    (people.State ?? "").Trim().ToUpper().Contains(filter.Street == null ? "" : filter.State.Trim().ToUpper()) &&
                    (people.ZipCode ?? "").Trim().ToUpper().Contains(filter.ZipCode == null ? "" : filter.ZipCode.Trim().ToUpper()) &&
                    (people.AdressEmail ?? "").Trim().ToUpper().Contains(filter.AdressEmail == null ? "" : filter.AdressEmail.Trim().ToUpper()) &&
                    (people.PhoneNumber ?? "").Trim().ToUpper().Contains(filter.PhoneNumber == null ? "" : filter.PhoneNumber.Trim().ToUpper());
        }
    }
}
