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
        public void Validation_should_fail_when_the_name_has_no_min_length()
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
        public void Validation_should_fail_when_the_contact_is_null()
        {
            var invalidCommand = MakeValidPeopleCreateCommand();
            invalidCommand.Contact = null;
            invalidCommand.Validate();

            Assert.AreEqual("Contact", invalidCommand.Notifications.First().Property);
        }

        [TestMethod]
        public void Validation_should_fail_when_the_contact_has_no_min_length()
        {
            var invalidCommand = MakeValidPeopleCreateCommand();
            invalidCommand.Contact = "";
            invalidCommand.Validate();

            Assert.AreEqual("Contact", invalidCommand.Notifications.First().Property);
        }

        [TestMethod]
        public void Validation_should_fail_when_the_contact_exceed_the_max_length()
        {
            var invalidCommand = MakeValidPeopleCreateCommand();
            invalidCommand.Contact = "".PadLeft(151, '0');
            invalidCommand.Validate();

            Assert.AreEqual("Contact", invalidCommand.Notifications.First().Property);
        }

        [TestMethod]
        public void Validation_should_fail_when_the_street_is_null()
        {
            var invalidCommand = MakeValidPeopleCreateCommand();
            invalidCommand.Street = null;
            invalidCommand.Validate();

            Assert.AreEqual("Street", invalidCommand.Notifications.First().Property);
        }

        [TestMethod]
        public void Validation_should_fail_when_the_street_has_no_min_length()
        {
            var invalidCommand = MakeValidPeopleCreateCommand();
            invalidCommand.Street = "";
            invalidCommand.Validate();

            Assert.AreEqual("Street", invalidCommand.Notifications.First().Property);
        }

        [TestMethod]
        public void Validation_should_fail_when_the_street_exceed_the_max_length()
        {
            var invalidCommand = MakeValidPeopleCreateCommand();
            invalidCommand.Street = "".PadLeft(151, '0');
            invalidCommand.Validate();

            Assert.AreEqual("Street", invalidCommand.Notifications.First().Property);
        }

        [TestMethod]
        public void Validation_should_fail_when_the_number_has_no_min_length()
        {
            var invalidCommand = MakeValidPeopleCreateCommand();
            invalidCommand.Number = "";
            invalidCommand.Validate();

            Assert.AreEqual("Number", invalidCommand.Notifications.First().Property);
        }

        [TestMethod]
        public void Validation_should_fail_when_the_number_exceed_the_max_length()
        {
            var invalidCommand = MakeValidPeopleCreateCommand();
            invalidCommand.Number = "".PadLeft(11, '0');
            invalidCommand.Validate();

            Assert.AreEqual("Number", invalidCommand.Notifications.First().Property);
        }

        [TestMethod]
        public void Validation_should_fail_when_the_neighborhood_has_no_min_length()
        {
            var invalidCommand = MakeValidPeopleCreateCommand();
            invalidCommand.Neighborhood = "";
            invalidCommand.Validate();

            Assert.AreEqual("Neighborhood", invalidCommand.Notifications.First().Property);
        }

        [TestMethod]
        public void Validation_should_fail_when_the_neighborhood_exceed_the_max_length()
        {
            var invalidCommand = MakeValidPeopleCreateCommand();
            invalidCommand.Neighborhood = "".PadLeft(31, '0');
            invalidCommand.Validate();

            Assert.AreEqual("Neighborhood", invalidCommand.Notifications.First().Property);
        }

        [TestMethod]
        public void Validation_should_fail_when_the_city_exceed_the_max_length()
        {
            var invalidCommand = MakeValidPeopleCreateCommand();
            invalidCommand.City = "".PadLeft(51, '0');
            invalidCommand.Validate();

            Assert.AreEqual("City", invalidCommand.Notifications.First().Property);
        }

        [TestMethod]
        public void Validation_should_fail_when_the_zipcode_exceed_the_max_length()
        {
            var invalidCommand = MakeValidPeopleCreateCommand();
            invalidCommand.ZipCode = "".PadLeft(11, '0');
            invalidCommand.Validate();

            Assert.AreEqual("ZipCode", invalidCommand.Notifications.First().Property);
        }

        [TestMethod]
        public void Validation_should_fail_when_the_state_has_a_different_len()
        {
            var invalidCommand = MakeValidPeopleCreateCommand();
            invalidCommand.State = "".PadLeft(3, '0');
            invalidCommand.Validate();
            Assert.AreEqual("State", invalidCommand.Notifications.First().Property);
        }

        [TestMethod]
        public void Validation_should_fail_when_the_phoneNumber_has_no_min_length()
        {
            var invalidCommand = MakeValidPeopleCreateCommand();
            invalidCommand.PhoneNumber = "";
            invalidCommand.Validate();

            Assert.AreEqual("PhoneNumber", invalidCommand.Notifications.First().Property);
        }

        [TestMethod]
        public void Validation_should_fail_when_the_phoneNumber_exceeds_the_max_length()
        {
            var invalidCommand = MakeValidPeopleCreateCommand();
            invalidCommand.PhoneNumber = "".PadLeft(12, '0');
            invalidCommand.Validate();

            Assert.AreEqual("PhoneNumber", invalidCommand.Notifications.First().Property);
        }

        [TestMethod]
        public void Validation_should_fail_when_the_CPF_exceeds_the_max_length()
        {
            var invalidCommand = MakeValidPeopleCreateCommand();
            invalidCommand.CPF = "";
            invalidCommand.Validate();

            Assert.AreEqual("CPF", invalidCommand.Notifications.First().Property);
        }

        [TestMethod]
        public void Validation_should_fail_when_the_CNPJ_exceeds_the_max_length()
        {
            var invalidCommand = MakeValidPeopleCreateCommand();
            invalidCommand.CNPJ = "";
            invalidCommand.Validate();

            Assert.AreEqual("CNPJ", invalidCommand.Notifications.First().Property);
        }

        [TestMethod]
        public void Validation_should_fail_when_the_adressEmail_is_invalid()
        {
            var invalidCommand = MakeValidPeopleCreateCommand();
            invalidCommand.AdressEmail = "invalid_email";
            invalidCommand.Validate();

            Assert.AreEqual("AdressEmail", invalidCommand.Notifications.First().Property);
        }
    }
}
