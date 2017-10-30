using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CZZD.GSZX.S.Model
{    
    /// <summary>
	/// BASE_ORDER_INFO:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class BllOrderInfoTable
	{
        public BllOrderInfoTable()
		{}
		#region Model
		private decimal _order_id;
		private string _order_sn;
		private int? _user_id;
		private int? _order_status;
		private int? _shipping_status;
		private int? _pay_status;
		private string _consignee;
		private string _country;
		private string _province;
		private string _city;
		private string _district;
		private string _address;
		private string _zipcode;
		private string _tel;
		private string _mobile;
		private string _email;
		private int? _best_time;
		private string _sign_building;
		private string _post_script;
		private int? _shipping_id;
		private string _shipping_name;
		private int? _pay_id;
		private string _pay_name;
		private string _how_oos;
		private string _how_surplus;
		private string _pack_name;
		private string _card_name;
		private string _card_message;
		private string _inv_payee;
		private string _inv_content;
		private decimal? _goods_amount;
		private decimal? _shipping_fee;
		private decimal? _insure_fee;
		private decimal? _pay_fee;
		private decimal? _pack_fee;
		private decimal? _card_fee;
		private decimal? _money_paid;
		private decimal? _surplus;
		private int? _integral;
		private decimal? _integrall_money;
		private decimal? _bonus;
		private decimal? _order_amount;
		private int? _from_ad;
		private string _referer;
		private DateTime? _add_time;
		private DateTime? _confirm_time;
		private DateTime? _pay_time;
		private DateTime? _shipping_time;
		private int? _pack_id;
		private int? _card_id;
		private int? _bonus_id;
		private string _invoice_no;
		private string _extension_code;
		private int? _extension_id;
		private string _to_buyer;
		private string _pay_note;
		private int? _agency_id;
		private string _inv_type;
		private decimal? _tax;
		private int? _is_separate;
		private string _parent_id;
		private decimal? _discount;
		private int _order_type;
		private decimal? _actual_amount;
		private int? _print_status;
        private List<BllOrderGoodsTable> _orderGoods = new List<BllOrderGoodsTable>();
        
		/// <summary>
		/// 订单详细信息自增id
		/// </summary>
		public decimal ORDER_ID
		{
			set{ _order_id=value;}
			get{return _order_id;}
		}
		/// <summary>
		/// 订单号，唯一
		/// </summary>
		public string ORDER_SN
		{
			set{ _order_sn=value;}
			get{return _order_sn;}
		}
		/// <summary>
		/// 用户id，同ecs_users的user_id
		/// </summary>
		public int? USER_ID
		{
			set{ _user_id=value;}
			get{return _user_id;}
		}
		/// <summary>
		/// 订单状态。0，未确认；1，已确认；2，已取消；3，无效；4，退货；
		/// </summary>
		public int? ORDER_STATUS
		{
			set{ _order_status=value;}
			get{return _order_status;}
		}
		/// <summary>
		/// 商品配送情况，0，未发货；1，已发货；2，已收货；3，备货中
		/// </summary>
		public int? SHIPPING_STATUS
		{
			set{ _shipping_status=value;}
			get{return _shipping_status;}
		}
		/// <summary>
		/// 支付状态；0，未付款；1，付款中；2，已付款
		/// </summary>
		public int? PAY_STATUS
		{
			set{ _pay_status=value;}
			get{return _pay_status;}
		}
		/// <summary>
		/// 收货人的姓名，用户页面填写，默认取值于表user_address
		/// </summary>
		public string CONSIGNEE
		{
			set{ _consignee=value;}
			get{return _consignee;}
		}
		/// <summary>
		/// 收货人的国家，用户页面填写，默认取值于表user_address，其id对应的值在ecs_region
		/// </summary>
		public string COUNTRY
		{
			set{ _country=value;}
			get{return _country;}
		}
		/// <summary>
		/// 收货人的省份，用户页面填写，默认取值于表user_address，其id对应的值在ecs_region
		/// </summary>
		public string PROVINCE
		{
			set{ _province=value;}
			get{return _province;}
		}
		/// <summary>
		/// 收货人的城市，用户页面填写，默认取值于表user_address，其id对应的值在ecs_region
		/// </summary>
		public string CITY
		{
			set{ _city=value;}
			get{return _city;}
		}
		/// <summary>
		/// 收货人的地区，用户页面填写，默认取值于表user_address，其id对应的值在ecs_region
		/// </summary>
		public string DISTRICT
		{
			set{ _district=value;}
			get{return _district;}
		}
		/// <summary>
		/// 收货人的详细地址，用户页面填写，默认取值于表user_address
		/// </summary>
		public string ADDRESS
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 收货人的邮编，用户页面填写，默认取值于表user_address
		/// </summary>
		public string ZIPCODE
		{
			set{ _zipcode=value;}
			get{return _zipcode;}
		}
		/// <summary>
		/// 收货人的电话，用户页面填写，默认取值于表user_address
		/// </summary>
		public string TEL
		{
			set{ _tel=value;}
			get{return _tel;}
		}
		/// <summary>
		/// 收货人的手机，用户页面填写，默认取值于表user_address
		/// </summary>
		public string MOBILE
		{
			set{ _mobile=value;}
			get{return _mobile;}
		}
		/// <summary>
		/// 收货人的手机，用户页面填写，默认取值于表user_address
		/// </summary>
		public string EMAIL
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 收货人的最佳送货时间，用户页面填写，默认取值于表user_address
		/// </summary>
		public int? BEST_TIME
		{
			set{ _best_time=value;}
			get{return _best_time;}
		}
		/// <summary>
		/// 收货人的地址的标志性建筑，用户页面填写，默认取值于表user_address
		/// </summary>
		public string SIGN_BUILDING
		{
			set{ _sign_building=value;}
			get{return _sign_building;}
		}
		/// <summary>
		/// 订单附言，由用户提交订单前填写
		/// </summary>
		public string POST_SCRIPT
		{
			set{ _post_script=value;}
			get{return _post_script;}
		}
		/// <summary>
		/// 用户选择的配送方式id，取值表ecs_shipping
		/// </summary>
		public int? SHIPPING_ID
		{
			set{ _shipping_id=value;}
			get{return _shipping_id;}
		}
		/// <summary>
		/// 用户选择的配送方式的名称，取值表ecs_shipping
		/// </summary>
		public string SHIPPING_NAME
		{
			set{ _shipping_name=value;}
			get{return _shipping_name;}
		}
		/// <summary>
		/// 用户选择的支付方式的id，取值表ecs_payment
		/// </summary>
		public int? PAY_ID
		{
			set{ _pay_id=value;}
			get{return _pay_id;}
		}
		/// <summary>
		/// 用户选择的支付方式的名称，取值表ecs_payment'
		/// </summary>
		public string PAY_NAME
		{
			set{ _pay_name=value;}
			get{return _pay_name;}
		}
		/// <summary>
		/// 缺货处理方式，等待所有商品备齐后再发； 取消订单；与店主协商
		/// </summary>
		public string HOW_OOS
		{
			set{ _how_oos=value;}
			get{return _how_oos;}
		}
		/// <summary>
		/// 根据字段猜测应该是余额处理方式，程序未作这部分实现
		/// </summary>
		public string HOW_SURPLUS
		{
			set{ _how_surplus=value;}
			get{return _how_surplus;}
		}
		/// <summary>
		/// 包装名称，取值表ecs_pack
		/// </summary>
		public string PACK_NAME
		{
			set{ _pack_name=value;}
			get{return _pack_name;}
		}
		/// <summary>
		/// 贺卡的名称，取值ecs_card 
		/// </summary>
		public string CARD_NAME
		{
			set{ _card_name=value;}
			get{return _card_name;}
		}
		/// <summary>
		/// 贺卡内容，由用户提交
		/// </summary>
		public string CARD_MESSAGE
		{
			set{ _card_message=value;}
			get{return _card_message;}
		}
		/// <summary>
		/// 发票抬头，用户页面填写
		/// </summary>
		public string INV_PAYEE
		{
			set{ _inv_payee=value;}
			get{return _inv_payee;}
		}
		/// <summary>
		/// 发票内容，用户页面选择，取值ecs_shop_config的code字段的值为invoice_content的value
		/// </summary>
		public string INV_CONTENT
		{
			set{ _inv_content=value;}
			get{return _inv_content;}
		}
		/// <summary>
		/// 商品总金额
		/// </summary>
		public decimal? GOODS_AMOUNT
		{
			set{ _goods_amount=value;}
			get{return _goods_amount;}
		}
		/// <summary>
		/// 配送费用
		/// </summary>
		public decimal? SHIPPING_FEE
		{
			set{ _shipping_fee=value;}
			get{return _shipping_fee;}
		}
		/// <summary>
		/// 保价费用
		/// </summary>
		public decimal? INSURE_FEE
		{
			set{ _insure_fee=value;}
			get{return _insure_fee;}
		}
		/// <summary>
		/// 支付费用,跟支付方式的配置相关，取值表ecs_payment
		/// </summary>
		public decimal? PAY_FEE
		{
			set{ _pay_fee=value;}
			get{return _pay_fee;}
		}
		/// <summary>
		/// 包装费用，取值表取值表ecs_pack
		/// </summary>
		public decimal? PACK_FEE
		{
			set{ _pack_fee=value;}
			get{return _pack_fee;}
		}
		/// <summary>
		/// 贺卡费用，取值ecs_card 
		/// </summary>
		public decimal? CARD_FEE
		{
			set{ _card_fee=value;}
			get{return _card_fee;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? MONEY_PAID
		{
			set{ _money_paid=value;}
			get{return _money_paid;}
		}
		/// <summary>
		/// 该订单使用余额的数量，取用户设定余额，用户可用余额，订单金额中最小者
		/// </summary>
		public decimal? SURPLUS
		{
			set{ _surplus=value;}
			get{return _surplus;}
		}
		/// <summary>
		/// 使用的积分的数量，取用户使用积分，商品可用积分，用户拥有积分中最小者
		/// </summary>
		public int? INTEGRAL
		{
			set{ _integral=value;}
			get{return _integral;}
		}
		/// <summary>
		/// 使用积分金额
		/// </summary>
		public decimal? INTEGRALl_MONEY
		{
			set{ _integrall_money=value;}
			get{return _integrall_money;}
		}
		/// <summary>
		/// 使用红包金额
		/// </summary>
		public decimal? BONUS
		{
			set{ _bonus=value;}
			get{return _bonus;}
		}
		/// <summary>
		/// 应付款金额
		/// </summary>
		public decimal? ORDER_AMOUNT
		{
			set{ _order_amount=value;}
			get{return _order_amount;}
		}
		/// <summary>
		/// 订单由某广告带来的广告id，应该取值于ecs_ad
		/// </summary>
		public int? FROM_AD
		{
			set{ _from_ad=value;}
			get{return _from_ad;}
		}
		/// <summary>
		/// 订单的来源页面
		/// </summary>
		public string REFERER
		{
			set{ _referer=value;}
			get{return _referer;}
		}
		/// <summary>
		/// 订单生成时间
		/// </summary>
		public DateTime? ADD_TIME
		{
			set{ _add_time=value;}
			get{return _add_time;}
		}
		/// <summary>
		/// 订单确认时间
		/// </summary>
		public DateTime? CONFIRM_TIME
		{
			set{ _confirm_time=value;}
			get{return _confirm_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? PAY_TIME
		{
			set{ _pay_time=value;}
			get{return _pay_time;}
		}
		/// <summary>
		/// 订单配送时间
		/// </summary>
		public DateTime? SHIPPING_TIME
		{
			set{ _shipping_time=value;}
			get{return _shipping_time;}
		}
		/// <summary>
		/// 包装id，取值取值表ecs_pack
		/// </summary>
		public int? PACK_ID
		{
			set{ _pack_id=value;}
			get{return _pack_id;}
		}
		/// <summary>
		/// 贺卡id，用户在页面选择，取值取值ecs_card
		/// </summary>
		public int? CARD_ID
		{
			set{ _card_id=value;}
			get{return _card_id;}
		}
		/// <summary>
		/// 红包的id，ecs_user_bonus的bonus_id
		/// </summary>
		public int? BONUS_ID
		{
			set{ _bonus_id=value;}
			get{return _bonus_id;}
		}
		/// <summary>
		/// 发货单号，发货时填写，可在订单查询查看
		/// </summary>
		public string INVOICE_NO
		{
			set{ _invoice_no=value;}
			get{return _invoice_no;}
		}
		/// <summary>
		/// 通过活动购买的商品的代号；GROUP_BUY是团购；AUCTION，是拍卖；SNATCH，夺宝奇兵；正常普通产品该处为空
		/// </summary>
		public string EXTENSION_CODE
		{
			set{ _extension_code=value;}
			get{return _extension_code;}
		}
		/// <summary>
		/// 通过活动购买的物品的id，取值ecs_goods_activity；如果是正常普通商品，该处为0
		/// </summary>
		public int? EXTENSION_ID
		{
			set{ _extension_id=value;}
			get{return _extension_id;}
		}
		/// <summary>
		/// 商家给客户的留言,当该字段有值时可以在订单查询看到
		/// </summary>
		public string TO_BUYER
		{
			set{ _to_buyer=value;}
			get{return _to_buyer;}
		}
		/// <summary>
		/// 付款备注，在订单管理里编辑修改
		/// </summary>
		public string PAY_NOTE
		{
			set{ _pay_note=value;}
			get{return _pay_note;}
		}
		/// <summary>
		/// 该笔订单被指派给的办事处的id，根据订单内容和办事处负责范围自动决定，也可以有管理员修改，取值于表ecs_agency
		/// </summary>
		public int? AGENCY_ID
		{
			set{ _agency_id=value;}
			get{return _agency_id;}
		}
		/// <summary>
		/// 发票类型，用户页面选择，取值ecs_shop_config的code字段的值为invoice_type的value
		/// </summary>
		public string INV_TYPE
		{
			set{ _inv_type=value;}
			get{return _inv_type;}
		}
		/// <summary>
		/// 发票税额
		/// </summary>
		public decimal? TAX
		{
			set{ _tax=value;}
			get{return _tax;}
		}
		/// <summary>
		/// 0，未分成或等待分成；1，已分成；2，取消分成；
		/// </summary>
		public int? IS_SEPARATE
		{
			set{ _is_separate=value;}
			get{return _is_separate;}
		}
		/// <summary>
		/// 能获得推荐分成的用户id，id取值于表ecs_users
		/// </summary>
		public string PARENT_ID
		{
			set{ _parent_id=value;}
			get{return _parent_id;}
		}
		/// <summary>
		/// 折扣金额
		/// </summary>
		public decimal? DISCOUNT
		{
			set{ _discount=value;}
			get{return _discount;}
		}
		/// <summary>
		/// 订单分类：0为本地，1为上传
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
		/// 打印状态
		/// </summary>
		public int? PRINT_STATUS
		{
			set{ _print_status=value;}
			get{return _print_status;}
		}

        /// <summary>
        /// 订单明细
        /// </summary>
        public List<BllOrderGoodsTable> ORDER_GOODS
        {
            get { return _orderGoods; }
            set { _orderGoods = value; }
        }

        /// <summary>
        /// 增加一条订单明细
        /// </summary>
        /// <param name="orderGoodsTable"></param>
        public void AddItems(BllOrderGoodsTable orderGoodsTable)
        {
            _orderGoods.Add(orderGoodsTable);
        }
		#endregion Model

	}
}
