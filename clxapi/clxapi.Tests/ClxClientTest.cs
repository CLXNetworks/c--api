using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using clxapi.Client;
using clxapi.Tests.Adapter;
using Newtonsoft.Json.Linq;
using clxapi.App_Data;
using clxapi.Adapter;

namespace clxapi.Tests
{
    [TestClass] 
    public class ClxClientTest
    {
        //TODO: Add test for Post and Put in ClxHttpClient
        [TestMethod]
        public void AssertHttpClientInitializeCorrectDefaultBaseUrl()
        {
            ClxApi api = new ClxApi(new string[] { "Username", "Password" });
            ClxSettings settings = new ClxSettings();
            Assert.AreEqual(api.Client.BaseURL, settings.BaseURI);
        }

        [TestMethod]
        [ExpectedException(typeof(ClxApiException))]
        public void AssertHttpClientThrowClxApiExceptionWhenNotFound()
        {
            ClxResponse response = new ClxResponse();
            response.Body = JValue.Parse("{\"error\":{\"message\":\"Could not find operator with id: 8976\",\"code\":3001}}").ToString();
            response.StatusCode = 404;
            ClxTestAdapter testAdapter = new ClxTestAdapter(response);
            ClxApi clxApi = new ClxApi(new string[] { "Username", "Password" }, testAdapter);
            clxApi.SetBaseUrl("https://TEST");
            var client = clxApi.Client;
            dynamic clientParsedResponse = client.Get("/TESTSTRING/");
        }

        [TestMethod]
        [ExpectedException(typeof(ClxException))]
        public void AssertHttpClientParseResponseThrowClxExceptionWhenInvalidJson()
        {
            ClxResponse response = new ClxResponse();
            response.Body = "{\"error\":{\"message\":Invalid Json format object\",\"code\":3001}";
            ClxTestAdapter testAdapter = new ClxTestAdapter(response);
            ClxApi clxApi = new ClxApi(new string[] { "Username", "Password"},testAdapter );
            var client = clxApi.Client;
            client.Get("/TESTSTRING/");
        }

        [TestMethod]
        [ExpectedException(typeof(ClxException))]
        public void AssertHttpClientParseResponseThrowClxExceptionWhenBodyIsNull()
        {
            ClxResponse response = new ClxResponse();
            response.Body = null;
            ClxTestAdapter testAdapter = new ClxTestAdapter(response);
            ClxApi clxApi = new ClxApi(new string[] { "Username", "Password" }, testAdapter);
            var client = clxApi.Client;
            client.Get("/TESTSTRING/");
        }

        [TestMethod]
        public void AssertHttpClientDoesCorrectParseWhenBodyIsEmtyObject()
        {
            ClxResponse response = new ClxResponse();
            response.Body = "{}";
            ClxTestAdapter testAdapter = new ClxTestAdapter(response);
            ClxApi clxApi = new ClxApi(new string[] { "Username", "Password" }, testAdapter);
            var client = clxApi.Client;
            var parsedResponse = client.Put("/TESTSTRING/","{Placeholder:NotImportant}");

            Assert.AreEqual("{}", parsedResponse.ToString());
        }

        [TestMethod]
        public void AssertHttpClientThrowCorrectFormatClxApiException()
        {
            ClxResponse response = new ClxResponse();
            response.Body = JValue.Parse("{\"error\":{\"message\":\"You made a bad request\",\"code\":4000}}").ToString();
            response.StatusCode = 400;
            ClxTestAdapter testAdapter = new ClxTestAdapter(response);
            ClxApi clxApi = new ClxApi(new string[] { "Username", "Password" }, testAdapter);
            clxApi.SetBaseUrl("https://TEST");
            var client = clxApi.Client;
            try
            {
                client.Post("/TESTSTRING/", "{Placeholder:NotImportant}");
            }
            catch (ClxApiException e)
            {
                var errorMessage = e.ClxErrorMessage;
                var errorCode = e.ClxErrorCode;
                Assert.IsNotNull(errorMessage);
                Assert.AreEqual("You made a bad request",errorMessage);
                Assert.IsInstanceOfType(errorMessage, typeof(string));
                Assert.IsNotNull(errorCode);
                Assert.AreEqual(4000, errorCode);
                Assert.IsInstanceOfType(errorCode, typeof(int));
            }
        }
    }
}
