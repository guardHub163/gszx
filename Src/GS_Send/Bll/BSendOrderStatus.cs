using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CZZD.GSZX.S.IDAL;
using CZZD.GSZX.S.DALFactory;
using System.Data;
using CZZD.GSZX.S.Model;

namespace CZZD.GSZX.S.Bll
{
    public class BSendOrderStatus
    {
        private ISendOrderStatus dal = DataAccess.CreateSendOrderStatusManage();

        public BSendOrderStatus()
        { }

         /// <summary>
         /// 更新一条数据
         /// </summary>
        public bool Update(decimal orderId, int statusType)
        {
            return dal.Update(orderId, statusType);
        }
         
            /// <summary>
         /// 得到一个对象实体
         /// </summary>
        public BllSendOrderStatusTable GetModelByOrderId(decimal orderId)
        {
            return dal.GetModelByOrderId(orderId);
        }

        /// <summary>
        /// 根据条件，获得数据集
        /// </summary>
        public DataSet GetDataList(string strWhere)
        {
            return dal.GetDataList(strWhere);
        }
    }//end class
}
