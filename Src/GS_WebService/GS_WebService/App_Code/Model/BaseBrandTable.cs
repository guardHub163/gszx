using System;
namespace CZZD.GSZX.Model
{
	/// <summary>
	/// ecs_brand:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class BaseBrandTable
	{
		public BaseBrandTable()
		{}
		#region Model
		private int _brand_id;
		private string _brand_name;
		private string _brand_logo;
		private string _brand_desc;
		private string _site_url;
		private int _sort_order=0;
		private int _is_show=1;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int brand_id
		{
			set{ _brand_id=value;}
			get{return _brand_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string brand_name
		{
			set{ _brand_name=value;}
			get{return _brand_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string brand_logo
		{
			set{ _brand_logo=value;}
			get{return _brand_logo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string brand_desc
		{
			set{ _brand_desc=value;}
			get{return _brand_desc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string site_url
		{
			set{ _site_url=value;}
			get{return _site_url;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int sort_order
		{
			set{ _sort_order=value;}
			get{return _sort_order;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int is_show
		{
			set{ _is_show=value;}
			get{return _is_show;}
		}
		#endregion Model

	}
}

