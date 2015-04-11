using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Net;
using clxapi.Client;

namespace clxapi
{
    /// <summary>
    /// Masterclass, holds all Operators through requests are done, Make an instance of this class to acces the public operator methods.
    /// </summary>
    public class ClxApi
    {
        private IHttpClient _clxHttpClient;
        private ClxSettings _settings;
        

        /// <summary>
        /// Constructor, Initialize with credentials array, It will then setup all other dependendancies in project.
        /// </summary>
        /// <param name="Auth">Array with username and password for authentication.</param>
        /// <param  name="httpClient">Optional parameter, support for multiple HttpClients</param>
        public ClxApi(String [] Auth, IHttpClient httpClient = null)
        {
            _settings = new ClxSettings();
            if (httpClient == null)
            {
                
                _clxHttpClient = new ClxHttpClient(Auth, _settings);
            }
            else
            {
                _clxHttpClient = httpClient;
            }
                    
        }

        /**************
        * OPERATORS
        **************/

        /// <summary>
        /// Returns all operators from Clx api.
        /// </summary>
        /// <returns>JArray with operators</returns>
        public IEnumerable<Operator> GetOperators()
        {
            var result = _clxHttpClient.Get(ClxSettings.OperatorPath);
            var operators = result.ToObject<List<Operator>>();

            return operators;
        }

        public Operator GetOperatorById(int id) 
        {
            var result = _clxHttpClient.Get(ClxSettings.OperatorPath +id);
                return new Operator();
        }

        /**************
        * GATEWAYS
        **************/

        public IEnumerable<Gateway> GetGateways()
        {
            var result = _clxHttpClient.Get(ClxSettings.GatewayPath);
            var gateways = result.ToObject<List<Gateway>>();

            return gateways;
        }

        public Gateway GetGatewayById(int id)
        {
            var result = _clxHttpClient.Get(ClxSettings.GatewayPath +id);
            var gateways = result.ToObject<Gateway>();

            return gateways;
        }

        /**************
        * Price Entries
        **************/

        public IEnumerable<PriceEntry> GetPriceEntriesByGatewayId(int id)
        {
            var result = _clxHttpClient.Get(ClxSettings.GatewayPath +id +ClxSettings.PricePath);
            var priceEntries = result.ToObject<List<PriceEntry>>();
            return priceEntries;
        }

        public IEnumerable<PriceEntry> GetPriceEntriesByGatewayIdAndOperatorId(int gatewayId, int operatorId)
        {
            var result = _clxHttpClient.Get(ClxSettings.GatewayPath +gatewayId +ClxSettings.PricePath +operatorId);
            var priceEntries = result.ToObject<List<PriceEntry>>();
            return priceEntries;
        }

        public PriceEntry GetPriceEntriesByGatewayIdAndOperatorIdAndDate(int gatewayId, int operatorId, DateTime date)
        {
            var selectedDateParam = String.Format("{0},{1}", ClxSettings.DateParam, date);
            var result = _clxHttpClient.Get(ClxSettings.GatewayPath + gatewayId + ClxSettings.PricePath + operatorId);
            var priceEntries = result.ToObject<PriceEntry>();
            return priceEntries;
        }

    }
}