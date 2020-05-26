using SisVenda.Shared.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        [Column(TypeName = "varchar(150)")]
        public string Name { get; private set; }
        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public double QuantityLosses { get; private set; }
        public IEnumerable<Products> Products { get; set; }

        public void Update(string name, double quantityLosses)
        {
            Name = name;
            QuantityLosses = quantityLosses;
        }
    }
}
