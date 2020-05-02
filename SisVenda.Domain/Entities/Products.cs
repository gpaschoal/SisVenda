using SisVenda.Shared.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace SisVenda.Domain.Entities
{
    public class Products : Entity
    {
        public Products(string name, string description, string unitMeasurementId, double qtdStock)
        {
            Name = name;
            Description = description;
            UnitMeasurementId = unitMeasurementId;
            QtdStock = qtdStock;
        }

        [Column(TypeName = "varchar(150)")]
        public string Name { get; private set; }
        [Column(TypeName = "varchar(150)")]
        public string Description { get; private set; }
        public string UnitMeasurementId { get; private set; }
        public UnitMeasurement UnitMeasurement { get; }
        [Column(TypeName = "decimal(10, 2)")]
        public double QtdStock { get; private set; }
        public IEnumerable<ProductsPrices> ProductsPrices { get; }
        public IEnumerable<Losses> Losses { get; }
        public IEnumerable<SalesItems> SalesItems { get; }
        public IEnumerable<PurchasesItems> PurchasesItems { get; }
    }
}
