using SisVenda.Domain.Base.Entities;

namespace SisVenda.Domain.Entities
{
    public class PurchasesItems : MovimentItems
    {
        public PurchasesItems(string purchasesId, string productsId, int quantityItem, double costPrice, double salePrice) : base(productsId, quantityItem, costPrice, salePrice)
        {
            PurchasesId = purchasesId;
        }

        public string PurchasesId { get; private set; }
        public Purchases Purchases { get; }
    }
}
