using Microsoft.VisualStudio.TestTools.UnitTesting;
using SisVenda.Domain.Commands;
using System.Linq;

namespace SisVenda.Domain.Tests.Commands
{
    [TestClass]
    public class ProductsCreateCommandTests
    {
        public ProductsCreateCommandTests()
        {

        }
        private ProductsCreateCommand MakeValidProductsCreateCommand() => new ProductsCreateCommand("Name", "Description");

        [TestMethod]
        public void Should_fail_when_the_name_is_null()
        {
            var invalidCommand = MakeValidProductsCreateCommand();
            invalidCommand.Name = null;
            invalidCommand.Validate();

            Assert.AreEqual("Name", invalidCommand.Notifications.First().Property);
        }

        [TestMethod]
        public void Should_fail_when_the_name_is_empty()
        {
            var invalidCommand = MakeValidProductsCreateCommand();
            invalidCommand.Name = "";
            invalidCommand.Validate();

            Assert.AreEqual("Name", invalidCommand.Notifications.First().Property);
        }

        [TestMethod]
        public void Should_fail_when_the_name_exceeds_max_length()
        {
            var invalidCommand = MakeValidProductsCreateCommand();
            invalidCommand.Name = "".PadLeft(151, '0');
            invalidCommand.Validate();

            Assert.AreEqual("Name", invalidCommand.Notifications.First().Property);
        }

        [TestMethod]
        public void Should_fail_when_the_description_is_null()
        {
            var invalidCommand = MakeValidProductsCreateCommand();
            invalidCommand.Description = null;
            invalidCommand.Validate();

            Assert.AreEqual("Description", invalidCommand.Notifications.First().Property);
        }

        [TestMethod]
        public void Should_fail_when_the_description_is_empty()
        {
            var invalidCommand = MakeValidProductsCreateCommand();
            invalidCommand.Description = "";
            invalidCommand.Validate();

            Assert.AreEqual("Description", invalidCommand.Notifications.First().Property);
        }

        [TestMethod]
        public void Should_fail_when_the_description_exceeds_max_length()
        {
            var invalidCommand = MakeValidProductsCreateCommand();
            invalidCommand.Description = "".PadLeft(151, '0');
            invalidCommand.Validate();

            Assert.AreEqual("Description", invalidCommand.Notifications.First().Property);
        }

        [TestMethod]
        public void Should_succeeds_when_ProductsCreateCommand_is_Valid()
        {
            var invalidCommand = MakeValidProductsCreateCommand();
            invalidCommand.Validate();

            Assert.AreEqual(0, invalidCommand.Notifications.Count);
        }
    }
}
