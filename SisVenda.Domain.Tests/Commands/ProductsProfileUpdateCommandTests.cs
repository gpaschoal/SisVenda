using Microsoft.VisualStudio.TestTools.UnitTesting;
using SisVenda.Domain.Commands;
using System.Linq;

namespace SisVenda.Domain.Tests.Commands
{
    [TestClass]
    public class ProductsProfileUpdateCommandTests
    {
        public ProductsProfileUpdateCommandTests() { }

        private ProductsProfileUpdateCommand MakeProductsProfileUpdateCommand() => new ProductsProfileUpdateCommand("valid_id", "validunitmeasurementid", "validproductid", "validbarcode");

        [TestMethod]
        public void Should_fail_when_id_is_null()
        {
            var invalidCommand = MakeProductsProfileUpdateCommand();
            invalidCommand.Id = null;
            invalidCommand.Validate();

            Assert.AreEqual("Id", invalidCommand.Notifications.Single().Property);
        }

        [TestMethod]
        public void Should_fail_when_id_is_empty()
        {
            var invalidCommand = MakeProductsProfileUpdateCommand();
            invalidCommand.Id = "";
            invalidCommand.Validate();

            Assert.AreEqual("Id", invalidCommand.Notifications.Single().Property);
        }

        [TestMethod]
        public void Should_fail_when_UnitMeasurementId_is_null()
        {
            var invalidCommand = MakeProductsProfileUpdateCommand();
            invalidCommand.UnitMeasurementId = null;
            invalidCommand.Validate();

            Assert.AreEqual("UnitMeasurementId", invalidCommand.Notifications.Single().Property);
        }

        [TestMethod]
        public void Should_fail_when_UnitMeasurementId_is_empty()
        {
            var invalidCommand = MakeProductsProfileUpdateCommand();
            invalidCommand.UnitMeasurementId = "";
            invalidCommand.Validate();

            Assert.AreEqual("UnitMeasurementId", invalidCommand.Notifications.Single().Property);
        }

        [TestMethod]
        public void Should_fail_when_ProductsId_is_null()
        {
            var invalidCommand = MakeProductsProfileUpdateCommand();
            invalidCommand.ProductsId = null;
            invalidCommand.Validate();

            Assert.AreEqual("ProductsId", invalidCommand.Notifications.Single().Property);
        }

        [TestMethod]
        public void Should_fail_when_ProductsId_is_empty()
        {
            var invalidCommand = MakeProductsProfileUpdateCommand();
            invalidCommand.ProductsId = "";
            invalidCommand.Validate();

            Assert.AreEqual("ProductsId", invalidCommand.Notifications.Single().Property);
        }

        [TestMethod]
        public void Should_fail_when_BarCode_is_null()
        {
            var invalidCommand = MakeProductsProfileUpdateCommand();
            invalidCommand.BarCode = null;
            invalidCommand.Validate();

            Assert.AreEqual("BarCode", invalidCommand.Notifications.Single().Property);
        }

        [TestMethod]
        public void Should_fail_when_BarCode_is_empty()
        {
            var invalidCommand = MakeProductsProfileUpdateCommand();
            invalidCommand.BarCode = "";
            invalidCommand.Validate();

            Assert.AreEqual("BarCode", invalidCommand.Notifications.Single().Property);
        }

        [TestMethod]
        public void Should_fail_when_BarCode_exceeds_max_length()
        {
            var invalidCommand = MakeProductsProfileUpdateCommand();
            invalidCommand.BarCode = "".PadLeft(101, '0');
            invalidCommand.Validate();

            Assert.AreEqual("BarCode", invalidCommand.Notifications.Single().Property);
        }

        [TestMethod]
        public void Should_succeeds_when_command_is_valid()
        {
            var validCommand = MakeProductsProfileUpdateCommand();
            validCommand.Validate();

            Assert.AreEqual(0, validCommand.Notifications.Count);
        }
    }
}
