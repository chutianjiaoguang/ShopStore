using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Web;

namespace Common.DBHelper
{
    public class PubConstant
    {
        private static string _ConnectionString = string.Empty;
        /// <summary>
        /// 获取连接字符串
        /// </summary>
        public static string ConnectionString
        {
            set { _ConnectionString = value; }
            get
            {
                if (string.IsNullOrEmpty(_ConnectionString))
                {
                    Common.Functions.IniFiles ini = new Functions.IniFiles(HttpContext.Current.Server.MapPath("~/bin/Config/dbconfig.xml"));
                    _ConnectionString=ini.ReadString("SQLCON", "con",string.Empty);
                    _ConnectionString =Common.Functions.DESEncrypt.Decrypt(_ConnectionString);
                }
                return _ConnectionString;
            }
        }

    }
}
