using System;
namespace WebService.Model
{
    /// <summary>
    /// st_providecompany:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class st_providecompany
    {
        public st_providecompany()
        { }
        #region Model
        private int _companyid;
        private string _companyname;
        private string _pycode;
        private string _code;
        private string _phone;
        private string _website;
        private string _contactman;
        private string _contactphone;
        private string _qq;
        private string _mc;
        private string _industry;
        private string _remark;
        private DateTime _setdate;
        private int? _shopid;
        /// <summary>
        /// 
        /// </summary>
        public int companyid
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
        public string pycode
        {
            set { _pycode = value; }
            get { return _pycode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string code
        {
            set { _code = value; }
            get { return _code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string phone
        {
            set { _phone = value; }
            get { return _phone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string website
        {
            set { _website = value; }
            get { return _website; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string contactman
        {
            set { _contactman = value; }
            get { return _contactman; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string contactphone
        {
            set { _contactphone = value; }
            get { return _contactphone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string qq
        {
            set { _qq = value; }
            get { return _qq; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mc
        {
            set { _mc = value; }
            get { return _mc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string industry
        {
            set { _industry = value; }
            get { return _industry; }
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
        public DateTime setdate
        {
            set { _setdate = value; }
            get { return _setdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? shopid
        {
            set { _shopid = value; }
            get { return _shopid; }
        }
        #endregion Model

    }
}