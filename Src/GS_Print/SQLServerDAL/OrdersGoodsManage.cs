using System;
using System.Collections.Generic;
using System.Text;
using CZZD.GSZX.P.Model;
using System.Data.SqlClient;
using CZZD.GSZX.P.IDAL;
using System.Data;
using CZZD.GSZX.P.Common;
using CZZD.GSZX.P.DBUtility;

namespace CZZD.GSZX.P.SQLServerDAL
{
    public class OrdersGoodsManage:IOrderGoods
    {
        public OrdersGoodsManage()
		{}
		#region  Method

        public DataSet GetGoodsInfo(int ORDER_TYPE, decimal  ORDER_ID) 
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select REC_ID,ORDER_ID,GOODS_ID,GOODS_NAME,GOODS_SN,GOODS_NUMBER,MARKET_PRICE,GOODS_PRICE,GOODS_ATTR,SEND_NUMBER,IS_REAL,EXTENSION_CODE,PARENT_ID,IS_GIFT,ORDER_TYPE,ACTUAL_AMOUNT,ACTUAL_NUMBER from BLL_ORDER_GOODS ");
            strSql.Append(" where  ORDER_TYPE=@ORDER_TYPE and ORDER_ID=@ORDER_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ORDER_TYPE", SqlDbType.Int,4),
					new SqlParameter("@ORDER_ID", SqlDbType.Int,4)};
            parameters[0].Value = ORDER_TYPE;
            parameters[1].Value = ORDER_ID;
           return DbHelperSQL.Query(strSql.ToString(), parameters);
        }
		#endregion  Method
    }
}
