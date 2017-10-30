using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CZZD.GSZX.S.IDAL;
using System.Data;
using System.Data.SqlClient;
using CZZD.GSZX.S.DBUtility;
using CZZD.GSZX.S.Model;

namespace CZZD.GSZX.S.SQLServerDAL
{
    public class CustomerAddressManage : ICustomerAddress
    {
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(decimal addressId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_CUSTOMER_ADDRESS");
            strSql.Append(" where ADDRESS_ID=@ADDRESS_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ADDRESS_ID", SqlDbType.Decimal)};
            parameters[0].Value = addressId;

            return DbHelperSqlServer.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BaseCustomerAddressTable model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BASE_CUSTOMER_ADDRESS(");
            strSql.Append("ADDRESS_ID,ADDRESS_NAME,USER_ID,CONSIGNEE,EMAIL,COUNTRY,PROVINCE,CITY,DISTRICT,ADDRESS,ZIPCODE,TEL,MOBILE,SIGN_BUILDING,BEST_TIME)");
            strSql.Append(" values (");
            strSql.Append("@ADDRESS_ID,@ADDRESS_NAME,@USER_ID,@CONSIGNEE,@EMAIL,@COUNTRY,@PROVINCE,@CITY,@DISTRICT,@ADDRESS,@ZIPCODE,@TEL,@MOBILE,@SIGN_BUILDING,@BEST_TIME)");
            SqlParameter[] parameters = {
					new SqlParameter("@ADDRESS_ID", SqlDbType.Decimal,5),
					new SqlParameter("@ADDRESS_NAME", SqlDbType.VarChar,50),
					new SqlParameter("@USER_ID", SqlDbType.Decimal,5),
					new SqlParameter("@CONSIGNEE", SqlDbType.VarChar,60),
					new SqlParameter("@EMAIL", SqlDbType.VarChar,60),
					new SqlParameter("@COUNTRY", SqlDbType.SmallInt,2),
					new SqlParameter("@PROVINCE", SqlDbType.SmallInt,2),
					new SqlParameter("@CITY", SqlDbType.SmallInt,2),
					new SqlParameter("@DISTRICT", SqlDbType.SmallInt,2),
					new SqlParameter("@ADDRESS", SqlDbType.VarChar,120),
					new SqlParameter("@ZIPCODE", SqlDbType.VarChar,60),
					new SqlParameter("@TEL", SqlDbType.VarChar,60),
					new SqlParameter("@MOBILE", SqlDbType.VarChar,60),
					new SqlParameter("@SIGN_BUILDING", SqlDbType.VarChar,120),
					new SqlParameter("@BEST_TIME", SqlDbType.VarChar,120)};
            parameters[0].Value = model.ADDRESS_ID;
            parameters[1].Value = model.ADDRESS_NAME;
            parameters[2].Value = model.USER_ID;
            parameters[3].Value = model.CONSIGNEE;
            parameters[4].Value = model.EMAIL;
            parameters[5].Value = model.COUNTRY;
            parameters[6].Value = model.PROVINCE;
            parameters[7].Value = model.CITY;
            parameters[8].Value = model.DISTRICT;
            parameters[9].Value = model.ADDRESS;
            parameters[10].Value = model.ZIPCODE;
            parameters[11].Value = model.TEL;
            parameters[12].Value = model.MOBILE;
            parameters[13].Value = model.SIGN_BUILDING;
            parameters[14].Value = model.BEST_TIME;

            return DbHelperSqlServer.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(BaseCustomerAddressTable model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BASE_CUSTOMER_ADDRESS set ");
            strSql.Append("ADDRESS_NAME=@ADDRESS_NAME,");
            strSql.Append("USER_ID=@USER_ID,");
            strSql.Append("CONSIGNEE=@CONSIGNEE,");
            strSql.Append("EMAIL=@EMAIL,");
            strSql.Append("COUNTRY=@COUNTRY,");
            strSql.Append("PROVINCE=@PROVINCE,");
            strSql.Append("CITY=@CITY,");
            strSql.Append("DISTRICT=@DISTRICT,");
            strSql.Append("ADDRESS=@ADDRESS,");
            strSql.Append("ZIPCODE=@ZIPCODE,");
            strSql.Append("TEL=@TEL,");
            strSql.Append("MOBILE=@MOBILE,");
            strSql.Append("SIGN_BUILDING=@SIGN_BUILDING,");
            strSql.Append("BEST_TIME=@BEST_TIME");
            strSql.Append(" where ADDRESS_ID=@ADDRESS_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ADDRESS_ID", SqlDbType.Decimal,5),
					new SqlParameter("@ADDRESS_NAME", SqlDbType.VarChar,50),
					new SqlParameter("@USER_ID", SqlDbType.Decimal,5),
					new SqlParameter("@CONSIGNEE", SqlDbType.VarChar,60),
					new SqlParameter("@EMAIL", SqlDbType.VarChar,60),
					new SqlParameter("@COUNTRY", SqlDbType.SmallInt,2),
					new SqlParameter("@PROVINCE", SqlDbType.SmallInt,2),
					new SqlParameter("@CITY", SqlDbType.SmallInt,2),
					new SqlParameter("@DISTRICT", SqlDbType.SmallInt,2),
					new SqlParameter("@ADDRESS", SqlDbType.VarChar,120),
					new SqlParameter("@ZIPCODE", SqlDbType.VarChar,60),
					new SqlParameter("@TEL", SqlDbType.VarChar,60),
					new SqlParameter("@MOBILE", SqlDbType.VarChar,60),
					new SqlParameter("@SIGN_BUILDING", SqlDbType.VarChar,120),
					new SqlParameter("@BEST_TIME", SqlDbType.VarChar,120)};
            parameters[0].Value = model.ADDRESS_ID;
            parameters[1].Value = model.ADDRESS_NAME;
            parameters[2].Value = model.USER_ID;
            parameters[3].Value = model.CONSIGNEE;
            parameters[4].Value = model.EMAIL;
            parameters[5].Value = model.COUNTRY;
            parameters[6].Value = model.PROVINCE;
            parameters[7].Value = model.CITY;
            parameters[8].Value = model.DISTRICT;
            parameters[9].Value = model.ADDRESS;
            parameters[10].Value = model.ZIPCODE;
            parameters[11].Value = model.TEL;
            parameters[12].Value = model.MOBILE;
            parameters[13].Value = model.SIGN_BUILDING;
            parameters[14].Value = model.BEST_TIME;

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

        #endregion  Method
    }
}
