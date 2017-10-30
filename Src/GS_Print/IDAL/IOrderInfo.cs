using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using CZZD.GSZX.P.IDAL;
using System.Data;
using CZZD.GSZX.P.Model;

namespace CZZD.GSZX.P.IDAL
{
    public interface IOrderInfo
    {
        #region  成员方法
       /// <summary>
        /// 得到一个对象实体
        /// </summary>
        BaseOrderInfoTable GetModel(int ORDER_ID, int ORDER_TYPE);

        DataSet GetNoPrintSlipNumber();

        int UpdatePrintStatus(int ORDER_TYPE, string ORDER_SN);
        #endregion  成员方法
    }
}
