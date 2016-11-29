using System;
namespace WebService.Model
{
    /// <summary>
    /// Shop_Products:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Shop_Products
    {
        public Shop_Products()
        { }
        #region Model
        private int _categoryid;
        private int? _typeid;
        private long _productid;
        private int _brandid;
        private string _productname;
        private string _productcode;
        private int _supplierid;
        private int? _regionid;
        private string _shortdescription;
        private string _unit;
        private string _description;
        private string _meta_title;
        private string _meta_description;
        private string _meta_keywords;
        private int _salestatus;
        private DateTime _addeddate = DateTime.Now;
        private int _visticounts = 0;
        private int _salecounts = 0;
        private int? _stock;
        private int _displaysequence = 0;
        private int _lineid;
        private decimal? _marketprice;
        private decimal _lowestsaleprice;
        private int _penetrationstatus;
        private string _maincategorypath;
        private string _extendcategorypath;
        private bool _hassku;
        private decimal? _points = 0M;
        private string _imageurl;
        private string _thumbnailurl1;
        private string _thumbnailurl2;
        private string _thumbnailurl3;
        private string _thumbnailurl4;
        private string _thumbnailurl5;
        private string _thumbnailurl6;
        private string _thumbnailurl7;
        private string _thumbnailurl8;
        private int? _maxquantity = 0;
        private int? _minquantity = 0;
        private string _tags;
        private string _seourl;
        private string _seoimagealt;
        private string _seoimagetitle;
        private int _salestype = 1;
        private int _restrictioncount = 0;
        private int? _validday;
        private string _deliverytip;
        private string _remark;
        /// <summary>
        /// 
        /// </summary>
        public int CategoryId
        {
            set { _categoryid = value; }
            get { return _categoryid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? TypeId
        {
            set { _typeid = value; }
            get { return _typeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long ProductId
        {
            set { _productid = value; }
            get { return _productid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int BrandId
        {
            set { _brandid = value; }
            get { return _brandid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProductName
        {
            set { _productname = value; }
            get { return _productname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProductCode
        {
            set { _productcode = value; }
            get { return _productcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int SupplierId
        {
            set { _supplierid = value; }
            get { return _supplierid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? RegionId
        {
            set { _regionid = value; }
            get { return _regionid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ShortDescription
        {
            set { _shortdescription = value; }
            get { return _shortdescription; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Unit
        {
            set { _unit = value; }
            get { return _unit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Description
        {
            set { _description = value; }
            get { return _description; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Meta_Title
        {
            set { _meta_title = value; }
            get { return _meta_title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Meta_Description
        {
            set { _meta_description = value; }
            get { return _meta_description; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Meta_Keywords
        {
            set { _meta_keywords = value; }
            get { return _meta_keywords; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int SaleStatus
        {
            set { _salestatus = value; }
            get { return _salestatus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime AddedDate
        {
            set { _addeddate = value; }
            get { return _addeddate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int VistiCounts
        {
            set { _visticounts = value; }
            get { return _visticounts; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int SaleCounts
        {
            set { _salecounts = value; }
            get { return _salecounts; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Stock
        {
            set { _stock = value; }
            get { return _stock; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int DisplaySequence
        {
            set { _displaysequence = value; }
            get { return _displaysequence; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int LineId
        {
            set { _lineid = value; }
            get { return _lineid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? MarketPrice
        {
            set { _marketprice = value; }
            get { return _marketprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal LowestSalePrice
        {
            set { _lowestsaleprice = value; }
            get { return _lowestsaleprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int PenetrationStatus
        {
            set { _penetrationstatus = value; }
            get { return _penetrationstatus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MainCategoryPath
        {
            set { _maincategorypath = value; }
            get { return _maincategorypath; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ExtendCategoryPath
        {
            set { _extendcategorypath = value; }
            get { return _extendcategorypath; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool HasSKU
        {
            set { _hassku = value; }
            get { return _hassku; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Points
        {
            set { _points = value; }
            get { return _points; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ImageUrl
        {
            set { _imageurl = value; }
            get { return _imageurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ThumbnailUrl1
        {
            set { _thumbnailurl1 = value; }
            get { return _thumbnailurl1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ThumbnailUrl2
        {
            set { _thumbnailurl2 = value; }
            get { return _thumbnailurl2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ThumbnailUrl3
        {
            set { _thumbnailurl3 = value; }
            get { return _thumbnailurl3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ThumbnailUrl4
        {
            set { _thumbnailurl4 = value; }
            get { return _thumbnailurl4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ThumbnailUrl5
        {
            set { _thumbnailurl5 = value; }
            get { return _thumbnailurl5; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ThumbnailUrl6
        {
            set { _thumbnailurl6 = value; }
            get { return _thumbnailurl6; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ThumbnailUrl7
        {
            set { _thumbnailurl7 = value; }
            get { return _thumbnailurl7; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ThumbnailUrl8
        {
            set { _thumbnailurl8 = value; }
            get { return _thumbnailurl8; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? MaxQuantity
        {
            set { _maxquantity = value; }
            get { return _maxquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? MinQuantity
        {
            set { _minquantity = value; }
            get { return _minquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Tags
        {
            set { _tags = value; }
            get { return _tags; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SeoUrl
        {
            set { _seourl = value; }
            get { return _seourl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SeoImageAlt
        {
            set { _seoimagealt = value; }
            get { return _seoimagealt; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SeoImageTitle
        {
            set { _seoimagetitle = value; }
            get { return _seoimagetitle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int SalesType
        {
            set { _salestype = value; }
            get { return _salestype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int RestrictionCount
        {
            set { _restrictioncount = value; }
            get { return _restrictioncount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ValidDay
        {
            set { _validday = value; }
            get { return _validday; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DeliveryTip
        {
            set { _deliverytip = value; }
            get { return _deliverytip; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        #endregion Model

    }
}