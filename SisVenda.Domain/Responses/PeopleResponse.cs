using SisVenda.Domain.Entities;

namespace SisVenda.Domain.Responses
{
    public class PeopleResponse : IResponse
    {
        public PeopleResponse(People people)
        {
            Id = people.Id.Trim();
            IsCustomer = people.IsCustomer;
            IsSupplier = people.IsSupplier;
            Name = people.Name.Trim();
            Contact = people.Contact.Trim();
            CPF = people.CPF.Trim();
            CNPJ = people.CNPJ.Trim();
            Street = people.Street.Trim();
            Number = people.Number.Trim();
            Neighborhood = people.Neighborhood.Trim();
            City = people.City.Trim();
            State = people.State.Trim();
            ZipCode = people.ZipCode.Trim();
            AdressEmail = people.AdressEmail.Trim();
            PhoneNumber = people.PhoneNumber;
        }

        public string Id { get; private set; }
        public bool? IsCustomer { get; private set; }
        public bool? IsSupplier { get; private set; }
        public string Name { get; private set; }
        public string Contact { get; private set; }
        public string CPF { get; private set; }
        public string CNPJ { get; private set; }
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }
        public string AdressEmail { get; private set; }
        public string PhoneNumber { get; private set; }
    }
}
