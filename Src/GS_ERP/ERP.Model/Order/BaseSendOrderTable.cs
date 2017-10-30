using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.Model
{
    public class BaseSendOrderTable
    {

        public BaseSendOrderTable()
        { }
        #region Model
        private decimal _order_id;
        private string _order_sn;
        private decimal? _actual_goods_amount;
        private int _send_status = 0;
        private DateTime? _create_date_time;
        private decimal _goods_amount;
        private int? _community_code;
        private List<BaseSendOrderInfoTable> _items = new List<BaseSendOrderInfoTable>();

        public decimal GOODS_AMOUNT
        {
            get { return _goods_amount; }
            set { _goods_amount = value; }
        }


        public int? COMMUNITY_CODE
        {
            get { return _community_code; }
            set { _community_code = value; }
        }



        public List<BaseSendOrderInfoTable> ITEMS
        {
            get { return _items; }
            set { _items = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        public void AddItem(BaseSendOrderInfoTable model)
        {
            _items.Add(model);
        }
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
        #endregion Model
    }
}
