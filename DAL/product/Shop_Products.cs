using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Common.DBHelper;//Please add references
namespace WebService.DAL
{
    /// <summary>
    /// 数据访问类:Shop_Products
    /// </summary>
    public partial class Shop_Products
    {
        public Shop_Products()
        { }
        #region  Method
        /// <summary>
        ///  增加一条数据
        /// </summary>
        public long Add(WebService.Model.Shop_Products model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@CategoryId", SqlDbType.Int,4),
					new SqlParameter("@TypeId", SqlDbType.Int,4),
					new SqlParameter("@ProductId", SqlDbType.BigInt,8),
					new SqlParameter("@BrandId", SqlDbType.Int,4),
					new SqlParameter("@ProductName", SqlDbType.NVarChar,200),
					new SqlParameter("@ProductCode", SqlDbType.NVarChar,50),
					new SqlParameter("@SupplierId", SqlDbType.Int,4),
					new SqlParameter("@RegionId", SqlDbType.Int,4),
					new SqlParameter("@ShortDescription", SqlDbType.NVarChar,2000),
					new SqlParameter("@Unit", SqlDbType.NVarChar,50),
					new SqlParameter("@Description", SqlDbType.NText),
					new SqlParameter("@Meta_Title", SqlDbType.NVarChar,100),
					new SqlParameter("@Meta_Description", SqlDbType.NVarChar,1000),
					new SqlParameter("@Meta_Keywords", SqlDbType.NVarChar,1000),
					new SqlParameter("@SaleStatus", SqlDbType.Int,4),
					new SqlParameter("@AddedDate", SqlDbType.DateTime),
					new SqlParameter("@VistiCounts", SqlDbType.Int,4),
					new SqlParameter("@SaleCounts", SqlDbType.Int,4),
					new SqlParameter("@Stock", SqlDbType.Int,4),
					new SqlParameter("@DisplaySequence", SqlDbType.Int,4),
					new SqlParameter("@LineId", SqlDbType.Int,4),
					new SqlParameter("@MarketPrice", SqlDbType.Money,8),
					new SqlParameter("@LowestSalePrice", SqlDbType.Money,8),
					new SqlParameter("@PenetrationStatus", SqlDbType.SmallInt,2),
					new SqlParameter("@MainCategoryPath", SqlDbType.NVarChar,256),
					new SqlParameter("@ExtendCategoryPath", SqlDbType.NVarChar,256),
					new SqlParameter("@HasSKU", SqlDbType.Bit,1),
					new SqlParameter("@Points", SqlDbType.Decimal,9),
					new SqlParameter("@ImageUrl", SqlDbType.NVarChar,255),
					new SqlParameter("@ThumbnailUrl1", SqlDbType.NVarChar,255),
					new SqlParameter("@ThumbnailUrl2", SqlDbType.NVarChar,255),
					new SqlParameter("@ThumbnailUrl3", SqlDbType.NVarChar,255),
					new SqlParameter("@ThumbnailUrl4", SqlDbType.NVarChar,255),
					new SqlParameter("@ThumbnailUrl5", SqlDbType.NVarChar,255),
					new SqlParameter("@ThumbnailUrl6", SqlDbType.NVarChar,255),
					new SqlParameter("@ThumbnailUrl7", SqlDbType.NVarChar,255),
					new SqlParameter("@ThumbnailUrl8", SqlDbType.NVarChar,255),
					new SqlParameter("@MaxQuantity", SqlDbType.Int,4),
					new SqlParameter("@MinQuantity", SqlDbType.Int,4),
					new SqlParameter("@Tags", SqlDbType.NVarChar,50),
					new SqlParameter("@SeoUrl", SqlDbType.NVarChar,300),
					new SqlParameter("@SeoImageAlt", SqlDbType.NVarChar,300),
					new SqlParameter("@SeoImageTitle", SqlDbType.NVarChar,300),
					new SqlParameter("@SalesType", SqlDbType.SmallInt,2),
					new SqlParameter("@RestrictionCount", SqlDbType.Int,4),
					new SqlParameter("@ValidDay", SqlDbType.Int,4),
					new SqlParameter("@DeliveryTip", SqlDbType.NVarChar,100),
					new SqlParameter("@Remark", SqlDbType.NVarChar,500)};
            parameters[0].Value = model.CategoryId;
            parameters[1].Value = model.TypeId;
            parameters[2].Direction = ParameterDirection.Output;
            parameters[3].Value = model.BrandId;
            parameters[4].Value = model.ProductName;
            parameters[5].Value = model.ProductCode;
            parameters[6].Value = model.SupplierId;
            parameters[7].Value = model.RegionId;
            parameters[8].Value = model.ShortDescription;
            parameters[9].Value = model.Unit;
            parameters[10].Value = model.Description;
            parameters[11].Value = model.Meta_Title;
            parameters[12].Value = model.Meta_Description;
            parameters[13].Value = model.Meta_Keywords;
            parameters[14].Value = model.SaleStatus;
            parameters[15].Value = model.AddedDate;
            parameters[16].Value = model.VistiCounts;
            parameters[17].Value = model.SaleCounts;
            parameters[18].Value = model.Stock;
            parameters[19].Value = model.DisplaySequence;
            parameters[20].Value = model.LineId;
            parameters[21].Value = model.MarketPrice;
            parameters[22].Value = model.LowestSalePrice;
            parameters[23].Value = model.PenetrationStatus;
            parameters[24].Value = model.MainCategoryPath;
            parameters[25].Value = model.ExtendCategoryPath;
            parameters[26].Value = model.HasSKU;
            parameters[27].Value = model.Points;
            parameters[28].Value = model.ImageUrl;
            parameters[29].Value = model.ThumbnailUrl1;
            parameters[30].Value = model.ThumbnailUrl2;
            parameters[31].Value = model.ThumbnailUrl3;
            parameters[32].Value = model.ThumbnailUrl4;
            parameters[33].Value = model.ThumbnailUrl5;
            parameters[34].Value = model.ThumbnailUrl6;
            parameters[35].Value = model.ThumbnailUrl7;
            parameters[36].Value = model.ThumbnailUrl8;
            parameters[37].Value = model.MaxQuantity;
            parameters[38].Value = model.MinQuantity;
            parameters[39].Value = model.Tags;
            parameters[40].Value = model.SeoUrl;
            parameters[41].Value = model.SeoImageAlt;
            parameters[42].Value = model.SeoImageTitle;
            parameters[43].Value = model.SalesType;
            parameters[44].Value = model.RestrictionCount;
            parameters[45].Value = model.ValidDay;
            parameters[46].Value = model.DeliveryTip;
            parameters[47].Value = model.Remark;

            DbHelperSQL.RunProcedure("Shop_Products_ADD", parameters, out rowsAffected);
            return (long)parameters[2].Value;
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public bool Update(WebService.Model.Shop_Products model)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@CategoryId", SqlDbType.Int,4),
					new SqlParameter("@TypeId", SqlDbType.Int,4),
					new SqlParameter("@ProductId", SqlDbType.BigInt,8),
					new SqlParameter("@BrandId", SqlDbType.Int,4),
					new SqlParameter("@ProductName", SqlDbType.NVarChar,200),
					new SqlParameter("@ProductCode", SqlDbType.NVarChar,50),
					new SqlParameter("@SupplierId", SqlDbType.Int,4),
					new SqlParameter("@RegionId", SqlDbType.Int,4),
					new SqlParameter("@ShortDescription", SqlDbType.NVarChar,2000),
					new SqlParameter("@Unit", SqlDbType.NVarChar,50),
					new SqlParameter("@Description", SqlDbType.NText),
					new SqlParameter("@Meta_Title", SqlDbType.NVarChar,100),
					new SqlParameter("@Meta_Description", SqlDbType.NVarChar,1000),
					new SqlParameter("@Meta_Keywords", SqlDbType.NVarChar,1000),
					new SqlParameter("@SaleStatus", SqlDbType.Int,4),
					new SqlParameter("@AddedDate", SqlDbType.DateTime),
					new SqlParameter("@VistiCounts", SqlDbType.Int,4),
					new SqlParameter("@SaleCounts", SqlDbType.Int,4),
					new SqlParameter("@Stock", SqlDbType.Int,4),
					new SqlParameter("@DisplaySequence", SqlDbType.Int,4),
					new SqlParameter("@LineId", SqlDbType.Int,4),
					new SqlParameter("@MarketPrice", SqlDbType.Money,8),
					new SqlParameter("@LowestSalePrice", SqlDbType.Money,8),
					new SqlParameter("@PenetrationStatus", SqlDbType.SmallInt,2),
					new SqlParameter("@MainCategoryPath", SqlDbType.NVarChar,256),
					new SqlParameter("@ExtendCategoryPath", SqlDbType.NVarChar,256),
					new SqlParameter("@HasSKU", SqlDbType.Bit,1),
					new SqlParameter("@Points", SqlDbType.Decimal,9),
					new SqlParameter("@ImageUrl", SqlDbType.NVarChar,255),
					new SqlParameter("@ThumbnailUrl1", SqlDbType.NVarChar,255),
					new SqlParameter("@ThumbnailUrl2", SqlDbType.NVarChar,255),
					new SqlParameter("@ThumbnailUrl3", SqlDbType.NVarChar,255),
					new SqlParameter("@ThumbnailUrl4", SqlDbType.NVarChar,255),
					new SqlParameter("@ThumbnailUrl5", SqlDbType.NVarChar,255),
					new SqlParameter("@ThumbnailUrl6", SqlDbType.NVarChar,255),
					new SqlParameter("@ThumbnailUrl7", SqlDbType.NVarChar,255),
					new SqlParameter("@ThumbnailUrl8", SqlDbType.NVarChar,255),
					new SqlParameter("@MaxQuantity", SqlDbType.Int,4),
					new SqlParameter("@MinQuantity", SqlDbType.Int,4),
					new SqlParameter("@Tags", SqlDbType.NVarChar,50),
					new SqlParameter("@SeoUrl", SqlDbType.NVarChar,300),
					new SqlParameter("@SeoImageAlt", SqlDbType.NVarChar,300),
					new SqlParameter("@SeoImageTitle", SqlDbType.NVarChar,300),
					new SqlParameter("@SalesType", SqlDbType.SmallInt,2),
					new SqlParameter("@RestrictionCount", SqlDbType.Int,4),
					new SqlParameter("@ValidDay", SqlDbType.Int,4),
					new SqlParameter("@DeliveryTip", SqlDbType.NVarChar,100),
					new SqlParameter("@Remark", SqlDbType.NVarChar,500)};
            parameters[0].Value = model.CategoryId;
            parameters[1].Value = model.TypeId;
            parameters[2].Value = model.ProductId;
            parameters[3].Value = model.BrandId;
            parameters[4].Value = model.ProductName;
            parameters[5].Value = model.ProductCode;
            parameters[6].Value = model.SupplierId;
            parameters[7].Value = model.RegionId;
            parameters[8].Value = model.ShortDescription;
            parameters[9].Value = model.Unit;
            parameters[10].Value = model.Description;
            parameters[11].Value = model.Meta_Title;
            parameters[12].Value = model.Meta_Description;
            parameters[13].Value = model.Meta_Keywords;
            parameters[14].Value = model.SaleStatus;
            parameters[15].Value = model.AddedDate;
            parameters[16].Value = model.VistiCounts;
            parameters[17].Value = model.SaleCounts;
            parameters[18].Value = model.Stock;
            parameters[19].Value = model.DisplaySequence;
            parameters[20].Value = model.LineId;
            parameters[21].Value = model.MarketPrice;
            parameters[22].Value = model.LowestSalePrice;
            parameters[23].Value = model.PenetrationStatus;
            parameters[24].Value = model.MainCategoryPath;
            parameters[25].Value = model.ExtendCategoryPath;
            parameters[26].Value = model.HasSKU;
            parameters[27].Value = model.Points;
            parameters[28].Value = model.ImageUrl;
            parameters[29].Value = model.ThumbnailUrl1;
            parameters[30].Value = model.ThumbnailUrl2;
            parameters[31].Value = model.ThumbnailUrl3;
            parameters[32].Value = model.ThumbnailUrl4;
            parameters[33].Value = model.ThumbnailUrl5;
            parameters[34].Value = model.ThumbnailUrl6;
            parameters[35].Value = model.ThumbnailUrl7;
            parameters[36].Value = model.ThumbnailUrl8;
            parameters[37].Value = model.MaxQuantity;
            parameters[38].Value = model.MinQuantity;
            parameters[39].Value = model.Tags;
            parameters[40].Value = model.SeoUrl;
            parameters[41].Value = model.SeoImageAlt;
            parameters[42].Value = model.SeoImageTitle;
            parameters[43].Value = model.SalesType;
            parameters[44].Value = model.RestrictionCount;
            parameters[45].Value = model.ValidDay;
            parameters[46].Value = model.DeliveryTip;
            parameters[47].Value = model.Remark;

            DbHelperSQL.RunProcedure("Shop_Products_Update", parameters, out rowsAffected);
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
        public bool Delete(long ProductId)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@ProductId", SqlDbType.BigInt)
			};
            parameters[0].Value = ProductId;

            DbHelperSQL.RunProcedure("Shop_Products_Delete", parameters, out rowsAffected);
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
        public bool DeleteList(string ProductIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Shop_Products ");
            strSql.Append(" where ProductId in (" + ProductIdlist + ")  ");
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
        public WebService.Model.Shop_Products GetModel(long ProductId)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ProductId", SqlDbType.BigInt)
			};
            parameters[0].Value = ProductId;

            WebService.Model.Shop_Products model = new WebService.Model.Shop_Products();
            DataSet ds = DbHelperSQL.RunProcedure("Shop_Products_GetModel", parameters, "ds");
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
        public WebService.Model.Shop_Products DataRowToModel(DataRow row)
        {
            WebService.Model.Shop_Products model = new WebService.Model.Shop_Products();
            if (row != null)
            {
                if (row["CategoryId"] != null && row["CategoryId"].ToString() != "")
                {
                    model.CategoryId = int.Parse(row["CategoryId"].ToString());
                }
                if (row["TypeId"] != null && row["TypeId"].ToString() != "")
                {
                    model.TypeId = int.Parse(row["TypeId"].ToString());
                }
                if (row["ProductId"] != null && row["ProductId"].ToString() != "")
                {
                    model.ProductId = long.Parse(row["ProductId"].ToString());
                }
                if (row["BrandId"] != null && row["BrandId"].ToString() != "")
                {
                    model.BrandId = int.Parse(row["BrandId"].ToString());
                }
                if (row["ProductName"] != null)
                {
                    model.ProductName = row["ProductName"].ToString();
                }
                if (row["ProductCode"] != null)
                {
                    model.ProductCode = row["ProductCode"].ToString();
                }
                if (row["SupplierId"] != null && row["SupplierId"].ToString() != "")
                {
                    model.SupplierId = int.Parse(row["SupplierId"].ToString());
                }
                if (row["RegionId"] != null && row["RegionId"].ToString() != "")
                {
                    model.RegionId = int.Parse(row["RegionId"].ToString());
                }
                if (row["ShortDescription"] != null)
                {
                    model.ShortDescription = row["ShortDescription"].ToString();
                }
                if (row["Unit"] != null)
                {
                    model.Unit = row["Unit"].ToString();
                }
                if (row["Description"] != null)
                {
                    model.Description = row["Description"].ToString();
                }
                if (row["Meta_Title"] != null)
                {
                    model.Meta_Title = row["Meta_Title"].ToString();
                }
                if (row["Meta_Description"] != null)
                {
                    model.Meta_Description = row["Meta_Description"].ToString();
                }
                if (row["Meta_Keywords"] != null)
                {
                    model.Meta_Keywords = row["Meta_Keywords"].ToString();
                }
                if (row["SaleStatus"] != null && row["SaleStatus"].ToString() != "")
                {
                    model.SaleStatus = int.Parse(row["SaleStatus"].ToString());
                }
                if (row["AddedDate"] != null && row["AddedDate"].ToString() != "")
                {
                    model.AddedDate = DateTime.Parse(row["AddedDate"].ToString());
                }
                if (row["VistiCounts"] != null && row["VistiCounts"].ToString() != "")
                {
                    model.VistiCounts = int.Parse(row["VistiCounts"].ToString());
                }
                if (row["SaleCounts"] != null && row["SaleCounts"].ToString() != "")
                {
                    model.SaleCounts = int.Parse(row["SaleCounts"].ToString());
                }
                if (row["Stock"] != null && row["Stock"].ToString() != "")
                {
                    model.Stock = int.Parse(row["Stock"].ToString());
                }
                if (row["DisplaySequence"] != null && row["DisplaySequence"].ToString() != "")
                {
                    model.DisplaySequence = int.Parse(row["DisplaySequence"].ToString());
                }
                if (row["LineId"] != null && row["LineId"].ToString() != "")
                {
                    model.LineId = int.Parse(row["LineId"].ToString());
                }
                if (row["MarketPrice"] != null && row["MarketPrice"].ToString() != "")
                {
                    model.MarketPrice = decimal.Parse(row["MarketPrice"].ToString());
                }
                if (row["LowestSalePrice"] != null && row["LowestSalePrice"].ToString() != "")
                {
                    model.LowestSalePrice = decimal.Parse(row["LowestSalePrice"].ToString());
                }
                if (row["PenetrationStatus"] != null && row["PenetrationStatus"].ToString() != "")
                {
                    model.PenetrationStatus = int.Parse(row["PenetrationStatus"].ToString());
                }
                if (row["MainCategoryPath"] != null)
                {
                    model.MainCategoryPath = row["MainCategoryPath"].ToString();
                }
                if (row["ExtendCategoryPath"] != null)
                {
                    model.ExtendCategoryPath = row["ExtendCategoryPath"].ToString();
                }
                if (row["HasSKU"] != null && row["HasSKU"].ToString() != "")
                {
                    if ((row["HasSKU"].ToString() == "1") || (row["HasSKU"].ToString().ToLower() == "true"))
                    {
                        model.HasSKU = true;
                    }
                    else
                    {
                        model.HasSKU = false;
                    }
                }
                if (row["Points"] != null && row["Points"].ToString() != "")
                {
                    model.Points = decimal.Parse(row["Points"].ToString());
                }
                if (row["ImageUrl"] != null)
                {
                    model.ImageUrl = row["ImageUrl"].ToString();
                }
                if (row["ThumbnailUrl1"] != null)
                {
                    model.ThumbnailUrl1 = row["ThumbnailUrl1"].ToString();
                }
                if (row["ThumbnailUrl2"] != null)
                {
                    model.ThumbnailUrl2 = row["ThumbnailUrl2"].ToString();
                }
                if (row["ThumbnailUrl3"] != null)
                {
                    model.ThumbnailUrl3 = row["ThumbnailUrl3"].ToString();
                }
                if (row["ThumbnailUrl4"] != null)
                {
                    model.ThumbnailUrl4 = row["ThumbnailUrl4"].ToString();
                }
                if (row["ThumbnailUrl5"] != null)
                {
                    model.ThumbnailUrl5 = row["ThumbnailUrl5"].ToString();
                }
                if (row["ThumbnailUrl6"] != null)
                {
                    model.ThumbnailUrl6 = row["ThumbnailUrl6"].ToString();
                }
                if (row["ThumbnailUrl7"] != null)
                {
                    model.ThumbnailUrl7 = row["ThumbnailUrl7"].ToString();
                }
                if (row["ThumbnailUrl8"] != null)
                {
                    model.ThumbnailUrl8 = row["ThumbnailUrl8"].ToString();
                }
                if (row["MaxQuantity"] != null && row["MaxQuantity"].ToString() != "")
                {
                    model.MaxQuantity = int.Parse(row["MaxQuantity"].ToString());
                }
                if (row["MinQuantity"] != null && row["MinQuantity"].ToString() != "")
                {
                    model.MinQuantity = int.Parse(row["MinQuantity"].ToString());
                }
                if (row["Tags"] != null)
                {
                    model.Tags = row["Tags"].ToString();
                }
                if (row["SeoUrl"] != null)
                {
                    model.SeoUrl = row["SeoUrl"].ToString();
                }
                if (row["SeoImageAlt"] != null)
                {
                    model.SeoImageAlt = row["SeoImageAlt"].ToString();
                }
                if (row["SeoImageTitle"] != null)
                {
                    model.SeoImageTitle = row["SeoImageTitle"].ToString();
                }
                if (row["SalesType"] != null && row["SalesType"].ToString() != "")
                {
                    model.SalesType = int.Parse(row["SalesType"].ToString());
                }
                if (row["RestrictionCount"] != null && row["RestrictionCount"].ToString() != "")
                {
                    model.RestrictionCount = int.Parse(row["RestrictionCount"].ToString());
                }
                if (row["ValidDay"] != null && row["ValidDay"].ToString() != "")
                {
                    model.ValidDay = int.Parse(row["ValidDay"].ToString());
                }
                if (row["DeliveryTip"] != null)
                {
                    model.DeliveryTip = row["DeliveryTip"].ToString();
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
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
            strSql.Append("select CategoryId,TypeId,ProductId,BrandId,ProductName,ProductCode,SupplierId,RegionId,ShortDescription,Unit,Description,Meta_Title,Meta_Description,Meta_Keywords,SaleStatus,AddedDate,VistiCounts,SaleCounts,Stock,DisplaySequence,LineId,MarketPrice,LowestSalePrice,PenetrationStatus,MainCategoryPath,ExtendCategoryPath,HasSKU,Points,ImageUrl,ThumbnailUrl1,ThumbnailUrl2,ThumbnailUrl3,ThumbnailUrl4,ThumbnailUrl5,ThumbnailUrl6,ThumbnailUrl7,ThumbnailUrl8,MaxQuantity,MinQuantity,Tags,SeoUrl,SeoImageAlt,SeoImageTitle,SalesType,RestrictionCount,ValidDay,DeliveryTip,Remark ");
            strSql.Append(" FROM Shop_Products ");
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
            strSql.Append(" CategoryId,TypeId,ProductId,BrandId,ProductName,ProductCode,SupplierId,RegionId,ShortDescription,Unit,Description,Meta_Title,Meta_Description,Meta_Keywords,SaleStatus,AddedDate,VistiCounts,SaleCounts,Stock,DisplaySequence,LineId,MarketPrice,LowestSalePrice,PenetrationStatus,MainCategoryPath,ExtendCategoryPath,HasSKU,Points,ImageUrl,ThumbnailUrl1,ThumbnailUrl2,ThumbnailUrl3,ThumbnailUrl4,ThumbnailUrl5,ThumbnailUrl6,ThumbnailUrl7,ThumbnailUrl8,MaxQuantity,MinQuantity,Tags,SeoUrl,SeoImageAlt,SeoImageTitle,SalesType,RestrictionCount,ValidDay,DeliveryTip,Remark ");
            strSql.Append(" FROM Shop_Products ");
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
            strSql.Append("select count(1) FROM Shop_Products ");
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
                strSql.Append("order by T.ProductId desc");
            }
            strSql.Append(")AS Row, T.*  from Shop_Products T ");
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