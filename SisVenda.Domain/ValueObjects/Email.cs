using Flunt.Validations;
using SisVenda.Shared.ValueObjects;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SisVenda.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        //public Email(string adressEmail)
        //{
        //    AdressEmail = adressEmail;

        //    AddNotifications(new Contract()
        //        .Requires()
        //        .IsEmail(AdressEmail, "Email.Address", "E-mail inválido")
        //    );
        //}


        //[Column(TypeName = "char(50)")]
        //public string AdressEmail { get; private set; }

        //protected override IEnumerable<object> GetEqualityComponents()
        //{
        //    yield return AdressEmail;
        //}
    }
}
