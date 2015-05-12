using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;
using clxapi;
using clxapi.Client;
using clxapi.Adapter;
using clxapi.Tests.Adapter;
using clxapi.App_Data;
using Newtonsoft.Json.Linq;


namespace clxapi.Tests
{
    [TestClass]
    public class ClxHttpAdapterTest
    {

        [TestMethod]
        public void AssertAdaptertCanGet()
        {
            HttpAdapter httpAdapter = new HttpAdapter();
            httpAdapter.Auth = new string[] { "Username", "Password" };

            ClxResponse response = httpAdapter.Get("Http://httpbin.org/get");

            Assert.AreEqual(response.StatusCode, 200);
            dynamic body = JValue.Parse(response.Body);
            Assert.AreEqual((string)body.headers.Host, "httpbin.org");
        }

        [TestMethod]
        public void AssertAdaptertCanPut()
        {
            HttpAdapter httpAdapter = new HttpAdapter();
            httpAdapter.Auth = new string[] { "Username", "Password" };

            Gateway putObject = new Gateway
            {
                id = 5,
                name = "Phone Expert 3",
                type = "Internal messaging"
            };

            String stringifiedObject = putObject.Stringyfy();

            ClxResponse response = httpAdapter.Put("Http://httpbin.org/put", stringifiedObject);
            JObject body = JObject.Parse(response.Body);
            Gateway objectReturned = body["json"].ToObject<Gateway>();

            Assert.AreEqual(response.StatusCode, 200);
            Assert.AreEqual(objectReturned.id, putObject.id);
            Assert.AreEqual(objectReturned.name, putObject.name);
            Assert.AreEqual(objectReturned.type, putObject.type);
        }

        [TestMethod]
        public void AssertAdaptertCanPost()
        {           
            Operator postObject = new Operator
            {
                name = "Testoperatpor",
                isoCountryCode = "5",
                network = "TestNetwork",
                operationalStatDate = "-0001-11-30 00:00:00",
                operationalState = "active",
                uniqueName = "Testing",
                numberOfSubscribers = 1
            };

            String stringifiedData = postObject.Stringyfy();
            HttpAdapter httpAdapter = new HttpAdapter();
            httpAdapter.Auth = new string[] { "Username", "Password" };

            ClxResponse response = httpAdapter.Post("Http://httpbin.org/post", stringifiedData);

            Assert.AreEqual(response.StatusCode, 200);
            JObject body = JObject.Parse(response.Body);
            Operator objectReturned = body["json"].ToObject<Operator>();

            Assert.AreEqual(objectReturned.isoCountryCode, postObject.isoCountryCode);
            Assert.AreEqual(objectReturned.name, postObject.name);
            Assert.AreEqual(objectReturned.network, postObject.network);
            Assert.AreEqual(objectReturned.operationalStatDate, postObject.operationalStatDate);
            Assert.AreEqual(objectReturned.operationalState, postObject.operationalState);
            Assert.AreEqual(objectReturned.uniqueName, postObject.uniqueName);
            Assert.AreEqual(objectReturned.numberOfSubscribers, postObject.numberOfSubscribers);
        }
    }
}
