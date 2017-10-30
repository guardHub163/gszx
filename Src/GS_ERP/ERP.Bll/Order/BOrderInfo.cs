using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.Model;
using CZZD.ERP.IDAL;
using System.Data;
using CZZD.ERP.DALFactory;

namespace CZZD.ERP.Bll
{
    public class BOrderInfo
    {
        private readonly IOrderInfo dal = DALFactory.DataAccess.CreatOrderInfoManage();
        public BOrderInfo()
        { }
        #region  Method
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(BaseOrderInfoTable model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(BaseOrderInfoTable model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ORDER_ID, int ORDER_TYPE)
        {

            return dal.Delete(ORDER_ID, ORDER_TYPE);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BaseOrderInfoTable GetModel(decimal ORDER_ID, int ORDER_TYPE)
        {

            return dal.GetModel(ORDER_ID, ORDER_TYPE);
        }

        public BaseOrderInfoTable GetOrderSnModel(decimal ORDER_SN, int ORDER_TYPE)
        {

            return dal.GetOrderSnModel(ORDER_SN, ORDER_TYPE);
        }

        public string GetMaxCode()
        {
            return dal.GetMaxCode();
        }

        public DataSet GetAreaInfo()
        {
            return dal.GetAreaInfo();
        }

        /// <summary>
        /// 获得分页数据总的记录条数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }

        public string GetMaxOrderSn()
        {
            return dal.GetMaxOrderSn();
        }

        /// <summary>
        /// 获得分页数据列表
        /// </summary>
        public DataSet GetList(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetList(strWhere, orderby, startIndex, endIndex);
        }

        public int DeleteOrderInfo(int ORDER_ID, int ORDER_TYPE)
        {
            return dal.DeleteOrderInfo(ORDER_ID, ORDER_TYPE);
        }

        public int UpdatePrintStatus(int ORDER_ID, int ORDER_TYPE)
        {
            return dal.UpdatePrintStatus(ORDER_ID, ORDER_TYPE);
        }

        public int LibraryDeter(BaseOrderInfoTable orderInfotable, BaseSendOrderTable sendTable)
        {
            return dal.LibraryDeter(orderInfotable, sendTable);
        }

        public string GetMaxQuCode(string COMMUNITY)
        {
            return dal.GetMaxQuCode(COMMUNITY);
        }

        public DataSet GetOrderTable(string strWhre)
        {
            return dal.GetOrderTable(strWhre);
        }

        public int AddDeliveryInfo(BaseOrderInfoTable model, BaseDeliveryTable deTable, BaseSendOrderStatusTable sendTable)
        {
            return dal.AddDeliveryInfo(model, deTable,sendTable);
        }

        public string GetMaxDeliveryCode()
        {
            return dal.GetMaxDeliveryCode();
        }
        #endregion  Method
    }
}
