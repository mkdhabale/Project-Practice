using GitRepository.Models;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLog.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitRepository.Helpers.GitAPICommunication
{

    public class GitAPICommunication
    {
        static NLog.Logger logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

        public static async Task<List<GitUserRecieved>> FetchGitDetails(List<string> usernames, IMemoryCache _cache)
        {
            List<string> usernamesDistinct = new List<string>();
            usernamesDistinct.AddRange(usernames.Distinct());
            string url = API.configValue("FetchUser");
            RestSharp.Method RequestType = RestSharp.Method.Get;
            List<GitUserRecieved> gitUserRecieved = new List<GitUserRecieved>();
            //get all users detail from API 
            foreach (var user in usernamesDistinct)
            {
                string strDetail = "";
                GitUserRecieved gitUser = null;
                try
                {
                    if (!_cache.TryGetValue(user, out string userDetail))
                    {
                        //memory cache
                        int cacheConfig = Convert.ToInt32(API.configValue("CacheInMin"));
                        MemoryCacheEntryOptions cacheEntryOptions = new MemoryCacheEntryOptions
                        {
                            AbsoluteExpiration = DateTime.Now.AddMinutes(cacheConfig),
                            SlidingExpiration = TimeSpan.FromMinutes(cacheConfig),
                            Size = 1024,
                        };
                        try
                        {
                            //get from api if not in cache
                            strDetail = await API.GetAPIResultProcess(url + user, RequestType);
                            _cache.Set(user, strDetail, cacheEntryOptions);
                        }
                        catch (Exception ex)
                        {
                            logger.Error(ex, "Something went wrong, Please Contant Support Team.");
                            gitUser.is_found = false;
                            gitUser.error = "Something went wrong, Please Contant Support Team.";
                        }
                    }
                    else
                    {
                        strDetail = userDetail;
                    }
                }
                catch (Exception ex)
                {
                    logger.Error(ex, "Something went wrong, Please Contant Support Team.");
                    try
                    {
                        strDetail = await API.GetAPIResultProcess(url + user, RequestType);
                    }
                    catch (Exception ex1)
                    {
                        logger.Error(ex1, "Something went wrong, Please Contant Support Team.");
                        gitUser.is_found = false;
                        gitUser.error = "Something went wrong, Please Contant Support Team.";
                    }
                }

                if (gitUser == null)
                {
                    //create response based on api result
                    gitUser = JsonConvert.DeserializeObject<GitUserRecieved>(strDetail);
                    if (string.IsNullOrWhiteSpace(gitUser.message))
                        gitUser.is_found = true;
                    else if (gitUser.message.ToUpper() == "NOT FOUND")
                    {
                        gitUser.is_found = false;
                        gitUser.error = gitUser.message;
                    }
                    else
                    {
                        gitUser.error = gitUser.message;
                    }
                    if (gitUser != null)
                        gitUserRecieved.Add(gitUser);
                }
            }
            //order alplhabetically with null first and result result 
            return gitUserRecieved.OrderBy(q => q.name).ToList();
        }
    }
}
