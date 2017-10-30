using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.Model;
using CZZD.ERP.IDAL;
using System.Data;
using CZZD.ERP.DALFactory;

namespace CZZD.ERP.Bll
{
   public class BOrderGoods
    {
        private readonly IOrderGoods dal =DALFactory.DataAccess.CreatOrdersGoodsManage();
        public BOrderGoods()
        { }

        #region  Method
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BaseOrdersGoodsTable GetModel(int ORDER_TYPE, decimal ORDER_ID)
        {

            return dal.GetModel(ORDER_TYPE, ORDER_ID);
        }

        public DataSet GetGoodsInfo(int ORDER_TYPE, decimal ORDER_ID) 
        {
            return dal.GetGoodsInfo(ORDER_TYPE, ORDER_ID);
        }

        #endregion  Method
    }
}
