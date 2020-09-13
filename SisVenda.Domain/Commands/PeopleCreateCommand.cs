using Flunt.Notifications;
using Flunt.Validations;
using SisVenda.Domain.Commands.Contracts;

namespace SisVenda.Domain.Commands
{
    public class PeopleCreateCommand : Notifiable, ICommand
    {
        public PeopleCreateCommand() { }

        public PeopleCreateCommand(
            bool? isCustomer,
            bool? isSupplier,
            string name,
            string contact,
            string cpf,
            string cnpj,
            string street,
            string number,
            string neighborhood,
            string city,
            string state,
            string zipCode,
            string adressEmail,
            string phoneNumber)
        {
            IsCustomer = isCustomer;
            IsSupplier = isSupplier;
            Name = name;
            Contact = contact;
            CPF = cpf;
            CNPJ = cnpj;
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            ZipCode = zipCode;
            AdressEmail = adressEmail;
            PhoneNumber = phoneNumber;
        }

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
        public void Validate()
        {
            if (!(IsCustomer ?? false) && !(IsSupplier ?? false))
            {
                AddNotification(new Notification("IsCustomer", "É necessário que seja Cliente ou fornecedor!"));
            }
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsBetween(Name?.Trim().Length ?? 0, 3, 150, "Name", "O Nome precisa ter entre 3 e 150 dígitos")
                    .IsBetween(Contact?.Trim().Length ?? 0, 4, 150, "Contact", "O Contato precisa ter entre 4 e 150 dígitos")
                    .IsBetween(Street?.Trim().Length ?? 0, 4, 150, "Street", "O Contato precisa ter entre 4 e 150 dígitos")
                    .IsBetween(Number?.Trim().Length ?? 0, 1, 10, "Number", "O número do endereço precisa ter entre 1 e 150 dígitos")
                    .IsBetween(Neighborhood?.Trim().Length ?? 0, 5, 30, "Neighborhood", "O bairro precisa ter entre 5 e 30 dígitos")
                    .HasMaxLen(City, 50, "City", "A cidade precisa ter no máximo 50 dígitos")
                    .HasMaxLen(ZipCode, 10, "ZipCode", "O CEP precisa ter no máximo 10 dígitos")
                    .HasLen(State, 2, "State", "A UF do estado precisa ter 2 dígitos")
                    .HasMinLen(PhoneNumber, 8, "PhoneNumber", "O número do telefone precisa ter no mínimo 8 dígitos")
                    .HasMaxLen(PhoneNumber, 11, "PhoneNumber", "O número do telefone precisa ter no máximo 11 dígitos")
                    .HasMaxLen(CPF, 11, "CPF", "O número do CPF precisa ter no máximo 11 dígitos")
                    .HasMaxLen(CNPJ, 14, "CNPJ", "O número do CNPJ precisa ter no máximo 14 dígitos")
                    .IsEmail(AdressEmail, "AdressEmail", "O e-mail é Inválido, por favor digite um e-mail válido")
                    .HasMaxLen(AdressEmail, 50, "AddresEmail", "O e-mail precisa ter no máximo 50 dígitos")
            );
        }
    }
}
