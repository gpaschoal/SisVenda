namespace SisVenda.UI.CQRS.Commands
{
    public class ProductsDeleteCommand : IDeleteCommand
    {
        public string Id { get; set; }
    }
}
