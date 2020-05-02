using Flunt.Validations;
using SisVenda.Shared.ValueObjects;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SisVenda.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        //private Address()
        //{

        //}
        //public Address(string street, string number, string neighborhood, string city, string state, string zipCode)
        //{
        //    Street = street;
        //    Number = number;
        //    Neighborhood = neighborhood;
        //    City = city;
        //    State = state;
        //    ZipCode = zipCode;

        //    AddNotifications(new Contract()
        //        .Requires()
        //        .HasMinLen(Street, 3, "Address.Street", "A rua deve conter pelo menos 3 caracteres")
        //    );
        //}

        //[Column(TypeName = "char(100)")]
        //public string Street { get; private set; }
        //[Column(TypeName = "char(10)")]
        //public string Number { get; private set; }
        //[Column(TypeName = "char(30)")]
        //public string Neighborhood { get; private set; }
        //[Column(TypeName = "char(50)")]
        //public string City { get; private set; }
        //[Column(TypeName = "char(2)")]
        //public string State { get; private set; }
        //[Column(TypeName = "char(10)")]
        //public string ZipCode { get; private set; }

        //protected override IEnumerable<object> GetEqualityComponents()
        //{
        //    yield return Street;
        //    yield return Number;
        //    yield return Neighborhood;
        //    yield return City;
        //    yield return State;
        //    yield return ZipCode;
        //}
    }
}
