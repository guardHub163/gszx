using System;
namespace CZZD.GSZX.Model
{
	/// <summary>
	/// ecs_category:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class BaseCategoryTable
	{
		public BaseCategoryTable()
		{}
		#region Model
		private int _cat_id;
		private string _cat_name;
		private string _keywords;
		private string _cat_desc;
		private int _parent_id=0;
		private int _sort_order=0;
		private string _template_file;
		private string _measure_unit;
		private int _show_in_nav=0;
		private string _style;
		private int _is_show=1;
		private int _grade=0;
		private int _filter_attr=0;
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
		public string keywords
		{
			set{ _keywords=value;}
			get{return _keywords;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cat_desc
		{
			set{ _cat_desc=value;}
			get{return _cat_desc;}
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
		public int sort_order
		{
			set{ _sort_order=value;}
			get{return _sort_order;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string template_file
		{
			set{ _template_file=value;}
			get{return _template_file;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string measure_unit
		{
			set{ _measure_unit=value;}
			get{return _measure_unit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int show_in_nav
		{
			set{ _show_in_nav=value;}
			get{return _show_in_nav;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string style
		{
			set{ _style=value;}
			get{return _style;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int is_show
		{
			set{ _is_show=value;}
			get{return _is_show;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int grade
		{
			set{ _grade=value;}
			get{return _grade;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int filter_attr
		{
			set{ _filter_attr=value;}
			get{return _filter_attr;}
		}
		#endregion Model

	}
}

