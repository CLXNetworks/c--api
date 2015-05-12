using clxapi.Adapter;
using clxapi.App_Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace clxapi.Tests.Adapter
{
    public class ClxTestAdapter : IHttpAdapter
    {
        public ClxResponse Response { get; set; }

        public string FullUrl { get; set; }

        public ClxTestAdapter(ClxResponse clxResponse)
        {
            Response = clxResponse;
        }
        public ClxResponse Get(string url)
        {
            return execute("GET", url);
        }

        public ClxResponse Post(string url, string body)
        {
            return execute("POST", url);
        }

        public ClxResponse Put(string url, string body)
        {
            return execute("PUT", url);
        }

        private ClxResponse execute(string method, string url)
        {
            FullUrl = url;
           
            return Response;
        }

        public string[] Auth{ get; set; }
    }
}
