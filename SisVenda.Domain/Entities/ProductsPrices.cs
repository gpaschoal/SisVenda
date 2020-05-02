using SisVenda.Shared.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SisVenda.Domain.Entities
{
    public class ProductsPrices : Entity
    {
        public ProductsPrices(string productId, DateTime dtEffective, double salesCost, double salesPrice)
        {
            ProductId = productId;
            DtEffective = dtEffective;
            SalesCost = salesCost;
            SalesPrice = salesPrice;
        }

        public string ProductId { get; private set; }
        public Products Product { get; }
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime DtEffective { get; private set; }
        [Column(TypeName = "decimal(10, 2)")]
        public double SalesCost { get; private set; }
        [Column(TypeName = "decimal(10, 2)")]
        public double SalesPrice { get; private set; }
    }
}
