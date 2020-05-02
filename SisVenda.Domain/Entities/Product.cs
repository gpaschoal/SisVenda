using SisVenda.Shared.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace SisVenda.Domain.Entities
{
    public class Product : Entity
    {
        public Product(string name, string description, Guid idUnitMeasurement, double qtdStock)
        {
            Name = name;
            Description = description;
            IdUnitMeasurement = idUnitMeasurement;
            QtdStock = qtdStock;
        }

        [Column(TypeName = "varchar(150)")]
        public string Name { get; private set; }
        [Column(TypeName = "varchar(150)")]
        public string Description { get; private set; }
        public Guid IdUnitMeasurement { get; private set; }
        public UnitMeasurement UnitMeasurement { get; }
        [Column(TypeName = "decimal(10, 2)")]
        public double QtdStock { get; private set; }
        public IEnumerable<ProductPrices> ProductPrices { get; }
    }
}
