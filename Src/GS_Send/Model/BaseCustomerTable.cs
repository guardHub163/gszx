using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CZZD.GSZX.S.Model
{
   /// <summary>
	/// BASE_CUSTOMER:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class BaseCustomerTable
	{
        public BaseCustomerTable()
		{}
		#region Model
		private decimal _user_id;
		private string _email;
		private string _user_name;
		private string _password;
		private string _question;
		private string _answer;
		private int? _sex;
		private DateTime? _birthday;
		private decimal? _user_money;
		private decimal? _frozen_money;
		private int? _pay_points;
		private int? _rank_points;
		private int? _address_id;
		private int? _reg_time;
		private int? _last_login;
		private DateTime? _last_time;
		private string _last_ip;
		private int? _visit_count;
		private int? _user_rank;
		private int? _is_special;
		private int? _salt;
		private int? _parent_id;
		private int? _flag;
		private string _alias;
		private string _msn;
		private int? _qq;
		private string _office_phone;
		private string _home_phone;
		private string _mobile_phone;
		private int? _is_validated;
		private decimal? _credit_line;
		/// <summary>
		/// 会员资料自增id
		/// </summary>
		public decimal USER_ID
		{
			set{ _user_id=value;}
			get{return _user_id;}
		}
		/// <summary>
		/// 会员邮箱
		/// </summary>
		public string EMAIL
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 用户名
		/// </summary>
		public string USER_NAME
		{
			set{ _user_name=value;}
			get{return _user_name;}
		}
		/// <summary>
		/// 密码
		/// </summary>
		public string PASSWORD
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 安全问题答案
		/// </summary>
		public string QUESTION
		{
			set{ _question=value;}
			get{return _question;}
		}
		/// <summary>
		/// 安全问题
		/// </summary>
		public string ANSWER
		{
			set{ _answer=value;}
			get{return _answer;}
		}
		/// <summary>
		/// 性别，0，保密；1，男；2，女'
		/// </summary>
		public int? SEX
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// 生日日期
		/// </summary>
		public DateTime? BIRTHDAY
		{
			set{ _birthday=value;}
			get{return _birthday;}
		}
		/// <summary>
		/// 用户现有资金
		/// </summary>
		public decimal? USER_MONEY
		{
			set{ _user_money=value;}
			get{return _user_money;}
		}
		/// <summary>
		/// 用户冻结资金'
		/// </summary>
		public decimal? FROZEN_MONEY
		{
			set{ _frozen_money=value;}
			get{return _frozen_money;}
		}
		/// <summary>
		/// 消费积分
		/// </summary>
		public int? PAY_POINTS
		{
			set{ _pay_points=value;}
			get{return _pay_points;}
		}
		/// <summary>
		/// 会员等级积分
		/// </summary>
		public int? RANK_POINTS
		{
			set{ _rank_points=value;}
			get{return _rank_points;}
		}
		/// <summary>
		/// 收货信息id，取值表ecs_user_address
		/// </summary>
		public int? ADDRESS_ID
		{
			set{ _address_id=value;}
			get{return _address_id;}
		}
		/// <summary>
		/// 注册时间
		/// </summary>
		public int? REG_TIME
		{
			set{ _reg_time=value;}
			get{return _reg_time;}
		}
		/// <summary>
		/// 最后一次登录时间IN
		/// </summary>
		public int? LAST_LOGIN
		{
			set{ _last_login=value;}
			get{return _last_login;}
		}
		/// <summary>
		/// 应该是最后一次修改信息时间，该表信息从其他表同步过来考虑
		/// </summary>
		public DateTime? LAST_TIME
		{
			set{ _last_time=value;}
			get{return _last_time;}
		}
		/// <summary>
		/// 最后一次登录ip
		/// </summary>
		public string LAST_IP
		{
			set{ _last_ip=value;}
			get{return _last_ip;}
		}
		/// <summary>
		/// 登录次数
		/// </summary>
		public int? VISIT_COUNT
		{
			set{ _visit_count=value;}
			get{return _visit_count;}
		}
		/// <summary>
		/// 会员登记id，取值ecs_user_rank
		/// </summary>
		public int? USER_RANK
		{
			set{ _user_rank=value;}
			get{return _user_rank;}
		}
		/// <summary>
		/// 0
		/// </summary>
		public int? IS_SPECIAL
		{
			set{ _is_special=value;}
			get{return _is_special;}
		}
		/// <summary>
		/// 0
		/// </summary>
		public int? SALT
		{
			set{ _salt=value;}
			get{return _salt;}
		}
		/// <summary>
		/// 推荐人会员id，
		/// </summary>
		public int? PARENT_ID
		{
			set{ _parent_id=value;}
			get{return _parent_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? FLAG
		{
			set{ _flag=value;}
			get{return _flag;}
		}
		/// <summary>
		/// 昵称
		/// </summary>
		public string ALIAS
		{
			set{ _alias=value;}
			get{return _alias;}
		}
		/// <summary>
		/// MSN
		/// </summary>
		public string MSN
		{
			set{ _msn=value;}
			get{return _msn;}
		}
		/// <summary>
		/// QQ
		/// </summary>
		public int? QQ
		{
			set{ _qq=value;}
			get{return _qq;}
		}
		/// <summary>
		/// 办公电话
		/// </summary>
		public string OFFICE_PHONE
		{
			set{ _office_phone=value;}
			get{return _office_phone;}
		}
		/// <summary>
		/// 家庭电话
		/// </summary>
		public string HOME_PHONE
		{
			set{ _home_phone=value;}
			get{return _home_phone;}
		}
		/// <summary>
		/// 手机
		/// </summary>
		public string MOBILE_PHONE
		{
			set{ _mobile_phone=value;}
			get{return _mobile_phone;}
		}
		/// <summary>
		/// 0
		/// </summary>
		public int? IS_VALIDATED
		{
			set{ _is_validated=value;}
			get{return _is_validated;}
		}
		/// <summary>
		///  '信用额度，目前2.6.0版好像没有作实现',
		/// </summary>
		public decimal? CREDIT_LINE
		{
			set{ _credit_line=value;}
			get{return _credit_line;}
		}
		#endregion Model

	}
}