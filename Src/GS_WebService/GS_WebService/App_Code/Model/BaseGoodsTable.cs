using System;
namespace CZZD.GSZX.Model
{
	/// <summary>
	/// ecs_goods:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class BaseGoodsTable
	{
		public BaseGoodsTable()
		{}
		#region Model
		private decimal _goods_id;
		private int _cat_id=0;
		private string _goods_sn;
		private string _goods_name;
		private string _goods_name_style;
		private int _click_count=0;
		private int _brand_id=0;
		private string _provider_name;
		private int _goods_number=0;
		private decimal _goods_weight;
		private decimal _market_price;
		private decimal _shop_price;
		private decimal _promote_price;
		private int _promote_start_date=0;
		private int _promote_end_date=0;
		private int _warn_number=1;
		private string _keywords;
		private string _goods_brief;
		private string _goods_desc;
		private string _goods_thumb;
		private string _goods_img;
		private string _original_img;
		private int _is_real=1;
		private string _extension_code;
		private int _is_on_sale=1;
		private int _is_alone_sale=1;
		private int _integral=0;
		private int _add_time=0;
		private int _sort_order=0;
		private int _is_delete=0;
		private int _is_best=0;
		private int _is_new=0;
		private int _is_hot=0;
		private int _is_promote=0;
		private int _bonus_type_id=0;
		private int _last_update=0;
		private int _goods_type=0;
		private string _seller_note;
		private int _give_integral=-1;
		/// <summary>
		/// auto_increment
		/// </summary>
		public decimal goods_id
		{
			set{ _goods_id=value;}
			get{return _goods_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int cat_id
		{
			set{ _cat_id=value;}
			get{return _cat_id;}
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
		public string goods_name
		{
			set{ _goods_name=value;}
			get{return _goods_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string goods_name_style
		{
			set{ _goods_name_style=value;}
			get{return _goods_name_style;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int click_count
		{
			set{ _click_count=value;}
			get{return _click_count;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int brand_id
		{
			set{ _brand_id=value;}
			get{return _brand_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string provider_name
		{
			set{ _provider_name=value;}
			get{return _provider_name;}
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
		public decimal goods_weight
		{
			set{ _goods_weight=value;}
			get{return _goods_weight;}
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
		public decimal shop_price
		{
			set{ _shop_price=value;}
			get{return _shop_price;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal promote_price
		{
			set{ _promote_price=value;}
			get{return _promote_price;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int promote_start_date
		{
			set{ _promote_start_date=value;}
			get{return _promote_start_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int promote_end_date
		{
			set{ _promote_end_date=value;}
			get{return _promote_end_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int warn_number
		{
			set{ _warn_number=value;}
			get{return _warn_number;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string keywords
		{
			set{ _keywords=value;}
			get{return _keywords;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string goods_brief
		{
			set{ _goods_brief=value;}
			get{return _goods_brief;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string goods_desc
		{
			set{ _goods_desc=value;}
			get{return _goods_desc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string goods_thumb
		{
			set{ _goods_thumb=value;}
			get{return _goods_thumb;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string goods_img
		{
			set{ _goods_img=value;}
			get{return _goods_img;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string original_img
		{
			set{ _original_img=value;}
			get{return _original_img;}
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
		public int is_on_sale
		{
			set{ _is_on_sale=value;}
			get{return _is_on_sale;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int is_alone_sale
		{
			set{ _is_alone_sale=value;}
			get{return _is_alone_sale;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int integral
		{
			set{ _integral=value;}
			get{return _integral;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int add_time
		{
			set{ _add_time=value;}
			get{return _add_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int sort_order
		{
			set{ _sort_order=value;}
			get{return _sort_order;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int is_delete
		{
			set{ _is_delete=value;}
			get{return _is_delete;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int is_best
		{
			set{ _is_best=value;}
			get{return _is_best;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int is_new
		{
			set{ _is_new=value;}
			get{return _is_new;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int is_hot
		{
			set{ _is_hot=value;}
			get{return _is_hot;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int is_promote
		{
			set{ _is_promote=value;}
			get{return _is_promote;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int bonus_type_id
		{
			set{ _bonus_type_id=value;}
			get{return _bonus_type_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int last_update
		{
			set{ _last_update=value;}
			get{return _last_update;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int goods_type
		{
			set{ _goods_type=value;}
			get{return _goods_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string seller_note
		{
			set{ _seller_note=value;}
			get{return _seller_note;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int give_integral
		{
			set{ _give_integral=value;}
			get{return _give_integral;}
		}
		#endregion Model

	}
}

