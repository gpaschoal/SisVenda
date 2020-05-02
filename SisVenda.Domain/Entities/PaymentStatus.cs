using SisVenda.Shared.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace SisVenda.Domain.Entities
{
    public class PaymentStatus : Entity
    {
        [Column(TypeName = "char(150)")]
        public string Description { get; private set; }
    }
}
