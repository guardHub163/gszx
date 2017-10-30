using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CZZD.GSZX.S.IDAL;
using System.Data;
using CZZD.GSZX.S.DBUtility;
using System.Data.SqlClient;
using CZZD.GSZX.S.Model;
using CZZD.GSZX.S.Common;

namespace CZZD.GSZX.S.SQLServerDAL
{
    public class SendOrderStatusManage : ISendOrderStatus
    {

        #region ISendOrderStatus 成员

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(decimal orderId, int statusType)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update BLL_SEND_ORDER_STATUS set ");
            strSql.Append(" SEND_STATUS=@SEND_STATUS");
            strSql.Append(" where ORDER_ID=@ORDER_ID AND STATUS_TYPE=@STATUS_TYPE");
            SqlParameter[] parameters = {
					new SqlParameter("@ORDER_ID", SqlDbType.Decimal,5),
					new SqlParameter("@STATUS_TYPE", SqlDbType.Int,4),
					new SqlParameter("@SEND_STATUS", SqlDbType.Int,4)};
            parameters[1].Value = orderId;
            parameters[2].Value = statusType;
            parameters[3].Value = CConstant.ORDER_SEND;

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

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BllSendOrderStatusTable GetModelByOrderId(decimal orderId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 from BLL_SEND_ORDER_STATUS ");
            strSql.Append(" where ORDER_ID=@ORDER_ID");
            strSql.Append(" and SEND_STATUS=@SEND_STATUS");
            strSql.Append(" order by ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ORDER_ID", SqlDbType.Int,4),
                    new SqlParameter("@SEND_STATUS", SqlDbType.Int,4)};
            parameters[0].Value = orderId;
            parameters[1].Value = CConstant.ORDER_UNSEND;

            BllSendOrderStatusTable model = new BllSendOrderStatusTable();
            DataSet ds = DbHelperSqlServer.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ORDER_ID"].ToString() != "")
                {
                    model.ORDER_ID = decimal.Parse(ds.Tables[0].Rows[0]["ORDER_ID"].ToString());
                }
                model.ORDER_SN = ds.Tables[0].Rows[0]["ORDER_SN"].ToString();
                if (ds.Tables[0].Rows[0]["STATUS_TYPE"].ToString() != "")
                {
                    model.STATUS_TYPE = int.Parse(ds.Tables[0].Rows[0]["STATUS_TYPE"].ToString());
                }
                if (ds.Tables[0].Rows[0]["STATUS_FLAG"].ToString() != "")
                {
                    model.STATUS_FLAG = int.Parse(ds.Tables[0].Rows[0]["STATUS_FLAG"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SEND_STATUS"].ToString() != "")
                {
                    model.SEND_STATUS = int.Parse(ds.Tables[0].Rows[0]["SEND_STATUS"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CREATE_DATE_TIME"].ToString() != "")
                {
                    model.CREATE_DATE_TIME = DateTime.Parse(ds.Tables[0].Rows[0]["CREATE_DATE_TIME"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DataSet GetDataList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select *  FROM BLL_SEND_ORDER_STATUS ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSqlServer.Query(strSql.ToString());
        }

        #endregion
    }//end class
}
