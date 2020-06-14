namespace SisVenda.UI.CQRS.Commands
{
    public class ProductsCreateCommand : ICreateCommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
