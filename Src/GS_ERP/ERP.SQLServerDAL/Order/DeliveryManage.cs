using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.DBUtility;
using CZZD.ERP.Model;
using System.Data.SqlClient;
using CZZD.ERP.IDAL;
using CZZD.ERP.CacheData;
using System.Data;
using CZZD.ERP.Common;

namespace CZZD.ERP.SQLServerDAL
{
    public class DeliveryManage : IDelivery
    {
        public DeliveryManage()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BaseDeliveryTable model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BLL_DELIVERY(");
            strSql.Append("DELIVERY_CODE,ORDER_ID,CONSIGNEE,COMMUNITY_CODE,STATUS_FLAG)");
            strSql.Append(" values (");
            strSql.Append("@DELIVERY_CODE,@ORDER_ID,@CONSIGNEE,@COMMUNITY_CODE,@STATUS_FLAG)");
            SqlParameter[] parameters = {
					new SqlParameter("@DELIVERY_CODE", SqlDbType.VarChar,50),
					new SqlParameter("@ORDER_ID", SqlDbType.Decimal,5),
					new SqlParameter("@CONSIGNEE", SqlDbType.VarChar,50),
					new SqlParameter("@COMMUNITY_CODE", SqlDbType.Int,4),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4)};
            parameters[0].Value = model.DELIVERY_CODE;
            parameters[1].Value = model.ORDER_ID;
            parameters[2].Value = model.CONSIGNEE;
            parameters[3].Value = model.COMMUNITY_CODE;
            parameters[4].Value = model.STATUS_FLAG;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        public DataSet GetDeliveryTable(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("SELECT * FROM BLL_DELIVERY WHERE {0}", strWhere);
            return DbHelperSQL.Query(strSql.ToString());
        }

        public bool Update(string SlipNumber,BaseSendOrderStatusTable sendTable)
        {
            List<CommandInfo> listSql = new List<CommandInfo>();
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("UPDATE BLL_DELIVERY SET STATUS_FLAG=@STATUS_FLAG WHERE ORDER_ID=@ORDER_ID");
            SqlParameter[] Parameters = {
                    new SqlParameter("@STATUS_FLAG",SqlDbType.Int),
                    new SqlParameter("@ORDER_ID",SqlDbType.Decimal)
                                        };
            Parameters[0].Value = CConstant.LIBRARY_INT;
            Parameters[1].Value = CConvert.ToDecimal(SlipNumber);
            listSql.Add(new CommandInfo(strSql.ToString(), Parameters));

            strSql = new StringBuilder();
            strSql.Append("insert into BLL_SEND_ORDER_STATUS(");
            strSql.Append("ORDER_ID,ORDER_SN,ORDER_STATUS,SEND_STATUS,CREATE_DATE_TIME)");
            strSql.Append(" values (");
            strSql.Append("@ORDER_ID,@ORDER_SN,@ORDER_STATUS,@SEND_STATUS,@CREATE_DATE_TIME)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parametersSend = {
					new SqlParameter("@ORDER_ID", SqlDbType.Decimal,5),
					new SqlParameter("@ORDER_SN", SqlDbType.VarChar,20),
					new SqlParameter("@ORDER_STATUS", SqlDbType.Int,4),
					new SqlParameter("@SEND_STATUS", SqlDbType.Int,4),
					new SqlParameter("@CREATE_DATE_TIME", SqlDbType.DateTime)};
            parametersSend[0].Value = sendTable.ORDER_ID;
            parametersSend[1].Value = sendTable.ORDER_SN;
            parametersSend[2].Value = sendTable.ORDER_STATUS;
            parametersSend[3].Value = sendTable.SEND_STATUS;
            parametersSend[4].Value = sendTable.CREATE_DATE_TIME;
            listSql.Add(new CommandInfo(strSql.ToString(), parametersSend));

            int result =  DbHelperSQL.ExecuteSqlTran(listSql);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion  Method
    }
}
