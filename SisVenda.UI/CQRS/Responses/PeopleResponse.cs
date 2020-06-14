namespace SisVenda.UI.CQRS.Responses
{
    public class PeopleResponse : IResponse
    {
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
