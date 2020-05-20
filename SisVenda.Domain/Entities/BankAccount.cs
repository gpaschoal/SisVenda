using System.ComponentModel.DataAnnotations.Schema;
using SisVenda.Shared.Entities;

namespace SisVenda.Domain.Entities
{
    public class BankAccount: Entity
    {
        public BankAccount(string account, string bankAgencyId)
        {
            this.Account = account;
            this.BankAgencyId = bankAgencyId;
        }

        [Column(TypeName = "char(25)")]
        public string Account { get; private set; }
        public string BankAgencyId { get; private set; }
        public BankAgency BankAgency { get; }
    }
}