using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CZZD.GSZX.S.Model
{
    /// <summary>
	/// BASE_PRODUCT:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class BaseProductTable
	{
        public BaseProductTable()
		{}
		#region Model
		private int _goods_id;
		private int? _cat_id;
		private string _goods_sn;
		private string _goods_name;
		private string _goods_name_style;
		private int? _click_count;
		private int? _brand_id;
		private string _provider_name;
		private int? _goods_number;
		private decimal? _goods_weight;
		private decimal? _market_price;
		private decimal? _shop_price;
		private decimal? _promote_price;
		private int? _promote_start_date;
		private int? _promote_end_date;
		private int? _warn_number;
		private string _keywords;
		private string _goods_brief;
		private string _goods_desc;
		private string _goods_thumb;
		private string _goods_img;
		private string _original_img;
		private int? _is_real;
		private string _extension_code;
		private int? _is_on_sale;
		private int? _is_alone_sale;
		private int? _integral;
		private int? _add_time;
		private int? _sort_order;
		private int? _is_best;
		private int? _is_delete;
		private int? _is_new;
		private int? _is_hot;
		private int? _is_promote;
		private int? _bonus_type_id;
		private int? _last_update;
		private int? _goods_type;
		private string _seller_note;
		private int? _give_integral;
		/// <summary>
		/// 商品的自增id
		/// </summary>
		public int GOODS_ID
		{
			set{ _goods_id=value;}
			get{return _goods_id;}
		}
		/// <summary>
		/// 商品所属商品分类id，取值ecs_category的cat_id
		/// </summary>
		public int? CAT_ID
		{
			set{ _cat_id=value;}
			get{return _cat_id;}
		}
		/// <summary>
		/// 商品的唯一货号
		/// </summary>
		public string GOODS_SN
		{
			set{ _goods_sn=value;}
			get{return _goods_sn;}
		}
		/// <summary>
		/// 商品的名称
		/// </summary>
		public string GOODS_NAME
		{
			set{ _goods_name=value;}
			get{return _goods_name;}
		}
		/// <summary>
		/// 商品名称显示的样式；包括颜色和字体样式；格式如#ff00ff+strong
		/// </summary>
		public string GOODS_NAME_STYLE
		{
			set{ _goods_name_style=value;}
			get{return _goods_name_style;}
		}
		/// <summary>
		/// 商品点击数
		/// </summary>
		public int? CLICK_COUNT
		{
			set{ _click_count=value;}
			get{return _click_count;}
		}
		/// <summary>
		/// 品牌id，取值于ecs_brand 的brand_id
		/// </summary>
		public int? BRAND_ID
		{
			set{ _brand_id=value;}
			get{return _brand_id;}
		}
		/// <summary>
		/// 供货人的名称，程序还没实现该功能
		/// </summary>
		public string PROVIDER_NAME
		{
			set{ _provider_name=value;}
			get{return _provider_name;}
		}
		/// <summary>
		/// 商品库存数量
		/// </summary>
		public int? GOODS_NUMBER
		{
			set{ _goods_number=value;}
			get{return _goods_number;}
		}
		/// <summary>
		/// 商品的重量，以千克为单位
		/// </summary>
		public decimal? GOODS_WEIGHT
		{
			set{ _goods_weight=value;}
			get{return _goods_weight;}
		}
		/// <summary>
		/// 市场售价
		/// </summary>
		public decimal? MARKET_PRICE
		{
			set{ _market_price=value;}
			get{return _market_price;}
		}
		/// <summary>
		/// 本店售价
		/// </summary>
		public decimal? SHOP_PRICE
		{
			set{ _shop_price=value;}
			get{return _shop_price;}
		}
		/// <summary>
		/// 促销价格
		/// </summary>
		public decimal? PROMOTE_PRICE
		{
			set{ _promote_price=value;}
			get{return _promote_price;}
		}
		/// <summary>
		/// 促销价格开始日期
		/// </summary>
		public int? PROMOTE_START_DATE
		{
			set{ _promote_start_date=value;}
			get{return _promote_start_date;}
		}
		/// <summary>
		/// 促销价结束日期
		/// </summary>
		public int? PROMOTE_END_DATE
		{
			set{ _promote_end_date=value;}
			get{return _promote_end_date;}
		}
		/// <summary>
		/// 商品报警数量
		/// </summary>
		public int? WARN_NUMBER
		{
			set{ _warn_number=value;}
			get{return _warn_number;}
		}
		/// <summary>
		/// 商品关键字，放在商品页的关键字中，为搜索引擎收录用
		/// </summary>
		public string KEYWORDS
		{
			set{ _keywords=value;}
			get{return _keywords;}
		}
		/// <summary>
		/// 商品的简短描述
		/// </summary>
		public string GOODS_BRIEF
		{
			set{ _goods_brief=value;}
			get{return _goods_brief;}
		}
		/// <summary>
		/// 商品的详细描述
		/// </summary>
		public string GOODS_DESC
		{
			set{ _goods_desc=value;}
			get{return _goods_desc;}
		}
		/// <summary>
		/// 商品在前台显示的微缩图片，如在分类筛选时显示的小图片
		/// </summary>
		public string GOODS_THUMB
		{
			set{ _goods_thumb=value;}
			get{return _goods_thumb;}
		}
		/// <summary>
		/// 商品的实际大小图片，如进入该商品页时介绍商品属性所显示的大图片
		/// </summary>
		public string GOODS_IMG
		{
			set{ _goods_img=value;}
			get{return _goods_img;}
		}
		/// <summary>
		/// 应该是上传的商品的原始图片
		/// </summary>
		public string ORIGINAL_IMG
		{
			set{ _original_img=value;}
			get{return _original_img;}
		}
		/// <summary>
		/// 是否是实物，1，是；0，否；比如虚拟卡就为0，不是实物
		/// </summary>
		public int? IS_REAL
		{
			set{ _is_real=value;}
			get{return _is_real;}
		}
		/// <summary>
		/// 商品的扩展属性，比如像虚拟卡
		/// </summary>
		public string EXTENSION_CODE
		{
			set{ _extension_code=value;}
			get{return _extension_code;}
		}
		/// <summary>
		/// 该商品是否开放销售，1，是；0，否
		/// </summary>
		public int? IS_ON_SALE
		{
			set{ _is_on_sale=value;}
			get{return _is_on_sale;}
		}
		/// <summary>
		/// 是否能单独销售，1，是；0，否；如果不能单独销售，则只能作为某商品的配件或者赠品销售
		/// </summary>
		public int? IS_ALONE_SALE
		{
			set{ _is_alone_sale=value;}
			get{return _is_alone_sale;}
		}
		/// <summary>
		/// 购买该商品可以使用的积分数量，估计应该是用积分代替金额消费；但程序好像还没有实现该功能
		/// </summary>
		public int? INTEGRAL
		{
			set{ _integral=value;}
			get{return _integral;}
		}
		/// <summary>
		/// 商品的添加时间
		/// </summary>
		public int? ADD_TIME
		{
			set{ _add_time=value;}
			get{return _add_time;}
		}
		/// <summary>
		/// 应该是商品的显示顺序，不过该版程序中没实现该功能
		/// </summary>
		public int? SORT_ORDER
		{
			set{ _sort_order=value;}
			get{return _sort_order;}
		}
		/// <summary>
		/// 是否是精品；0，否；1，是
		/// </summary>
		public int? IS_BEST
		{
			set{ _is_best=value;}
			get{return _is_best;}
		}
		/// <summary>
		/// 商品是否已经删除，0，否；1，已删除
		/// </summary>
		public int? IS_DELETE
		{
			set{ _is_delete=value;}
			get{return _is_delete;}
		}
		/// <summary>
		/// 是否是精品；0，否；1，是
		/// </summary>
		public int? IS_NEW
		{
			set{ _is_new=value;}
			get{return _is_new;}
		}
		/// <summary>
		/// 是否热销，0，否；1，是
		/// </summary>
		public int? IS_HOT
		{
			set{ _is_hot=value;}
			get{return _is_hot;}
		}
		/// <summary>
		/// 是否特价促销；0，否；1，是
		/// </summary>
		public int? IS_PROMOTE
		{
			set{ _is_promote=value;}
			get{return _is_promote;}
		}
		/// <summary>
		/// 购买该商品所能领到的红包类型
		/// </summary>
		public int? BONUS_TYPE_ID
		{
			set{ _bonus_type_id=value;}
			get{return _bonus_type_id;}
		}
		/// <summary>
		/// 最近一次更新商品配置的时间
		/// </summary>
		public int? LAST_UPDATE
		{
			set{ _last_update=value;}
			get{return _last_update;}
		}
		/// <summary>
		/// 商品所属类型id，取值表goods_type的cat_id
		/// </summary>
		public int? GOODS_TYPE
		{
			set{ _goods_type=value;}
			get{return _goods_type;}
		}
		/// <summary>
		/// 商品的商家备注，仅商家可见
		/// </summary>
		public string SELLER_NOTE
		{
			set{ _seller_note=value;}
			get{return _seller_note;}
		}
		/// <summary>
		/// 购买该商品时每笔成功交易赠送的积分数量
		/// </summary>
		public int? GIVE_INTEGRAL
		{
			set{ _give_integral=value;}
			get{return _give_integral;}
		}
		#endregion Model

	}
}
