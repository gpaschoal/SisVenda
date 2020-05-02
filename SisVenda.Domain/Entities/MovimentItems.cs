using SisVenda.Shared.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SisVenda.Domain.Entities
{
    public class MovimentItems : Entity
    {
        public MovimentItems(Guid idProduct, int quantityItem, double costPrice, double salePrice)
        {
            IdProduct = idProduct;
            QuantityItem = quantityItem;
            CostPrice = costPrice;
            SalePrice = salePrice;
        }

        public Guid IdProduct { get; private set; }
        public Product Product { get; }
        [Column(TypeName = "decimal(10, 2)")]
        public int QuantityItem { get; private set; }
        [Column(TypeName = "decimal(10, 2)")]
        public double CostPrice { get; private set; }
        [Column(TypeName = "decimal(10, 2)")]
        public double SalePrice { get; private set; }
    }
}
