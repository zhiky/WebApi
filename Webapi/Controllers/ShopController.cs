using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI;
using IOT.DAL;
using IOT.Model;
using SelectModel;

namespace Webapi.Controllers
{
    public class ShopController : ApiController
    {
        ShopDAL dal = new ShopDAL();
        // GET: api/Shop
        public PageInfor Get(string Name = "", string Pricemin = "", string Pricemax = "", int Type = 0, int Band = 0, int CurrentPage = 1, int PageSize = 2)
        {
            var list = dal.Show();
            if (!string.IsNullOrEmpty(Name))
            {
                list = list.Where(s => s.Pname.Contains(Name)).ToList();
            }
            if (!string.IsNullOrEmpty(Pricemin) && !string.IsNullOrEmpty(Pricemax))
            {
                list = list.Where(s => s.Pmarket >= Convert.ToInt32(Pricemin) && s.Pmarket <= Convert.ToInt32(Pricemax)).ToList();
            }
            if (Type != 0)
            {
                list = list.Where(s => s.Ptype == Type).ToList();
            }
            if (Band != 0)
            {
                list = list.Where(s => s.Ppinpai == Band).ToList(); ;
            }
            //实例化分页类
            var p = new PageInfor();
            //总记录数
            p.TotalCount = list.Count();
            //计算总页数
            if (p.TotalCount == 0)
            {
                p.TotalPage = 1;
            }
            else if (p.TotalCount % PageSize == 0)
            {
                p.TotalPage = p.TotalCount / PageSize;
            }
            else
            {
                p.TotalPage = (p.TotalCount / PageSize) + 1;
            }
            //纠正当前页不正确的值
            if (CurrentPage < 1)
            {
                CurrentPage = 1;
            }
            if (CurrentPage > p.TotalPage)
            {
                CurrentPage = p.TotalPage;
            }
            p.shopModels = list.Skip(CurrentPage * (CurrentPage - 1)).Take(PageSize).ToList();

            p.CurrentPage = CurrentPage;
            return p;
            //var list = dal.Show();
            //if (!string.IsNullOrEmpty(goodPara.Name))
            //{
            //    list = list.Where(s => s.Pname.Contains(goodPara.Name)).ToList();
            //}
            //if (!string.IsNullOrEmpty(goodPara.Pricemin) && !string.IsNullOrEmpty(goodPara.pricemax))
            //{
            //    list = list.Where(s => s.Pmarket >= Convert.ToInt32(goodPara.Pricemin) && s.Pmarket <= Convert.ToInt32(goodPara.pricemax)).ToList();
            //}
            //if (goodPara.Type!=0)
            //{
            //    list = list.Where(s => s.Ptype == goodPara.Type).ToList();
            //}
            //if (goodPara.Band!=0)
            //{
            //    list = list.Where(s => s.Ppinpai == goodPara.Band).ToList(); ;
            //}
            ////实例化分页类
            //var p = new PageInfor();
            ////总记录数
            //p.TotalCount = list.Count();
            ////计算总页数
            //if (p.TotalCount==0)
            //{
            //    p.TotalPage = 1;
            //}
            //else if(p.TotalCount%goodPara.PageSize==0)
            //{
            //    p.TotalPage = p.TotalCount / goodPara.PageSize;
            //}
            //else
            //{
            //    p.TotalPage = (p.TotalCount / goodPara.PageSize) + 1;
            //}
            ////纠正当前页不正确的值
            //if (goodPara.CurrentPage<1)
            //{
            //    goodPara.CurrentPage = 1;
            //}
            //if (goodPara.CurrentPage>p.TotalPage)
            //{
            //    goodPara.CurrentPage = p.TotalPage;
            //}
            //p.shopModels = list.Skip(goodPara.CurrentPage * (goodPara.CurrentPage - 1)).Take(goodPara.PageSize).ToList();
            
            //p.CurrentPage = goodPara.CurrentPage;
            //return p;
        }

        
        //商品详情
        // GET: api/Shop/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Shop
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Shop/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Shop/5
        public void Delete(int id)
        {
        }
    }
}
