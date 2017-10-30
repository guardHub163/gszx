using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CZZD.GSZX.S.Model
{
 /// <summary>
	/// BLL_SEND_ORDER_STATUS:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class BllSendOrderStatusTable
	{
		public BllSendOrderStatusTable()
		{}
		#region Model
		private int _id;
		private decimal? _order_id;
		private string _order_sn;
		private int _status_type;
		private int? _status_flag;
		private int? _send_status;
		private DateTime? _create_date_time;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 订单自动增长编号
		/// </summary>
		public decimal? ORDER_ID
		{
			set{ _order_id=value;}
			get{return _order_id;}
		}
		/// <summary>
		/// 订单编号
		/// </summary>
		public string ORDER_SN
		{
			set{ _order_sn=value;}
			get{return _order_sn;}
		}
		/// <summary>
		/// 0:订单状态;　1:付款状态;　2:发货状态;
		/// </summary>
		public int STATUS_TYPE
		{
			set{ _status_type=value;}
			get{return _status_type;}
		}
		/// <summary>
		/// 状态
		/// </summary>
		public int? STATUS_FLAG
		{
			set{ _status_flag=value;}
			get{return _status_flag;}
		}
		/// <summary>
		/// 送信状态：０：未送信；１：己送信；
		/// </summary>
		public int? SEND_STATUS
		{
			set{ _send_status=value;}
			get{return _send_status;}
		}
		/// <summary>
		/// 创建日期
		/// </summary>
		public DateTime? CREATE_DATE_TIME
		{
			set{ _create_date_time=value;}
			get{return _create_date_time;}
		}
		#endregion Model

	}
}