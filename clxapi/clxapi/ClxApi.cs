using System;
using System.Collections.Generic;
using clxapi.Client;
using clxapi.Adapter;

namespace clxapi
{
    /// <summary>
    /// Masterclass, To make request to Api, instance ClxApi and then call on chosen operator to retrieve data.
    /// </summary>
    public class ClxApi
    {
        private IHttpClient _httpClient;
        private ClxSettings _settings;

        /// <summary>
        /// Property to set client for api.
        /// </summary>
        public IHttpClient Client { 
            get 
            {
                return _httpClient;
            } 
        }    

        /// <summary>
        /// Constructor, Initialize with credentials array, It will then setup all other dependendancies in project.
        /// </summary>
        /// <example>Code example:
        /// <code> var clxApi = new ClxApi(new string[] { "Username", "Password" }); </code>
        /// </example>
        /// <param name="auth">Array with username and password for authentication.</param>
        /// <param  name="httpAdapter">Optional parameter, to add support for test adapters.</param>
        public ClxApi(String[] auth, IHttpAdapter httpAdapter = null)
        {
            _settings = new ClxSettings();
            _httpClient = new ClxHttpClient(_settings.BaseURI);

            _httpClient.HttpAdapter = (httpAdapter != null) ? httpAdapter : new HttpAdapter();
            _httpClient.HttpAdapter.Auth = auth;
        }

        /// <summary>
        /// Optional : Change base url for api.
        /// </summary>
        /// <example>Code example:
        /// <code> 
        /// var clxApi = new ClxApi(new string[] { "Username", "Password" }); 
        /// clxApi.SetBaseUrl("https://my-api.com/api")
        /// </code>
        /// </example>
        /// <param name="url">Send Url string to root of api.</param>
        public void SetBaseUrl(String url)
        {
            _httpClient.BaseURL = url;
        }


        /**************
        * OPERATORS
        **************/

        /// <summary>
        /// Returns all operators from Clx api.
        /// </summary>
        /// <example>Code example:
        /// <code> 
        /// var clxApi = new ClxApi(new string[] { "Username", "Password" }); 
        /// var operators = clxApi.GetOperators();
        /// </code>
        /// </example>
        /// <returns>IEnumerable list of all operators</returns>
        public IEnumerable<Operator> GetOperators()
        {
            var result = _httpClient.Get(ClxSettings.OperatorPath);
            var operators = result.ToObject<List<Operator>>();

            return operators;
        }

        /// <summary>
        /// Returns one operator from Clx api.
        /// </summary>
        /// <example>Code example:
        /// <code> 
        /// var clxApi = new ClxApi(new string[] { "Username", "Password" }); 
        /// Operator operator = clxApi.GetOperatorByID(14);
        /// </code>
        /// </example>
        /// <param name="id">Id of selected operator</param>
        /// <returns>Operator with selected id</returns>
        public Operator GetOperatorById(int id) 
        {
            var result = _httpClient.Get(ClxSettings.OperatorPath +id);
            var @operator = result.ToObject<Operator>();


            return @operator;
        }

        /**************
        * GATEWAYS
        **************/

        /// <summary>
        /// Returns all operators from Clx api.
        /// </summary>
        /// <example> Code example:
        /// <code>
        /// var clxApi = new ClxApi(new string[] { "Username", "Password" });
        /// var gateways = clxApi.GetGateways();
        /// </code>
        /// </example>
        /// <returns>IEnumerable list of all gateways</returns>
        public IEnumerable<Gateway> GetGateways()
        {
            var result = _httpClient.Get(ClxSettings.GatewayPath);
            var gateways = result.ToObject<List<Gateway>>();
          

            return gateways;
        }

        /// <summary>
        /// Returns one gateway from Clx api.
        /// </summary>
        /// <example>Code example:
        /// <code> 
        /// var clxApi = new ClxApi(new string[] { "Username", "Password" }); 
        /// Gateway gateway = clxApi.GetGatewayById(2182);
        /// </code>
        /// </example>
        /// <param name="id">Id of selected gateway</param>
        /// <returns>Gateway with selected id</returns>
        public Gateway GetGatewayById(int id)
        {
            var result = _httpClient.Get(ClxSettings.GatewayPath +id);
            var gateways = result.ToObject<Gateway>();

            return gateways;
        }

        /**************
        * Price Entries
        **************/

        /// <summary>
        /// Returns all price entries from selected gateway.
        /// </summary>
        /// <example>Code example:
        /// <code> 
        /// var clxApi = new ClxApi(new string[] { "Username", "Password" }); 
        /// var priceEntries = clxApi.GetPriceEntriesByGatewayId(2182);
        /// </code>
        /// </example>
        /// <param name="id">Id of selected gateway</param>
        /// <returns>IEnumerable list of all price entries by selected gateway id.</returns>
        public IEnumerable<PriceEntry> GetPriceEntriesByGatewayId(int id)
        {
            var result = _httpClient.Get(ClxSettings.GatewayPath +id +ClxSettings.PricePath);
            var priceEntries = result.ToObject<List<PriceEntry>>();
            return priceEntries;
        }

        /// <summary>
        /// Returns all price entries from selected gateway and selected operator.
        /// </summary>
        /// <example>Code example:
        /// <code> 
        /// var clxApi = new ClxApi(new string[] { "Username", "Password" }); 
        /// var priceEntries = clxApi.GetPriceEntriesByGatewayId(2182, 14);
        /// </code>
        /// </example>
        /// <param name="gatewayId">Id of selected gateway</param>
        /// <param name="operatorId">Id of selected operator</param>
        /// <returns>PriceEntry by selected gateway id and operator id.</returns>
        public PriceEntry GetPriceEntriesByGatewayIdAndOperatorId(int gatewayId, int operatorId)
        {
            var result = _httpClient.Get(ClxSettings.GatewayPath +gatewayId +ClxSettings.PricePath +operatorId);
            var priceEntries = result.ToObject<PriceEntry>();
            return priceEntries;
        }

        /// <summary>
        /// Returns all price entries from selected gateway and selected operator by selected date.
        /// </summary>
        /// <example>Code example:
        /// <code> 
        /// var clxApi = new ClxApi(new string[] { "Username", "Password" }); 
        /// var priceEntries = clxApi.GetPriceEntriesByGatewayId(2182, 14, new DateTime(2014, 05, 12));
        /// </code>
        /// </example>
        /// <param name="gatewayId">Id of selected gateway</param>
        /// <param name="operatorId">Id of selected operator</param>
        /// <param name="date">Selected date</param>
        /// <returns>PriceEntry by selected gateway id and operator id and operator id selected by Date.</returns>
        public PriceEntry GetPriceEntriesByGatewayIdAndOperatorIdAndDate(int gatewayId, int operatorId, DateTime date)
        {
            var selectedDateParam = String.Format("{0},{1}", ClxSettings.DateParam, date);
            var result = _httpClient.Get(ClxSettings.GatewayPath + gatewayId + ClxSettings.PricePath + operatorId);
            var priceEntries = result.ToObject<PriceEntry>();
            return priceEntries;
        }
    }
}