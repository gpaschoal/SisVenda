using Microsoft.VisualStudio.TestTools.UnitTesting;
using SisVenda.Domain.Commands;
using System.Linq;

namespace SisVenda.Domain.Tests.Commands
{
    [TestClass]
    public class PeopleCreateCommandTests
    {
        public PeopleCreateCommandTests()
        {
        }
        private PeopleCreateCommand MakeValidPeopleCreateCommand() => new PeopleCreateCommand(
                true,
                true,
                "name",
                "contact",
                "cpf",
                "cnpj",
                "street",
                "number",
                "neighborhood",
                "valid_city",
                "UF",
                "zipCode",
                "adressEmail@mail.com",
                "phoneNumber");

        [TestMethod]
        public void Validation_should_fail_when_the_name_is_null()
        {
            var invalidCommand = MakeValidPeopleCreateCommand();
            invalidCommand.Name = null;
            invalidCommand.Validate();

            Assert.AreEqual("Name", invalidCommand.Notifications.First().Property);
        }

        [TestMethod]
        public void Validation_should_fail_when_the_name_does_not_require_min_length()
        {
            var invalidCommand = MakeValidPeopleCreateCommand();
            invalidCommand.Name = string.Empty;
            invalidCommand.Validate();

            Assert.AreEqual("Name", invalidCommand.Notifications.First().Property);
        }

        [TestMethod]
        public void Validation_should_fail_when_the_name_exceed_the_max_length()
        {
            var invalidCommand = MakeValidPeopleCreateCommand();
            invalidCommand.Name = "".PadLeft(151, '0');
            invalidCommand.Validate();

            Assert.AreEqual("Name", invalidCommand.Notifications.First().Property);
        }

        [TestMethod]
        public void Validation_should_fail_when_the_Contact_is_null()
        {
            var invalidCommand = MakeValidPeopleCreateCommand();
            invalidCommand.Contact = null;
            invalidCommand.Validate();

            Assert.AreEqual("Contact", invalidCommand.Notifications.First().Property);
        }
    }
}
