using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NFine.Code;
using Common.Functions;
using WebService.Model;

namespace NFine.Web.Areas.StoreManage.Controllers
{
    public class StoreInController : ControllerBase
    {
        //
        // GET: /StoreManage/StoreIn/
        private WebService.BLL.st_stockin bll = new WebService.BLL.st_stockin();
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
            List<WebService.Model.st_stockin> list = bll.GetModelList(keyword);

            var data = new
            {
                rows = list
            };
            return Content(data.ToJson());
        }
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetStoreSelectJson()
        {
            WebService.BLL.st_store storebll = new WebService.BLL.st_store();
            string s = storebll.GetListJosn("");
            return Content(s);
        }
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetCompanySelectJson()
        {
            WebService.BLL.st_providecompany company = new WebService.BLL.st_providecompany();
            string data = company.GetListJosn("");
            return Content(data);
        }
        [HandlerAjaxOnly]
        public ActionResult GetFormJson(string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                var data = bll.GetModel(keyValue);
                return Content(data.ToJson());
            }
            else
                return Content("");
        }
        [HttpPost]
        [HandlerAjaxOnly]
        public ActionResult GetProductGridJson(string keyValue)
        {
            if (keyValue == null)
                keyValue = "";
            WebService.BLL.st_stockproduct stobll = new WebService.BLL.st_stockproduct();
            List<WebService.Model.st_stockproductEx> list = stobll.GetModelList(keyValue);
            JsonObject jsonObject = new JsonObject();
            jsonObject.AddProperty("List", ConvertJson.ListToJson<WebService.Model.st_stockproductEx>(list, "Data"));
            jsonObject.AddProperty("Count", list.Count);
            return Content(jsonObject.ToString());
        }
        public ActionResult EditProduct()
        {
            return View();
        }
        [HttpPost]
        [HandlerAjaxOnly]
        public ActionResult GetProductSelectJson()
        {
            WebService.BLL.Shop_Products productbll = new WebService.BLL.Shop_Products();

            var data = productbll.GetModelList("");


            List<object> list = new List<object>();
            foreach (WebService.Model.Shop_Products item in data)
            {
                list.Add(new { id = item.ProductId, text = item.ProductName });
            }
            return Content(list.ToJson());
        }
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(WebService.Model.st_stockin storein,string datatablelist,  string keyValue)
        {
            string resultstr = "";
            string[] args = { };
            var t = ConvertJson.Deserialize<List<st_stockproductEx>>(datatablelist);
            List<st_stockproductEx> list = new List<st_stockproductEx>();
            JsonObject json = new JsonObject(datatablelist);
            int yy=json.GetPropertyNames().Count();
            for (int i = 0; i < yy;i++)
            {
                st_stockproductEx st = new st_stockproductEx();
                string ssss=json[i.ToString()].GetValue().ToString();
                if (ssss != "{}")
                {
                    st = ConvertJson.Deserialize<st_stockproductEx>(json[i.ToString()].GetValue().ToString());
                    list.Add(st);
                }
            }
            WebService.BLL.st_stockin bll = new WebService.BLL.st_stockin();
            storein.myname = OperatorProvider.Provider.GetCurrent().UserName;
            storein.userid = OperatorProvider.Provider.GetCurrent().UserId;
            int   result=bll.StoreInAdd(storein, list, keyValue);
            if (result > 0)
                resultstr = "操作成功";
            else
                resultstr = "操作失败";
            return Success(resultstr);
        }
    }
}
