using SisVenda.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SisVenda.Domain.Base.Entities
{
    public class MovimentItems : Entity
    {
        public MovimentItems(string productsProfileId, int quantityItem, double costPrice, double salePrice)
        {
            ProductsProfileId = productsProfileId;
            QuantityItem = quantityItem;
            CostPrice = costPrice;
            SalePrice = salePrice;
        }

        [Required]
        public string ProductsProfileId { get; private set; }
        public ProductsProfile ProductsProfile { get; }
        [Column(TypeName = "decimal(10, 2)")]
        public int QuantityItem { get; private set; }
        [Column(TypeName = "decimal(10, 2)")]
        public double CostPrice { get; private set; }
        [Column(TypeName = "decimal(10, 2)")]
        public double SalePrice { get; private set; }
    }
}
