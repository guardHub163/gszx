using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CZZD.GSZX.S.Model
{
   /// <summary>
	/// BASE_ORDER_GOODS:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class BllOrderGoodsTable
	{
		public BllOrderGoodsTable()
		{}
		#region Model
		private int _rec_id;
		private int? _order_id;
		private int? _goods_id;
		private string _goods_name;
		private string _goods_sn;
		private int? _goods_number;
		private decimal? _market_price;
		private decimal? _goods_price;
		private string _goods_attr;
		private int? _send_number;
		private int? _is_real;
		private string _extension_code;
		private int? _parent_id;
		private int? _is_gift;
		private int _order_type;
		private decimal? _actual_amount;
		private decimal? _actual_weight;
		/// <summary>
		/// 订单商品信息自增id
		/// </summary>
		public int REC_ID
		{
			set{ _rec_id=value;}
			get{return _rec_id;}
		}
		/// <summary>
		/// 订单商品信息对应的详细信息id，取值order_info的order_id
		/// </summary>
		public int? ORDER_ID
		{
			set{ _order_id=value;}
			get{return _order_id;}
		}
		/// <summary>
		/// 商品的的id，取值表ecs_goods 的goods_idINT
		/// </summary>
		public int? GOODS_ID
		{
			set{ _goods_id=value;}
			get{return _goods_id;}
		}
		/// <summary>
		/// 商品的名称，取值表ecs_goods
		/// </summary>
		public string GOODS_NAME
		{
			set{ _goods_name=value;}
			get{return _goods_name;}
		}
		/// <summary>
		/// 商品的唯一货号，取值ecs_goods 
		/// </summary>
		public string GOODS_SN
		{
			set{ _goods_sn=value;}
			get{return _goods_sn;}
		}
		/// <summary>
		/// 商品的购买数量
		/// </summary>
		public int? GOODS_NUMBER
		{
			set{ _goods_number=value;}
			get{return _goods_number;}
		}
		/// <summary>
		/// 商品的市场售价，取值ecs_goods
		/// </summary>
		public decimal? MARKET_PRICE
		{
			set{ _market_price=value;}
			get{return _market_price;}
		}
		/// <summary>
		/// 商品的本店售价，取值ecs_goods 
		/// </summary>
		public decimal? GOODS_PRICE
		{
			set{ _goods_price=value;}
			get{return _goods_price;}
		}
		/// <summary>
		/// 购买该商品时所选择的属性
		/// </summary>
		public string GOODS_ATTR
		{
			set{ _goods_attr=value;}
			get{return _goods_attr;}
		}
		/// <summary>
		/// 当不是实物时，是否已发货，0，否；1，是
		/// </summary>
		public int? SEND_NUMBER
		{
			set{ _send_number=value;}
			get{return _send_number;}
		}
		/// <summary>
		/// I是否是实物，0，否；1，是；取值ecs_goods 
		/// </summary>
		public int? IS_REAL
		{
			set{ _is_real=value;}
			get{return _is_real;}
		}
		/// <summary>
		/// 商品的扩展属性，比如像虚拟卡。取值ecs_goods
		/// </summary>
		public string EXTENSION_CODE
		{
			set{ _extension_code=value;}
			get{return _extension_code;}
		}
		/// <summary>
		/// 父商品id，取值于ecs_cart的parent_id；如果有该值则是值多代表的物品的配件
		/// </summary>
		public int? PARENT_ID
		{
			set{ _parent_id=value;}
			get{return _parent_id;}
		}
		/// <summary>
		/// 是否参加优惠活动，0，否；其他，取值于ecs_cart 的is_gift，跟其一样，是参加的优惠活动的id
		/// </summary>
		public int? IS_GIFT
		{
			set{ _is_gift=value;}
			get{return _is_gift;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ORDER_TYPE
		{
			set{ _order_type=value;}
			get{return _order_type;}
		}
		/// <summary>
		/// 实际金额
		/// </summary>
		public decimal? ACTUAL_AMOUNT
		{
			set{ _actual_amount=value;}
			get{return _actual_amount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? ACTUAL_WEIGHT
		{
			set{ _actual_weight=value;}
			get{return _actual_weight;}
		}
		#endregion Model

	}
}
