using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Common.DBHelper;

namespace WebService.DAL
{
    /// <summary>
	/// 数据访问类:st_stockproduct
	/// </summary>
    public partial class st_stockproduct
    {
        public st_stockproduct()
        { }
        #region  Method
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ProductName,ProductCode,stproductid,stocktype,singernumber,SkuId,productid,innum,outnum,unit,price,storeid,storename,userid,myname,setdate,productremark ");
            strSql.Append(" FROM vw_stockproduct ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public WebService.Model.st_stockproductEx DataRowToModel(DataRow row)
        {
            WebService.Model.st_stockproductEx model = new WebService.Model.st_stockproductEx();
            if (row != null)
            {
                if (row["stproductid"] != null && row["stproductid"].ToString() != "")
                {
                    model.stproductid = int.Parse(row["stproductid"].ToString());
                }
                if (row["stocktype"] != null)
                {
                    model.stocktype = row["stocktype"].ToString();
                }
                if (row["singernumber"] != null)
                {
                    model.singernumber = row["singernumber"].ToString();
                }
                if (row["SkuId"] != null && row["SkuId"].ToString() != "")
                {
                    model.SkuId = long.Parse(row["SkuId"].ToString());
                }
                if (row["productid"] != null && row["productid"].ToString() != "")
                {
                    model.productid = int.Parse(row["productid"].ToString());
                }
                if (row["innum"] != null && row["innum"].ToString() != "")
                {
                    model.innum = decimal.Parse(row["innum"].ToString());
                }
                if (row["outnum"] != null && row["outnum"].ToString() != "")
                {
                    model.outnum = decimal.Parse(row["outnum"].ToString());
                }
                if (row["unit"] != null)
                {
                    model.unit = row["unit"].ToString();
                }
                if (row["price"] != null && row["price"].ToString() != "")
                {
                    model.price = decimal.Parse(row["price"].ToString());
                }
                if (row["storeid"] != null && row["storeid"].ToString() != "")
                {
                    model.storeid = int.Parse(row["storeid"].ToString());
                }
                if (row["storename"] != null)
                {
                    model.storename = row["storename"].ToString();
                }
                if (row["userid"] != null && row["userid"].ToString() != "")
                {
                    model.userid = row["userid"].ToString();
                }
                if (row["myname"] != null)
                {
                    model.myname = row["myname"].ToString();
                }
                if (row["setdate"] != null && row["setdate"].ToString() != "")
                {
                    model.setdate = DateTime.Parse(row["setdate"].ToString());
                }
                if (row["productremark"] != null)
                {
                    model.productremark = row["productremark"].ToString();
                }
                if (row["ProductName"] != null)
                {
                    model.ProductName = row["ProductName"].ToString();
                }
                if (row["ProductCode"] != null)
                {
                    model.ProductCode = row["ProductCode"].ToString();
                }
                if (row["productremark"] != null)
                {
                    model.smallsumprice = decimal.Parse(row["price"].ToString()) * decimal.Parse(model.innum.ToString()) + decimal.Parse(row["price"].ToString()) * decimal.Parse(model.outnum.ToString());
                }
            }
            return model;
        }
        /// <summary>
        ///  增加一条数据
        /// </summary>
        public int Add(WebService.Model.st_stockproductEx model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@stproductid", SqlDbType.Int,4),
					new SqlParameter("@stocktype", SqlDbType.Char,10),
					new SqlParameter("@singernumber", SqlDbType.NVarChar,32),
					new SqlParameter("@SkuId", SqlDbType.BigInt,8),
					new SqlParameter("@productid", SqlDbType.Int,4),
					new SqlParameter("@innum", SqlDbType.Float,8),
					new SqlParameter("@outnum", SqlDbType.Float,8),
					new SqlParameter("@unit", SqlDbType.Char,10),
					new SqlParameter("@price", SqlDbType.Money,8),
					new SqlParameter("@storeid", SqlDbType.Int,4),
					new SqlParameter("@storename", SqlDbType.NVarChar,50),
					new SqlParameter("@userid", SqlDbType.VarChar,50),
					new SqlParameter("@myname", SqlDbType.NVarChar,20),
					new SqlParameter("@productremark", SqlDbType.NVarChar,100)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.stocktype;
            parameters[2].Value = model.singernumber;
            parameters[3].Value = model.SkuId;
            parameters[4].Value = model.productid;
            parameters[5].Value = model.innum;
            parameters[6].Value = model.outnum;
            parameters[7].Value = model.unit;
            parameters[8].Value = model.price;
            parameters[9].Value = model.storeid;
            parameters[10].Value = model.storename;
            parameters[11].Value = model.userid;
            parameters[12].Value = model.myname;
            parameters[13].Value = model.productremark;

            DbHelperSQL.RunProcedure("st_stockproduct_ADD", parameters, out rowsAffected);
            return (int)parameters[0].Value;
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public int Update(WebService.Model.st_stockproduct model)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@stproductid", SqlDbType.Int,4),
					new SqlParameter("@stocktype", SqlDbType.Char,10),
					new SqlParameter("@singernumber", SqlDbType.NVarChar,32),
					new SqlParameter("@SkuId", SqlDbType.BigInt,8),
					new SqlParameter("@productid", SqlDbType.Int,4),
					new SqlParameter("@innum", SqlDbType.Float,8),
					new SqlParameter("@outnum", SqlDbType.Float,8),
					new SqlParameter("@unit", SqlDbType.Char,10),
					new SqlParameter("@price", SqlDbType.Money,8),
					new SqlParameter("@storeid", SqlDbType.Int,4),
					new SqlParameter("@storename", SqlDbType.NVarChar,50),
					new SqlParameter("@userid", SqlDbType.VarChar,50),
					new SqlParameter("@myname", SqlDbType.NVarChar,20),
					new SqlParameter("@productremark", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.stproductid;
            parameters[1].Value = model.stocktype;
            parameters[2].Value = model.singernumber;
            parameters[3].Value = model.SkuId;
            parameters[4].Value = model.productid;
            parameters[5].Value = model.innum;
            parameters[6].Value = model.outnum;
            parameters[7].Value = model.unit;
            parameters[8].Value = model.price;
            parameters[9].Value = model.storeid;
            parameters[10].Value = model.storename;
            parameters[11].Value = model.userid;
            parameters[12].Value = model.myname;
            parameters[13].Value = model.productremark;

            DbHelperSQL.RunProcedure("st_stockproduct_Update", parameters, out rowsAffected);
            return rowsAffected;
        }
        #endregion
    }
}
