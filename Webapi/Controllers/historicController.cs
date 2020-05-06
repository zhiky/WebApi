using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IOT.Model;
using IOT.DAL;

namespace Webapi.Controllers
{
    public class historicController : ApiController
    {
        ShopDAL dal = new ShopDAL();
        // GET: api/historic
        //历史记录显示
        public IEnumerable<historic> Get()
        {
            return dal.Shows();
        }

        // GET: api/historic/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/historic
        //历史记录添加
        public int Post([FromBody]historic m)
        {
            return dal.Add(m);
        }

        // PUT: api/historic/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/historic/5
        public void Delete(int id)
        {
        }
    }
}
