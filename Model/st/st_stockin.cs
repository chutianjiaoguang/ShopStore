using System;
using System.Collections.Generic;
namespace WebService.Model
{
    /// <summary>
    /// st_stockin:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class st_stockin
    {
        public st_stockin()
        { }
        #region Model
        private int _stockinid;
        private string _singernumber;
        private int? _storeid;
        private string _storename;
        private int? _companyid;
        private string _companyname;
        private DateTime? _purchasedate;
        private string _checkuserid;
        private string _checkname;
        private DateTime? _checkdate;
        private string _checkstatetext;
        private int? _checkstate;
        private string _userid;
        private string _myname;
        private DateTime? _setdate;
        private string _remark;
        private decimal? _summoney;
        private decimal _writeoff;
        private decimal _nowriteoff;

        /// <summary>
        /// 
        /// </summary>
        public decimal writeoff
        {
            set { _writeoff = value; }
            get { return _writeoff; }
        }

        /// <summary>
        /// 
        /// </summary>
        public decimal nowriteoff
        {
            set { _nowriteoff = value; }
            get { return _nowriteoff; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int stockinid
        {
            set { _stockinid = value; }
            get { return _stockinid; }
        }


        private List<st_stockproduct> _w_changebyproducts;
        /// <summary>
        /// 子类 
        /// </summary>
        public List<st_stockproduct> w_changebyproducts
        {
            set { _w_changebyproducts = value; }
            get { return _w_changebyproducts; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string singernumber
        {
            set { _singernumber = value; }
            get { return _singernumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? storeid
        {
            set { _storeid = value; }
            get { return _storeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string storename
        {
            set { _storename = value; }
            get { return _storename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? companyid
        {
            set { _companyid = value; }
            get { return _companyid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string companyname
        {
            set { _companyname = value; }
            get { return _companyname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? purchasedate
        {
            set { _purchasedate = value; }
            get { return _purchasedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string checkuserid
        {
            set { _checkuserid = value; }
            get { return _checkuserid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string checkname
        {
            set { _checkname = value; }
            get { return _checkname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? checkdate
        {
            set { _checkdate = value; }
            get { return _checkdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string checkstatetext
        {
            set { _checkstatetext = value; }
            get { return _checkstatetext; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? checkstate
        {
            set { _checkstate = value; }
            get { return _checkstate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string userid
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string myname
        {
            set { _myname = value; }
            get { return _myname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? setdate
        {
            set { _setdate = value; }
            get { return _setdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? summoney
        {
            set { _summoney = value; }
            get { return _summoney; }
        }
        #endregion Model

    }
}
