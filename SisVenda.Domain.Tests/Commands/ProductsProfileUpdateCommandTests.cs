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

            Assert.AreEqual("Id", invalidCommand.Notifications.First().Property);
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
    }
}
