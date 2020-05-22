using SisVenda.Shared.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SisVenda.Domain.Entities
{
    public class BankAgency : Entity
    {
        public BankAgency(string name, string code, string bankId)
        {
            this.Name = name;
            this.Code = code;
            this.BankId = bankId;
        }
        [Column(TypeName = "char(150)")]
        public string Name { get; private set; }
        [Column(TypeName = "char(10)")]
        public string Code { get; private set; } /* This code is his own external Agency Code by bank - Unique by bank */
        public string BankId { get; private set; }
        public Bank Bank { get; }
        public IEnumerable<BankAccount> BankAccount { get; }
    }
}