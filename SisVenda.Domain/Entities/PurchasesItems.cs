using System;

namespace SisVenda.Domain.Entities
{
    public class PurchasesItems : MovimentItems
    {
        public PurchasesItems(Guid idPurchase, Guid idProduct, int quantityItem, double costPrice, double salePrice) : base(idProduct, quantityItem, costPrice, salePrice)
        {
            IdPurchase = idPurchase;
        }

        public Guid IdPurchase { get; private set; }
        public Purchases Purchase { get; }
    }
}
