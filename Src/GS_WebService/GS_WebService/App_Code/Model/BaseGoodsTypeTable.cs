using System;
namespace CZZD.GSZX.Model
{
	/// <summary>
	/// ecs_goods_type:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class BaseGoodsTypeTable
	{
		public BaseGoodsTypeTable()
		{}
		#region Model
		private int _cat_id;
		private string _cat_name;
		private int _enabled=1;
		private string _attr_group;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int cat_id
		{
			set{ _cat_id=value;}
			get{return _cat_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cat_name
		{
			set{ _cat_name=value;}
			get{return _cat_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int enabled
		{
			set{ _enabled=value;}
			get{return _enabled;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string attr_group
		{
			set{ _attr_group=value;}
			get{return _attr_group;}
		}
		#endregion Model

	}
}

