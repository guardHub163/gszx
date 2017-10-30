using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CZZD.GSZX.S.IDAL;
using System.Data;
using CZZD.GSZX.S.DBUtility;
using System.Data.SqlClient;

namespace CZZD.GSZX.S.SQLServerDAL
{
    public class SendOrderManage : ISendOrder
    {

        #region ISendOrder 成员

        /// <summary>
        /// 出库送信数据的获得
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetSendOrderData(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("  SELECT O.ORDER_ID ,O.ORDER_SN ,O.GOODS_AMOUNT,O.ACTUAL_GOODS_AMOUNT, O.SEND_STATUS, O.CREATE_DATE_TIME,O.COMMUNITY_CODE ");
            strSql.Append("   , OL.REC_ID, OL.GOODS_ID, OL.GOODS_SN, OL.ACTUAL_NUMBER, OL.GOODS_PRICE, OL.ACTUAL_AMOUNT ");
            strSql.Append("  FROM BLL_SEND_ORDER AS O ");
            strSql.Append("  LEFT JOIN BLL_SEND_ORDER_LINE AS OL ON O.ORDER_ID = OL.ORDER_ID ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql.AppendFormat("where {0}", strWhere);
            }
            return DbHelperSqlServer.Query(strSql.ToString());
        }


        /// <summary>
        /// 出库送信状态的更新
        /// </summary>
        /// <param name="orderID"></param>
        /// <param name="sendStatus"></param>
        /// <returns></returns>
        public bool UpdateSendStatus(string orderID, int sendStatus)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BLL_SEND_ORDER set ");
            strSql.Append("SEND_STATUS=@SEND_STATUS");
            strSql.Append(" where ORDER_ID=@ORDER_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ORDER_ID", SqlDbType.Decimal,5),					
					new SqlParameter("@SEND_STATUS", SqlDbType.Int,4)};
            parameters[0].Value = orderID;
            parameters[1].Value = sendStatus;


            int rows = DbHelperSqlServer.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
    }//end class
}
