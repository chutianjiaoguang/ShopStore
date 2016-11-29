using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Common.DBHelper;//Please add references
namespace WebService.DAL
{
    /// <summary>
    /// 数据访问类:st_providecompany
    /// </summary>
    public partial class st_providecompany
    {
        public st_providecompany()
        { }
        #region  Method
        /// <summary>
        ///  增加一条数据
        /// </summary>
        public int Add(WebService.Model.st_providecompany model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@companyid", SqlDbType.Int,4),
					new SqlParameter("@companyname", SqlDbType.NVarChar,100),
					new SqlParameter("@pycode", SqlDbType.NVarChar,100),
					new SqlParameter("@code", SqlDbType.NChar,10),
					new SqlParameter("@phone", SqlDbType.NVarChar,20),
					new SqlParameter("@website", SqlDbType.NVarChar,100),
					new SqlParameter("@contactman", SqlDbType.NVarChar,20),
					new SqlParameter("@contactphone", SqlDbType.NVarChar,20),
					new SqlParameter("@qq", SqlDbType.NVarChar,20),
					new SqlParameter("@mc", SqlDbType.NVarChar,100),
					new SqlParameter("@industry", SqlDbType.NVarChar,200),
					new SqlParameter("@remark", SqlDbType.NVarChar,500),
					new SqlParameter("@shopid", SqlDbType.Int,4)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.companyname;
            parameters[2].Value = model.pycode;
            parameters[3].Value = model.code;
            parameters[4].Value = model.phone;
            parameters[5].Value = model.website;
            parameters[6].Value = model.contactman;
            parameters[7].Value = model.contactphone;
            parameters[8].Value = model.qq;
            parameters[9].Value = model.mc;
            parameters[10].Value = model.industry;
            parameters[11].Value = model.remark;
            parameters[12].Value = model.shopid;

            DbHelperSQL.RunProcedure("st_providecompany_ADD", parameters, out rowsAffected);
            return (int)parameters[0].Value;
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public bool Update(WebService.Model.st_providecompany model)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@companyid", SqlDbType.Int,4),
					new SqlParameter("@companyname", SqlDbType.NVarChar,100),
					new SqlParameter("@pycode", SqlDbType.NVarChar,100),
					new SqlParameter("@code", SqlDbType.NChar,10),
					new SqlParameter("@phone", SqlDbType.NVarChar,20),
					new SqlParameter("@website", SqlDbType.NVarChar,100),
					new SqlParameter("@contactman", SqlDbType.NVarChar,20),
					new SqlParameter("@contactphone", SqlDbType.NVarChar,20),
					new SqlParameter("@qq", SqlDbType.NVarChar,20),
					new SqlParameter("@mc", SqlDbType.NVarChar,100),
					new SqlParameter("@industry", SqlDbType.NVarChar,200),
					new SqlParameter("@remark", SqlDbType.NVarChar,500),
					new SqlParameter("@shopid", SqlDbType.Int,4)};
            parameters[0].Value = model.companyid;
            parameters[1].Value = model.companyname;
            parameters[2].Value = model.pycode;
            parameters[3].Value = model.code;
            parameters[4].Value = model.phone;
            parameters[5].Value = model.website;
            parameters[6].Value = model.contactman;
            parameters[7].Value = model.contactphone;
            parameters[8].Value = model.qq;
            parameters[9].Value = model.mc;
            parameters[10].Value = model.industry;
            parameters[11].Value = model.remark;
            parameters[12].Value = model.shopid;

            DbHelperSQL.RunProcedure("st_providecompany_Update", parameters, out rowsAffected);
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
        public bool Delete(int companyid)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@companyid", SqlDbType.Int,4)
			};
            parameters[0].Value = companyid;

            DbHelperSQL.RunProcedure("st_providecompany_Delete", parameters, out rowsAffected);
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
        public bool DeleteList(string companyidlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from st_providecompany ");
            strSql.Append(" where companyid in (" + companyidlist + ")  ");
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
        public WebService.Model.st_providecompany GetModel(int companyid)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@companyid", SqlDbType.Int,4)
			};
            parameters[0].Value = companyid;

            WebService.Model.st_providecompany model = new WebService.Model.st_providecompany();
            DataSet ds = DbHelperSQL.RunProcedure("st_providecompany_GetModel", parameters, "ds");
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
        public WebService.Model.st_providecompany DataRowToModel(DataRow row)
        {
            WebService.Model.st_providecompany model = new WebService.Model.st_providecompany();
            if (row != null)
            {
                if (row["companyid"] != null && row["companyid"].ToString() != "")
                {
                    model.companyid = int.Parse(row["companyid"].ToString());
                }
                if (row["companyname"] != null)
                {
                    model.companyname = row["companyname"].ToString();
                }
                if (row["pycode"] != null)
                {
                    model.pycode = row["pycode"].ToString();
                }
                if (row["code"] != null)
                {
                    model.code = row["code"].ToString();
                }
                if (row["phone"] != null)
                {
                    model.phone = row["phone"].ToString();
                }
                if (row["website"] != null)
                {
                    model.website = row["website"].ToString();
                }
                if (row["contactman"] != null)
                {
                    model.contactman = row["contactman"].ToString();
                }
                if (row["contactphone"] != null)
                {
                    model.contactphone = row["contactphone"].ToString();
                }
                if (row["qq"] != null)
                {
                    model.qq = row["qq"].ToString();
                }
                if (row["mc"] != null)
                {
                    model.mc = row["mc"].ToString();
                }
                if (row["industry"] != null)
                {
                    model.industry = row["industry"].ToString();
                }
                if (row["remark"] != null)
                {
                    model.remark = row["remark"].ToString();
                }
                if (row["setdate"] != null && row["setdate"].ToString() != "")
                {
                    model.setdate = DateTime.Parse(row["setdate"].ToString());
                }
                if (row["shopid"] != null && row["shopid"].ToString() != "")
                {
                    model.shopid = int.Parse(row["shopid"].ToString());
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
            strSql.Append("select companyid,companyname,pycode,code,phone,website,contactman,contactphone,qq,mc,industry,remark,setdate,shopid ");
            strSql.Append(" FROM st_providecompany ");
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
            strSql.Append(" companyid,companyname,pycode,code,phone,website,contactman,contactphone,qq,mc,industry,remark,setdate,shopid ");
            strSql.Append(" FROM st_providecompany ");
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
            strSql.Append("select count(1) FROM st_providecompany ");
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
                strSql.Append("order by T.companyid desc");
            }
            strSql.Append(")AS Row, T.*  from st_providecompany T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "st_providecompany";
            parameters[1].Value = "companyid";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}