using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebService.Model
{
    [Serializable]
    public partial class st_store
    {
        public st_store()
        { }
        #region Model
        private int _storeid;
        private string _storename;
        private int? _shopid;
        private string _storecode;
        private string _remark;
        /// <summary>
        /// 
        /// </summary>
        public int storeid
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
        public int? shopid
        {
            set { _shopid = value; }
            get { return _shopid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string storecode
        {
            set { _storecode = value; }
            get { return _storecode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        #endregion Model

    }
}

