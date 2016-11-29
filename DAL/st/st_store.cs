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
    /// 数据访问类:st_store
    /// </summary>
    public partial class st_store
    {
        public st_store()
        { }
        #region  Method
        /// <summary>
        ///  增加一条数据
        /// </summary>
        public int Add(WebService.Model.st_store model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@storeid", SqlDbType.Int,4),
					new SqlParameter("@storename", SqlDbType.NVarChar,100),
					new SqlParameter("@shopid", SqlDbType.Int,4),
					new SqlParameter("@storecode", SqlDbType.NChar,10),
					new SqlParameter("@remark", SqlDbType.NVarChar,100)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.storename;
            parameters[2].Value = model.shopid;
            parameters[3].Value = model.storecode;
            parameters[4].Value = model.remark;

            DbHelperSQL.RunProcedure("st_store_ADD", parameters, out rowsAffected);
            return (int)parameters[0].Value;
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public bool Update(WebService.Model.st_store model)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@storeid", SqlDbType.Int,4),
					new SqlParameter("@storename", SqlDbType.NVarChar,100),
					new SqlParameter("@shopid", SqlDbType.Int,4),
					new SqlParameter("@storecode", SqlDbType.NChar,10),
					new SqlParameter("@remark", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.storeid;
            parameters[1].Value = model.storename;
            parameters[2].Value = model.shopid;
            parameters[3].Value = model.storecode;
            parameters[4].Value = model.remark;

            DbHelperSQL.RunProcedure("st_store_Update", parameters, out rowsAffected);
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
        /// 删除一条数据
        /// </summary>
        public bool Delete(int storeid)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@storeid", SqlDbType.Int,4)
			};
            parameters[0].Value = storeid;

            DbHelperSQL.RunProcedure("st_store_Delete", parameters, out rowsAffected);
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
        /// 得到一个对象实体
        /// </summary>
        public WebService.Model.st_store GetModel(int storeid)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@storeid", SqlDbType.Int,4)
			};
            parameters[0].Value = storeid;

            WebService.Model.st_store model = new WebService.Model.st_store();
            DataSet ds = DbHelperSQL.RunProcedure("st_store_GetModel", parameters, "ds");
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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string storeidlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from st_store ");
            strSql.Append(" where storeid in (" + storeidlist + ")  ");
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
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select storeid,storename,shopid,storecode,remark ");
            strSql.Append(" FROM st_store ");
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
            strSql.Append(" storeid,storename,shopid,storecode,remark ");
            strSql.Append(" FROM st_store ");
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
            strSql.Append("select count(1) FROM st_store ");
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
                strSql.Append("order by T.storeid desc");
            }
            strSql.Append(")AS Row, T.*  from st_store T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public WebService.Model.st_store DataRowToModel(DataRow row)
        {
            WebService.Model.st_store model = new WebService.Model.st_store();
            if (row != null)
            {
                if (row["storeid"] != null && row["storeid"].ToString() != "")
                {
                    model.storeid = int.Parse(row["storeid"].ToString());
                }
                if (row["storename"] != null)
                {
                    model.storename = row["storename"].ToString();
                }
                if (row["shopid"] != null && row["shopid"].ToString() != "")
                {
                    model.shopid = int.Parse(row["shopid"].ToString());
                }
                if (row["storecode"] != null)
                {
                    model.storecode = row["storecode"].ToString();
                }
                if (row["remark"] != null)
                {
                    model.remark = row["remark"].ToString();
                }
            }
            return model;
        }
        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}