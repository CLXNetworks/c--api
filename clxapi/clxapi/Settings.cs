using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace clxapi
{
    public class Settings : ISettings
    {
        // Add all paths to clx api here.
        public string operatorPath = "operator";

        /// <summary>
        /// Property to change selected path.
        /// </summary>
        public string Url { get; set; }
    }
}
