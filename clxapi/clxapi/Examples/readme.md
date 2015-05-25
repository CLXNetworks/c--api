## Examples 

###### In all examples, don't forget to use correct "Username" and "Password"

 ```  
GetGatewayById

try
{
    ClxApi clxApi = new ClxApi(new string[] { "Username", "Password" });
    Gateway gateway = clxApi.GetGatewayById(2182);
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



GetGateways

try
{
    ClxApi clxApi = new ClxApi(new string[] { "Username", "Password" });
    IEnumerable<Gateway> gateways = clxApi.GetGateways();
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



GetOperatorById

try
{
   ClxApi clxApi = new ClxApi(new string[] { "Username", "Password" }); 
   Operator @operator = clxApi.GetOperatorById(14);
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



GetOperators

try
{
    ClxApi clxApi = new ClxApi(new string[] { "Username", "Password" });
    IEnumerable<Operator> operators = clxApi.GetOperators();
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



GetPriceEntriesByGatewayId

try
{
    ClxApi clxApi = new ClxApi(new string[] { "Username", "Password" });
    IEnumerable<PriceEntry> priceEntries = clxApi.GetPriceEntriesByGatewayId(2183);
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



GetPriceEntriesByGatewayIdAndOperatorId   

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



GetPriceEntriesByGatewayIdAndOperatorIdAndDate

try
{
   ClxApi clxApi = new ClxApi(new string[] { "Username", "Password" }); 
   PriceEntry priceEntry = clxApi.GetPriceEntriesByGatewayIdAndOperatorIdAndDate(2182, 14, new DateTime(2014, 05, 12));
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
```  
