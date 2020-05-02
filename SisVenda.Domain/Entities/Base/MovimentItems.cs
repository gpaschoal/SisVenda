using SisVenda.Domain.Entities;
using SisVenda.Shared.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SisVenda.Domain.Base.Entities
{
    public class MovimentItems : Entity
    {
        public MovimentItems(string productsId, int quantityItem, double costPrice, double salePrice)
        {
            ProductsId = productsId;
            QuantityItem = quantityItem;
            CostPrice = costPrice;
            SalePrice = salePrice;
        }

        [Required]
        public string ProductsId { get; set; }
        public Products Product { get; }
        [Column(TypeName = "decimal(10, 2)")]
        public int QuantityItem { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public double CostPrice { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public double SalePrice { get; set; }
    }
}
