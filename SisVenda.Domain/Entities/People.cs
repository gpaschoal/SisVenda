using SisVenda.Domain.Base.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SisVenda.Domain.Entities
{
    public class People : Entity
    {
        public People(bool isCustomer, bool isSupplier, string name, string contact, string cPF, string cNPJ, string street, string number, string neighborhood, string city, string state, string zipCode, string adressEmail, string phoneNumber)
        {
            IsCustomer = isCustomer;
            IsSupplier = isSupplier;
            Name = name;
            Contact = contact;
            CPF = cPF;
            CNPJ = cNPJ;
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            ZipCode = zipCode;
            AdressEmail = adressEmail;
            PhoneNumber = phoneNumber;
        }
        [Required]
        public bool IsCustomer { get; private set; }
        [Required]
        public bool IsSupplier { get; private set; }
        [Required]
        [Column(TypeName = "char(150)")]
        public string Name { get; private set; }
        [Required]
        [Column(TypeName = "char(150)")]
        public string Contact { get; private set; }
        [Required]
        [Column(TypeName = "char(11)")]
        public string CPF { get; private set; }
        [Required]
        [Column(TypeName = "char(14)")]
        public string CNPJ { get; private set; }
        [Required]
        [Column(TypeName = "char(100)")]
        public string Street { get; private set; }
        [Required]
        [Column(TypeName = "char(10)")]
        public string Number { get; private set; }
        [Required]
        [Column(TypeName = "char(30)")]
        public string Neighborhood { get; private set; }
        [Required]
        [Column(TypeName = "char(50)")]
        public string City { get; private set; }
        [Required]
        [Column(TypeName = "char(2)")]
        public string State { get; private set; }
        [Required]
        [Column(TypeName = "char(10)")]
        public string ZipCode { get; private set; }
        [Required]
        [Column(TypeName = "char(50)")]
        public string AdressEmail { get; private set; }
        [Required]
        [Column(TypeName = "char(11)")]
        public string PhoneNumber { get; private set; }
        public IEnumerable<Sales> Sales { get; }
        public IEnumerable<Purchases> Purchases { get; }
        public void Update(bool? isCustomer, bool? isSupplier, string name, string contact, string cPF, string cNPJ, string street, string number, string neighborhood, string city,
                    string state, string zipCode, string adressEmail, string phoneNumber)
        {
            IsCustomer = isCustomer ?? false;
            IsSupplier = isSupplier ?? false;
            Name = name;
            Contact = contact;
            CPF = cPF;
            CNPJ = cNPJ;
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            ZipCode = zipCode;
            AdressEmail = adressEmail;
            PhoneNumber = phoneNumber;
        }
    }
}
