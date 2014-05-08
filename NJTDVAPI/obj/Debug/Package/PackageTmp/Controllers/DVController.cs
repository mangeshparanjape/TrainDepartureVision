using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NJTDVAPI.Models;

namespace NJTDVAPI.Controllers
{
    public class DVController : ApiController
    {
        // GET api/dv
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/dv/5
        public string Get(string id)
        {
            string dv = string.Empty;
            DV objDV = new DV();
            dv = objDV.GetDVByStationID(id);
            return dv;
        }

        // POST api/dv
        public void Post([FromBody]string value)
        {
        }

        // PUT api/dv/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/dv/5
        public void Delete(int id)
        {
        }
    }
}
