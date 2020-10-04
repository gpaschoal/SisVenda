using Microsoft.VisualStudio.TestTools.UnitTesting;
using SisVenda.Domain.Commands;
using System.Linq;

namespace SisVenda.Domain.Tests.Commands
{
    [TestClass]
    public class ProductsProfileCreateCommandTests
    {
        public ProductsProfileCreateCommandTests() { }
        private ProductsProfileCreateCommand MakeProductsProfileCreateCommand() => new ProductsProfileCreateCommand("validunitmeasurementid", "validproductid", "validbarcode");

        [TestMethod]
        public void Should_fail_when_UnitMeasurementId_is_null()
        {
            var invalidCommand = MakeProductsProfileCreateCommand();
            invalidCommand.UnitMeasurementId = null;
            invalidCommand.Validate();

            Assert.AreEqual("UnitMeasurementId", invalidCommand.Notifications.First().Property);
        }

        [TestMethod]
        public void Should_fail_when_UnitMeasurementId_is_empty()
        {
            var invalidCommand = MakeProductsProfileCreateCommand();
            invalidCommand.UnitMeasurementId = "";
            invalidCommand.Validate();

            Assert.AreEqual("UnitMeasurementId", invalidCommand.Notifications.First().Property);
        }
    }
}
