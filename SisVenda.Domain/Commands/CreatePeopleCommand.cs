using Flunt.Notifications;
using Flunt.Validations;
using SisVenda.Domain.Commands.Contracts;

namespace SisVenda.Domain.Commands
{
    public class CreatePeopleCommand : Notifiable, ICommand
    {
        public CreatePeopleCommand() { }

        public CreatePeopleCommand(bool? isCustomer, bool? isSupplier, string name, string contact, string cpf, string cnpj, string street, string number, string neighborhood, string city, string state, string zipCode, string adressEmail, string phoneNumber)
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
                AddNotification(new Notification("IsSupplier", "É necessário que seja Cliente ou fornecedor!"));
            }
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(Name, 3, "Name", "O Nome precisa ter pelo menos 3 dígitos")
                    .HasMinLen(Contact, 4, "Contact", "O Contato precisa ter no mínimo 4 dígitos")
                    .HasMinLen(Street, 6, "Street", "A rua precisa ter no mínimo 6 dígitos")
                    .HasMinLen(Number, 1, "Number", "O número precisa ter pelo menos 1 dígito")
                    .HasMinLen(Neighborhood, 5, "Neighborhood", "O bairro precisa ter no mínimo 5 dígitos")
                    .HasMinLen(State, 2, "State", "A UF do estado precisa ter 2 dígitos")
                    .HasMaxLen(State, 2, "State", "A UF do estado precisa ter 2 dígitos")
                    .IsEmail(AdressEmail, "AdressEmail", "O e-mail é Inválido, por favor digite um e-mail válido!")
            );
        }
    }
}
