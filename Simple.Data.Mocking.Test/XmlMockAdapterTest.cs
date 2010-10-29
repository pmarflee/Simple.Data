﻿// ReSharper disable InconsistentNaming
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Simple.Data.Mocking.Test
{
    /// <summary>
    ///This is a test class for XmlStubAdapterTest and is intended
    ///to contain all XmlStubAdapterTest Unit Tests
    ///</summary>
    [TestClass]
    public class XmlMockAdapterTest
    {
        [TestInitialize]
        public void MyTestInitialize()
        {
            MockHelper.UseMockAdapter(
                new XmlMockAdapter(
                    @"<Root><Users Id=""System.Int32""><User Id=""1"" Email=""foo"" Password=""bar""/><User Email=""baz"" Password=""quux""/></Users></Root>"));
        }


        /// <summary>
        ///A test for Find
        ///</summary>
        [TestMethod]
        public void FindByEmail_ShouldFindRecord()
        {
            dynamic user = Database.Default.Users.FindByEmail("foo");
            Assert.AreEqual(1, user.Id);
            Assert.AreEqual("foo", user.Email);
            Assert.AreEqual("bar", user.Password);
        }

        /// <summary>
        ///A test for Find
        ///</summary>
        [TestMethod]
        public void FindById_ShouldFindRecord()
        {
            dynamic user = Database.Default.Users.FindById(1);
            Assert.AreEqual(1, user.Id);
        }

        /// <summary>
        ///A test for All
        ///</summary>
        [TestMethod]
        public void All_ShouldReturnTwoUsers()
        {
            IEnumerable<object> users = Database.Default.Users.All;
            Assert.AreEqual(2, users.Count());
        }
    }
}

// ReSharper restore InconsistentNaming