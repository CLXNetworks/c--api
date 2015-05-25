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
using clxapi.App_Data;


namespace clxapi.Tests
{
    [TestClass]
    public class ClxApiTests
    {

        [TestMethod]
        public void CanChangeBaseUrlOfClient()
        {
            ClxApi clxApi = new ClxApi(new string[] { "Username", "Password" });
            ClxSettings settings = new ClxSettings();
            Assert.AreEqual(clxApi.Client.BaseURL, settings.BaseURI);

            clxApi.SetBaseUrl("newBaseUrl");
            Assert.AreNotEqual(clxApi.Client.BaseURL, settings.BaseURI);
            Assert.AreEqual(clxApi.Client.BaseURL, "newBaseUrl");
        }

        [TestMethod]
        public void AssertClxApiCanGetOperators()
        {
            TestData testdata = new TestData();

            ClxResponse response = new ClxResponse();
            response.Body = testdata.operators;
            response.StatusCode = 200;

            ClxTestAdapter testAdapter = new ClxTestAdapter(response);
            ClxApi clxApi = new ClxApi(new string[] { "Username", "Password" }, testAdapter);
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

            Assert.AreEqual(clxApi.Client.BaseURL + ClxSettings.OperatorPath, testAdapter.FullUrl);
        }

        [TestMethod]
        public void AssertClxApiCanGetOperatorByID()
        {
            TestData testdata = new TestData();

            ClxResponse response = new ClxResponse();
            response.Body = testdata.@operator;
            response.StatusCode = 200;


            ClxTestAdapter testAdapter = new ClxTestAdapter(response);
            ClxApi clxApi = new ClxApi(new string[] { "Username", "Password" }, testAdapter);
            clxApi.SetBaseUrl("Https://TEST");
            int id = 55;
            Operator data = clxApi.GetOperatorById(id);

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

            Assert.AreEqual(clxApi.Client.BaseURL + ClxSettings.OperatorPath + id, testAdapter.FullUrl);
        }

        

        [TestMethod]
        public void AssertClxApiCanGetGateways()
        {
            TestData testdata = new TestData();

            ClxResponse response = new ClxResponse();
            response.Body = testdata.Gateways;
            response.StatusCode = 200;

            ClxTestAdapter testAdapter = new ClxTestAdapter(response);
            ClxApi clxApi = new ClxApi(new string[] { "Username", "Password" }, testAdapter);
            clxApi.SetBaseUrl("Https://TEST");
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

            Assert.AreEqual(clxApi.Client.BaseURL + ClxSettings.GatewayPath, testAdapter.FullUrl);
        }

        [TestMethod]
        public void AssertClxApiCanGetGatewayByID()
        {
            TestData testdata = new TestData();
            ClxResponse response = new ClxResponse();
            response.Body = testdata.Gateway;
            response.StatusCode = 200;

            ClxTestAdapter testAdapter = new ClxTestAdapter(response);
            ClxApi clxApi = new ClxApi(new string[] { "Username", "Password" }, testAdapter);
            int id = 1888;
            Gateway data = clxApi.GetGatewayById(id);

            Assert.IsInstanceOfType(data, typeof(Gateway));
            Assert.IsNotNull(data);
            Assert.AreEqual(data.id, 1888);
            Assert.AreEqual(data.name, "Demo");
            Assert.AreEqual(data.type, "TestSupplier");

            Assert.AreEqual(clxApi.Client.BaseURL + ClxSettings.GatewayPath + id, testAdapter.FullUrl);
        }

        [TestMethod]
        public void CheckUrlOfGetOperators()
        {
            ClxResponse response = new ClxResponse();
            response.Body = "[{},{}]";
            ClxTestAdapter testAdapter = new ClxTestAdapter(response);
            ClxApi clxApi = new ClxApi(new string[] { "Username", "Password" }, testAdapter);
            clxApi.SetBaseUrl("Https://TEST");
            IEnumerable<Operator> data = clxApi.GetOperators();

            Assert.AreEqual("Https://TEST" + ClxSettings.OperatorPath, testAdapter.FullUrl);
        }

        [TestMethod]
        public void CheckUrlOfGetOperatorById()
        {
            ClxResponse response = new ClxResponse();
            response.Body = "{}";
            ClxTestAdapter testAdapter = new ClxTestAdapter(response);
            ClxApi clxApi = new ClxApi(new string[] { "Username", "Password" }, testAdapter);
            clxApi.SetBaseUrl("Https://TEST");
            int id = 55;
            Operator data = clxApi.GetOperatorById(id);

            Assert.AreEqual("Https://TEST" + ClxSettings.OperatorPath + "55", testAdapter.FullUrl);
        }

        [TestMethod]
        public void CheckUrlOfGetGateways()
        {
            ClxResponse response = new ClxResponse();
            response.Body = "[{},{}]";
            ClxTestAdapter testAdapter = new ClxTestAdapter(response);
            ClxApi clxApi = new ClxApi(new string[] { "Username", "Password" }, testAdapter);
            clxApi.SetBaseUrl("Https://TEST");
            IEnumerable<Gateway> data = clxApi.GetGateways();

            Assert.AreEqual("Https://TEST" + ClxSettings.GatewayPath, testAdapter.FullUrl);
        }

        [TestMethod]
        public void CheckUrlOfGetGatewaysById()
        {
            ClxResponse response = new ClxResponse();
            response.Body = "{}";
            ClxTestAdapter testAdapter = new ClxTestAdapter(response);
            ClxApi clxApi = new ClxApi(new string[] { "Username", "Password" }, testAdapter);
            clxApi.SetBaseUrl("Https://TEST");
            int id = 66;
            Gateway data = clxApi.GetGatewayById(id);

            Assert.AreEqual("Https://TEST" + ClxSettings.GatewayPath + id, testAdapter.FullUrl);
        }

        [TestMethod]
        public void CheckUrlOfGetPriceEntriesByGatewayId()
        {
            ClxResponse response = new ClxResponse();
            response.Body = "[{},{}]";
            ClxTestAdapter testAdapter = new ClxTestAdapter(response);
            ClxApi clxApi = new ClxApi(new string[] { "Username", "Password" }, testAdapter);
            clxApi.SetBaseUrl("Https://TEST");
            int id = 5234378;
            IEnumerable<PriceEntry> data = clxApi.GetPriceEntriesByGatewayId(id);

            Assert.AreEqual("Https://TEST" + ClxSettings.GatewayPath + id + ClxSettings.PricePath, testAdapter.FullUrl);
        }

        [TestMethod]
        public void CheckUrlOfGetPriceEntriesByGatewayIdAndOperatorId()
        {
            ClxResponse response = new ClxResponse();
            response.Body = "{}";
            ClxTestAdapter testAdapter = new ClxTestAdapter(response);
            ClxApi clxApi = new ClxApi(new string[] { "Username", "Password" }, testAdapter);
            clxApi.SetBaseUrl("Https://TEST");
            int id = 5234378;
            int id2 = 1312;
            PriceEntry data = clxApi.GetPriceEntriesByGatewayIdAndOperatorId(id, id2);

            Assert.AreEqual("Https://TEST" + ClxSettings.GatewayPath + id + ClxSettings.PricePath + id2, testAdapter.FullUrl);
        }

        [TestMethod]
        public void CheckUrlOfGetPriceEntriesByGatewayIdAndOperatorIdAndDate()
        {
            ClxResponse response = new ClxResponse();
            response.Body = "{}";
            ClxTestAdapter testAdapter = new ClxTestAdapter(response);
            ClxApi clxApi = new ClxApi(new string[] { "Username", "Password" }, testAdapter);
            clxApi.SetBaseUrl("Https://TEST");
            int id = 5234378;
            int id2 = 1312;
            DateTime date = new DateTime(1999,12,12);
            PriceEntry data = clxApi.GetPriceEntriesByGatewayIdAndOperatorIdAndDate(id, id2, date);

            Assert.AreEqual("Https://TEST"  + ClxSettings.GatewayPath + id + ClxSettings.PricePath + id2 + ClxSettings.DateParam + "1999-12-12", testAdapter.FullUrl);
        }
    }
}
