using System;
namespace CZZD.GSZX.Model
{
	/// <summary>
	/// ecs_shipping_area:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class BaseShippingAreaTable
	{
		public BaseShippingAreaTable()
		{}
		#region Model
		private int _shipping_area_id;
		private string _shipping_area_name;
		private int _shipping_id=0;
		private string _configure;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int shipping_area_id
		{
			set{ _shipping_area_id=value;}
			get{return _shipping_area_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string shipping_area_name
		{
			set{ _shipping_area_name=value;}
			get{return _shipping_area_name;}
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
		public string configure
		{
			set{ _configure=value;}
			get{return _configure;}
		}
		#endregion Model

	}
}

