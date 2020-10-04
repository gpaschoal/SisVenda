using Microsoft.VisualStudio.TestTools.UnitTesting;
using SisVenda.Domain.Commands;
using System.Linq;

namespace SisVenda.Domain.Tests.Commands
{
    [TestClass]
    public class ProductsDeleteCommandTests
    {
        public ProductsDeleteCommandTests()
        {

        }
        private ProductsDeleteCommand MakeValidProductsDeleteCommand() => new ProductsDeleteCommand("valid_id");

        [TestMethod]
        public void Should_fail_when_id_is_empty()
        {
            var invalidCommand = MakeValidProductsDeleteCommand();
            invalidCommand.Id = "";
            invalidCommand.Validate();

            Assert.AreEqual("Id", invalidCommand.Notifications.First().Property);
        }
    }
}
