using Microsoft.VisualStudio.TestTools.UnitTesting;
using SisVenda.Domain.Commands;
using System.Linq;

namespace SisVenda.Domain.Tests.Commands
{
    [TestClass]
    public class PeopleUpdateCommandTests
    {
        public PeopleUpdateCommandTests() { }
        private PeopleUpdateCommand MakeValidPeopleUpdateCommand() => new PeopleUpdateCommand(
                 "valid_id", 
                 true, 
                 true, 
                 "name", 
                 "contact", 
                 "cpf", 
                 "cnpj", 
                 "street",
                 "number", 
                 "neighborhood", 
                 "city", 
                 "UF", 
                 "zipCode", 
                 "adressEmail@mail.com", 
                 "phoneNumber"
            );
        [TestMethod]
        public void Should_fail_when_Id_is_empty()
        {
            var invalidCommand = MakeValidPeopleUpdateCommand();
            invalidCommand.Id = "";
            invalidCommand.Validate();

            Assert.AreEqual("Id", invalidCommand.Notifications.First().Property);
        }
    }
}
