using SisVenda.Domain.Base.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SisVenda.Domain.Entities
{
    public class BankAccount : Entity
    {
        public BankAccount(string account, string bankAgencyId)
        {
            Account = account;
            BankAgencyId = bankAgencyId;
        }

        [Column(TypeName = "char(25)")]
        public string Account { get; private set; }
        [Required]
        [Column(TypeName = "varchar(32)")]
        public string BankAgencyId { get; private set; }
        public BankAgency BankAgency { get; }
    }
}