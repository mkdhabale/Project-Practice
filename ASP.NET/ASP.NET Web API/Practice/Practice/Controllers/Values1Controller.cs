using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Practice.Controllers
{
    public class Values1Controller : ApiController
    {
        static List<string> strings = new List<string>()
        {
            "value0", "value1", "value2"
        };
        // GET: api/Values1
        public IEnumerable<string> Get()
        {
            return strings;
        }

        // GET: api/Values1/5
        public string Get(int id)
        {
            return strings[id];
        }

        // POST: api/Values1
        public void Post([FromBody] string value)
        {
            strings.Add(value);
        }

        // PUT: api/Values1/5
        public void Put(int id, [FromBody] string value)
        {
            strings[id] = value;
        }

        // DELETE: api/Values1/5
        public void Delete(int id)
        {
            strings.RemoveAt(id);
        }
    }
}
