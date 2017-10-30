using System;
namespace CZZD.GSZX.Model
{
	/// <summary>
	/// ecs_user_account:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class BaseUserAccountTable
	{
		public BaseUserAccountTable()
		{}
		#region Model
		private decimal _id;
		private decimal _user_id=0;
		private string _admin_user;
		private decimal _amount;
		private int _add_time=0;
		private int _paid_time=0;
		private string _admin_note;
		private string _user_note;
		private int _process_type=0;
		private string _payment;
		private int _is_paid=0;
		/// <summary>
		/// auto_increment
		/// </summary>
		public decimal id
		{
			set{ _id=value;}
			get{return _id;}
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
		public string admin_user
		{
			set{ _admin_user=value;}
			get{return _admin_user;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal amount
		{
			set{ _amount=value;}
			get{return _amount;}
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
		public int paid_time
		{
			set{ _paid_time=value;}
			get{return _paid_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string admin_note
		{
			set{ _admin_note=value;}
			get{return _admin_note;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string user_note
		{
			set{ _user_note=value;}
			get{return _user_note;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int process_type
		{
			set{ _process_type=value;}
			get{return _process_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string payment
		{
			set{ _payment=value;}
			get{return _payment;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int is_paid
		{
			set{ _is_paid=value;}
			get{return _is_paid;}
		}
		#endregion Model

	}
}

