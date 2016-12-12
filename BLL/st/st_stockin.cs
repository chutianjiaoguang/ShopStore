using System;
using System.Data;
using System.Collections.Generic;
using WebService.Model;
using System.Transactions;
namespace WebService.BLL
{
    /// <summary>
    /// st_stockin
    /// </summary>
    public partial class st_stockin
    {
        private readonly WebService.DAL.st_stockin dal = new WebService.DAL.st_stockin();
        public st_stockin()
        { }
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(WebService.Model.st_stockin model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(WebService.Model.st_stockin model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int stockinid)
        {

            return dal.Delete(stockinid);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string stockinidlist)
        {
            return dal.DeleteList(stockinidlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public WebService.Model.st_stockin GetModel(string singernumber)
        {

            return dal.GetModel(singernumber);
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
        public List<WebService.Model.st_stockin> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<WebService.Model.st_stockin> DataTableToList(DataTable dt)
        {
            List<WebService.Model.st_stockin> modelList = new List<WebService.Model.st_stockin>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                WebService.Model.st_stockin model;
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
        #region  ExtensionMethod   入库单事务性操作
        public int StoreInAdd(WebService.Model.st_stockin storein, List<st_stockproductEx> list,string keyvalue)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                int result = -1;
                storein.singernumber ="CG"+System.DateTime.Now.ToString("yyyyMMddHHmmss");  //通过一定方式来获取入库单编号
                if (list.Count>0)
                {
                    list.ForEach(a =>
                    {
                        a.singernumber = storein.singernumber;
                        a.storeid = storein.storeid;
                        a.storename = storein.storename;
                        a.userid = storein.userid;
                        a.myname = storein.myname;
                        a.stocktype = "CG";
                    });
                    if (string.IsNullOrEmpty(keyvalue))
                      result=dal.Add(storein);
                    else
                       result = dal.Update(storein);
                    BLL.st_stockproduct pro=new st_stockproduct();
                    result += pro.AddProductlist(list);
                    ts.Complete();
                    if (result > 0)
                        return 1;
                }
                return -1;
            }
        }
        #endregion  ExtensionMethod
    }
}