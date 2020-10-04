using Microsoft.VisualStudio.TestTools.UnitTesting;
using SisVenda.Domain.Commands;

namespace SisVenda.Domain.Tests.Commands
{
    [TestClass]
    public class ProductsCreateCommandTests
    {
        public ProductsCreateCommandTests()
        {

        }
        private ProductsCreateCommand MakeValidProductsCreateCommand() => new ProductsCreateCommand("Name", "Description");
    }
}
