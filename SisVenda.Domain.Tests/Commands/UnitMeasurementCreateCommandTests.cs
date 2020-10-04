using Microsoft.VisualStudio.TestTools.UnitTesting;
using SisVenda.Domain.Commands;
using System.Linq;

namespace SisVenda.Domain.Tests.Commands
{
    [TestClass]
    public class UnitMeasurementCreateCommandTests
    {
        public UnitMeasurementCreateCommandTests() { }
        private UnitMeasurementCreateCommand MakeUnitMeasurementCreateCommand() => new UnitMeasurementCreateCommand("ValidName", 1);

        [TestMethod]
        public void Should_fail_when_Name_is_null()
        {
            var invalidCommand = MakeUnitMeasurementCreateCommand();
            invalidCommand.Name = null;
            invalidCommand.Validate();

            Assert.AreEqual("Name", invalidCommand.Notifications.Single().Property);
        }

        [TestMethod]
        public void Should_fail_when_Name_is_empty()
        {
            var invalidCommand = MakeUnitMeasurementCreateCommand();
            invalidCommand.Name = "";
            invalidCommand.Validate();

            Assert.AreEqual("Name", invalidCommand.Notifications.Single().Property);
        }

        [TestMethod]
        public void Should_fail_when_Name_exceeds_max_length()
        {
            var invalidCommand = MakeUnitMeasurementCreateCommand();
            invalidCommand.Name = "".PadLeft(151, '0');
            invalidCommand.Validate();

            Assert.AreEqual("Name", invalidCommand.Notifications.Single().Property);
        }

        [TestMethod]
        public void Should_fail_when_QuantityLosses_is_null()
        {
            var invalidCommand = MakeUnitMeasurementCreateCommand();
            invalidCommand.QuantityLosses = null;
            invalidCommand.Validate();

            Assert.AreEqual("QuantityLosses", invalidCommand.Notifications.Single().Property);
        }

        [TestMethod]
        public void Should_fail_when_QuantityLosses_is_zero()
        {
            var invalidCommand = MakeUnitMeasurementCreateCommand();
            invalidCommand.QuantityLosses = 0;
            invalidCommand.Validate();

            Assert.AreEqual("QuantityLosses", invalidCommand.Notifications.Single().Property);
        }

        [TestMethod]
        public void Should_succeeds_when_command_is_valid()
        {
            var invalidCommand = MakeUnitMeasurementCreateCommand();
            invalidCommand.Validate();

            Assert.AreEqual(0, invalidCommand.Notifications.Count);
        }
    }
}
