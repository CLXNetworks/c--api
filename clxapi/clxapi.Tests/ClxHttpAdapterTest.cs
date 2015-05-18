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
        public void AssertAdaptertCanHttpAuthWithCorrectAuth()
        {
            HttpAdapter httpAdapter = new HttpAdapter();
            httpAdapter.Auth = new string[] { "correctUsername", "correctPassword" };

            ClxResponse httpResponse = httpAdapter.Get("Http://httpbin.org/basic-auth/correctUsername/correctPassword");

            Assert.AreEqual(200, httpResponse.StatusCode);    
        }

        [TestMethod]
        public void HttpAdapterCatchBadRequest() 
        {
            HttpAdapter httpAdapter = new HttpAdapter();
            httpAdapter.Auth = new string[] { "Username", "Password" };

            ClxResponse httpsResponse = httpAdapter.Get("https://httpbin.org/status/400");
            Assert.AreEqual(400, httpsResponse.StatusCode);
        }

        [TestMethod]
        public void HttpAdapterCatchNotFound()
        {
            HttpAdapter httpAdapter = new HttpAdapter();
            httpAdapter.Auth = new string[] { "Username", "Password" };

            ClxResponse httpsResponse = httpAdapter.Get("https://httpbin.org/status/404");
            Assert.AreEqual(404, httpsResponse.StatusCode);
        }

        [TestMethod]
        public void HttpAdaptercatchInternalServerErrors()
        {
            HttpAdapter httpAdapter = new HttpAdapter();
            httpAdapter.Auth = new string[] { "Username", "Password" };

            ClxResponse httpsResponse = httpAdapter.Get("https://httpbin.org/status/500");
            Assert.AreEqual(500, httpsResponse.StatusCode);
        }

        [TestMethod]
        public void AssertAdaptertCanHttpsAuthWithCorrectAuth()
        {
            HttpAdapter httpAdapter = new HttpAdapter();
            httpAdapter.Auth = new string[] { "correctUsername", "correctPassword" };
       
            ClxResponse httpsResponse = httpAdapter.Get("Https://httpbin.org/basic-auth/correctUsername/correctPassword");
            Assert.AreEqual(200, httpsResponse.StatusCode);

        }

        [TestMethod]
        public void AuthWithIncorrectUsername()
        {
            HttpAdapter httpAdapter = new HttpAdapter();
            httpAdapter.Auth = new string[] { "wrongUsername", "correctPassword" };

            ClxResponse response = httpAdapter.Get("Http://httpbin.org/basic-auth/correctUsername/correctPassword");

            Assert.AreEqual(401, response.StatusCode);
        }

        

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

            List<int> list = new List<int>() { 200, 201};
            CollectionAssert.Contains(list,response.StatusCode);
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
