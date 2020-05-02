using SisVenda.Shared.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SisVenda.Domain.Entities
{
    public class PaymentMethods : Entity
    {
        public PaymentMethods(string name)
        {
            Name = name;
        }

        [Column(TypeName = "char(150)")]
        [Required]
        public string Name { get; private set; }
        public List<PurchasesPayments> PurchasesPayments { get; }
        public List<SalesPayment> SalesPayment { get; }
    }
}
