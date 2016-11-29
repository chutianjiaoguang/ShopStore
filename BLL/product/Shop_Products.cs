using System;
using System.Data;
using System.Collections.Generic;
using WebService.Model;
using System.Text;
using Common.Functions;
namespace WebService.BLL
{
    /// <summary>
    /// Shop_Products
    /// </summary>
    public partial class Shop_Products
    {
        private readonly WebService.DAL.Shop_Products dal = new WebService.DAL.Shop_Products();
        public Shop_Products()
        { }
        #region  BasicMethod
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(WebService.Model.Shop_Products model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(WebService.Model.Shop_Products model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(long ProductId)
        {

            return dal.Delete(ProductId);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string ProductIdlist)
        {
            return dal.DeleteList(ProductIdlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public WebService.Model.Shop_Products GetModel(long ProductId)
        {

            return dal.GetModel(ProductId);
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
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<WebService.Model.Shop_Products> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<WebService.Model.Shop_Products> DataTableToList(DataTable dt)
        {
            List<WebService.Model.Shop_Products> modelList = new List<WebService.Model.Shop_Products>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                WebService.Model.Shop_Products model;
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
        public string GetListJosn(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            List<WebService.Model.Shop_Products> list = DataTableToList(ds.Tables[0]);
            StringBuilder sb = new StringBuilder();
            JsonObject jsonObject = null;
            foreach (WebService.Model.Shop_Products t in list)
            {
                jsonObject = new JsonObject();
                jsonObject.AddProperty("ProductCode", t.ProductCode);
                jsonObject.AddProperty("ProductName", t.ProductName);
                jsonObject.AddProperty("Unit", t.Unit);
                jsonObject.AddProperty("LowestSalePrice", t.LowestSalePrice);
                jsonObject.AddProperty("productid", t.ProductId);

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
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}