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

        #region  ����
        /// <summary>
        /// ������Ϣ��ȡ�á�--�����ݲ�ѯ�������ز�ѯ���Ķ������/������ŵ�ͳ������
        /// </summary>
        public DataSet GetOrderIds(string type, string startTime, string endTime, string sendStatus, string strWhere)
        {
            return dal.GetOrderIds(type, startTime, endTime, sendStatus, strWhere);
        }

        /// <summary>
        /// ������Ϣ��ȡ�á�--�����ݶ�����ŷ���һ��/���������������Ϣ
        /// </summary>
        public DataSet GetOrders(string type, string orderID)
        {
            return dal.GetOrders(type, orderID);
        }

        /// <summary>
        /// ������Ϣ��ȡ�á�--�����ݲ�ѯ�������ز�ѯ���Ķ�������
        /// </summary>
        public DataSet SelectOrders(string type, string startTime, string endTime, string sendStatus, string strWhere)
        {
            return dal.SelectOrders(type, startTime, endTime, sendStatus, strWhere);
        }
        #endregion

        #region ����
        /// <summary>
        /// ��������״̬[����ȷ��]/����[��������]�Ļ�д
        /// </summary>
        public DataSet ReceiveOrderStatus(string type, string orderIDs)
        {
            return dal.ReceiveOrderStatus(type, orderIDs);
        }

        /// <summary>
        /// ���Ŷ���ʵ�ʽ�ʵ���������˻����ĸ���
        /// </summary>
        public string ReceiveOrderInfo(BllSendOrderTable sendOrderTable)
        {
            return dal.ReceiveOrderInfo(sendOrderTable);
        }
        #endregion





        
    }//end class
}

