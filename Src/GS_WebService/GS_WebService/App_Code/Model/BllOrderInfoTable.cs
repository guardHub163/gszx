using System;
namespace CZZD.GSZX.Model
{
	/// <summary>
	/// ecs_order_info:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class BllOrderInfoTable
	{
		public BllOrderInfoTable()
		{}
		#region Model
		private decimal _order_id;
		private string _order_sn;
		private decimal _user_id=0;
		private int _order_status=0;
		private int _shipping_status=0;
		private int _pay_status=0;
		private string _consignee;
		private int _country=0;
		private int _province=0;
		private int _city=0;
		private int _district=0;
		private string _address;
		private string _zipcode;
		private string _tel;
		private string _mobile;
		private string _email;
		private string _best_time;
		private string _sign_building;
		private string _postscript;
		private int _shipping_id=0;
		private string _shipping_name;
		private int _pay_id=0;
		private string _pay_name;
		private string _how_oos;
		private string _how_surplus;
		private string _pack_name;
		private string _card_name;
		private string _card_message;
		private string _inv_payee;
		private string _inv_content;
		private decimal _goods_amount;
		private decimal _shipping_fee;
		private decimal _insure_fee;
		private decimal _pay_fee;
		private decimal _pack_fee;
		private decimal _card_fee;
		private decimal _money_paid;
		private decimal _surplus;
		private int _integral=0;
		private decimal _integral_money;
		private decimal _bonus;
		private decimal _order_amount;
		private int _from_ad=0;
		private string _referer;
		private int _add_time=0;
		private int _confirm_time=0;
		private int _pay_time=0;
		private int _shipping_time=0;
		private int _pack_id=0;
		private int _card_id=0;
		private int _bonus_id=0;
		private string _invoice_no;
		private string _extension_code;
		private decimal _extension_id=0;
		private string _to_buyer;
		private string _pay_note;
		private int _agency_id;
		private string _inv_type;
		private decimal _tax;
		private int _is_separate=0;
		private decimal _parent_id=0;
		private decimal _discount;
        private int? _send_status = 0;
        private decimal? _actual_goods_amount;
		/// <summary>
		/// auto_increment
		/// </summary>
		public decimal order_id
		{
			set{ _order_id=value;}
			get{return _order_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string order_sn
		{
			set{ _order_sn=value;}
			get{return _order_sn;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal user_id
		{
			set{ _user_id=value;}
			get{return _user_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int order_status
		{
			set{ _order_status=value;}
			get{return _order_status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int shipping_status
		{
			set{ _shipping_status=value;}
			get{return _shipping_status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int pay_status
		{
			set{ _pay_status=value;}
			get{return _pay_status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string consignee
		{
			set{ _consignee=value;}
			get{return _consignee;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int country
		{
			set{ _country=value;}
			get{return _country;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int province
		{
			set{ _province=value;}
			get{return _province;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int city
		{
			set{ _city=value;}
			get{return _city;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int district
		{
			set{ _district=value;}
			get{return _district;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string zipcode
		{
			set{ _zipcode=value;}
			get{return _zipcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string tel
		{
			set{ _tel=value;}
			get{return _tel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string mobile
		{
			set{ _mobile=value;}
			get{return _mobile;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string best_time
		{
			set{ _best_time=value;}
			get{return _best_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sign_building
		{
			set{ _sign_building=value;}
			get{return _sign_building;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string postscript
		{
			set{ _postscript=value;}
			get{return _postscript;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int shipping_id
		{
			set{ _shipping_id=value;}
			get{return _shipping_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string shipping_name
		{
			set{ _shipping_name=value;}
			get{return _shipping_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int pay_id
		{
			set{ _pay_id=value;}
			get{return _pay_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string pay_name
		{
			set{ _pay_name=value;}
			get{return _pay_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string how_oos
		{
			set{ _how_oos=value;}
			get{return _how_oos;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string how_surplus
		{
			set{ _how_surplus=value;}
			get{return _how_surplus;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string pack_name
		{
			set{ _pack_name=value;}
			get{return _pack_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string card_name
		{
			set{ _card_name=value;}
			get{return _card_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string card_message
		{
			set{ _card_message=value;}
			get{return _card_message;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string inv_payee
		{
			set{ _inv_payee=value;}
			get{return _inv_payee;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string inv_content
		{
			set{ _inv_content=value;}
			get{return _inv_content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal goods_amount
		{
			set{ _goods_amount=value;}
			get{return _goods_amount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal shipping_fee
		{
			set{ _shipping_fee=value;}
			get{return _shipping_fee;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal insure_fee
		{
			set{ _insure_fee=value;}
			get{return _insure_fee;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal pay_fee
		{
			set{ _pay_fee=value;}
			get{return _pay_fee;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal pack_fee
		{
			set{ _pack_fee=value;}
			get{return _pack_fee;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal card_fee
		{
			set{ _card_fee=value;}
			get{return _card_fee;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal money_paid
		{
			set{ _money_paid=value;}
			get{return _money_paid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal surplus
		{
			set{ _surplus=value;}
			get{return _surplus;}
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
		public decimal integral_money
		{
			set{ _integral_money=value;}
			get{return _integral_money;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal bonus
		{
			set{ _bonus=value;}
			get{return _bonus;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal order_amount
		{
			set{ _order_amount=value;}
			get{return _order_amount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int from_ad
		{
			set{ _from_ad=value;}
			get{return _from_ad;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string referer
		{
			set{ _referer=value;}
			get{return _referer;}
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
		public int confirm_time
		{
			set{ _confirm_time=value;}
			get{return _confirm_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int pay_time
		{
			set{ _pay_time=value;}
			get{return _pay_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int shipping_time
		{
			set{ _shipping_time=value;}
			get{return _shipping_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int pack_id
		{
			set{ _pack_id=value;}
			get{return _pack_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int card_id
		{
			set{ _card_id=value;}
			get{return _card_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int bonus_id
		{
			set{ _bonus_id=value;}
			get{return _bonus_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string invoice_no
		{
			set{ _invoice_no=value;}
			get{return _invoice_no;}
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
		public decimal extension_id
		{
			set{ _extension_id=value;}
			get{return _extension_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string to_buyer
		{
			set{ _to_buyer=value;}
			get{return _to_buyer;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string pay_note
		{
			set{ _pay_note=value;}
			get{return _pay_note;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int agency_id
		{
			set{ _agency_id=value;}
			get{return _agency_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string inv_type
		{
			set{ _inv_type=value;}
			get{return _inv_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal tax
		{
			set{ _tax=value;}
			get{return _tax;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int is_separate
		{
			set{ _is_separate=value;}
			get{return _is_separate;}
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
		public decimal discount
		{
			set{ _discount=value;}
			get{return _discount;}
		}
        /// <summary>
        /// 
        /// </summary>
        public int? send_status
        {
            set { _send_status = value; }
            get { return _send_status; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? actual_goods_amount
        {
            set { _actual_goods_amount = value; }
            get { return _actual_goods_amount; }
        }

		#endregion Model

	}
}

