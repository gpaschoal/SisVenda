using Microsoft.VisualStudio.TestTools.UnitTesting;
using SisVenda.Domain.Commands;
using System.Linq;

namespace SisVenda.Domain.Tests.Commands
{
    [TestClass]
    public class ProductsUpdateCommandTests
    {
        public ProductsUpdateCommandTests() { }

        private ProductsUpdateCommand MakeProductsUpdateCommandCommand() => new ProductsUpdateCommand("valid_id", "Name", "Description");

        [TestMethod]
        public void Should_fail_when_the_name_is_null()
        {
            var invalidCommand = MakeProductsUpdateCommandCommand();
            invalidCommand.Name = null;
            invalidCommand.Validate();

            Assert.AreEqual("Name", invalidCommand.Notifications.First().Property);
        }

        [TestMethod]
        public void Should_fail_when_the_name_is_empty()
        {
            var invalidCommand = MakeProductsUpdateCommandCommand();
            invalidCommand.Name = "";
            invalidCommand.Validate();

            Assert.AreEqual("Name", invalidCommand.Notifications.First().Property);
        }

        [TestMethod]
        public void Should_fail_when_the_name_exceeds_max_length()
        {
            var invalidCommand = MakeProductsUpdateCommandCommand();
            invalidCommand.Name = "".PadLeft(151, '0');
            invalidCommand.Validate();

            Assert.AreEqual("Name", invalidCommand.Notifications.First().Property);
        }

        [TestMethod]
        public void Should_fail_when_id_is_empty()
        {
            var invalidCommand = MakeProductsUpdateCommandCommand();
            invalidCommand.Id = "";
            invalidCommand.Validate();

            Assert.AreEqual("Id", invalidCommand.Notifications.First().Property);
        }

        [TestMethod]
        public void Should_fail_when_id_is_null()
        {
            var invalidCommand = MakeProductsUpdateCommandCommand();
            invalidCommand.Id = null;
            invalidCommand.Validate();

            Assert.AreEqual("Id", invalidCommand.Notifications.First().Property);
        }

        [TestMethod]
        public void Should_fail_when_the_description_is_null()
        {
            var invalidCommand = MakeProductsUpdateCommandCommand();
            invalidCommand.Description = null;
            invalidCommand.Validate();

            Assert.AreEqual("Description", invalidCommand.Notifications.First().Property);
        }

        [TestMethod]
        public void Should_fail_when_the_description_is_empty()
        {
            var invalidCommand = MakeProductsUpdateCommandCommand();
            invalidCommand.Description = "";
            invalidCommand.Validate();

            Assert.AreEqual("Description", invalidCommand.Notifications.First().Property);
        }

        [TestMethod]
        public void Should_fail_when_the_description_exceeds_max_length()
        {
            var invalidCommand = MakeProductsUpdateCommandCommand();
            invalidCommand.Description = "".PadLeft(151, '0');
            invalidCommand.Validate();

            Assert.AreEqual("Description", invalidCommand.Notifications.First().Property);
        }
    }
}
