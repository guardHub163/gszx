using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.Model
{
  public class BaseOrderActionTable
    {
      public BaseOrderActionTable()
		{}
		#region Model
		private int _action_id;
		private int _order_id;
		private string _action_user;
		private int _order_status;
		private int _shipping_status;
		private int _pay_status;
		private string _action_note;
		private int _long_time;
		private int _order_type;
		/// <summary>
		/// 流水号
		/// </summary>
		public int ACTION_ID
		{
			set{ _action_id=value;}
			get{return _action_id;}
		}
		/// <summary>
		/// 被操作的交易号
		/// </summary>
		public int ORDER_ID
		{
			set{ _order_id=value;}
			get{return _order_id;}
		}
		/// <summary>
		/// 操作该次的人员
		/// </summary>
		public string ACTION_USER
		{
			set{ _action_user=value;}
			get{return _action_user;}
		}
		/// <summary>
		/// 作何操作.0，未确认；1，已确认；2，已取消；3，无效；4，退货；
		/// </summary>
		public int ORDER_STATUS
		{
			set{ _order_status=value;}
			get{return _order_status;}
		}
		/// <summary>
		/// 发货状态。0，未发货；1，已发货；2，已收货；3，备货中
		/// </summary>
		public int SHIPPING_STATUS
		{
			set{ _shipping_status=value;}
			get{return _shipping_status;}
		}
		/// <summary>
		/// 支付状态.0,未付款;1,付款中;2,已付款;
		/// </summary>
		public int PAY_STATUS
		{
			set{ _pay_status=value;}
			get{return _pay_status;}
		}
		/// <summary>
		/// 操作备注
		/// </summary>
		public string ACTION_NOTE
		{
			set{ _action_note=value;}
			get{return _action_note;}
		}
		/// <summary>
		/// 操作时间
		/// </summary>
		public int LONG_TIME
		{
			set{ _long_time=value;}
			get{return _long_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ORDER_TYPE
		{
			set{ _order_type=value;}
			get{return _order_type;}
		}
		#endregion Model
    }
}
