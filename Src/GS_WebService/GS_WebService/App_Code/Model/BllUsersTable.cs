using System;
namespace CZZD.GSZX.Model
{
	/// <summary>
	/// ecs_users:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class BllUsersTable
	{
		public BllUsersTable()
		{}
		#region Model
		private decimal _user_id;
		private string _email;
		private string _user_name;
		private string _password;
		private string _question;
		private string _answer;
		private int _sex=0;
		private DateTime _birthday= Convert.ToDateTime("0000-00-00");
		private decimal _user_money;
		private decimal _frozen_money;
		private int _pay_points=0;
		private int _rank_points=0;
		private decimal _address_id=0;
		private int _reg_time=0;
		private int _last_login=0;
		private DateTime _last_time= Convert.ToDateTime("0000-00-00 00:00:00");
		private string _last_ip;
		private int _visit_count=0;
		private int _user_rank=0;
		private int _is_special=0;
		private string _salt="0";
		private decimal _parent_id=0;
		private int _flag=0;
		private string _alias;
		private string _msn;
		private string _qq;
		private string _office_phone;
		private string _home_phone;
		private string _mobile_phone;
		private int _is_validated=0;
		private decimal _credit_line;
		/// <summary>
		/// auto_increment
		/// </summary>
		public decimal user_id
		{
			set{ _user_id=value;}
			get{return _user_id;}
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
		public string user_name
		{
			set{ _user_name=value;}
			get{return _user_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string password
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string question
		{
			set{ _question=value;}
			get{return _question;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string answer
		{
			set{ _answer=value;}
			get{return _answer;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int sex
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime birthday
		{
			set{ _birthday=value;}
			get{return _birthday;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal user_money
		{
			set{ _user_money=value;}
			get{return _user_money;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal frozen_money
		{
			set{ _frozen_money=value;}
			get{return _frozen_money;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int pay_points
		{
			set{ _pay_points=value;}
			get{return _pay_points;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int rank_points
		{
			set{ _rank_points=value;}
			get{return _rank_points;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal address_id
		{
			set{ _address_id=value;}
			get{return _address_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int reg_time
		{
			set{ _reg_time=value;}
			get{return _reg_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int last_login
		{
			set{ _last_login=value;}
			get{return _last_login;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime last_time
		{
			set{ _last_time=value;}
			get{return _last_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string last_ip
		{
			set{ _last_ip=value;}
			get{return _last_ip;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int visit_count
		{
			set{ _visit_count=value;}
			get{return _visit_count;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int user_rank
		{
			set{ _user_rank=value;}
			get{return _user_rank;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int is_special
		{
			set{ _is_special=value;}
			get{return _is_special;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string salt
		{
			set{ _salt=value;}
			get{return _salt;}
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
		public int flag
		{
			set{ _flag=value;}
			get{return _flag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string alias
		{
			set{ _alias=value;}
			get{return _alias;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string msn
		{
			set{ _msn=value;}
			get{return _msn;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string qq
		{
			set{ _qq=value;}
			get{return _qq;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string office_phone
		{
			set{ _office_phone=value;}
			get{return _office_phone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string home_phone
		{
			set{ _home_phone=value;}
			get{return _home_phone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string mobile_phone
		{
			set{ _mobile_phone=value;}
			get{return _mobile_phone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int is_validated
		{
			set{ _is_validated=value;}
			get{return _is_validated;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal credit_line
		{
			set{ _credit_line=value;}
			get{return _credit_line;}
		}
		#endregion Model

	}
}

