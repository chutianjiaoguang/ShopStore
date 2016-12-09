using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace WebService.BLL
{
	/// <summary>
	/// st_stockproduct
	/// </summary>
	public partial class st_stockproduct
	{
		private readonly WebService.DAL.st_stockproduct dal=new WebService.DAL.st_stockproduct();
		public st_stockproduct()
		{}
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<WebService.Model.st_stockproductEx> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<WebService.Model.st_stockproductEx> DataTableToList(DataTable dt)
        {
            List<WebService.Model.st_stockproductEx> modelList = new List<WebService.Model.st_stockproductEx>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                WebService.Model.st_stockproductEx model;
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
        public int AddProductlist(List<WebService.Model.st_stockproductEx> list)
        {
           int result = -1;
           foreach (WebService.Model.st_stockproductEx productex in list)
           {
               if (productex.stproductid > 0)
                   result = dal.Update(productex);
               else
                   result=dal.Add(productex);
              if (result < 0)
                  return -1;
           }
           return result;
        }
    }
}
