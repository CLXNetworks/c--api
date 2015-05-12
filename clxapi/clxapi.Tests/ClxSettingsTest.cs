using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace clxapi.Tests
{
    [TestClass]
    public class ClxSettingsTest
    {
        [TestMethod]
        public void AssertCorrectClxSettingsDateParam()
        {
            Assert.AreEqual(ClxSettings.DateParam, "/date=");
        }

        [TestMethod]
        public void AssertCorrectClxSettingsGatewayPath()
        {
            Assert.AreEqual(ClxSettings.GatewayPath, "/gateway/");  
        }

        [TestMethod]
        public void AssertCorrectClxSettingsOperatorPath()
        {
            Assert.AreEqual(ClxSettings.OperatorPath, "/operator/");
            Assert.AreEqual(ClxSettings.PricePath, "/price/");
            var settings = new ClxSettings();
            Assert.AreEqual(settings.BaseURI, "https://clx-aws.clxnetworks.com/api"); 
        }

         [TestMethod]
        public void AssertCorrectClxSettingsPricePath()
         {
             Assert.AreEqual(ClxSettings.PricePath, "/price/");
         }

         [TestMethod]
         public void AssertCorrectClxSettingsBaseUriPath()
         {
             var settings = new ClxSettings();
             Assert.AreEqual(settings.BaseURI, "https://clx-aws.clxnetworks.com/api");
         }
      
    }
}
