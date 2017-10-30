using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.Model
{
   public class BaseRegionTable
    {
       public BaseRegionTable()
		{}
		#region Model
		private int _region_id;
		private int? _parent_id;
		private string _region_name;
		private int? _region_type;
		private int? _agency_id;
		/// <summary>
		/// 表示该地区的id'
		/// </summary>
		public int REGION_ID
		{
			set{ _region_id=value;}
			get{return _region_id;}
		}
		/// <summary>
		/// 该地区的上一个节点的地区id
		/// </summary>
		public int? PARENT_ID
		{
			set{ _parent_id=value;}
			get{return _parent_id;}
		}
		/// <summary>
		/// 地区的名字
		/// </summary>
		public string REGION_NAME
		{
			set{ _region_name=value;}
			get{return _region_name;}
		}
		/// <summary>
		/// 该地区的下一个节点的地区
		/// </summary>
		public int? REGION_TYPE
		{
			set{ _region_type=value;}
			get{return _region_type;}
		}
		/// <summary>
		/// 办事处的id,这里有一个bug,同一个省不能有多个办事处,该字段只记录最新的那个办事处的id
		/// </summary>
		public int? AGENCY_ID
		{
			set{ _agency_id=value;}
			get{return _agency_id;}
		}
		#endregion Model

    }
}
