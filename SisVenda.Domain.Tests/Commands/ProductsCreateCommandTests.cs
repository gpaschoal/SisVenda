﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using SisVenda.Domain.Commands;
using System.Linq;

namespace SisVenda.Domain.Tests.Commands
{
    [TestClass]
    public class ProductsCreateCommandTests
    {
        public ProductsCreateCommandTests()
        {

        }
        private ProductsCreateCommand MakeValidProductsCreateCommand() => new ProductsCreateCommand("Name", "Description");

        [TestMethod]
        public void Should_fail_when_the_name_is_null()
        {
            var invalidCommand = MakeValidProductsCreateCommand();
            invalidCommand.Name = null;
            invalidCommand.Validate();

            Assert.AreEqual("Name", invalidCommand.Notifications.First().Property);
        }
    }
}