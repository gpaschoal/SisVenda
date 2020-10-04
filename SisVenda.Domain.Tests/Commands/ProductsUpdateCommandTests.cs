using Microsoft.VisualStudio.TestTools.UnitTesting;
using SisVenda.Domain.Commands;
using System.Linq;

namespace SisVenda.Domain.Tests.Commands
{
    [TestClass]
    public class ProductsUpdateCommandTests
    {
        public ProductsUpdateCommandTests() { }

        private ProductsUpdateCommand ProductsUpdateCommandCommand() => new ProductsUpdateCommand("valid_id", "Name", "Description");

        [TestMethod]
        public void Should_fail_when_the_name_is_null()
        {
            var invalidCommand = ProductsUpdateCommandCommand();
            invalidCommand.Name = null;
            invalidCommand.Validate();

            Assert.AreEqual("Name", invalidCommand.Notifications.First().Property);
        }

        [TestMethod]
        public void Should_fail_when_the_name_is_empty()
        {
            var invalidCommand = ProductsUpdateCommandCommand();
            invalidCommand.Name = "";
            invalidCommand.Validate();

            Assert.AreEqual("Name", invalidCommand.Notifications.First().Property);
        }
    }
}
