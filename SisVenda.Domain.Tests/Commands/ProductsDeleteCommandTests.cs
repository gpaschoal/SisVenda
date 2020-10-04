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

            Assert.AreEqual("Id", invalidCommand.Notifications.Single().Property);
        }

        [TestMethod]
        public void Should_fail_when_id_is_null()
        {
            var invalidCommand = MakeValidProductsDeleteCommand();
            invalidCommand.Id = null;
            invalidCommand.Validate();

            Assert.AreEqual("Id", invalidCommand.Notifications.Single().Property);
        }

        [TestMethod]
        public void Should_succeeds_when_ProductsDeleteCommand_is_valid()
        {
            var invalidCommand = MakeValidProductsDeleteCommand();
            invalidCommand.Validate();

            Assert.AreEqual(0, invalidCommand.Notifications.Count);
        }
    }
}
