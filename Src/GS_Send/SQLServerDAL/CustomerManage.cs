using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CZZD.GSZX.S.IDAL;
using CZZD.GSZX.S.DBUtility;
using CZZD.GSZX.S.Model;
using System.Data.SqlClient;
using System.Data;

namespace CZZD.GSZX.S.SQLServerDAL
{
    public class CustomerManage : ICustomer
    {
        #region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal USER_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BASE_CUSTOMER");
			strSql.Append(" where USER_ID=@USER_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@USER_ID", SqlDbType.Decimal)};
			parameters[0].Value = USER_ID;

			return DbHelperSqlServer.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(BaseCustomerTable model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BASE_CUSTOMER(");
			strSql.Append("USER_ID,EMAIL,USER_NAME,PASSWORD,QUESTION,ANSWER,SEX,BIRTHDAY,USER_MONEY,FROZEN_MONEY,PAY_POINTS,RANK_POINTS,ADDRESS_ID,REG_TIME,LAST_LOGIN,LAST_TIME,LAST_IP,VISIT_COUNT,USER_RANK,IS_SPECIAL,SALT,PARENT_ID,FLAG,ALIAS,MSN,QQ,OFFICE_PHONE,HOME_PHONE,MOBILE_PHONE,IS_VALIDATED,CREDIT_LINE)");
			strSql.Append(" values (");
			strSql.Append("@USER_ID,@EMAIL,@USER_NAME,@PASSWORD,@QUESTION,@ANSWER,@SEX,@BIRTHDAY,@USER_MONEY,@FROZEN_MONEY,@PAY_POINTS,@RANK_POINTS,@ADDRESS_ID,@REG_TIME,@LAST_LOGIN,@LAST_TIME,@LAST_IP,@VISIT_COUNT,@USER_RANK,@IS_SPECIAL,@SALT,@PARENT_ID,@FLAG,@ALIAS,@MSN,@QQ,@OFFICE_PHONE,@HOME_PHONE,@MOBILE_PHONE,@IS_VALIDATED,@CREDIT_LINE)");
			SqlParameter[] parameters = {
					new SqlParameter("@USER_ID", SqlDbType.Decimal,5),
					new SqlParameter("@EMAIL", SqlDbType.VarChar,60),
					new SqlParameter("@USER_NAME", SqlDbType.VarChar,60),
					new SqlParameter("@PASSWORD", SqlDbType.VarChar,32),
					new SqlParameter("@QUESTION", SqlDbType.VarChar,255),
					new SqlParameter("@ANSWER", SqlDbType.VarChar,255),
					new SqlParameter("@SEX", SqlDbType.Int,4),
					new SqlParameter("@BIRTHDAY", SqlDbType.DateTime),
					new SqlParameter("@USER_MONEY", SqlDbType.Decimal,9),
					new SqlParameter("@FROZEN_MONEY", SqlDbType.Decimal,9),
					new SqlParameter("@PAY_POINTS", SqlDbType.Int,4),
					new SqlParameter("@RANK_POINTS", SqlDbType.Int,4),
					new SqlParameter("@ADDRESS_ID", SqlDbType.Int,4),
					new SqlParameter("@REG_TIME", SqlDbType.Int,4),
					new SqlParameter("@LAST_LOGIN", SqlDbType.Int,4),
					new SqlParameter("@LAST_TIME", SqlDbType.DateTime),
					new SqlParameter("@LAST_IP", SqlDbType.VarChar,15),
					new SqlParameter("@VISIT_COUNT", SqlDbType.SmallInt,2),
					new SqlParameter("@USER_RANK", SqlDbType.Int,4),
					new SqlParameter("@IS_SPECIAL", SqlDbType.Int,4),
					new SqlParameter("@SALT", SqlDbType.Int,4),
					new SqlParameter("@PARENT_ID", SqlDbType.Int,4),
					new SqlParameter("@FLAG", SqlDbType.Int,4),
					new SqlParameter("@ALIAS", SqlDbType.VarChar,60),
					new SqlParameter("@MSN", SqlDbType.VarChar,60),
					new SqlParameter("@QQ", SqlDbType.Int,4),
					new SqlParameter("@OFFICE_PHONE", SqlDbType.VarChar,20),
					new SqlParameter("@HOME_PHONE", SqlDbType.VarChar,20),
					new SqlParameter("@MOBILE_PHONE", SqlDbType.VarChar,20),
					new SqlParameter("@IS_VALIDATED", SqlDbType.Int,4),
					new SqlParameter("@CREDIT_LINE", SqlDbType.Decimal,9)};
			parameters[0].Value = model.USER_ID;
			parameters[1].Value = model.EMAIL;
			parameters[2].Value = model.USER_NAME;
			parameters[3].Value = model.PASSWORD;
			parameters[4].Value = model.QUESTION;
			parameters[5].Value = model.ANSWER;
			parameters[6].Value = model.SEX;
			parameters[7].Value = model.BIRTHDAY;
			parameters[8].Value = model.USER_MONEY;
			parameters[9].Value = model.FROZEN_MONEY;
			parameters[10].Value = model.PAY_POINTS;
			parameters[11].Value = model.RANK_POINTS;
			parameters[12].Value = model.ADDRESS_ID;
			parameters[13].Value = model.REG_TIME;
			parameters[14].Value = model.LAST_LOGIN;
			parameters[15].Value = model.LAST_TIME;
			parameters[16].Value = model.LAST_IP;
			parameters[17].Value = model.VISIT_COUNT;
			parameters[18].Value = model.USER_RANK;
			parameters[19].Value = model.IS_SPECIAL;
			parameters[20].Value = model.SALT;
			parameters[21].Value = model.PARENT_ID;
			parameters[22].Value = model.FLAG;
			parameters[23].Value = model.ALIAS;
			parameters[24].Value = model.MSN;
			parameters[25].Value = model.QQ;
			parameters[26].Value = model.OFFICE_PHONE;
			parameters[27].Value = model.HOME_PHONE;
			parameters[28].Value = model.MOBILE_PHONE;
			parameters[29].Value = model.IS_VALIDATED;
			parameters[30].Value = model.CREDIT_LINE;

			return DbHelperSqlServer.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(BaseCustomerTable model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BASE_CUSTOMER set ");
			strSql.Append("EMAIL=@EMAIL,");
			strSql.Append("USER_NAME=@USER_NAME,");
			strSql.Append("PASSWORD=@PASSWORD,");
			strSql.Append("QUESTION=@QUESTION,");
			strSql.Append("ANSWER=@ANSWER,");
			strSql.Append("SEX=@SEX,");
			strSql.Append("BIRTHDAY=@BIRTHDAY,");
			strSql.Append("USER_MONEY=@USER_MONEY,");
			strSql.Append("FROZEN_MONEY=@FROZEN_MONEY,");
			strSql.Append("PAY_POINTS=@PAY_POINTS,");
			strSql.Append("RANK_POINTS=@RANK_POINTS,");
			strSql.Append("ADDRESS_ID=@ADDRESS_ID,");
			strSql.Append("REG_TIME=@REG_TIME,");
			strSql.Append("LAST_LOGIN=@LAST_LOGIN,");
			strSql.Append("LAST_TIME=@LAST_TIME,");
			strSql.Append("LAST_IP=@LAST_IP,");
			strSql.Append("VISIT_COUNT=@VISIT_COUNT,");
			strSql.Append("USER_RANK=@USER_RANK,");
			strSql.Append("IS_SPECIAL=@IS_SPECIAL,");
			strSql.Append("SALT=@SALT,");
			strSql.Append("PARENT_ID=@PARENT_ID,");
			strSql.Append("FLAG=@FLAG,");
			strSql.Append("ALIAS=@ALIAS,");
			strSql.Append("MSN=@MSN,");
			strSql.Append("QQ=@QQ,");
			strSql.Append("OFFICE_PHONE=@OFFICE_PHONE,");
			strSql.Append("HOME_PHONE=@HOME_PHONE,");
			strSql.Append("MOBILE_PHONE=@MOBILE_PHONE,");
			strSql.Append("IS_VALIDATED=@IS_VALIDATED,");
			strSql.Append("CREDIT_LINE=@CREDIT_LINE");
			strSql.Append(" where USER_ID=@USER_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@USER_ID", SqlDbType.Decimal,5),
					new SqlParameter("@EMAIL", SqlDbType.VarChar,60),
					new SqlParameter("@USER_NAME", SqlDbType.VarChar,60),
					new SqlParameter("@PASSWORD", SqlDbType.VarChar,32),
					new SqlParameter("@QUESTION", SqlDbType.VarChar,255),
					new SqlParameter("@ANSWER", SqlDbType.VarChar,255),
					new SqlParameter("@SEX", SqlDbType.Int,4),
					new SqlParameter("@BIRTHDAY", SqlDbType.DateTime),
					new SqlParameter("@USER_MONEY", SqlDbType.Decimal,9),
					new SqlParameter("@FROZEN_MONEY", SqlDbType.Decimal,9),
					new SqlParameter("@PAY_POINTS", SqlDbType.Int,4),
					new SqlParameter("@RANK_POINTS", SqlDbType.Int,4),
					new SqlParameter("@ADDRESS_ID", SqlDbType.Int,4),
					new SqlParameter("@REG_TIME", SqlDbType.Int,4),
					new SqlParameter("@LAST_LOGIN", SqlDbType.Int,4),
					new SqlParameter("@LAST_TIME", SqlDbType.DateTime),
					new SqlParameter("@LAST_IP", SqlDbType.VarChar,15),
					new SqlParameter("@VISIT_COUNT", SqlDbType.SmallInt,2),
					new SqlParameter("@USER_RANK", SqlDbType.Int,4),
					new SqlParameter("@IS_SPECIAL", SqlDbType.Int,4),
					new SqlParameter("@SALT", SqlDbType.Int,4),
					new SqlParameter("@PARENT_ID", SqlDbType.Int,4),
					new SqlParameter("@FLAG", SqlDbType.Int,4),
					new SqlParameter("@ALIAS", SqlDbType.VarChar,60),
					new SqlParameter("@MSN", SqlDbType.VarChar,60),
					new SqlParameter("@QQ", SqlDbType.Int,4),
					new SqlParameter("@OFFICE_PHONE", SqlDbType.VarChar,20),
					new SqlParameter("@HOME_PHONE", SqlDbType.VarChar,20),
					new SqlParameter("@MOBILE_PHONE", SqlDbType.VarChar,20),
					new SqlParameter("@IS_VALIDATED", SqlDbType.Int,4),
					new SqlParameter("@CREDIT_LINE", SqlDbType.Decimal,9)};
			parameters[0].Value = model.USER_ID;
			parameters[1].Value = model.EMAIL;
			parameters[2].Value = model.USER_NAME;
			parameters[3].Value = model.PASSWORD;
			parameters[4].Value = model.QUESTION;
			parameters[5].Value = model.ANSWER;
			parameters[6].Value = model.SEX;
			parameters[7].Value = model.BIRTHDAY;
			parameters[8].Value = model.USER_MONEY;
			parameters[9].Value = model.FROZEN_MONEY;
			parameters[10].Value = model.PAY_POINTS;
			parameters[11].Value = model.RANK_POINTS;
			parameters[12].Value = model.ADDRESS_ID;
			parameters[13].Value = model.REG_TIME;
			parameters[14].Value = model.LAST_LOGIN;
			parameters[15].Value = model.LAST_TIME;
			parameters[16].Value = model.LAST_IP;
			parameters[17].Value = model.VISIT_COUNT;
			parameters[18].Value = model.USER_RANK;
			parameters[19].Value = model.IS_SPECIAL;
			parameters[20].Value = model.SALT;
			parameters[21].Value = model.PARENT_ID;
			parameters[22].Value = model.FLAG;
			parameters[23].Value = model.ALIAS;
			parameters[24].Value = model.MSN;
			parameters[25].Value = model.QQ;
			parameters[26].Value = model.OFFICE_PHONE;
			parameters[27].Value = model.HOME_PHONE;
			parameters[28].Value = model.MOBILE_PHONE;
			parameters[29].Value = model.IS_VALIDATED;
			parameters[30].Value = model.CREDIT_LINE;

			int rows=DbHelperSqlServer.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		#endregion  Method

	}//end class
}
