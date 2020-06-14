namespace SisVenda.UI.CQRS.Responses
{
    public class ProductResponse : IResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double QuantityStock { get; set; }
    }
}
