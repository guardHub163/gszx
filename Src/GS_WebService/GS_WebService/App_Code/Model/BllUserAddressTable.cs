using System;
namespace CZZD.GSZX.Model
{
	/// <summary>
	/// ecs_user_address:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class BllUserAddressTable
	{
		public BllUserAddressTable()
		{}
		#region Model
		private decimal _address_id;
		private string _address_name;
		private decimal _user_id=0;
		private string _consignee;
		private string _email;
		private int _country=0;
		private int _province=0;
		private int _city=0;
		private int _district=0;
		private string _address;
		private string _zipcode;
		private string _tel;
		private string _mobile;
		private string _sign_building;
		private string _best_time;
		/// <summary>
		/// auto_increment
		/// </summary>
		public decimal address_id
		{
			set{ _address_id=value;}
			get{return _address_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string address_name
		{
			set{ _address_name=value;}
			get{return _address_name;}
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
		public string consignee
		{
			set{ _consignee=value;}
			get{return _consignee;}
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
		public string sign_building
		{
			set{ _sign_building=value;}
			get{return _sign_building;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string best_time
		{
			set{ _best_time=value;}
			get{return _best_time;}
		}
		#endregion Model

	}
}

