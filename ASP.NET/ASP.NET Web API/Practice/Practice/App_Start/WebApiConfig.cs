using Newtonsoft.Json.Serialization;
using Practice.CustomController.Versioning_QueryString;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace Practice
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            //Versioning with URI
            //placed custom routing at first before default
            //This is convention-based routing, you can use directly attribure routing in controller itself
            /*config.Routes.MapHttpRoute(
                name: "Version1",
                routeTemplate: "api/v1/VersioningURI/{id}",
                defaults: new { id = RouteParameter.Optional, controller = "VersioningURI1" }
                );
            config.Routes.MapHttpRoute(
                name: "Version2",
                routeTemplate: "api/v2/VersioningURI/{id}",
                defaults: new { id = RouteParameter.Optional, controller = "VersioningURI2" }
            );*/

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                 routeTemplate: "api/{controller}/{id}",
                 defaults: new { id = RouteParameter.Optional }
            //routeTemplate: "api/{controller}/{action}/{id}", // to custom Method name
            // defaults: new {id = RouteParameter.Optional }
            // defaults: new { action = RouteParameter.Optional, id = RouteParameter.Optional }
            );

            // Versioning with QueryString
            // Versioning with Custom Version Header
            // Versioning with Accept Header
            config.Services.Replace(typeof(IHttpControllerSelector),new CustomControllerSelector(config));

            //Raw data in Response should be Indented for proper visualisation
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            //Response Property Name formation to camel Case
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            //Return only JSON from ASP.NET Web API Service irrespective of the Accept header value
            //config.Formatters.Remove(config.Formatters.XmlFormatter);

            //Return only XML from ASP.NET Web API Service irrespective of the Accept header value
            //config.Formatters.Remove(config.Formatters.JsonFormatter);

            //Return JSON instead of XML from ASP.NET Web API Service when a request is made from the browser. 
            //Approach 1: The problem with this approach is that Content-Type header of the response is set to text/html which is misleading.
            //config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            //Approach 2:
            //config.Formatters.Add(new CustomJsonFormatter());

            //Enable HTTPS for ASP.NET Web API service.
            //Same can be done at controller level and method level
            config.Filters.Add(new RequireHttpsAttribute());
        }

        //Return JSON instead of XML from ASP.NET Web API Service when a request is made from the browser. 
        //Approach 2:
        public class CustomJsonFormatter : JsonMediaTypeFormatter
        {
            public CustomJsonFormatter()
            {
                this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            }

            public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, MediaTypeHeaderValue mediaType)
            {
                base.SetDefaultContentHeaders(type, headers, mediaType);
                headers.ContentType = new MediaTypeHeaderValue("application/json");
            }
        }

    }
}
