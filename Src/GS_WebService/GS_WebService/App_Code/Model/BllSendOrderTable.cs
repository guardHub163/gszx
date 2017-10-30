using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;

namespace CZZD.GSZX.Model
{
    /// <summary>
    /// BLL_SEND_ORDER:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class BllSendOrderTable
    {
        public BllSendOrderTable()
        { }
        #region Model
        private decimal _order_id;
        private string _order_sn;
        private decimal? _goods_amount;
        private decimal? _actual_goods_amount;
        private int _send_status = 0;
        private DateTime? _create_date_time;
        private int? _community_code;
        private List<BllSendOrderLineTable> _lines = new List<BllSendOrderLineTable>();

        
        /// <summary>
        /// 订单自增编号
        /// </summary>
        public decimal ORDER_ID
        {
            set { _order_id = value; }
            get { return _order_id; }
        }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string ORDER_SN
        {
            set { _order_sn = value; }
            get { return _order_sn; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? GOODS_AMOUNT
        {
            set { _goods_amount = value; }
            get { return _goods_amount; }
        }
        /// <summary>
        /// 商品实际金额
        /// </summary>
        public decimal? ACTUAL_GOODS_AMOUNT
        {
            set { _actual_goods_amount = value; }
            get { return _actual_goods_amount; }
        }
        /// <summary>
        /// 0:未送信　1:己送信
        /// </summary>
        public int SEND_STATUS
        {
            set { _send_status = value; }
            get { return _send_status; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CREATE_DATE_TIME
        {
            set { _create_date_time = value; }
            get { return _create_date_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? COMMUNITY_CODE
        {
            set { _community_code = value; }
            get { return _community_code; }
        }

        public List<BllSendOrderLineTable> LINES
        {
            get { return _lines; }
            set { _lines = value; }
        }

        public void AddLine(BllSendOrderLineTable line)
        {
            if (_lines == null)
            {
                _lines = new List<BllSendOrderLineTable>();
            }
            _lines.Add(line);
        }
        #endregion Model

    }//end class

    /// <summary>
    /// BLL_SEND_ORDER_LINE:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class BllSendOrderLineTable
    {
        public BllSendOrderLineTable()
        { }
        #region Model
        private int _rec_id;
        private decimal _order_id;
        private int? _goods_id;
        private string _goods_sn;
        private decimal? _actual_number;
        private decimal? _goods_price;
        private decimal? _actual_amount;
        /// <summary>
        /// 
        /// </summary>
        public int REC_ID
        {
            set { _rec_id = value; }
            get { return _rec_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal ORDER_ID
        {
            set { _order_id = value; }
            get { return _order_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? GOODS_ID
        {
            set { _goods_id = value; }
            get { return _goods_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GOODS_SN
        {
            set { _goods_sn = value; }
            get { return _goods_sn; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ACTUAL_NUMBER
        {
            set { _actual_number = value; }
            get { return _actual_number; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? GOODS_PRICE
        {
            set { _goods_price = value; }
            get { return _goods_price; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ACTUAL_AMOUNT
        {
            set { _actual_amount = value; }
            get { return _actual_amount; }
        }
        #endregion Model

    }//end class
}
