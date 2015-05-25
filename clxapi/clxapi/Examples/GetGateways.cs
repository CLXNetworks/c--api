using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace clxapi.Examples
{
    public class GetGateways
    {

        public void Example()
        {
            try
            {
                var clxApi = new ClxApi(new string[] { "Username", "Password" });
                var gateways = clxApi.GetGateways();
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