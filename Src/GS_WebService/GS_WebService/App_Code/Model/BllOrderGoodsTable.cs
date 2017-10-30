using System;
namespace CZZD.GSZX.Model
{
	/// <summary>
	/// ecs_order_goods:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class BllOrderGoodsTable
	{
		public BllOrderGoodsTable()
		{}
		#region Model
		private decimal _rec_id;
		private decimal _order_id=0;
		private decimal _goods_id=0;
		private string _goods_name;
		private string _goods_sn;
		private int _goods_number=1;
		private decimal _market_price;
		private decimal _goods_price;
		private string _goods_attr;
		private int _send_number=0;
		private int _is_real=0;
		private string _extension_code;
		private decimal _parent_id=0;
		private int _is_gift=0;
        private decimal? _act_goods_number;
		/// <summary>
		/// auto_increment
		/// </summary>
		public decimal rec_id
		{
			set{ _rec_id=value;}
			get{return _rec_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal order_id
		{
			set{ _order_id=value;}
			get{return _order_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal goods_id
		{
			set{ _goods_id=value;}
			get{return _goods_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string goods_name
		{
			set{ _goods_name=value;}
			get{return _goods_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string goods_sn
		{
			set{ _goods_sn=value;}
			get{return _goods_sn;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int goods_number
		{
			set{ _goods_number=value;}
			get{return _goods_number;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal market_price
		{
			set{ _market_price=value;}
			get{return _market_price;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal goods_price
		{
			set{ _goods_price=value;}
			get{return _goods_price;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string goods_attr
		{
			set{ _goods_attr=value;}
			get{return _goods_attr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int send_number
		{
			set{ _send_number=value;}
			get{return _send_number;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int is_real
		{
			set{ _is_real=value;}
			get{return _is_real;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string extension_code
		{
			set{ _extension_code=value;}
			get{return _extension_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal parent_id
		{
			set{ _parent_id=value;}
			get{return _parent_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int is_gift
		{
			set{ _is_gift=value;}
			get{return _is_gift;}
		}
        /// <summary>
        /// 
        /// </summary>
        public decimal? act_goods_number
        {
            set { _act_goods_number = value; }
            get { return _act_goods_number; }
        }
		#endregion Model

	}
}

