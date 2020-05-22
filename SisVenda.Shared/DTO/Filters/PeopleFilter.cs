namespace SisVenda.Shared.DTO.Filters
{
    public class PeopleFilter : IFilter
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

        public void Normalize()
        {
            IsCustomer ??= false;
            IsSupplier ??= false;
            Name ??= "";
            Name = Name.ToUpper().Trim();
            Contact ??= "";
            Contact = Contact.ToUpper().Trim();
            CPF ??= "";
            CPF = CPF.ToUpper().Trim();
            CNPJ ??= "";
            CNPJ = CNPJ.ToUpper().Trim();
            Street ??= "";
            Street = Street.ToUpper().Trim();
            Number ??= "";
            Number = Number.ToUpper().Trim();
            Neighborhood ??= "";
            Neighborhood = Neighborhood.ToUpper().Trim();
            City ??= "";
            City = City.ToUpper().Trim();
            State ??= "";
            State = State.ToUpper().Trim();
            ZipCode ??= "";
            ZipCode = ZipCode.ToUpper().Trim();
            AdressEmail ??= "";
            AdressEmail = AdressEmail.ToUpper().Trim();
            PhoneNumber ??= "";
            PhoneNumber = PhoneNumber.ToUpper().Trim();
        }
    }
}
