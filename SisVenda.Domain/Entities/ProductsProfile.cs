using SisVenda.Domain.Base.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SisVenda.Domain.Entities
{
    public class ProductsProfile : Entity
    {
        public ProductsProfile(string unitMeasurementId, string productsId, string barCode)
        {
            UnitMeasurementId = unitMeasurementId;
            ProductsId = productsId;
            BarCode = barCode;
        }
        [Required]
        [Column(TypeName = "varchar(32)")]
        public string UnitMeasurementId { get; private set; }
        public UnitMeasurement UnitMeasurement { get; }
        [Required]
        [Column(TypeName = "varchar(32)")]
        public string ProductsId { get; private set; }
        public Products Products { get; }
        [Required]
        [Column(TypeName = "char(100)")]
        public string BarCode { get; private set; }
        public IEnumerable<ProductsPrices> ProductsPrices { get; }
        public IEnumerable<Losses> Losses { get; }
        public IEnumerable<SalesItems> SalesItems { get; }
        public IEnumerable<PurchasesItems> PurchasesItems { get; }
    }
}
