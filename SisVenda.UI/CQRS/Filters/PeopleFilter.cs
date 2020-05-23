namespace SisVenda.UI.CQRS.Filters
{
    public class PeopleFilter
    {
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

        public int RowsByPage { get; set; }
        public int PageNumber { get; set; }
    }
}
