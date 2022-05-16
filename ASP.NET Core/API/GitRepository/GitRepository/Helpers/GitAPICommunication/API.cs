using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using NLog.Web;

namespace GitRepository.Helpers.GitAPICommunication
{
    public class API
    {
        static NLog.Logger logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

        public static async Task<string> GetAPIResult(string url, Method RequestType, string parameter, string access_token)
        {
            string strDetail = string.Empty;
            try
            {
                //TO handle TLS SSL issue
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | (SecurityProtocolType)768 | (SecurityProtocolType)3072; // .NET 4.0

                var client = new RestClient(url);
                var request = new RestRequest("", RequestType);
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("content-type", "application/json");
                request.AddHeader("accept", "application/json");
                if (!string.IsNullOrWhiteSpace(access_token))
                    request.AddHeader("Authorization", "Bearer " + access_token);
                if (!string.IsNullOrWhiteSpace(parameter))
                    request.AddParameter("application/json", parameter, ParameterType.RequestBody);
                var response = await client.ExecuteAsync(request);
                strDetail = response.Content;

                if (Convert.ToString(response.StatusCode).ToUpper() == "UNAUTHORIZED")
                {
                    strDetail = "Unauthenticated.";
                }
                //invalid parameter send
                else if (Convert.ToString(response.StatusCode).ToUpper() == "422")
                {
                    strDetail = "ERROR";
                    throw new Exception(response.Content);
                }
                else if (Convert.ToString(response.StatusCode).ToUpper() == "NOTFOUND")
                {
                    //strDetail = "NOTFOUND";
                }
            }
            catch (WebException e)
            {
                logger.Error(e, "Something went wrong, Please Contant Support Team.");

                using (WebResponse response = e.Response)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)response;
                    using (Stream data = response.GetResponseStream())
                    using (var reader = new StreamReader(data))
                    {
                        JObject objJsonResponse = JObject.Parse(reader.ReadToEnd());
                        strDetail = Convert.ToString((JValue)objJsonResponse["message"]);
                    }
                }

                if (strDetail != "Unauthenticated.")
                {
                    throw;
                }

            }
            return strDetail;
        }

        public static async Task<string> GetAPIResultProcess(string url, Method RequestType, string parameter = "", string access_token = "")
        {
            //Generate token logic in case token requried
            if (string.IsNullOrEmpty(access_token)) { }


            string strFinalReponse = string.Empty;
            string strGetResponse = string.Empty;
            strGetResponse = await GetAPIResult(url, RequestType, parameter, access_token);
            if (!string.IsNullOrEmpty(strGetResponse))
            {
                if (strGetResponse.ToUpper() == "UNAUTHENTICATED.")
                {
                    //Get update token and used that
                    //access_token = GenerateAccessToken();
                    //updated token
                    strGetResponse = await GetAPIResult(url, RequestType, parameter, access_token);
                }

                if (!string.IsNullOrEmpty(strGetResponse))
                {
                    //response of url
                    strFinalReponse = strGetResponse;
                }
            }
            return strFinalReponse;
        }

        public static string configValue(string key)
        {
            return new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("GitAPI")[key];
        }
    }
}
