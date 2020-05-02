using SisVenda.Shared.Entities;
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
        public string Name { get; private set; }
    }
}
