using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace EmpService.Custom
{
    public class CustomControllerSelector : DefaultHttpControllerSelector
    {
        HttpConfiguration _config;
        public CustomControllerSelector(HttpConfiguration config) : base(config)
        {
            _config = config;
        }

        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            // returns all web api controllers
            var controllers = GetControllerMapping();
            var routeData = request.GetRouteData();

            var controllerName = routeData.Values["controller"].ToString();

            string versionNumber = "1";
            var versionQueryString = HttpUtility.ParseQueryString(request.RequestUri.Query);
            if(versionQueryString["v"] != null) 
            {
                versionNumber = versionQueryString["v"];
            }

            if(versionNumber == "1")
            {
                controllerName = controllerName + "V1";
            }
            else
            {
                controllerName = controllerName + "V2";
            }

            HttpControllerDescriptor controllerDescriptor;
            if(controllers.TryGetValue(controllerName, out controllerDescriptor) == true)
            {
                return controllerDescriptor;                
            }

            return null;
        }
    }
}