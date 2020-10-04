using Microsoft.VisualStudio.TestTools.UnitTesting;
using SisVenda.Domain.Commands;
using System.Linq;

namespace SisVenda.Domain.Tests.Commands
{
    [TestClass]
    public class ProductsProfileDeleteCommandTests
    {
        public ProductsProfileDeleteCommandTests() { }
        private ProductsProfileDeleteCommand MakeProductsProfileDeleteCommand() => new ProductsProfileDeleteCommand("valid_id");

        [TestMethod]
        public void Should_fail_when_id_is_null()
        {
            var invalidCommand = MakeProductsProfileDeleteCommand();
            invalidCommand.Id = null;
            invalidCommand.Validate();

            Assert.AreEqual("Id", invalidCommand.Notifications.First().Property);
        }

        [TestMethod]
        public void Should_fail_when_id_is_empty()
        {
            var invalidCommand = MakeProductsProfileDeleteCommand();
            invalidCommand.Id = null;
            invalidCommand.Validate();

            Assert.AreEqual("Id", invalidCommand.Notifications.First().Property);
        }

        [TestMethod]
        public void Should_suceeds_when_command_is_valid()
        {
            var invalidCommand = MakeProductsProfileDeleteCommand();
            invalidCommand.Validate();

            Assert.AreEqual(0, invalidCommand.Notifications.Count);
        }
    }
}
