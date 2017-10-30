using System;
using System.Collections.Generic;
using System.Text;
using CZZD.GSZX.P.Model;
using CZZD.GSZX.P.IDAL;
using System.Data;
using CZZD.GSZX.P.DALFactory;

namespace CZZD.GSZX.P.BLL
{
    public class BOrderInfo
    {
        private readonly IOrderInfo dal =DALFactory.DataAccess.CreatOrderInfoManage();
        public BOrderInfo()
        { }
        #region  Method
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BaseOrderInfoTable GetModel(int ORDER_ID, int ORDER_TYPE)
        {

            return dal.GetModel(ORDER_ID,ORDER_TYPE);
        }

        public DataSet GetNoPrintSlipNumber() 
        {
            return dal.GetNoPrintSlipNumber();
        }


        public int UpdatePrintStatus(int ORDER_TYPE, string ORDER_SN)
        {
            return dal.UpdatePrintStatus(ORDER_TYPE, ORDER_SN);
        }
        #endregion  Method
    }
}
