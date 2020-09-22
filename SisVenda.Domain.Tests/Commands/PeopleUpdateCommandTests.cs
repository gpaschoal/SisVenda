﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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

        [TestMethod]
        public void Should_fail_when_Id_is_null()
        {
            var invalidCommand = MakeValidPeopleUpdateCommand();
            invalidCommand.Id = null;
            invalidCommand.Validate();

            Assert.AreEqual("Id", invalidCommand.Notifications.First().Property);
        }

        [TestMethod]
        public void Should_fail_when_the_name_is_null()
        {
            var invalidCommand = MakeValidPeopleUpdateCommand();
            invalidCommand.Name = null;
            invalidCommand.Validate();

            Assert.AreEqual("Name", invalidCommand.Notifications.First().Property);
        }

        [TestMethod]
        public void Should_fail_when_the_name_has_no_min_length()
        {
            var invalidCommand = MakeValidPeopleUpdateCommand();
            invalidCommand.Name = string.Empty;
            invalidCommand.Validate();

            Assert.AreEqual("Name", invalidCommand.Notifications.First().Property);
        }

        [TestMethod]
        public void Should_fail_when_the_name_exceed_the_max_length()
        {
            var invalidCommand = MakeValidPeopleUpdateCommand();
            invalidCommand.Name = "".PadLeft(151, '0');
            invalidCommand.Validate();

            Assert.AreEqual("Name", invalidCommand.Notifications.First().Property);
        }

        [TestMethod]
        public void Should_fail_when_the_contact_is_null()
        {
            var invalidCommand = MakeValidPeopleUpdateCommand();
            invalidCommand.Contact = null;
            invalidCommand.Validate();

            Assert.AreEqual("Contact", invalidCommand.Notifications.First().Property);
        }
    }
}
