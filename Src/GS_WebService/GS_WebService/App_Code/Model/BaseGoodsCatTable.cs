using System;
namespace CZZD.GSZX.Model
{
	/// <summary>
	/// ecs_goods_cat:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class BaseGoodsCatTable
	{
		public BaseGoodsCatTable()
		{}
		#region Model
		private decimal _goods_id=0;
		private int _cat_id=0;
		/// <summary>
		/// 
		/// </summary>
		public decimal goods_id
		{
			set{ _goods_id=value;}
			get{return _goods_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int cat_id
		{
			set{ _cat_id=value;}
			get{return _cat_id;}
		}
		#endregion Model

	}
}

