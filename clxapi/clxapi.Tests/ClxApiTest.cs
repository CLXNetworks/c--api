using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Security.Authentication;

namespace clxapi.Tests
{
    [TestClass]
    public class ClxApiTests
    { 
        
        [TestMethod]
        public void GetTest()
        {
            var dev = new DeveloperSettings();

            var clxApi = new ClxApi(new string[] { dev.Username, dev.Password });
            //var data = clxApi.GetGatewayById(2182);
            //var data = clxApi.GetGateways();
            //var data = clxApi.GetOperatorById(10);
            var data = clxApi.GetPriceEntriesByGatewayId(2182);
            //var data = clxApi.GetPriceEntriesByGatewayIdAndOperatorId(2182, 8);
            //var data = clxApi.GetPriceEntriesByGatewayIdAndOperatorIdAndDate(2182, 8, new DateTime(2012,01,01));
            Assert.IsInstanceOfType(data, typeof(JArray));
            Assert.IsNotNull(data);
        
        }
        [TestMethod]
        [ExpectedException(typeof(AuthenticationException))]
        public void GetOperatorTestAuthenticationWrongPassword()
        {
            var dev = new DeveloperSettings();

            var clxApi = new ClxApi(new string[] { dev.Username, "wrongPassword" });
            var data = clxApi.GetOperators();
            Assert.IsNull(data);

        }

        [TestMethod]
        [ExpectedException(typeof(AuthenticationException))]
        public void GetOperatorTestAuthenticationWrongUsername()
        {
            var dev = new DeveloperSettings();

            var clxApi = new ClxApi(new string[] { "wrongUserName", dev.Password });
            var data = clxApi.GetOperators();
            Assert.IsNull(data);
        } 
        // TODO: Add more testing
    }
}
