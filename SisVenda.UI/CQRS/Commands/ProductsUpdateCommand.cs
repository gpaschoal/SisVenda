using SisVenda.UI.CQRS.Responses;

namespace SisVenda.UI.CQRS.Commands
{
    public class ProductsUpdateCommand : IUpdateCommand
    {
        public ProductsUpdateCommand() { }
        public ProductsUpdateCommand(ProductResponse response)
        {
            Id = response.Id;
            Name = response.Name;
            Description = response.Description;
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
