using Microsoft.VisualStudio.TestTools.UnitTesting;
using SisVenda.Domain.Base.Entities;

namespace SisVenda.Domain.Tests.Entities.Base
{
    [TestClass]
    public class EntityTests
    {
        private class EntityStub : Entity { }

        public EntityTests() { }

        [TestMethod]
        [DataRow("")]
        [DataRow(null)]
        public void After_create_id_should_has_value(string value)
        {
            var entityStub = new EntityStub();

            Assert.AreNotEqual(value, entityStub.Id);
        }
    }
}
