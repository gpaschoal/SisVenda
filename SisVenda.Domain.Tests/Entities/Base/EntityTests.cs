using Microsoft.VisualStudio.TestTools.UnitTesting;
using SisVenda.Domain.Base.Entities;
using System;

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

        [TestMethod]
        public void After_create_DtRegister_should_has_value()
        {
            var entityStub = new EntityStub();

            Assert.AreNotEqual(null, entityStub.DtRegister);
        }

        [TestMethod]
        public void After_create_DtDeleted_should_be_null()
        {
            var entityStub = new EntityStub();

            Assert.AreEqual(null, entityStub.DtDeleted);
        }
    }
}
