using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Security.Authentication;
using System.Collections.Generic;
using clxapi;
using clxapi.Client;
using clxapi.Adapter;
using clxapi.Tests.Adapter;


namespace clxapi.Tests
{
    [TestClass]
    public class ClxApiTests
    {
        [TestMethod]
        public void TestGetOperators()
        {
            ClxTestAdapter testAdapter= new ClxTestAdapter();
            ClxApi clxApi = new ClxApi(new string[] { "Username", "Password" }, testAdapter);
            clxApi.SetBaseUrl("https://TEST");
            var data = clxApi.GetOperators();

            Assert.IsInstanceOfType(data, typeof(IEnumerable<Operator>));
            Assert.IsNotNull(data);
            Assert.AreEqual(data.ToList().Count, 2);
            Assert.AreEqual(data.ToList()[0].id, 1);
            Assert.AreEqual(data.ToList()[0].name, "Testoperatpor");
            Assert.AreEqual(data.ToList()[0].isoCountryCode, "5");
            Assert.AreEqual(data.ToList()[1].network, "Secretary");
            Assert.AreEqual(data.ToList()[1].operationalStatDate, "-0001-11-30 00:00:00");
            Assert.AreEqual(data.ToList()[1].operationalState, "inactive");
            Assert.AreEqual(data.ToList()[1].uniqueName, "Bella");
            Assert.AreEqual(data.ToList()[1].numberOfSubscribers, 8888);
        }

        [TestMethod]
        public void TestGetOperatorByID()
        {
            ClxTestAdapter testAdapter = new ClxTestAdapter();
            ClxApi clxApi = new ClxApi(new string[] { "Username", "Password" }, testAdapter);
            clxApi.SetBaseUrl("https://TEST");
            var data = clxApi.GetOperatorById(55);

            Assert.IsInstanceOfType(data, typeof(Operator));
            Assert.IsNotNull(data);
            Assert.AreEqual(data.id, 55);
            Assert.AreEqual(data.name, "Testoperatpor");
            Assert.AreEqual(data.isoCountryCode, "5");
            Assert.AreEqual(data.network, "TestNetwork");
            Assert.AreEqual(data.operationalStatDate, "-0001-11-30 00:00:00");
            Assert.AreEqual(data.operationalState, "active");
            Assert.AreEqual(data.uniqueName, "Testing");
            Assert.AreEqual(data.numberOfSubscribers, 1);
        }


        [TestMethod]
        public void TestGetGateways()
        {
            ClxTestAdapter testAdapter = new ClxTestAdapter();
            ClxApi clxApi = new ClxApi(new string[] { "Username", "Password" }, testAdapter);
            clxApi.SetBaseUrl("https://TEST");
            IEnumerable<Gateway> data = clxApi.GetGateways();

            Assert.AreEqual(data.ToList().Count, 3);
            Assert.IsInstanceOfType(data, typeof(IEnumerable<Gateway>));
            Assert.IsNotNull(data);
            Assert.AreEqual(data.ToList()[0].id, 5);
            Assert.AreEqual(data.ToList()[0].name, "StringNameValue");
            Assert.AreEqual(data.ToList()[0].type, "StringTypeValue");
            Assert.AreEqual(data.ToList()[1].id, 88);
            Assert.AreEqual(data.ToList()[1].name, "AnotherString");
            Assert.AreEqual(data.ToList()[1].type, "AnotherString");
            Assert.AreEqual(data.ToList()[2].name, "HelgiMobile");
        }

        [TestMethod]
        public void TestTestGetOperatorsTestAPI()
        {
            var clxApi = new ClxApi(new string[] { "Username", "Password" });
            clxApi.SetBaseUrl("http://localhost:1129/api");
            var data = clxApi.GetOperators();

            Assert.IsInstanceOfType(data, typeof(IEnumerable<Operator>));
            Assert.IsNotNull(data);
            Assert.AreEqual(data.ToList()[0].id, 1);
            Assert.AreEqual(data.ToList()[0].name, "Testoperatpor");
            Assert.AreEqual(data.ToList()[0].isoCountryCode, "5");
            Assert.AreEqual(data.ToList()[1].network, "Secretary");
            Assert.AreEqual(data.ToList()[1].operationalStatDate, "-0001-11-30 00:00:00");
            Assert.AreEqual(data.ToList()[1].operationalState, "inactive");
            Assert.AreEqual(data.ToList()[1].uniqueName, "Bella");
            Assert.AreEqual(data.ToList()[1].numberOfSubscribers, 8888);
            
        }

        [TestMethod]
        public void TestTestGetOperatorsByIdTestAPI()
        {

            var clxApi = new ClxApi(new string[] { "Username", "Password" });
            clxApi.SetBaseUrl("http://localhost:1129/api");
            var data = clxApi.GetOperatorById(1);

            Assert.IsInstanceOfType(data, typeof(Operator));
            Assert.IsNotNull(data);

            Assert.AreEqual(data.id, 1);
            Assert.AreEqual(data.name, "Testoperatpor");
            Assert.AreEqual(data.isoCountryCode, "5");
            Assert.AreEqual(data.network, "TestNetwork");
            Assert.AreEqual(data.operationalStatDate, "-0001-11-30 00:00:00");
            Assert.AreEqual(data.operationalState, "active");
            Assert.AreEqual(data.uniqueName, "Testing");
            Assert.AreEqual(data.numberOfSubscribers, 1);
        }
    }
}
