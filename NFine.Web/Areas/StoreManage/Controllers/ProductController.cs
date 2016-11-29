using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NFine.Code;

namespace NFine.Web.Areas.StoreManage.Controllers
{
    public class ProductController : ControllerBase
    {
        private WebService.BLL.Shop_Products bll = new WebService.BLL.Shop_Products();
        //
        // GET: /StoreManage/Product/

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(string keyword)
        {
            if (keyword == null)
                keyword = "";
            List<WebService.Model.Shop_Products> list = bll.GetModelList(keyword);

            var data = new
            {
                rows = list
            };
            return Content(data.ToJson());
        }
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetProductSelectJson()
        {
            WebService.BLL.Shop_Products product = new WebService.BLL.Shop_Products();
            string s = product.GetListJosn("");
            return Content(s);
        }
    }
}
