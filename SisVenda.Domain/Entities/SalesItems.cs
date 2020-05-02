namespace SisVenda.Domain.Entities
{
    public class SalesItems : MovimentItems
    {
        public SalesItems(string salesId, string productsId, int quantityItem, double costPrice, double salePrice) : base(productsId, quantityItem, costPrice, salePrice)
        {
            SalesId = salesId;
        }

        public string SalesId { get; private set; }
        public Sales Sales { get; }
    }
}
