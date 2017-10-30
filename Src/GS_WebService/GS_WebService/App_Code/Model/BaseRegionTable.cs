using System;
namespace CZZD.GSZX.Model
{
	/// <summary>
	/// ecs_region:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class BaseRegionTable
	{
		public BaseRegionTable()
		{}
		#region Model
		private int _region_id;
		private int _parent_id=0;
		private string _region_name;
		private int _region_type=2;
		private int _agency_id;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int region_id
		{
			set{ _region_id=value;}
			get{return _region_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int parent_id
		{
			set{ _parent_id=value;}
			get{return _parent_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string region_name
		{
			set{ _region_name=value;}
			get{return _region_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int region_type
		{
			set{ _region_type=value;}
			get{return _region_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int agency_id
		{
			set{ _agency_id=value;}
			get{return _agency_id;}
		}
		#endregion Model

	}
}

