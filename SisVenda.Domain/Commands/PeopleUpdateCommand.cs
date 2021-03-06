﻿using Flunt.Notifications;
using Flunt.Validations;
using SisVenda.Domain.Commands.Contracts;

namespace SisVenda.Domain.Commands
{
    public class PeopleUpdateCommand : Notifiable, ICommand
    {
        public PeopleUpdateCommand() { }

        public PeopleUpdateCommand(string id, bool? isCustomer, bool? isSupplier, string name, string contact, string CPF, string CNPJ, string street,
                string number, string neighborhood, string city, string state, string zipCode, string adressEmail, string phoneNumber)
        {
            Id = id;
            IsCustomer = isCustomer;
            IsSupplier = isSupplier;
            Name = name;
            Contact = contact;
            this.CPF = CPF;
            this.CNPJ = CNPJ;
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            ZipCode = zipCode;
            AdressEmail = adressEmail;
            PhoneNumber = phoneNumber;
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
        public void Validate()
        {
            if (!(IsCustomer ?? false) && !(IsSupplier ?? false))
            {
                AddNotification(new Notification("IsCustomer", "É necessário que seja Cliente ou fornecedor!"));
            }
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNullOrEmpty(Id, "Id", "É necessário identificar o código")
                    .IsBetween(Name?.Trim().Length ?? 0, 3, 150, "Name", "O Nome precisa ter pelo entre 3 e 150 dígitos")
                    .IsBetween(Contact?.Trim().Length ?? 0, 4, 150, "Contact", "O Contato precisa ter entre 4 e 150 dígitos")
                    .IsBetween(Street?.Trim().Length ?? 0, 6, 100, "Street", "A rua precisa ter entre 6 e 100 dígitos")
                    .IsBetween(Number?.Trim().Length ?? 0, 1, 10, "Number", "O número precisa ter entre 1 e 10 dígitos")
                    .IsBetween(Neighborhood?.Trim().Length ?? 0, 5, 30, "Neighborhood", "O bairro precisa ter entre 5 e 10 dígitos")
                    .HasMaxLen(City, 50, "City", "A cidade precisa ter no máximo 50 dígitos")
                    .HasMaxLen(ZipCode, 10, "ZipCode", "O CEP precisa ter no máximo 10 dígitos")
                    .HasLen(State, 2, "State", "A UF do estado precisa ter 2 dígitos")
                    .IsBetween(PhoneNumber?.Trim().Length ?? 0, 8, 11, "PhoneNumber", "O número do telefone precisa ter entre 8 e 11 dígitos")
                    .HasMaxLen(CPF, 11, "CPF", "O número do telefone precisa ter no máximo 11 dígitos")
                    .HasMaxLen(CNPJ, 14, "CNPJ", "O número do telefone precisa ter no máximo 14 dígitos")
                    .IsEmail(AdressEmail, "AdressEmail", "O e-mail é Inválido, por favor digite um e-mail válido")
                    .HasMaxLen(AdressEmail, 50, "AddresEmail", "O e-mail precisa ter no máximo 50 dígitos")
            );
        }
    }
}
