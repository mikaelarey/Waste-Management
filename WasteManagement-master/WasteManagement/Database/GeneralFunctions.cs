using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace WasteManagement.Database
{
    public class GeneralFunctions
    {
        public  readonly string ConnectionString = ConfigurationManager.ConnectionStrings["TRASURA"].ConnectionString;
    }
}