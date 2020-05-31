using SisVenda.Domain.Base.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SisVenda.Domain.Entities
{
    public class PaymentStatus : Entity
    {
        public PaymentStatus(string description)
        {
            Description = description;
        }

        [Required]
        [Column(TypeName = "char(150)")]
        public string Description { get; private set; }
    }
}
