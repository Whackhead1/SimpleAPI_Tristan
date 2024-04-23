using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SimpleAPI_Project
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            //I removed basic route registration, since they are only relevant if [Route("x")] is unpopulated, but I prefer to write them in explicitly
        }
    }
}
