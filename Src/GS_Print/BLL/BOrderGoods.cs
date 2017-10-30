using System;
using System.Collections.Generic;
using System.Text;
using CZZD.GSZX.P.Model;
using CZZD.GSZX.P.IDAL;
using System.Data;
using CZZD.GSZX.P.DALFactory;

namespace CZZD.GSZX.P.BLL
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
        public DataSet GetGoodsInfo(int ORDER_TYPE, decimal ORDER_ID) 
        {
            return dal.GetGoodsInfo(ORDER_TYPE, ORDER_ID);
        }

        #endregion  Method
    }
}
