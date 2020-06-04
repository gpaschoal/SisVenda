namespace SisVenda.UI.CQRS.Commands
{
    public class ProductsUpdateCommand
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
