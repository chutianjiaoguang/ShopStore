using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Common.DBHelper;
namespace WebService.DAL
{
    /// <summary>
    /// 数据访问类:st_stockin
    /// </summary>
    public partial class st_stockin
    {
        public st_stockin()
        { }
        #region  Method

        /// <summary>
        ///  增加一条数据
        /// </summary>
        public int Add(WebService.Model.st_stockin model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@stockinid", SqlDbType.Int,4),
					new SqlParameter("@singernumber", SqlDbType.NVarChar,32),
					new SqlParameter("@storeid", SqlDbType.Int,4),
					new SqlParameter("@storename", SqlDbType.NVarChar,50),
					new SqlParameter("@companyid", SqlDbType.Int,4),
					new SqlParameter("@companyname", SqlDbType.NVarChar,100),
					new SqlParameter("@purchasedate", SqlDbType.DateTime),
					new SqlParameter("@wishdate", SqlDbType.DateTime),
					new SqlParameter("@userid", SqlDbType.Int,4),
					new SqlParameter("@myname", SqlDbType.NVarChar,20),
					new SqlParameter("@remark", SqlDbType.NVarChar,100),
					new SqlParameter("@summoney", SqlDbType.Money,8)
                                        };
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.singernumber;
            parameters[2].Value = model.storeid;
            parameters[3].Value = model.storename;
            parameters[4].Value = model.companyid;
            parameters[5].Value = model.companyname;
            parameters[6].Value = model.purchasedate;
            parameters[7].Value = model.wishdate;
            parameters[8].Value = model.userid;
            parameters[9].Value = model.myname;
            parameters[10].Value = model.remark;
            parameters[11].Value = model.summoney;

            DbHelperSQL.RunProcedure("st_stockin_ADD", parameters, out rowsAffected);
            return (int)parameters[0].Value;
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public int Update(WebService.Model.st_stockin model)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@stockinid", SqlDbType.Int,4),
					new SqlParameter("@singernumber", SqlDbType.NVarChar,32),
					new SqlParameter("@storeid", SqlDbType.Int,4),
					new SqlParameter("@storename", SqlDbType.NVarChar,50),
					new SqlParameter("@companyid", SqlDbType.Int,4),
					new SqlParameter("@companyname", SqlDbType.NVarChar,100),
					new SqlParameter("@purchasedate", SqlDbType.DateTime),
					new SqlParameter("@wishdate", SqlDbType.DateTime),
					new SqlParameter("@remark", SqlDbType.NVarChar,100),
					new SqlParameter("@summoney", SqlDbType.Money,8)
                                        };
            parameters[0].Value = model.stockinid;
            parameters[1].Value = model.singernumber;
            parameters[2].Value = model.storeid;
            parameters[3].Value = model.storename;
            parameters[4].Value = model.companyid;
            parameters[5].Value = model.companyname;
            parameters[6].Value = model.purchasedate;
            parameters[7].Value = model.wishdate;
            parameters[8].Value = model.remark;
            parameters[9].Value = model.summoney;

            DbHelperSQL.RunProcedure("st_stockin_Update", parameters, out rowsAffected);
            return rowsAffected;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int stockinid)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@stockinid", SqlDbType.Int,4)
			};
            parameters[0].Value = stockinid;

            DbHelperSQL.RunProcedure("st_stockin_Delete", parameters, out rowsAffected);
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string stockinidlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from st_stockin ");
            strSql.Append(" where stockinid in (" + stockinidlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public WebService.Model.st_stockin GetModel(int stockinid)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@stockinid", SqlDbType.Int,4)
			};
            parameters[0].Value = stockinid;

            WebService.Model.st_stockin model = new WebService.Model.st_stockin();
            DataSet ds = DbHelperSQL.RunProcedure("st_stockin_GetModel", parameters, "ds");
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public WebService.Model.st_stockin DataRowToModel(DataRow row)
        {
            WebService.Model.st_stockin model = new WebService.Model.st_stockin();
            if (row != null)
            {
                if (row["stockinid"] != null && row["stockinid"].ToString() != "")
                {
                    model.stockinid = int.Parse(row["stockinid"].ToString());
                }
                if (row["singernumber"] != null)
                {
                    model.singernumber = row["singernumber"].ToString();
                }
                if (row["storeid"] != null && row["storeid"].ToString() != "")
                {
                    model.storeid = int.Parse(row["storeid"].ToString());
                }
                if (row["storename"] != null)
                {
                    model.storename = row["storename"].ToString();
                }
                if (row["companyid"] != null && row["companyid"].ToString() != "")
                {
                    model.companyid = int.Parse(row["companyid"].ToString());
                }
                if (row["companyname"] != null)
                {
                    model.companyname = row["companyname"].ToString();
                }
                if (row["purchasedate"] != null && row["purchasedate"].ToString() != "")
                {
                    model.purchasedate = DateTime.Parse(row["purchasedate"].ToString());
                }
                if (row["wishdate"] != null && row["wishdate"].ToString() != "")
                {
                    model.wishdate = DateTime.Parse(row["wishdate"].ToString());
                }
                if (row["checkuserid"] != null && row["checkuserid"].ToString() != "")
                {
                    model.checkuserid = row["checkuserid"].ToString();
                }
                if (row["checkname"] != null)
                {
                    model.checkname = row["checkname"].ToString();
                }
                if (row["checkdate"] != null && row["checkdate"].ToString() != "")
                {
                    model.checkdate = DateTime.Parse(row["checkdate"].ToString());
                }
                if (row["checkstatetext"] != null)
                {
                    model.checkstatetext = row["checkstatetext"].ToString();
                }
                if (row["checkstate"] != null && row["checkstate"].ToString() != "")
                {
                    model.checkstate = int.Parse(row["checkstate"].ToString());
                }
                if (row["paystate"] != null && row["paystate"].ToString() != "")
                {
                    model.paystate = int.Parse(row["paystate"].ToString());
                }
                if (row["paystatetext"] != null)
                {
                    model.paystatetext = row["paystatetext"].ToString();
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
                if (row["remark"] != null)
                {
                    model.remark = row["remark"].ToString();
                }
                if (row["summoney"] != null && row["summoney"].ToString() != "")
                {
                    model.summoney = decimal.Parse(row["summoney"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select stockinid,singernumber,storeid,storename,companyid,companyname,purchasedate,wishdate,checkuserid,checkname,checkdate,checkstatetext,checkstate,paystate,paystatetext,userid,myname,setdate,remark,summoney ");
            strSql.Append(" FROM st_stockin ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" stockinid,singernumber,storeid,storename,companyid,companyname,purchasedate,wishdate,checkuserid,checkname,checkdate,checkstatetext,checkstate,paystate,paystatetext,userid,myname,setdate,remark,summoney ");
            strSql.Append(" FROM st_stockin ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM st_stockin ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.stockinid desc");
            }
            strSql.Append(")AS Row, T.*  from st_stockin T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

