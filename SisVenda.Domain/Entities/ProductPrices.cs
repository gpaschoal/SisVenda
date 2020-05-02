using SisVenda.Shared.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SisVenda.Domain.Entities
{
    public class ProductPrices : Entity
    {
        public ProductPrices(Guid idProduct, DateTime dtEffective, double salesCost, double salesPrice)
        {
            IdProduct = idProduct;
            DtEffective = dtEffective;
            SalesCost = salesCost;
            SalesPrice = salesPrice;
        }

        public Guid IdProduct { get; private set; }
        public Product Product { get; }
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime DtEffective { get; private set; }
        [Column(TypeName = "decimal(10, 2)")]
        public double SalesCost { get; private set; }
        [Column(TypeName = "decimal(10, 2)")]
        public double SalesPrice { get; private set; }
    }
}
