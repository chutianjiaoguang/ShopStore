using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Text.RegularExpressions;
using System.Collections;
using System.Web.Script.Serialization;

namespace Common.Functions
{
    public class DataToJson
    {

        /// <summary>    
        /// DataTable转Json    
        /// </summary>    
        /// <param name="dtb"></param>    
        /// <returns></returns>    
        #region DataTable转Json
        public static string CreateJsonParameters(DataTable dtb)
        {
            if (dtb == null)
                return string.Empty;
            if (dtb.Rows.Count == 0)
                return string.Empty;
            JavaScriptSerializer jss = new JavaScriptSerializer();
            ArrayList dic = new ArrayList();
            foreach (DataRow row in dtb.Rows)
            {
                Dictionary<string, object> drow = new Dictionary<string, object>();
                foreach (DataColumn col in dtb.Columns)
                {
                   drow.Add(col.ColumnName, row[col.ColumnName]);
                }
                dic.Add(drow);
            }
            string str=jss.Serialize(dic);
            str = Regex.Replace(str, @"\\/Date\((\d+)\)\\/", match =>
            {
                DateTime dt = new DateTime(1970, 1, 1);
                dt = dt.AddMilliseconds(long.Parse(match.Groups[1].Value));
                dt = dt.ToLocalTime();
                return dt.ToString("yyyy-MM-dd HH:mm:ss");
            });
            return str;

        }
        #endregion
        
        /// <summary>    
        /// Json转DataTable    
        /// </summary>    
        /// <param name="json"></param>    
        /// <returns></returns>
        #region Json转DataTable
        public static DataTable JsonToDataTable(string json)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            ArrayList dic = jss.Deserialize<ArrayList>(json);
            DataTable dtb = new DataTable();
            if (dic.Count > 0)
            {
                foreach (Dictionary<string, object> drow in dic)
                {
                    if (dtb.Columns.Count == 0)
                    {
                        foreach (string key in drow.Keys)
                        {
                            try
                            {
                                Type t = null;
                                if (drow[key] == null)
                                {
                                    t = typeof(string);
                                }
                                else
                                    t = drow[key].GetType();
                                if (t == System.Type.GetType("System.Int32"))
                                    dtb.Columns.Add(key, System.Type.GetType("System.Decimal"));
                                else
                                    dtb.Columns.Add(key, t);
                            }
                            catch { }
                        }
                    } DataRow row = dtb.NewRow();
                    foreach (string key in drow.Keys)
                    { row[key] = drow[key]; }
                    dtb.Rows.Add(row);
                }
            }
            return dtb;
        }

        #endregion



    }
}
