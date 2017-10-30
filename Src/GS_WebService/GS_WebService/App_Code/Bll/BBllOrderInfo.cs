using System;
using System.Data;
using System.Collections.Generic;
using CZZD.GSZX.Common;
using CZZD.GSZX.Model;
using CZZD.GSZX.DAL;
namespace CZZD.GSZX.BLL
{
    /// <summary>
    /// ecs_order_info
    /// </summary>
    public class BBllOrderInfo
    {
        private readonly BllOrderInfoManage dal = new BllOrderInfoManage();
        public BBllOrderInfo()
        { }

        #region  送信
        /// <summary>
        /// 订单信息的取得　--　根据查询条件返回查询到的订单编号/订单编号的统计数量
        /// </summary>
        public DataSet GetOrderIds(string type, string startTime, string endTime, string sendStatus, string strWhere)
        {
            return dal.GetOrderIds(type, startTime, endTime, sendStatus, strWhere);
        }

        /// <summary>
        /// 订单信息的取得　--　根据订单编号返回一个/多个订单的所有信息
        /// </summary>
        public DataSet GetOrders(string type, string orderID)
        {
            return dal.GetOrders(type, orderID);
        }

        /// <summary>
        /// 订单信息的取得　--　根据查询条件返回查询到的订单数据
        /// </summary>
        public DataSet SelectOrders(string type, string startTime, string endTime, string sendStatus, string strWhere)
        {
            return dal.SelectOrders(type, startTime, endTime, sendStatus, strWhere);
        }
        #endregion

        #region 收信
        /// <summary>
        /// 订单送信状态[订单确认]/结束[订单结束]的回写
        /// </summary>
        public DataSet ReceiveOrderStatus(string type, string orderIDs)
        {
            return dal.ReceiveOrderStatus(type, orderIDs);
        }

        /// <summary>
        /// 单张订单实际金额，实际重量及账户余额的更新
        /// </summary>
        public string ReceiveOrderInfo(BllSendOrderTable sendOrderTable)
        {
            return dal.ReceiveOrderInfo(sendOrderTable);
        }
        #endregion





        
    }//end class
}

