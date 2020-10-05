using Microsoft.VisualStudio.TestTools.UnitTesting;
using SisVenda.Domain.Entities;

namespace SisVenda.Domain.Tests.Entities
{
    [TestClass]
    public class BankTests
    {
        public BankTests() { }

        [TestMethod]
        public void Should_be_equal_parameters_and_properties()
        {
            var name = "Name";
            var code = "Code";

            var bank = new Bank(name, code);

            Assert.AreEqual(
                (name, code),
                (bank.Name, bank.Code)
            );
        }
    }
}
