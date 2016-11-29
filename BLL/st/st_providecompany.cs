using System;
using System.Data;
using System.Collections.Generic;
using WebService.Model;
using System.Text;
using Common.Functions;
namespace WebService.BLL
{
    /// <summary>
    /// st_providecompany
    /// </summary>
    public partial class st_providecompany
    {
        private readonly WebService.DAL.st_providecompany dal = new WebService.DAL.st_providecompany();
        public st_providecompany()
        { }
        #region  BasicMethod
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(WebService.Model.st_providecompany model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(WebService.Model.st_providecompany model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int companyid)
        {
            return dal.Delete(companyid);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string companyidlist)
        {
            return dal.DeleteList(companyidlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public WebService.Model.st_providecompany GetModel(int companyid)
        {
            return dal.GetModel(companyid);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        public string GetListJosn(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            List<WebService.Model.st_providecompany> list = DataTableToList(ds.Tables[0]);
            StringBuilder sb = new StringBuilder();
            JsonObject jsonObject = null;
            foreach (WebService.Model.st_providecompany t in list)
            {
                jsonObject = new JsonObject();
                jsonObject.AddProperty("code", t.code);
                jsonObject.AddProperty("companyname", t.companyname);
                jsonObject.AddProperty("companyid", t.companyid);
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
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<WebService.Model.st_providecompany> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<WebService.Model.st_providecompany> DataTableToList(DataTable dt)
        {
            List<WebService.Model.st_providecompany> modelList = new List<WebService.Model.st_providecompany>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                WebService.Model.st_providecompany model;
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
        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}