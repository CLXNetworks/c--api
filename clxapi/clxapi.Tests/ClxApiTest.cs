using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;
using System.Net;

namespace clxapi.Tests
{
    [TestClass]
    public class ClxApiTests
    {
        // Insert correct Username and Password for test.
        private ClxApi clxApi = new ClxApi(new string[] { "Username", "Password" });

        [TestMethod]
        public void GetOperatorTest()
        {
          var ret = clxApi.GetOperators();
          
          Assert.IsInstanceOfType(ret,typeof(JArray));         
        }

        // TODO: Add more testing
    }
}
