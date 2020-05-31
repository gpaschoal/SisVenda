using SisVenda.Domain.Base.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SisVenda.Domain.Entities
{
    public class BankAgency : Entity
    {
        public BankAgency(string name, string code, string bankId)
        {
            Name = name;
            Code = code;
            BankId = bankId;
        }
        [Column(TypeName = "char(150)")]
        public string Name { get; private set; }
        [Column(TypeName = "char(10)")]
        public string Code { get; private set; } /* This code is his own external Agency Code by bank - Unique by bank */
        [Required]
        [Column(TypeName = "varchar(32)")]
        public string BankId { get; private set; }
        public Bank Bank { get; }
        public IEnumerable<BankAccount> BankAccount { get; }
    }
}