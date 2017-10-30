using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.Model
{
    [Serializable]
    public class BaseDeliveryTable
    {
        public BaseDeliveryTable()
        { }
        #region Model
        private string _delivery_code;
        private decimal? _order_id;
        private string  _consignee;
        private int? _community_code;
        private int? _status_flag;
        /// <summary>
        /// 送货单号
        /// </summary>
        public string DELIVERY_CODE
        {
            set { _delivery_code = value; }
            get { return _delivery_code; }
        }
        /// <summary>
        /// 订单编号
        /// </summary>
        public decimal? ORDER_ID
        {
            set { _order_id = value; }
            get { return _order_id; }
        }
        /// <summary>
        /// 客户姓名
        /// </summary>
        public string  CONSIGNEE
        {
            set { _consignee = value; }
            get { return _consignee; }
        }
        /// <summary>
        /// 区域流水号
        /// </summary>
        public int? COMMUNITY_CODE
        {
            set { _community_code = value; }
            get { return _community_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? STATUS_FLAG
        {
            set { _status_flag = value; }
            get { return _status_flag; }
        }
        #endregion Model
    }
}
