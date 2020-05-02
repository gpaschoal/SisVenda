using SisVenda.Shared.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace SisVenda.Domain.Entities
{
    public class UnitMeasurement : Entity
    {
        public UnitMeasurement(string name, double quantityLosses)
        {
            Name = name;
            QuantityLosses = quantityLosses;
        }

        [Column(TypeName = "varchar(150)")]
        public string Name { get; private set; }
        [Column(TypeName = "decimal(10, 2)")]
        public double QuantityLosses { get; private set; }
    }
}
