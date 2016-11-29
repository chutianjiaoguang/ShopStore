using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common.Functions;
using NFine.Code;

namespace NFine.Web.Areas.StoreManage.Controllers
{
    public class StoreController : ControllerBase
    {
        //
        // GET: /StoreManage/Store/
        private WebService.BLL.st_store bll = new WebService.BLL.st_store();
        
        
        [HttpGet]
        [HandlerAjaxOnly]
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
           List<WebService.Model.st_store>  list = bll.GetModelList(keyword);
           
            var data = new
            {
                rows = list
            };
            return Content(data.ToJson());
        }
        [HttpPost]
        [HandlerAjaxOnly]
        public ActionResult GetStoreJson(string keyword)
        {
            if (keyword == null)
                keyword = "";
            List<WebService.Model.st_store> list = bll.GetModelList(keyword);

            var data = new
            {
                rows = list
            };
            return Content(data.ToJson());
        }
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(WebService.Model.st_store store, string keyValue)
        {
            string resultstr = "";
            if (!string.IsNullOrEmpty(keyValue))
            {
                store.storeid =int.Parse(keyValue);
                if (bll.Update(store))
                    resultstr = "修改成功";
                else
                    resultstr = "操作失败";
            }
            else
            {
                if(bll.Add(store)>0)
                    resultstr = "添加成功";
                else
                    resultstr = "操作失败";
            }
            return Success(resultstr);
        }
        [HttpPost]
        [HandlerAuthorize]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string keyValue)
        {
            string resultstr = "删除失败";
            if (!string.IsNullOrEmpty(keyValue))
            {
                if(bll.Delete(int.Parse(keyValue)))
                  resultstr = "删除成功";
                else
                  resultstr = "删除失败";
            }
            return Success(resultstr);
        }
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetFormJson(string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                var data = bll.GetMode(int.Parse(keyValue));
                return Content(data.ToJson());
            }
            else
                return Content("");
        }
        public ActionResult StoreDialog()
        {
            return View();
        }
    }
}
