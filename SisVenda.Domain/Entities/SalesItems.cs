using System;

namespace SisVenda.Domain.Entities
{
    public class SalesItems : MovimentItems
    {
        public SalesItems(Guid idSales, Guid idProduct, int quantityItem, double costPrice, double salePrice) : base(idProduct, quantityItem, costPrice, salePrice)
        {
            IdSales = idSales;
        }

        public Guid IdSales { get; private set; }
        public Sales Sales { get; }
    }
}
