using SisVenda.Domain.Base.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SisVenda.Domain.Entities
{
    public class ProductsPrices : Entity
    {
        public ProductsPrices(string productsProfileId, DateTime dtEffective, double averagePurchaseCost, double salesPrice)
        {
            ProductsProfileId = productsProfileId;
            DtEffective = dtEffective;
            AveragePurchaseCost = averagePurchaseCost;
            SalesPrice = salesPrice;
        }
        [Required]
        [Column(TypeName = "varchar(32)")]
        public string ProductsProfileId { get; private set; }
        public ProductsProfile ProductsProfile { get; }
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime DtEffective { get; private set; }
        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public double AveragePurchaseCost { get; private set; }
        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public double SalesPrice { get; private set; }
    }
}
