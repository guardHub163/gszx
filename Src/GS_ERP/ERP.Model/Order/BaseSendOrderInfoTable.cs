using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.Model
{
   public class BaseSendOrderInfoTable
    {
       public BaseSendOrderInfoTable()
		{}
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
			set{ _rec_id=value;}
			get{return _rec_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal ORDER_ID
		{
			set{ _order_id=value;}
			get{return _order_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? GOODS_ID
		{
			set{ _goods_id=value;}
			get{return _goods_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string GOODS_SN
		{
			set{ _goods_sn=value;}
			get{return _goods_sn;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? ACTUAL_NUMBER
		{
			set{ _actual_number=value;}
			get{return _actual_number;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? GOODS_PRICE
		{
			set{ _goods_price=value;}
			get{return _goods_price;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? ACTUAL_AMOUNT
		{
			set{ _actual_amount=value;}
			get{return _actual_amount;}
		}
		#endregion Model
    }
}
