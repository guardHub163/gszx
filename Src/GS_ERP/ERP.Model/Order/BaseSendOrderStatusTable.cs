using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.Model
{
   public class BaseSendOrderStatusTable
    {
        public BaseSendOrderStatusTable()
		{}
		#region Model
		private int _id;
		private decimal? _order_id;
		private string _order_sn;
		private int? _order_status;
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
		/// 
		/// </summary>
		public decimal? ORDER_ID
		{
			set{ _order_id=value;}
			get{return _order_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ORDER_SN
		{
			set{ _order_sn=value;}
			get{return _order_sn;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ORDER_STATUS
		{
			set{ _order_status=value;}
			get{return _order_status;}
		}

		/// <summary>
		/// 
		/// </summary>
		public int? SEND_STATUS
		{
			set{ _send_status=value;}
			get{return _send_status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CREATE_DATE_TIME
		{
			set{ _create_date_time=value;}
			get{return _create_date_time;}
		}
		#endregion Model
    }
}
