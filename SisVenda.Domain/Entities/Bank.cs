using SisVenda.Domain.Base.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SisVenda.Domain.Entities
{
    public class Bank : Entity
    {
        public Bank(string name, string code)
        {
            Name = name;
            Code = code;
        }
        [Column(TypeName = "char(150)")]
        public string Name { get; private set; }
        [Column(TypeName = "char(10)")]
        public string Code { get; private set; } /* This code is his own external Bank Code */
        public IEnumerable<BankAgency> BankAgency { get; }
    }
}