using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.Model;
using System.Data.SqlClient;
using CZZD.ERP.IDAL;
using System.Data;

namespace CZZD.ERP.IDAL
{
    public interface IOrderInfo
    {
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        string Add(BaseOrderInfoTable model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Update(BaseOrderInfoTable model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(int ORDER_ID, int ORDER_TYPE);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        BaseOrderInfoTable GetModel(decimal ORDER_ID, int ORDER_TYPE);

        BaseOrderInfoTable GetOrderSnModel(decimal ORDER_SN, int ORDER_TYPE);

        DataSet GetAreaInfo();

        string GetMaxCode();

        int GetRecordCount(string strWhere);

        DataSet GetList(string strWhere, string orderby, int startIndex, int endIndex);

        int DeleteOrderInfo(int ORDER_ID, int ORDER_TYPE);

        int UpdatePrintStatus(int ORDER_ID, int ORDER_TYPE);

        int LibraryDeter(BaseOrderInfoTable orderInfotable, BaseSendOrderTable sendTable);

        string GetMaxQuCode(string COMMUNITY);

        DataSet GetOrderTable(string strWhre);

        string GetMaxOrderSn();

        int AddDeliveryInfo(BaseOrderInfoTable model, BaseDeliveryTable deTable, BaseSendOrderStatusTable sendTable);

        string GetMaxDeliveryCode();
        #endregion  成员方法
    }
}
