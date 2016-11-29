using System;
using System.Data;
using System.Collections.Generic;
using WebService.Model;
using Common.Functions;
using System.Text;
namespace WebService.BLL
{
    /// <summary>
    /// st_store
    /// </summary>
    public partial class st_store
    {
        private readonly WebService.DAL.st_store dal = new WebService.DAL.st_store();
        public st_store()
        { }
        #region  BasicMethod
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(WebService.Model.st_store model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(WebService.Model.st_store model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int storeid)
        {

            return dal.Delete(storeid);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string storeidlist)
        {
            return dal.DeleteList(storeidlist);
        }
        public WebService.Model.st_store GetMode(int storeid)
        {
            return dal.GetModel(storeid);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        public string GetListJosn(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            List<WebService.Model.st_store> list= DataTableToList(ds.Tables[0]);
            StringBuilder sb = new StringBuilder();
            JsonObject jsonObject = null;
            foreach (WebService.Model.st_store t in list)
            {
                jsonObject = new JsonObject();
                jsonObject.AddProperty("storecode", t.storecode);
                jsonObject.AddProperty("storename", t.storename);
                jsonObject.AddProperty("storeid", t.storeid);
                sb.Append(jsonObject.ToString() + "\n");
            }
            if (sb.Length == 0)
            {
                sb.Append("\n");
            }
            string s = sb.ToString();
            return s;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<WebService.Model.st_store> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<WebService.Model.st_store> DataTableToList(DataTable dt)
        {
            List<WebService.Model.st_store> modelList = new List<WebService.Model.st_store>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                WebService.Model.st_store model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }
        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}