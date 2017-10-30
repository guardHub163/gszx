using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CZZD.GSZX.S.IDAL;
using CZZD.GSZX.S.DALFactory;
using System.Data;

namespace CZZD.GSZX.S.Bll
{
    public class BSendOrder
    {
        private ISendOrder dal = DataAccess.CreateSendOrderManage();

        public BSendOrder()
        { }

        /// <summary>
        /// 出库送信数据的获得
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetSendOrderData(string strWhere) 
        {
            return dal.GetSendOrderData(strWhere);
        }

        /// <summary>
        /// 出库送信状态的更新
        /// </summary>
        /// <param name="orderID"></param>
        /// <param name="sendStatus"></param>
        /// <returns></returns>
        public bool UpdateSendStatus(string orderID, int sendStatus) 
        {
            return dal.UpdateSendStatus(orderID, sendStatus);
        }
    }//end class
}
