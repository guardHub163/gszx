using System;
namespace CZZD.GSZX.Model
{
	/// <summary>
	/// ecs_area_region:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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

