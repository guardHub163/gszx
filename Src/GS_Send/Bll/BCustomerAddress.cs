using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CZZD.GSZX.S.IDAL;
using CZZD.GSZX.S.DALFactory;
using CZZD.GSZX.S.Model;

namespace CZZD.GSZX.S.Bll
{
    public class BCustomerAddress
    {
         private ICustomerAddress dal = DataAccess.CreateCustomerAddressManage();

         public BCustomerAddress()
        { }

		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal addressId)
		{
			return dal.Exists(addressId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(BaseCustomerAddressTable model)
		{
            return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(BaseCustomerAddressTable model)
		{
			return dal.Update(model);
		}

		#endregion  Method
    }
}
