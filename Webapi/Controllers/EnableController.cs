using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IOT.DAL;
using IOT.Model;


namespace Webapi.Controllers
{
    public class EnableController : ApiController
    {
        AdproductDal dal = new AdproductDal();
        // GET: api/Enable
        //状态
        public IEnumerable<AdEnable> Get()
        {
            return dal.AdEnable();
        }

        // GET: api/Enable/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Enable
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Enable/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Enable/5
        public void Delete(int id)
        {
        }
    }
}
