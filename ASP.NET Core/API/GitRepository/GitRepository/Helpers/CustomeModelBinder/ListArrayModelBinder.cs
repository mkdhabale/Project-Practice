using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GitRepository.Helpers.CustomeModelBinder
{
    //list array model binder from body
    public class ListArrayModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            string keyProperty = bindingContext.FieldName;

            if (bindingContext == null)
                throw new ArgumentNullException(nameof(bindingContext));

            string valueFromBody = string.Empty;

            using (var sr = new StreamReader(bindingContext.HttpContext.Request.Body))
            {
                valueFromBody =  sr.ReadToEnd();
            }
            List<string> strList = new List<string>();
            if (string.IsNullOrEmpty(valueFromBody))
            {
                // TO read from query string also
                string qS = bindingContext.HttpContext.Request.QueryString.Value;
                string[] qsArray = qS.Split(new[] { '&' });
                if (qsArray.Length > 0)
                    qsArray[0] = qsArray[0].TrimStart('?');
                for (int i = 0; i< qsArray.Length; i++)
                {
                    string[] qsArrayData = qsArray[i].Split(new[] { '=' });
                    if (qsArrayData[0] == keyProperty)
                        strList.Add(qsArrayData[1].ToString());
                }
                if(strList.Count == 0)
                    return Task.CompletedTask;
            }
            else {
                strList = JTokenToArray<string>(JObject.Parse(valueFromBody)[keyProperty]);
            }
            if (strList.Count > 0)
            {
                bindingContext.Result = ModelBindingResult.Success(strList);
            }

            return Task.CompletedTask;
        }


        private static List<T> JTokenToArray<T>(JToken jToken)
        {
            List<T> ret = new List<T>();
            foreach (JToken jItem in jToken)
                ret.Add(jItem.Value<T>());
            return ret;
        }
    }
}
