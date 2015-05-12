using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clxapi.App_Data
{
    /// <summary>
    /// Class contains testdata for tests.
    /// </summary>
    public class TestData
    { 
        /// <summary>
        /// Returns array of Operator for tests.
        /// </summary>
        public string operators
        {
            get {
                Operator[] operators = new Operator[]
                {
                    new Operator
                {
                    id = 1,
                    name = "Testoperatpor",
                    network = "TestNetwork",
                    uniqueName = "Testing",
                    isoCountryCode = "5",
                    operationalState = "active",
                    operationalStatDate = "-0001-11-30 00:00:00",
                    numberOfSubscribers =1
                },
                  new Operator
                {
                    id = 888,
                    name = "ULLA BELLA",
                    network = "Secretary",
                    uniqueName = "Bella",
                    isoCountryCode = "46",
                    operationalState = "inactive",
                    operationalStatDate = "-0001-11-30 00:00:00",
                    numberOfSubscribers = 8888
                }
                };
                return JsonConvert.SerializeObject(operators);
            }
        }
        /// <summary>
        /// Returns one Operator for tests.
        /// </summary>
        public string @operator { 

            get 
            {
                Operator @operator = new Operator 
                {
                    id = 55,
                    name = "Testoperatpor",
                    network = "TestNetwork",
                    uniqueName = "Testing",
                    isoCountryCode = "5",
                    operationalState = "active",
                    operationalStatDate = "-0001-11-30 00:00:00",
                    numberOfSubscribers = 1
                };
                return JsonConvert.SerializeObject(@operator);
            } 
        }
        /// <summary>
        /// Returns array of Gateway for tests. 
        /// </summary>
        public string Gateways
        {
            get
            {
                Gateway[] gateways = new Gateway[] 
                {
                    new Gateway
                    {
                        id = 5,
                        name = "StringNameValue",
                        type = "StringTypeValue"
                    },
                    new Gateway
                    {
                        id = 88,
                        name = "AnotherString",
                        type = "AnotherString"
                    },
                       new Gateway
                    {
                        id = 44,
                        name = "HelgiMobile",
                        type = "CustomType"
                    }
                };
                return JsonConvert.SerializeObject(gateways);
            }          
        }
        /// <summary>
        /// Returns one Gateway object for Tests.
        /// </summary>
          public string Gateway
        {
            get
            {
                var gateway = new Gateway
                      {
                          id = 1888,
                          name = "Demo",
                          type = "TestSupplier"
                      };
                return JsonConvert.SerializeObject(gateway);
            }
        }

    }
}
