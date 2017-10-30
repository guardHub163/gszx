using System;
namespace CZZD.GSZX.Model
{
	/// <summary>
	/// ecs_order_action:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class BllOrderActionTable
	{
		public BllOrderActionTable()
		{}
		#region Model
		private decimal _action_id;
		private decimal _order_id=0;
		private string _action_user;
		private int _order_status=0;
		private int _shipping_status=0;
		private int _pay_status=0;
		private string _action_note;
		private int _log_time=0;
		/// <summary>
		/// auto_increment
		/// </summary>
		public decimal action_id
		{
			set{ _action_id=value;}
			get{return _action_id;}
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
		public string action_user
		{
			set{ _action_user=value;}
			get{return _action_user;}
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
		public string action_note
		{
			set{ _action_note=value;}
			get{return _action_note;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int log_time
		{
			set{ _log_time=value;}
			get{return _log_time;}
		}
		#endregion Model

	}
}

