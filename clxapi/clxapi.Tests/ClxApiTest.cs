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
        // TODO: Add testing
    }
}
