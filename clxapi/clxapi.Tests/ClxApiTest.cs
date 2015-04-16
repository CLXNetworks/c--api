using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Security.Authentication;
using System.Collections.Generic;
using clxapi.Client;


namespace clxapi.Tests
{
    [TestClass]
    public class ClxApiTests
    {
        [TestMethod]
        public void TestGetOperators() 
        {
            var settings = new ClxSettings();
            var testClient = new TestClient(new string[] { "Username", "Password" }, settings);
            var clxApi = new ClxApi(new string[] { "Username", "Password" },testClient);
            var data = clxApi.GetOperators();

            Assert.IsInstanceOfType(data, typeof(IEnumerable<Operator>));
            Assert.IsNotNull(data);
            Assert.AreEqual(data.ToList()[1].name, "Bosse Mobile");
            Assert.AreEqual(data.ToList()[2].id, 777);
            Assert.AreEqual(data.ToList()[0].network, "PLC");
            Assert.AreEqual(data.ToList()[0].uniqueName, "PLC-PL");
            Assert.AreEqual(data.ToList()[1].isoCountryCode, "5");
            Assert.AreEqual(data.ToList()[2].operationalState, "active");
            Assert.AreEqual(data.ToList()[2].operationalStatDate, "-0001-11-30 00:00:00");
            Assert.AreEqual(data.ToList()[1].numberOfSubscribers, 11);
        }
        [TestMethod]
        public void TestGetOperatorByID()
        {
            var settings = new ClxSettings();
            var testClient = new TestClient(new string[] { "Username", "Password" }, settings);
            var clxApi = new ClxApi(new string[] { "Username", "Password" }, testClient);
            var data = clxApi.GetOperatorById(5);

            Assert.IsInstanceOfType(data, typeof(Operator));
            Assert.IsNotNull(data);
            Assert.AreEqual(data.name, "Bosse Mobile");
            Assert.AreEqual(data.id, 1058);
            Assert.AreEqual(data.network, "Bosse Mobile");
            Assert.AreEqual(data.uniqueName, "Bosse Mobile-AL");
            Assert.AreEqual(data.isoCountryCode, "5");
            Assert.AreEqual(data.operationalState, "inactive");
            Assert.AreEqual(data.operationalStatDate, "-0001-11-30 00:00:00");
            Assert.AreEqual(data.numberOfSubscribers, 5);
        }

        [TestMethod]
        public void TestGetGateways()
        {
            var settings = new ClxSettings();
            var testClient = new TestClient(new string[] { "Username", "Password" }, settings);
            var clxApi = new ClxApi(new string[] { "Username", "Password" }, testClient);
            IEnumerable<Gateway> data = clxApi.GetGateways();

            Assert.IsInstanceOfType(data, typeof(IEnumerable<Gateway>));
            Assert.IsNotNull(data);
            Assert.AreEqual(data.ToList()[0].id, 8888);
            Assert.AreEqual(data.ToList()[0].name, "Banan");
            Assert.AreEqual(data.ToList()[0].type, "Frukt");
            Assert.AreEqual(data.ToList()[1].id, 5);
            Assert.AreEqual(data.ToList()[2].name, "Kustpilen");
            Assert.AreEqual(data.ToList()[4].type, "Robot");
        }

        [TestMethod]
        public void TestTestGetOperatorsTestAPI()
        {
            var settings = new ClxSettings();
            settings.BaseURI = "http://localhost:1129/api";
            var testClient = new ClxHttpClient(new string[] { "Username", "Password" }, settings);
            var clxApi = new ClxApi(new string[] { "Username", "Password" }, testClient);
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
            var settings = new ClxSettings();
            settings.BaseURI = "http://localhost:1129/api";
            var testClient = new ClxHttpClient(new string[] { "Username", "Password" }, settings);
            var clxApi = new ClxApi(new string[] { "Username", "Password" }, testClient);
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

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void TestHttpNotFound()
        {
            var settings = new ClxSettings();
            settings.BaseURI = "http://localhost:1129/api";
            var testClient = new ClxHttpClient(new string[] { "Username", "Password" }, settings);
            var clxApi = new ClxApi(new string[] { "Username", "Password" }, testClient);
            testClient.Request("GET", ClxSettings.OperatorPath + 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestHttpBadRequest()
        {
            var settings = new ClxSettings();
            settings.BaseURI = "http://localhost:1129/api/";
            var testClient = new ClxHttpClient(new string[] { "Username", "Password" }, settings);
            var clxApi = new ClxApi(new string[] { "Username", "Password" }, testClient);
            testClient.Request("GET", ClxSettings.OperatorPath + "badparameter");
        }
        // TODO: Add testing
    }
}
