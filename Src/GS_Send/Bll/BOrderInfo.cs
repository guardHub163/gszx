using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CZZD.GSZX.S.IDAL;
using CZZD.GSZX.S.Model;

namespace CZZD.GSZX.S.Bll
{
    public class BOrderInfo
    {
        private IOrderInfo dal = DALFactory.DataAccess.CreateOrderInfoManage();

        public BOrderInfo()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(decimal orderId, int orderType)
        {
            return dal.Exists(orderId, orderType);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BllOrderInfoTable model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(BllOrderInfoTable model)
        {
            return dal.Update(model);
        }
        #endregion  Method

    }//end class
}
