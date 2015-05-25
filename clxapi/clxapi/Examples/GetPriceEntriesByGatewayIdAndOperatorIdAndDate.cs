using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace clxapi.Examples
{
    public class GetPriceEntriesByGatewayIdAndOperatorIdAndDate
    {
        public void Example()
        {
             try
             {
                 var clxApi = new ClxApi(new string[] { "Username", "Password" }); 
                 var priceEntry = clxApi.GetPriceEntriesByGatewayIdAndOperatorIdAndDate(2182, 14, new DateTime(2014, 05, 12));
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