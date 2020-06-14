using SisVenda.UI.CQRS.Responses;

namespace SisVenda.UI.CQRS.Commands
{
    public class PeopleUpdateCommand : IUpdateCommand
    {
        public PeopleUpdateCommand() { }
        public PeopleUpdateCommand(PeopleResponse response)
        {
            Id = response.Id;
            IsCustomer = response.IsCustomer;
            IsSupplier = response.IsSupplier;
            Name = response.Name;
            Contact = response.Contact;
            CPF = response.CPF;
            CNPJ = response.CNPJ;
            Street = response.Street;
            Number = response.Number;
            Neighborhood = response.Neighborhood;
            City = response.City;
            State = response.State;
            ZipCode = response.ZipCode;
            AdressEmail = response.AdressEmail;
            PhoneNumber = response.PhoneNumber;
        }
        public string Id { get; set; }
        public bool? IsCustomer { get; set; }
        public bool? IsSupplier { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string CPF { get; set; }
        public string CNPJ { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string AdressEmail { get; set; }
        public string PhoneNumber { get; set; }
    }
}
