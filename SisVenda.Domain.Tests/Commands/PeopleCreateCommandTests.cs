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
        public void Validation_should_fail_when_the_name_does_not_require_min_length()
        {
            var invalidCommand = MakeValidPeopleCreateCommand();
            invalidCommand.Name = string.Empty;
            invalidCommand.Validate();

            Assert.AreEqual("Name", invalidCommand.Notifications.First().Property);
        }
    }
}
