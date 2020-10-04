using Microsoft.VisualStudio.TestTools.UnitTesting;
using SisVenda.Domain.Commands;
using System.Linq;

namespace SisVenda.Domain.Tests.Commands
{
    [TestClass]
    public class UnitMeasurementCreateCommandTests
    {
        public UnitMeasurementCreateCommandTests() { }
        private UnitMeasurementCreateCommand MakeUnitMeasurementCreateCommand() => new UnitMeasurementCreateCommand("", 1);

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
    }
}
