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

            Assert.AreNotEqual(DateTime.MinValue, entityStub.DtRegister);
        }

        [TestMethod]
        public void After_create_DtDeleted_should_be_null()
        {
            var entityStub = new EntityStub();

            Assert.AreEqual(null, entityStub.DtDeleted);
        }

        [TestMethod]
        public void After_Delete_Method_is_called_DtDeleted_should_has_value()
        {
            var entityStub = new EntityStub();
            entityStub.Delete();

            Assert.AreNotEqual(null, entityStub.DtDeleted);
        }
    }
}
