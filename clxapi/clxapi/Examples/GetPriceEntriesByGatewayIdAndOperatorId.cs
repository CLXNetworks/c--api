using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace clxapi.Examples
{
    /// <summary>
    /// Exampleclass, contains example in how to get PriceEntry by Gateway id and Operator id.
    /// </summary>
    public class GetPriceEntriesByGatewayIdAndOperatorId
    {
        /// <summary>
        /// Remember to replace "Username" and "Password" with correct authentication.
        /// </summary>
        public void Example()
        {
            try
            {
                ClxApi clxApi = new ClxApi(new string[] { "Username", "Password" });
                PriceEntry priceEntry = clxApi.GetPriceEntriesByGatewayIdAndOperatorId(2182, 14);
            }
            catch (ClxException e)
            {
                string errrorMessage = e.Message;
            }
            catch (ClxApiException e)
            {
                string clxErrrorMessage = e.ClxErrorMessage;
                int? clxErrorCode = e.ClxErrorCode;
                int statusCode = e.StatusCode;
            }
        }
    }
}