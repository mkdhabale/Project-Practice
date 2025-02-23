﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace Practice.CustomController.Versioning_QueryString
{
    // Derive from the DefaultHttpControllerSelector class
    public class CustomControllerSelector : DefaultHttpControllerSelector
    {
        private HttpConfiguration _config;
        public CustomControllerSelector(HttpConfiguration config) : base(config)
        {
            _config = config;
        }

        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            // Get all the available Web API controllers
            var controllers = GetControllerMapping();
            // Get the controller name and parameter values from the request URI
            var routeData = request.GetRouteData();

            // Get the controller name from route data.
            // The name of the controller in our case is "Students"
            var controllerName = routeData.Values["controller"].ToString();

            // Default version number to 1
            string versionNumber = "1";

            // Versioning with QueryString
            /*var versionQueryString = HttpUtility.ParseQueryString(request.RequestUri.Query);
            if (versionQueryString["v"] != null)
            {
                versionNumber = versionQueryString["v"];
            }*/

            // Versioning with Custom Version Header
            // Get the version number from Custom version header
            // This custom header can have any name. We have to use this
            // same header to specify the version when issuing a request
            /*string customHeader = "X-CustomHeader-StudentService-Version";
            if (request.Headers.Contains(customHeader))
            {
                versionNumber = request.Headers.GetValues(customHeader).FirstOrDefault();
                //Check if versionNumber contains comma, in case multiple time same header sent
                if (versionNumber.Contains(","))
                {
                    versionNumber = versionNumber.Substring(0, versionNumber.IndexOf(","));
                }
            }*/

            // Versioning with Accept Header
            // Get the version number from the Accept header
            // Users can include multiple Accept headers in the request
            // Check if any of the Accept headers has a parameter with name version
            var acceptHeader = request.Headers.Accept.Where(a => a.Parameters
                                .Count(p => p.Name.ToLower() == "version") > 0);

            // If there is atleast one header with a "version" parameter
            if (acceptHeader.Any())
            {
                // Get the version parameter value from the Accept header
                versionNumber = acceptHeader.First().Parameters
                                .First(p => p.Name.ToLower() == "version").Value;
            }


            if (versionNumber == "1")
            {
                // if version number is 1, then append V1 to the controller name.
                // So at this point the, controller name will become StudentsV1
                controllerName = controllerName + "V1";
            }
            else
            {
                // if version number is 2, then append V2 to the controller name.
                // So at this point the, controller name will become StudentsV2
                controllerName = controllerName + "V2";
            }

            HttpControllerDescriptor controllerDescriptor;
            if (controllers.TryGetValue(controllerName, out controllerDescriptor))
            {
                return controllerDescriptor;
            }

            return null;
        }
    }
}