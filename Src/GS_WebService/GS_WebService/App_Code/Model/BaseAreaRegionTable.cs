using System;
namespace CZZD.GSZX.Model
{
	/// <summary>
	/// ecs_area_region:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class BaseAreaRegionTable
	{
		public BaseAreaRegionTable()
		{}
		#region Model
		private int _shipping_area_id=0;
		private int _region_id=0;
		/// <summary>
		/// 
		/// </summary>
		public int shipping_area_id
		{
			set{ _shipping_area_id=value;}
			get{return _shipping_area_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int region_id
		{
			set{ _region_id=value;}
			get{return _region_id;}
		}
		#endregion Model

	}
}

