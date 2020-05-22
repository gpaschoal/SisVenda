using SisVenda.Domain.Entities;

namespace SisVenda.Domain.Responses
{
    public class PeopleResponse : IResponse
    {
        public PeopleResponse(People people)
        {
            Id = people.Id;
            IsCustomer = people.IsCustomer;
            IsSupplier = people.IsSupplier;
            Name = people.Name;
            Contact = people.Contact;
            CPF = people.CPF;
            CNPJ = people.CNPJ;
            Street = people.Street;
            Number = people.Number;
            Neighborhood = people.Neighborhood;
            City = people.City;
            State = people.State;
            ZipCode = people.ZipCode;
            AdressEmail = people.AdressEmail;
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
