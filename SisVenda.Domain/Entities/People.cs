using SisVenda.Domain.ValueObjects;
using SisVenda.Shared.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace SisVenda.Domain.Entities
{
    public class People : Entity
    {
        public People(bool? isCustomer, bool? isSupplier, string name, string contact, string cPFCNPJ, string street, string number, string neighborhood, string city, string state, string zipCode, string adressEmail)
        {
            IsCustomer = isCustomer;
            IsSupplier = isSupplier;
            Name = name;
            Contact = contact;
            CPFCNPJ = cPFCNPJ;
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            ZipCode = zipCode;
            AdressEmail = adressEmail;
        }

        public bool? IsCustomer { get; private set; }
        public bool? IsSupplier { get; private set; }
        [Column(TypeName = "char(150)")]
        public string Name { get; private set; }
        [Column(TypeName = "char(150)")]
        public string Contact { get; private set; }
        [Column(TypeName = "char(25)")]
        public string CPFCNPJ { get; private set; }

        [Column(TypeName = "char(100)")]
        public string Street { get; private set; }
        [Column(TypeName = "char(10)")]
        public string Number { get; private set; }
        [Column(TypeName = "char(30)")]
        public string Neighborhood { get; private set; }
        [Column(TypeName = "char(50)")]
        public string City { get; private set; }
        [Column(TypeName = "char(2)")]
        public string State { get; private set; }
        [Column(TypeName = "char(10)")]
        public string ZipCode { get; private set; }
        [Column(TypeName = "char(50)")]
        public string AdressEmail { get; private set; }
    }
}
