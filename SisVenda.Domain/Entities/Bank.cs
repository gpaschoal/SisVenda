using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using SisVenda.Shared.Entities;

namespace SisVenda.Domain.Entities
{
    public class Bank : Entity
    {
        public Bank(string name, string code)
        {
            this.Name = name;
            this.Code = code;
        }
        [Column(TypeName = "char(150)")]
        public string Name { get; private set; }
        [Column(TypeName = "char(10)")]
        public string Code { get; private set; } /* This code is his own external Bank Code */
        public IEnumerable<BankAgency> BankAgency { get; }
    }
}