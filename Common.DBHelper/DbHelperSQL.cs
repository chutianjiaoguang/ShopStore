using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Configuration;
using Common.LogNet;
using System.Collections;

namespace Common.DBHelper
{
    public static class DbHelperSQL
    {
        //数据库连接字符串(web.config来配置)，可以动态更改connectionString支持多数据库.	

        public static readonly string connectionString = PubConstant.ConnectionString;
        /// <summary>
        /// true-连接成功;false-连接失败;
        /// </summary>
        public static bool _IsContect=true;

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        int rows = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return rows;
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        throw e;
                    }
                }
            }
        }

        #region  判断数据库连接是否正常
        /// <summary>
        /// 判断数据库连接是否正常
        /// </summary>
        /// <returns></returns>
        public static bool IsConnect()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    _IsContect = true;
                    return true;
                }
                catch (System.Data.SqlClient.SqlException E)
                {
                    MyLog.error(E.Message);
                    _IsContect = false;
                    return false;
                }
                finally
                {
                    conn.Dispose();
                }
            }
        }
        #endregion

        #region 判断某个表是否存在
        /// <summary>
        /// 表是否存在
        /// </summary>
        /// <param name="TableName">表名</param>
        /// <returns>表是否存在</returns>
        public static bool TabExists(string TableName)
        {
            StringBuilder sql = new StringBuilder("select count(*) from sysobjects where id = object_id(N'[");
            sql.Append(TableName);
            sql.Append("]') and OBJECTPROPERTY(id, N'IsUserTable') = 1");
            object obj = GetSingle(sql.ToString());
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                return false;
            }
            int.TryParse(obj.ToString(), out cmdresult);
            if (cmdresult == 0)
                return false;
            return true;
        }
        #endregion

        #region 判断某个表中是否存在某个字段
        /// <summary>
        /// 判断是否存在某表的某个字段
        /// </summary>
        /// <param name="tableName">表名称</param>
        /// <param name="columnName">列名称</param>
        /// <returns>是否存在</returns>
        public static bool ColumnExists(string tableName, string columnName)
        {
            StringBuilder sql = new StringBuilder("select count(1) from syscolumns where [id]=object_id('");
            sql.Append(tableName);
            sql.Append("') and [name]='");
            sql.Append(columnName);
            sql.Append("'");
            object res = GetSingle(sql.ToString());
            if (res == null)
            {
                return false;
            }
            int i;
            Int32.TryParse(res.ToString(), out i);
            if (i == 0)
                return false;
            else
                return true;
        }
        #endregion

        #region 判断某条记录是否存在 select count(1) from.....
        /// <summary>
        /// 判断某条记录是否存在 select count(1) from.....
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public static bool Exists(string strSql)
        {
            object obj = GetSingle(strSql);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                Int32.TryParse(obj.ToString(), out cmdresult);
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region 执行SQL语句，返回影响的记录数
        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>是否成功</returns>
        public static bool Execute(string SQLString)
        {
            return Execute(SQLString, 0);
        }
        #endregion

        #region 执行SQL语句，返回影响的记录数
        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="Times">超时时间</param>
        /// <returns>是否成功</returns>
        public static bool Execute(string SQLString, int Times)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, conn))
                {
                    try
                    {
                        conn.Open();
                        _IsContect = true;
                    }
                    catch (System.Data.SqlClient.SqlException E)
                    {
                        MyLog.fatal(E.Message);
                        MyLog.fatal(E.StackTrace);
                        _IsContect = false;
                        return false;
                    }
                    try
                    {
                        if (Times > 0)
                        {
                            cmd.CommandTimeout = Times;
                        }
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (System.Data.SqlClient.SqlException E)
                    {
                        MyLog.fatal(E.Message);
                        MyLog.fatal(E.StackTrace);
                        return false;
                    }
                    finally
                    {
                        cmd.Dispose();
                        conn.Close();
                    }
                }
            }
        }
        #endregion

        #region 带事务执行普通SQL语句
        /// <summary>
        /// 带事务执行普通SQL语句
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns></returns>
        public static bool ExecuteSqlWithTran(string SQLString)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    _IsContect = true;
                }
                catch (System.Data.SqlClient.SqlException E)
                {
                    MyLog.fatal(E.Message);
                    MyLog.fatal(E.StackTrace);
                    _IsContect = false;
                    return false;
                }
                using (SqlTransaction trans = con.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand(SQLString, con);
                        cmd.ExecuteNonQuery();
                        trans.Commit();
                        return true;
                    }
                    catch (SqlException er)
                    {
                        trans.Rollback();
                        MyLog.fatal(er.Message);
                        MyLog.fatal(er.StackTrace);
                        return false;
                    }
                }
            }
        }
        #endregion

        #region 执行多条SQL语句，实现数据库事务。
        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">多条SQL语句</param>		
        public static int ExecuteTran(List<String> SQLStringList)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    _IsContect = true;
                }
                catch (System.Data.SqlClient.SqlException E)
                {
                    MyLog.fatal(E.Message);
                    MyLog.fatal(E.StackTrace);
                    _IsContect = false;
                    return -1;
                }
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                SqlTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;
                try
                {
                    int count = 0;
                    for (int n = 0; n < SQLStringList.Count; n++)
                    {
                        string strsql = SQLStringList[n];
                        if (strsql.Trim().Length > 1)
                        {
                            cmd.CommandText = strsql;
                            count += cmd.ExecuteNonQuery();
                        }
                    }
                    tx.Commit();
                    return count;
                }
                catch (System.Data.SqlClient.SqlException E)
                {
                    tx.Rollback();
                    MyLog.fatal(E.Message);
                    MyLog.fatal(E.StackTrace);
                    return 0;
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }
        }
        #endregion

        #region 执行一条计算查询结果语句，返回查询结果（object）。
        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public static object GetSingle(string SQLString)
        {
            return GetSingle(SQLString, 0);
        }
        #endregion

        #region 执行一条计算查询结果语句，返回查询结果（object）。
        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <param name="Times">超时时间</param>
        /// <returns>查询结果（object）</returns>
        public static object GetSingle(string SQLString, int Times)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(SQLString, conn);
                try
                {
                    conn.Open();
                    _IsContect = true;
                }
                catch (System.Data.SqlClient.SqlException E)
                {
                    MyLog.fatal(E.Message);
                    MyLog.fatal(E.StackTrace);
                    _IsContect = false;
                    return null;
                }
                if (Times > 0)
                {
                    cmd.CommandTimeout = Times;
                }
                try
                {
                    object obj = cmd.ExecuteScalar();
                    if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                    {
                        return null;
                    }
                    else
                    {
                        return obj;
                    }
                }
                catch (System.Data.SqlClient.SqlException E)
                {
                    MyLog.fatal(E.Message);
                    MyLog.fatal(E.StackTrace);
                    return null;
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }
        }

        #endregion


        #region 执行查询语句，返回DataSet
        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string SQLString)
        {
            return Query(SQLString, 0);
        }
        #endregion

        #region 执行查询语句，返回DataSet
        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <param name="Times">超时时间</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string SQLString, int Times)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter cmd = new SqlDataAdapter(SQLString, conn))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        conn.Open();
                        _IsContect = true;
                    }
                    catch (System.Data.SqlClient.SqlException E)
                    {
                        MyLog.fatal(E.Message);
                        MyLog.fatal(E.StackTrace);
                        _IsContect = false;
                        return null;
                    }
                    try
                    {
                        if (Times > 0)
                        {
                            cmd.SelectCommand.CommandTimeout = Times;
                        }
                        cmd.Fill(ds, "ds");
                    }
                    catch (System.Data.SqlClient.SqlException E)
                    {
                        MyLog.fatal(E.Message);
                        MyLog.fatal(E.StackTrace);
                        return null;
                    }
                    finally
                    {
                        cmd.Dispose();
                        conn.Close();
                    }
                    return ds;
                }
            }

        }
        #endregion

        #region 执行查询语句，返回datatable
        /// <summary>
        /// 执行查询语句，返回datatable
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataTable</returns>
        public static DataTable QueryTable(string SQLString)
        {
            return QueryTable(SQLString, 0);
        }
        #endregion

        #region 执行查询语句，返回datatable
        /// <summary>
        /// 执行查询语句，返回datatable
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <param name="Times">超时时间</param>
        /// <returns>DataTable</returns>
        public static DataTable QueryTable(string SQLString, int Times,string constr)
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                using (SqlDataAdapter cmd = new SqlDataAdapter(SQLString, conn))
                {
                    DataTable dt = new DataTable();
                    try
                    {
                        conn.Open();
                        _IsContect = true;
                    }
                    catch (System.Data.SqlClient.SqlException E)
                    {
                        MyLog.fatal(E.Message);
                        MyLog.fatal(E.StackTrace);
                        _IsContect = false;
                        return null;
                    }
                    try
                    {
                        if (Times > 0)
                        {
                            cmd.SelectCommand.CommandTimeout = Times;
                        }
                        cmd.Fill(dt);
                    }
                    catch (System.Data.SqlClient.SqlException E)
                    {
                        MyLog.fatal(E.Message);
                        MyLog.fatal(E.StackTrace);
                        return null;
                    }
                    finally
                    {
                        cmd.Dispose();
                        conn.Close();
                    }
                    return dt;
                }
            }
        }
        /// <summary>
        /// 执行查询语句，返回datatable
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <param name="Times">超时时间</param>
        /// <returns>DataTable</returns>
        public static DataTable QueryTable(string SQLString, int Times)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter cmd = new SqlDataAdapter(SQLString, conn))
                {
                    DataTable dt = new DataTable();
                    try
                    {
                        conn.Open();
                        _IsContect = true;
                    }
                    catch (System.Data.SqlClient.SqlException E)
                    {
                        MyLog.fatal(E.Message);
                        MyLog.fatal(E.StackTrace);
                        _IsContect = false;
                        return null;
                    }
                    try
                    {
                        if (Times > 0)
                        {
                            cmd.SelectCommand.CommandTimeout = Times;
                        }
                        cmd.Fill(dt);
                    }
                    catch (System.Data.SqlClient.SqlException E)
                    {
                        MyLog.fatal(E.Message);
                        MyLog.fatal(E.StackTrace);
                        return null;
                    }
                    finally
                    {
                        cmd.Dispose();
                        conn.Close();
                    }
                    return dt;
                }
            }
        }
        #endregion

        #region 执行带参数的存储过程
        /// <summary>
        /// 执行带参数的存储过程
        /// </summary>
        /// <param name="storedProcName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static bool RunQuery(string storedProcName, SqlParameter[] parameters, int Times)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = BuildQueryCommand(conn, storedProcName, parameters))
                {
                    try
                    {
                        conn.Open();
                        _IsContect = true;
                    }
                    catch (System.Data.SqlClient.SqlException E)
                    {
                        MyLog.fatal(E.Message);
                        MyLog.fatal(E.StackTrace);
                        _IsContect = false;
                        return false;
                    }
                    try
                    {
                        if (Times > 0)
                        {
                            cmd.CommandTimeout = Times;
                        }
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception E)
                    {
                        MyLog.fatal(E.Message);
                        MyLog.fatal(E.StackTrace);
                        return false;
                    }
                    finally
                    {
                        cmd.Dispose();
                        conn.Close();
                    }
                }
            }
        }

        /// <summary>
        /// 执行带参数的存储过程
        /// </summary>
        /// <param name="storedProcName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static bool RunQuery(string storedProcName, SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = BuildQueryCommand(conn, storedProcName, parameters))
                {
                    try
                    {
                        conn.Open();
                        _IsContect = true;
                    }
                    catch (System.Data.SqlClient.SqlException E)
                    {
                        MyLog.fatal(E.Message);
                        MyLog.fatal(E.StackTrace);
                        _IsContect = false;
                        return false;
                    }
                    try
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception E)
                    {
                        MyLog.fatal(E.Message);
                        MyLog.fatal(E.StackTrace);
                        return false;
                    }
                    finally
                    {
                        cmd.Dispose();
                        conn.Close();
                    }
                }
            }
        }
        #endregion

        #region 执行不带参数存储过程
        /// <summary>
        /// 执行不带参数存储过程
        /// </summary>
        /// <param name="storedProcName"></param>
        /// <returns></returns>
        public static bool RunQuery(string storedProcName)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = BuildQueryCommand(conn, storedProcName))
                {
                    try
                    {
                        conn.Open();
                        _IsContect = true;
                    }
                    catch (System.Data.SqlClient.SqlException E)
                    {
                        MyLog.fatal(E.Message);
                        MyLog.fatal(E.StackTrace);
                        _IsContect = false;
                        return false;
                    }
                    try
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (System.Data.SqlClient.SqlException E)
                    {
                        MyLog.fatal(E.Message);
                        MyLog.fatal(E.StackTrace);
                        return false;
                    }
                    finally
                    {
                        cmd.Dispose();
                        conn.Close();
                    }
                }
            }
        }
        #endregion

        #region 执行存储过程
        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>DataSet</returns>
        /// 
        public static DataSet RunProcedure(string storedProcName, SqlParameter[] parameters)
        {
            return RunProcedure(storedProcName, parameters, "ds", 0);
        }
        #endregion

        #region 执行存储过程带表名
        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="tableName">DataSet结果中的表名</param>
        /// <returns>DataSet</returns>
        public static DataSet RunProcedure(string storedProcName, SqlParameter[] parameters, string tableName)
        {
            return RunProcedure(storedProcName, parameters, tableName, 0);
        }
        #endregion

        #region 执行存储过程带表名和超时时间
        /// <summary>
        /// 执行存储过程带表名和超时时间
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="tableName">结果中的表名</param>
        /// <param name="Times">超时时间</param>
        /// <returns>DataSet</returns>
        public static DataSet RunProcedure(string storedProcName, SqlParameter[] parameters, string tableName, int Times)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter sqlDA = new SqlDataAdapter())
                {
                    DataSet dataSet = new DataSet();
                    try
                    {
                        conn.Open();
                        _IsContect = true;
                    }
                    catch (System.Data.SqlClient.SqlException E)
                    {
                        MyLog.fatal(E.Message);
                        MyLog.fatal(E.StackTrace);
                        _IsContect = false;
                        return null;
                    }
                    try
                    {
                        sqlDA.SelectCommand = BuildQueryCommand(conn, storedProcName, parameters);
                        if (Times > 0)
                        {
                            sqlDA.SelectCommand.CommandTimeout = Times;
                        }
                        sqlDA.Fill(dataSet, tableName);
                    }
                    catch (System.Data.SqlClient.SqlException E)
                    {
                        MyLog.fatal(E.Message);
                        MyLog.fatal(E.StackTrace);
                        return null;
                    }
                    finally
                    {
                        sqlDA.Dispose();
                        conn.Close();
                    }
                    return dataSet;
                }
            }
        }
        #endregion

        #region 执行存储过程,返回DataTable
        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>DataTable</returns>
        public static DataTable RunProcedureTable(string storedProcName, SqlParameter[] parameters)
        {
            return RunProcedureTable(storedProcName, parameters, 0);
        }
        #endregion

        #region 执行存储过程带超时时间,返回DataTable
        /// <summary>
        /// 执行存储过程带超时时间
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="Times">超时时间</param>
        /// <returns>DataSet</returns>
        public static DataTable RunProcedureTable(string storedProcName, SqlParameter[] parameters, int Times)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter sqlDA = new SqlDataAdapter())
                {
                    DataTable dt = new DataTable();
                    try
                    {
                        conn.Open();
                        _IsContect = true;
                    }
                    catch (System.Data.SqlClient.SqlException E)
                    {
                        MyLog.fatal(E.Message);
                        MyLog.fatal(E.StackTrace);
                        _IsContect = false;
                        return null;
                    }
                    try
                    {
                        Times = 1800;
                        sqlDA.SelectCommand = BuildQueryCommand(conn, storedProcName, parameters);
                        if (Times > 0)
                        {
                            sqlDA.SelectCommand.CommandTimeout = Times;
                        }
                        sqlDA.Fill(dt);
                    }
                    catch (System.Data.SqlClient.SqlException E)
                    {
                        MyLog.fatal(E.Message);
                        MyLog.fatal(E.StackTrace);
                        return null;
                    }
                    finally
                    {
                        sqlDA.Dispose();
                        conn.Close();
                    }
                    return dt;
                }
            }
        }

        /// <summary>
        /// 执行存储过程带超时时间
        /// </summary>
        /// <param name="conString">连接字符串</param>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="Times">超时时间</param>
        /// <returns>DataSet</returns>
        public static DataTable RunProcedureTable(string conString,string storedProcName, SqlParameter[] parameters, int Times)
        {
            using (SqlConnection conn = new SqlConnection(conString))
            {
                using (SqlDataAdapter sqlDA = new SqlDataAdapter())
                {
                    DataTable dt = new DataTable();
                    try
                    {
                        conn.Open();
                        _IsContect = true;
                    }
                    catch (System.Data.SqlClient.SqlException E)
                    {
                        MyLog.fatal(E.Message);
                        MyLog.fatal(E.StackTrace);
                        _IsContect = false;
                        return null;
                    }
                    try
                    {
                        sqlDA.SelectCommand = BuildQueryCommand(conn, storedProcName, parameters);
                        if (Times > 0)
                        {
                            sqlDA.SelectCommand.CommandTimeout = Times;
                        }
                        sqlDA.Fill(dt);
                    }
                    catch (System.Data.SqlClient.SqlException E)
                    {
                        MyLog.fatal(E.Message);
                        MyLog.fatal(E.StackTrace);
                        return null;
                    }
                    finally
                    {
                        sqlDA.Dispose();
                        conn.Close();
                    }
                    return dt;
                }
            }
        }
        #endregion

        #region 构建 SqlCommand 对象(用来返回一个结果集，而不是一个整数值)
        /// <summary>
        /// 构建 SqlCommand 对象(用来返回一个结果集，而不是一个整数值)
        /// </summary>
        /// <param name="conn">数据库连接</param>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlCommand</returns>
        private static SqlCommand BuildQueryCommand(SqlConnection conn, string storedProcName, SqlParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand(storedProcName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter parameter in parameters)
            {
                if (parameter != null)
                {
                    // 检查未分配值的输出参数,将其分配以DBNull.Value.
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input || parameter.Direction == ParameterDirection.Output) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }

                    if (parameter.SqlDbType == SqlDbType.NVarChar || parameter.SqlDbType == SqlDbType.VarChar || parameter.SqlDbType == SqlDbType.Char || parameter.SqlDbType == SqlDbType.NChar)
                    {
                        parameter.Value = parameter.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }

            return cmd;
        }
        #endregion

        #region 构建 SqlCommand 对象
        private static SqlCommand BuildQueryCommand(SqlConnection conn, string storedProcName)
        {
            SqlCommand cmd = new SqlCommand(storedProcName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            return cmd;
        }
        #endregion

        #region 分页列表返回DataTable，必须具备p_PageList存储过程
        /// <summary>
        /// 分页列表
        /// </summary>
        /// <param name="currentPage">当前页</param>
        /// <param name="PageSize">页数</param>
        /// <param name="Count">总数</param>
        /// <param name="TableName">表名</param>
        /// <param name="Key">主键</param>
        /// <param name="Field">列</param>
        /// <param name="Where">条件</param>
        /// <param name="orderBy">排序列</param>
        /// <param name="Order">排序方向   true:降序  false: 升序</param>
        /// <returns></returns>
        public static DataTable ByPage(int currentPage, int PageSize, ref int Count, string TableName, string Key, string Field, string Where, string orderBy, bool Order)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter sqlDA = new SqlDataAdapter())
                {
                    DataTable dt = new DataTable();
                    try
                    {
                        conn.Open();
                        _IsContect = true;
                    }
                    catch (System.Data.SqlClient.SqlException E)
                    {
                        MyLog.fatal(E.Message);
                        MyLog.fatal(E.StackTrace);
                        _IsContect = false;
                        return null;
                    }
                    try
                    {
                        SqlCommand cmd = new SqlCommand("UP_PageList", conn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter Param_currentPage = new SqlParameter("@currentPage", SqlDbType.Int, 4);
                        Param_currentPage.Value = currentPage;
                        cmd.Parameters.Add(Param_currentPage);

                        SqlParameter Param_PageSize = new SqlParameter("@PageSize", SqlDbType.Int, 4);
                        Param_PageSize.Value = PageSize;
                        cmd.Parameters.Add(Param_PageSize);

                        SqlParameter Param_CountYesNo = new SqlParameter("@CountYesNo", SqlDbType.Bit, 1);
                        Param_CountYesNo.Value = true;
                        cmd.Parameters.Add(Param_CountYesNo);

                        SqlParameter Param_Count = new SqlParameter("@Count", SqlDbType.Int, 4);
                        Param_Count.Value = DBNull.Value;
                        Param_Count.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(Param_Count);

                        SqlParameter Param_TableName = new SqlParameter("@TableName", SqlDbType.VarChar, 50);
                        Param_TableName.Value = TableName.Trim();
                        cmd.Parameters.Add(Param_TableName);

                        SqlParameter Param_Key = new SqlParameter("@Key", SqlDbType.VarChar, 30);
                        Param_Key.Value = Key.Trim();
                        cmd.Parameters.Add(Param_Key);

                        SqlParameter Param_Field = new SqlParameter("@Field", SqlDbType.VarChar, 500);
                        Param_Field.Value = Field.Trim();
                        cmd.Parameters.Add(Param_Field);

                        SqlParameter Param_Where = new SqlParameter("@Where", SqlDbType.VarChar, 1000);
                        Param_Where.Value = Where == null ? string.Empty : Where.Trim();
                        cmd.Parameters.Add(Param_Where);

                        SqlParameter Param_orderBy = new SqlParameter("@orderBy", SqlDbType.VarChar, 100);
                        Param_orderBy.Value = orderBy.Trim();
                        cmd.Parameters.Add(Param_orderBy);

                        SqlParameter Param_order = new SqlParameter("@order", SqlDbType.Bit, 1);
                        Param_order.Value = Order;
                        cmd.Parameters.Add(Param_order);

                        sqlDA.SelectCommand = cmd;
                        sqlDA.SelectCommand.CommandTimeout = 60;

                        sqlDA.Fill(dt);
                        Count = (int)Param_Count.Value;
                    }
                    catch (System.Data.SqlClient.SqlException E)
                    {
                        sqlDA.Dispose();
                        conn.Close();
                        MyLog.fatal(E.Message);
                        MyLog.fatal(E.StackTrace);
                        return null;
                    }
                    return dt;
                }
            }
        }

        /// <summary>
        /// 分页列表
        /// </summary>
        /// <param name="constr">连接字符串</param>
        /// <param name="currentPage">当前页</param>
        /// <param name="PageSize">页数</param>
        /// <param name="Count">总数</param>
        /// <param name="TableName">表名</param>
        /// <param name="Key">主键</param>
        /// <param name="Field">列</param>
        /// <param name="Where">条件</param>
        /// <param name="orderBy">排序列</param>
        /// <param name="Order">排序方向   true:降序  false: 升序</param>
        /// <returns>DataTable</returns>
        public static DataTable ByPage(string constr,int currentPage, int PageSize, ref int Count, string TableName, string Key, string Field, string Where, string orderBy, bool Order)
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                using (SqlDataAdapter sqlDA = new SqlDataAdapter())
                {
                    DataTable dt = new DataTable();
                    try
                    {
                        conn.Open();
                        _IsContect = true;
                    }
                    catch (System.Data.SqlClient.SqlException E)
                    {
                        MyLog.fatal(E.Message);
                        MyLog.fatal(E.StackTrace);
                        _IsContect = false;
                        return null;
                    }
                    try
                    {
                        SqlCommand cmd = new SqlCommand("UP_PageList", conn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter Param_currentPage = new SqlParameter("@currentPage", SqlDbType.Int, 4);
                        Param_currentPage.Value = currentPage;
                        cmd.Parameters.Add(Param_currentPage);

                        SqlParameter Param_PageSize = new SqlParameter("@PageSize", SqlDbType.Int, 4);
                        Param_PageSize.Value = PageSize;
                        cmd.Parameters.Add(Param_PageSize);

                        SqlParameter Param_CountYesNo = new SqlParameter("@CountYesNo", SqlDbType.Bit, 1);
                        Param_CountYesNo.Value = true;
                        cmd.Parameters.Add(Param_CountYesNo);

                        SqlParameter Param_Count = new SqlParameter("@Count", SqlDbType.Int, 4);
                        Param_Count.Value = DBNull.Value;
                        Param_Count.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(Param_Count);

                        SqlParameter Param_TableName = new SqlParameter("@TableName", SqlDbType.VarChar, 50);
                        Param_TableName.Value = TableName.Trim();
                        cmd.Parameters.Add(Param_TableName);

                        SqlParameter Param_Key = new SqlParameter("@Key", SqlDbType.VarChar, 30);
                        Param_Key.Value = Key.Trim();
                        cmd.Parameters.Add(Param_Key);

                        SqlParameter Param_Field = new SqlParameter("@Field", SqlDbType.VarChar, 500);
                        Param_Field.Value = Field.Trim();
                        cmd.Parameters.Add(Param_Field);

                        SqlParameter Param_Where = new SqlParameter("@Where", SqlDbType.VarChar, 500);
                        Param_Where.Value = Where.Trim();
                        cmd.Parameters.Add(Param_Where);

                        SqlParameter Param_orderBy = new SqlParameter("@orderBy", SqlDbType.VarChar, 100);
                        Param_orderBy.Value = orderBy.Trim();
                        cmd.Parameters.Add(Param_orderBy);

                        SqlParameter Param_order = new SqlParameter("@order", SqlDbType.Bit, 1);
                        Param_order.Value = Order;
                        cmd.Parameters.Add(Param_order);

                        sqlDA.SelectCommand = cmd;
                        sqlDA.SelectCommand.CommandTimeout = 60;

                        sqlDA.Fill(dt);
                        Count = (int)Param_Count.Value;
                    }
                    catch (System.Data.SqlClient.SqlException E)
                    {
                        sqlDA.Dispose();
                        conn.Close();
                        MyLog.fatal(E.Message);
                        MyLog.fatal(E.StackTrace);
                        return null;
                    }
                    return dt;
                }
            }
        }
        #endregion

        #region 字符串拼接语句执行SQL语句 需存储过程UP_ExecuteSql
        /// <summary>
        /// 字符串拼接语句
        /// </summary>
        /// <param name="fname">字段</param>
        /// <param name="strTable">表或视图</param>
        /// <param name="strWhere">条件</param>
        /// <returns></returns>
        public static DataTable GetDataBySql(string fname, string strTable, string strWhere)
        {
            SqlParameter[] parameters = {
				        new SqlParameter("@fname", SqlDbType.VarChar,3400),
				        new SqlParameter("@table", SqlDbType.VarChar,100),
				        new SqlParameter("@where", SqlDbType.NVarChar,4000)
		        };
            parameters[0].Value = fname;
            parameters[1].Value = strTable;
            parameters[2].Value = strWhere;
            return DbHelperSQL.RunProcedureTable("UP_ExecuteSql", parameters);
        }
        #endregion

        #region 批量删除某张表的数据 需存储过程UP_DeleteList
        /// <summary>
        /// 批量删除某张表的数据
        /// </summary>
        /// <param name="tablename">表名</param>
        /// <param name="keyfield">关键字段</param>
        /// <param name="listid">字段编号</param>
        /// <returns></returns>
        public static bool DeleteList(string tablename, string keyfield, string listid)
        {
            SqlParameter[] parameters = {
				        new SqlParameter("@tablename", SqlDbType.VarChar,20),
				        new SqlParameter("@keyfield", SqlDbType.VarChar,15),
				        new SqlParameter("@listid", SqlDbType.NVarChar,4000)
		        };
            parameters[0].Value = tablename;
            parameters[1].Value = keyfield;
            parameters[2].Value = listid;
            return DbHelperSQL.RunQuery("UP_DeleteList", parameters);
        }
        #endregion

        #region-- 执行存储过程，返回影响的行数
        /// <summary>
        /// 执行存储过程，返回影响的行数		
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="rowsAffected">影响的行数</param>
        /// <returns></returns>
        public static int RunProcedure(string storedProcName, SqlParameter[] parameters, out int rowsAffected)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    _IsContect = true;
                }
                catch (System.Data.SqlClient.SqlException E)
                {
                    MyLog.fatal(E.Message);
                    MyLog.fatal(E.StackTrace);
                    _IsContect = false;
                    rowsAffected = -1;
                    return -1;
                }
                try
                {
                    using (SqlCommand cmd = BuildQueryCommand(conn, storedProcName, parameters))
                    {
                        rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected;
                    }
                }
                catch(Exception E)
                {
                    rowsAffected = -1;
                    MyLog.fatal(E.Message);
                  
                }
                return -1;
            }
        }
        public static void ExecuteSqlTranWithIndentity(Hashtable SQLStringList)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    SqlCommand cmd = new SqlCommand();
                    try
                    {
                        int indentity = 0;
                        //循环
                        foreach (DictionaryEntry myDE in SQLStringList)
                        {
                            string cmdText = myDE.Key.ToString();
                            SqlParameter[] cmdParms = (SqlParameter[])myDE.Value;
                            foreach (SqlParameter q in cmdParms)
                            {
                                if (q.Direction == ParameterDirection.InputOutput)
                                {
                                    q.Value = indentity;
                                }
                            }
                            PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
                            int val = cmd.ExecuteNonQuery();
                            foreach (SqlParameter q in cmdParms)
                            {
                                if (q.Direction == ParameterDirection.Output)
                                {
                                    indentity = Convert.ToInt32(q.Value);
                                }
                            }
                            cmd.Parameters.Clear();
                        }
                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans,  string cmdText, SqlParameter[] cmdParms)
        {

            //判断数据库连接状态
            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            //判断是否需要事物处理
            if (trans != null)
                cmd.Transaction = trans;
            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }
        public static int ExecuteSqlTran(System.Collections.Generic.List<CommandInfo> cmdList)
        {
            using (SqlConnection conns = new SqlConnection(connectionString))
            {
                conns.Open();
                using (SqlTransaction trans = conns.BeginTransaction())
                {
                    SqlCommand cmd = new SqlCommand();
                    try
                    {
                        int count = 0;
                        //循环
                        foreach (CommandInfo myDE in cmdList)
                        {
                            string cmdText = myDE.CommandText;
                            SqlParameter[] cmdParms = (SqlParameter[])myDE.Parameters;
                            PrepareCommand(cmd, conns, trans, cmdText, cmdParms);

                            if (myDE.EffentNextType == EffentNextType.WhenHaveContine || myDE.EffentNextType == EffentNextType.WhenNoHaveContine)
                            {
                                if (myDE.CommandText.ToLower().IndexOf("count(") == -1)
                                {
                                    trans.Rollback();
                                    return 0;
                                }

                                object obj = cmd.ExecuteScalar();
                                bool isHave = false;
                                if (obj == null && obj == DBNull.Value)
                                {
                                    isHave = false;
                                }
                                isHave = Convert.ToInt32(obj) > 0;

                                if (myDE.EffentNextType == EffentNextType.WhenHaveContine && !isHave)
                                {
                                    trans.Rollback();
                                    return 0;
                                }
                                if (myDE.EffentNextType == EffentNextType.WhenNoHaveContine && isHave)
                                {
                                    trans.Rollback();
                                    return 0;
                                }
                                continue;
                            }
                            int val = cmd.ExecuteNonQuery();
                            count += val;
                            if (myDE.EffentNextType == EffentNextType.ExcuteEffectRows && val == 0)
                            {
                                trans.Rollback();
                                return 0;
                            }
                            cmd.Parameters.Clear();
                        }
                        trans.Commit();
                        return count;
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }
        #endregion

    }
}
