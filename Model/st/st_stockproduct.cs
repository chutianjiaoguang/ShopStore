using System;
using System.Runtime.Serialization;
namespace WebService.Model
{
    /// <summary>
    /// st_stockproduct:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class st_stockproduct
    {
        public st_stockproduct()
        { }
        #region Model
        private int _stproductid;
        private string _stocktype;
        private string _singernumber;
        private long? _skuid;
        private int? _productid;
        private decimal _innum;
        private decimal _outnum;
        private string _unit;
        private decimal? _price;
        private int? _storeid;
        private string _storename;
        private string _userid;
        private string _myname;
        private DateTime? _setdate;
        private string _productremark;
        private decimal _saleprice;
        private int _state;
        /// <summary>
        /// 
        /// </summary>
        [DataMember(IsRequired = false)]
        public int state
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(IsRequired = false)]
        public decimal saleprice
        {
            set { _saleprice = value; }
            get { return _saleprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(IsRequired = false)]
        public int stproductid
        {
            set { _stproductid = value; }
            get { return _stproductid; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(IsRequired = false)]
        public string stocktype
        {
            set { _stocktype = value; }
            get { return _stocktype; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(IsRequired = false)]
        public string singernumber
        {
            set { _singernumber = value; }
            get { return _singernumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(IsRequired = false)]
        public long? SkuId
        {
            set { _skuid = value; }
            get { return _skuid; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(IsRequired = false)]
        public int? productid
        {
            set { _productid = value; }
            get { return _productid; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(IsRequired = false)]
        public decimal innum
        {
            set { _innum = value; }
            get { return _innum; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(IsRequired = false)]
        public decimal outnum
        {
            set { _outnum = value; }
            get { return _outnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(IsRequired = false)]
        public string unit
        {
            set { _unit = value; }
            get { return _unit; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(IsRequired = false)]
        public decimal? price
        {
            set { _price = value; }
            get { return _price; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(IsRequired = false)]
        public int? storeid
        {
            set { _storeid = value; }
            get { return _storeid; }
        }
        /// <summary>
        /// 
        /// </summary>
       [DataMember(IsRequired = false)]
        public string storename
        {
            set { _storename = value; }
            get { return _storename; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(IsRequired = false)]
        public string userid
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(IsRequired = false)]
        public string myname
        {
            set { _myname = value; }
            get { return _myname; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(IsRequired = false)]
        public DateTime? setdate
        {
            set { _setdate = value; }
            get { return _setdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(IsRequired = false)]
        public string productremark
        {
            set { _productremark = value; }
            get { return _productremark; }
        }
        #endregion Model

    }
}