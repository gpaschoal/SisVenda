using SisVenda.Domain.Base.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SisVenda.Domain.Entities
{
    public class Products : Entity
    {
        public Products(string name, string description, double quantityStock)
        {
            Name = name;
            Description = description;
            QuantityStock = quantityStock;
        }
        [Required]
        [Column(TypeName = "varchar(150)")]
        public string Name { get; private set; }
        [Required]
        [Column(TypeName = "varchar(150)")]
        public string Description { get; private set; }
        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public double QuantityStock { get; private set; }
        public IEnumerable<ProductsProfile> ProductsProfile { get; }
    }
}
