namespace SisVenda.UI.CQRS.Commands
{
    public class ProductsProfileDeleteCommand : IDeleteCommand
    {
        public string Id { get; set; }
    }
}
