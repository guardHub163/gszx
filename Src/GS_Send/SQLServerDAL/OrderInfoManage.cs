using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CZZD.GSZX.S.IDAL;
using CZZD.GSZX.S.DBUtility;
using System.Data;
using System.Data.SqlClient;
using CZZD.GSZX.S.Model;

namespace CZZD.GSZX.S.SQLServerDAL
{
    public class OrderInfoManage : IOrderInfo
    {
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(decimal orderId, int orderType)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BLL_ORDER_INFO");
            strSql.Append(" where ORDER_ID=@ORDER_ID and ORDER_TYPE=@ORDER_TYPE ");
            SqlParameter[] parameters = {
					new SqlParameter("@ORDER_ID", SqlDbType.Decimal),
					new SqlParameter("@ORDER_TYPE", SqlDbType.Int,4)};
            parameters[0].Value = orderId;
            parameters[1].Value = orderType;

            return DbHelperSqlServer.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BllOrderInfoTable model)
        {
            List<CommandInfo> sqlList = new List<CommandInfo>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BLL_ORDER_INFO(");
            strSql.Append("ORDER_ID,ORDER_SN,USER_ID,ORDER_STATUS,SHIPPING_STATUS,PAY_STATUS,CONSIGNEE,COUNTRY,PROVINCE,CITY,DISTRICT,ADDRESS,ZIPCODE,TEL,MOBILE,EMAIL,BEST_TIME,SIGN_BUILDING,POST_SCRIPT,SHIPPING_ID,SHIPPING_NAME,PAY_ID,PAY_NAME,HOW_OOS,HOW_SURPLUS,PACK_NAME,CARD_NAME,CARD_MESSAGE,INV_PAYEE,INV_CONTENT,GOODS_AMOUNT,SHIPPING_FEE,INSURE_FEE,PAY_FEE,PACK_FEE,CARD_FEE,MONEY_PAID,SURPLUS,INTEGRAL,INTEGRALl_MONEY,BONUS,ORDER_AMOUNT,FROM_AD,REFERER,ADD_TIME,CONFIRM_TIME,PAY_TIME,SHIPPING_TIME,PACK_ID,CARD_ID,BONUS_ID,INVOICE_NO,EXTENSION_CODE,EXTENSION_ID,TO_BUYER,PAY_NOTE,AGENCY_ID,INV_TYPE,TAX,IS_SEPARATE,PARENT_ID,DISCOUNT,ORDER_TYPE,ACTUAL_AMOUNT,PRINT_STATUS)");
            strSql.Append(" values (");
            strSql.Append("@ORDER_ID,@ORDER_SN,@USER_ID,@ORDER_STATUS,@SHIPPING_STATUS,@PAY_STATUS,@CONSIGNEE,@COUNTRY,@PROVINCE,@CITY,@DISTRICT,@ADDRESS,@ZIPCODE,@TEL,@MOBILE,@EMAIL,@BEST_TIME,@SIGN_BUILDING,@POST_SCRIPT,@SHIPPING_ID,@SHIPPING_NAME,@PAY_ID,@PAY_NAME,@HOW_OOS,@HOW_SURPLUS,@PACK_NAME,@CARD_NAME,@CARD_MESSAGE,@INV_PAYEE,@INV_CONTENT,@GOODS_AMOUNT,@SHIPPING_FEE,@INSURE_FEE,@PAY_FEE,@PACK_FEE,@CARD_FEE,@MONEY_PAID,@SURPLUS,@INTEGRAL,@INTEGRALl_MONEY,@BONUS,@ORDER_AMOUNT,@FROM_AD,@REFERER,@ADD_TIME,@CONFIRM_TIME,@PAY_TIME,@SHIPPING_TIME,@PACK_ID,@CARD_ID,@BONUS_ID,@INVOICE_NO,@EXTENSION_CODE,@EXTENSION_ID,@TO_BUYER,@PAY_NOTE,@AGENCY_ID,@INV_TYPE,@TAX,@IS_SEPARATE,@PARENT_ID,@DISCOUNT,@ORDER_TYPE,@ACTUAL_AMOUNT,@PRINT_STATUS)");
            SqlParameter[] parameters = {
					new SqlParameter("@ORDER_ID", SqlDbType.Decimal,5),
					new SqlParameter("@ORDER_SN", SqlDbType.VarChar,20),
					new SqlParameter("@USER_ID", SqlDbType.Int,4),
					new SqlParameter("@ORDER_STATUS", SqlDbType.Int,4),
					new SqlParameter("@SHIPPING_STATUS", SqlDbType.Int,4),
					new SqlParameter("@PAY_STATUS", SqlDbType.Int,4),
					new SqlParameter("@CONSIGNEE", SqlDbType.VarChar,60),
					new SqlParameter("@COUNTRY", SqlDbType.VarChar,60),
					new SqlParameter("@PROVINCE", SqlDbType.VarChar,60),
					new SqlParameter("@CITY", SqlDbType.VarChar,60),
					new SqlParameter("@DISTRICT", SqlDbType.VarChar,60),
					new SqlParameter("@ADDRESS", SqlDbType.VarChar,255),
					new SqlParameter("@ZIPCODE", SqlDbType.VarChar,60),
					new SqlParameter("@TEL", SqlDbType.VarChar,60),
					new SqlParameter("@MOBILE", SqlDbType.VarChar,60),
					new SqlParameter("@EMAIL", SqlDbType.NChar,10),
					new SqlParameter("@BEST_TIME", SqlDbType.Int,4),
					new SqlParameter("@SIGN_BUILDING", SqlDbType.VarChar,120),
					new SqlParameter("@POST_SCRIPT", SqlDbType.VarChar,255),
					new SqlParameter("@SHIPPING_ID", SqlDbType.Int,4),
					new SqlParameter("@SHIPPING_NAME", SqlDbType.VarChar,120),
					new SqlParameter("@PAY_ID", SqlDbType.Int,4),
					new SqlParameter("@PAY_NAME", SqlDbType.VarChar,120),
					new SqlParameter("@HOW_OOS", SqlDbType.VarChar,120),
					new SqlParameter("@HOW_SURPLUS", SqlDbType.VarChar,120),
					new SqlParameter("@PACK_NAME", SqlDbType.VarChar,120),
					new SqlParameter("@CARD_NAME", SqlDbType.VarChar,120),
					new SqlParameter("@CARD_MESSAGE", SqlDbType.VarChar,255),
					new SqlParameter("@INV_PAYEE", SqlDbType.VarChar,120),
					new SqlParameter("@INV_CONTENT", SqlDbType.VarChar,120),
					new SqlParameter("@GOODS_AMOUNT", SqlDbType.Decimal,9),
					new SqlParameter("@SHIPPING_FEE", SqlDbType.Decimal,9),
					new SqlParameter("@INSURE_FEE", SqlDbType.Decimal,9),
					new SqlParameter("@PAY_FEE", SqlDbType.Decimal,9),
					new SqlParameter("@PACK_FEE", SqlDbType.Decimal,9),
					new SqlParameter("@CARD_FEE", SqlDbType.Decimal,9),
					new SqlParameter("@MONEY_PAID", SqlDbType.Decimal,9),
					new SqlParameter("@SURPLUS", SqlDbType.Decimal,9),
					new SqlParameter("@INTEGRAL", SqlDbType.Int,4),
					new SqlParameter("@INTEGRALl_MONEY", SqlDbType.Decimal,9),
					new SqlParameter("@BONUS", SqlDbType.Decimal,9),
					new SqlParameter("@ORDER_AMOUNT", SqlDbType.Decimal,9),
					new SqlParameter("@FROM_AD", SqlDbType.SmallInt,2),
					new SqlParameter("@REFERER", SqlDbType.VarChar,255),
					new SqlParameter("@ADD_TIME", SqlDbType.DateTime),
					new SqlParameter("@CONFIRM_TIME", SqlDbType.DateTime),
					new SqlParameter("@PAY_TIME", SqlDbType.DateTime),
					new SqlParameter("@SHIPPING_TIME", SqlDbType.DateTime),
					new SqlParameter("@PACK_ID", SqlDbType.Int,4),
					new SqlParameter("@CARD_ID", SqlDbType.Int,4),
					new SqlParameter("@BONUS_ID", SqlDbType.SmallInt,2),
					new SqlParameter("@INVOICE_NO", SqlDbType.VarChar,50),
					new SqlParameter("@EXTENSION_CODE", SqlDbType.VarChar,30),
					new SqlParameter("@EXTENSION_ID", SqlDbType.Int,4),
					new SqlParameter("@TO_BUYER", SqlDbType.VarChar,255),
					new SqlParameter("@PAY_NOTE", SqlDbType.VarChar,255),
					new SqlParameter("@AGENCY_ID", SqlDbType.SmallInt,2),
					new SqlParameter("@INV_TYPE", SqlDbType.VarChar,60),
					new SqlParameter("@TAX", SqlDbType.Decimal,9),
					new SqlParameter("@IS_SEPARATE", SqlDbType.Int,4),
					new SqlParameter("@PARENT_ID", SqlDbType.NChar,10),
					new SqlParameter("@DISCOUNT", SqlDbType.Decimal,9),
					new SqlParameter("@ORDER_TYPE", SqlDbType.Int,4),
					new SqlParameter("@ACTUAL_AMOUNT", SqlDbType.Decimal,9),
					new SqlParameter("@PRINT_STATUS", SqlDbType.Int,4)};
            parameters[0].Value = model.ORDER_ID;
            parameters[1].Value = model.ORDER_SN;
            parameters[2].Value = model.USER_ID;
            parameters[3].Value = model.ORDER_STATUS;
            parameters[4].Value = model.SHIPPING_STATUS;
            parameters[5].Value = model.PAY_STATUS;
            parameters[6].Value = model.CONSIGNEE;
            parameters[7].Value = model.COUNTRY;
            parameters[8].Value = model.PROVINCE;
            parameters[9].Value = model.CITY;
            parameters[10].Value = model.DISTRICT;
            parameters[11].Value = model.ADDRESS;
            parameters[12].Value = model.ZIPCODE;
            parameters[13].Value = model.TEL;
            parameters[14].Value = model.MOBILE;
            parameters[15].Value = model.EMAIL;
            parameters[16].Value = model.BEST_TIME;
            parameters[17].Value = model.SIGN_BUILDING;
            parameters[18].Value = model.POST_SCRIPT;
            parameters[19].Value = model.SHIPPING_ID;
            parameters[20].Value = model.SHIPPING_NAME;
            parameters[21].Value = model.PAY_ID;
            parameters[22].Value = model.PAY_NAME;
            parameters[23].Value = model.HOW_OOS;
            parameters[24].Value = model.HOW_SURPLUS;
            parameters[25].Value = model.PACK_NAME;
            parameters[26].Value = model.CARD_NAME;
            parameters[27].Value = model.CARD_MESSAGE;
            parameters[28].Value = model.INV_PAYEE;
            parameters[29].Value = model.INV_CONTENT;
            parameters[30].Value = model.GOODS_AMOUNT;
            parameters[31].Value = model.SHIPPING_FEE;
            parameters[32].Value = model.INSURE_FEE;
            parameters[33].Value = model.PAY_FEE;
            parameters[34].Value = model.PACK_FEE;
            parameters[35].Value = model.CARD_FEE;
            parameters[36].Value = model.MONEY_PAID;
            parameters[37].Value = model.SURPLUS;
            parameters[38].Value = model.INTEGRAL;
            parameters[39].Value = model.INTEGRALl_MONEY;
            parameters[40].Value = model.BONUS;
            parameters[41].Value = model.ORDER_AMOUNT;
            parameters[42].Value = model.FROM_AD;
            parameters[43].Value = model.REFERER;
            parameters[44].Value = model.ADD_TIME;
            parameters[45].Value = model.CONFIRM_TIME;
            parameters[46].Value = model.PAY_TIME;
            parameters[47].Value = model.SHIPPING_TIME;
            parameters[48].Value = model.PACK_ID;
            parameters[49].Value = model.CARD_ID;
            parameters[50].Value = model.BONUS_ID;
            parameters[51].Value = model.INVOICE_NO;
            parameters[52].Value = model.EXTENSION_CODE;
            parameters[53].Value = model.EXTENSION_ID;
            parameters[54].Value = model.TO_BUYER;
            parameters[55].Value = model.PAY_NOTE;
            parameters[56].Value = model.AGENCY_ID;
            parameters[57].Value = model.INV_TYPE;
            parameters[58].Value = model.TAX;
            parameters[59].Value = model.IS_SEPARATE;
            parameters[60].Value = model.PARENT_ID;
            parameters[61].Value = model.DISCOUNT;
            parameters[62].Value = model.ORDER_TYPE;
            parameters[63].Value = model.ACTUAL_AMOUNT;
            parameters[64].Value = model.PRINT_STATUS;

            sqlList.Add(new CommandInfo(strSql.ToString(), parameters));

            foreach (BllOrderGoodsTable lineMode in model.ORDER_GOODS)
            {
                strSql = new StringBuilder();
                strSql.Append("insert into BLL_ORDER_GOODS(");
                strSql.Append("REC_ID,ORDER_ID,GOODS_ID,GOODS_NAME,GOODS_SN,GOODS_NUMBER,MARKET_PRICE,GOODS_PRICE,GOODS_ATTR,SEND_NUMBER,IS_REAL,EXTENSION_CODE,PARENT_ID,IS_GIFT,ORDER_TYPE,ACTUAL_AMOUNT,ACTUAL_WEIGHT)");
                strSql.Append(" values (");
                strSql.Append("@REC_ID,@ORDER_ID,@GOODS_ID,@GOODS_NAME,@GOODS_SN,@GOODS_NUMBER,@MARKET_PRICE,@GOODS_PRICE,@GOODS_ATTR,@SEND_NUMBER,@IS_REAL,@EXTENSION_CODE,@PARENT_ID,@IS_GIFT,@ORDER_TYPE,@ACTUAL_AMOUNT,@ACTUAL_WEIGHT)");
                SqlParameter[] lineParams = {
					new SqlParameter("@REC_ID", SqlDbType.Int,4),
					new SqlParameter("@ORDER_ID", SqlDbType.Int,4),
					new SqlParameter("@GOODS_ID", SqlDbType.Int,4),
					new SqlParameter("@GOODS_NAME", SqlDbType.VarChar,120),
					new SqlParameter("@GOODS_SN", SqlDbType.VarChar,60),
					new SqlParameter("@GOODS_NUMBER", SqlDbType.Int,4),
					new SqlParameter("@MARKET_PRICE", SqlDbType.Decimal,9),
					new SqlParameter("@GOODS_PRICE", SqlDbType.Decimal,9),
					new SqlParameter("@GOODS_ATTR", SqlDbType.Text),
					new SqlParameter("@SEND_NUMBER", SqlDbType.SmallInt,2),
					new SqlParameter("@IS_REAL", SqlDbType.Int,4),
					new SqlParameter("@EXTENSION_CODE", SqlDbType.VarChar,30),
					new SqlParameter("@PARENT_ID", SqlDbType.Int,4),
					new SqlParameter("@IS_GIFT", SqlDbType.SmallInt,2),
					new SqlParameter("@ORDER_TYPE", SqlDbType.Int,4),
					new SqlParameter("@ACTUAL_AMOUNT", SqlDbType.Decimal,9),
					new SqlParameter("@ACTUAL_WEIGHT", SqlDbType.Decimal,9)};
                lineParams[0].Value = lineMode.REC_ID;
                lineParams[1].Value = lineMode.ORDER_ID;
                lineParams[2].Value = lineMode.GOODS_ID;
                lineParams[3].Value = lineMode.GOODS_NAME;
                lineParams[4].Value = lineMode.GOODS_SN;
                lineParams[5].Value = lineMode.GOODS_NUMBER;
                lineParams[6].Value = lineMode.MARKET_PRICE;
                lineParams[7].Value = lineMode.GOODS_PRICE;
                lineParams[8].Value = lineMode.GOODS_ATTR;
                lineParams[9].Value = lineMode.SEND_NUMBER;
                lineParams[10].Value = lineMode.IS_REAL;
                lineParams[11].Value = lineMode.EXTENSION_CODE;
                lineParams[12].Value = lineMode.PARENT_ID;
                lineParams[13].Value = lineMode.IS_GIFT;
                lineParams[14].Value = lineMode.ORDER_TYPE;
                lineParams[15].Value = lineMode.ACTUAL_AMOUNT;
                lineParams[16].Value = lineMode.ACTUAL_WEIGHT;

                sqlList.Add(new CommandInfo(strSql.ToString(), lineParams));
            }

            return DbHelperSqlServer.ExecuteSqlTran(sqlList);
        }

        #region 更新一条数据 暂不使用
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(BllOrderInfoTable model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BLL_ORDER_INFO set ");
            strSql.Append("ORDER_SN=@ORDER_SN,");
            strSql.Append("USER_ID=@USER_ID,");
            strSql.Append("ORDER_STATUS=@ORDER_STATUS,");
            strSql.Append("SHIPPING_STATUS=@SHIPPING_STATUS,");
            strSql.Append("PAY_STATUS=@PAY_STATUS,");
            strSql.Append("CONSIGNEE=@CONSIGNEE,");
            strSql.Append("COUNTRY=@COUNTRY,");
            strSql.Append("PROVINCE=@PROVINCE,");
            strSql.Append("CITY=@CITY,");
            strSql.Append("DISTRICT=@DISTRICT,");
            strSql.Append("ADDRESS=@ADDRESS,");
            strSql.Append("ZIPCODE=@ZIPCODE,");
            strSql.Append("TEL=@TEL,");
            strSql.Append("MOBILE=@MOBILE,");
            strSql.Append("EMAIL=@EMAIL,");
            strSql.Append("BEST_TIME=@BEST_TIME,");
            strSql.Append("SIGN_BUILDING=@SIGN_BUILDING,");
            strSql.Append("POST_SCRIPT=@POST_SCRIPT,");
            strSql.Append("SHIPPING_ID=@SHIPPING_ID,");
            strSql.Append("SHIPPING_NAME=@SHIPPING_NAME,");
            strSql.Append("PAY_ID=@PAY_ID,");
            strSql.Append("PAY_NAME=@PAY_NAME,");
            strSql.Append("HOW_OOS=@HOW_OOS,");
            strSql.Append("HOW_SURPLUS=@HOW_SURPLUS,");
            strSql.Append("PACK_NAME=@PACK_NAME,");
            strSql.Append("CARD_NAME=@CARD_NAME,");
            strSql.Append("CARD_MESSAGE=@CARD_MESSAGE,");
            strSql.Append("INV_PAYEE=@INV_PAYEE,");
            strSql.Append("INV_CONTENT=@INV_CONTENT,");
            strSql.Append("GOODS_AMOUNT=@GOODS_AMOUNT,");
            strSql.Append("SHIPPING_FEE=@SHIPPING_FEE,");
            strSql.Append("INSURE_FEE=@INSURE_FEE,");
            strSql.Append("PAY_FEE=@PAY_FEE,");
            strSql.Append("PACK_FEE=@PACK_FEE,");
            strSql.Append("CARD_FEE=@CARD_FEE,");
            strSql.Append("MONEY_PAID=@MONEY_PAID,");
            strSql.Append("SURPLUS=@SURPLUS,");
            strSql.Append("INTEGRAL=@INTEGRAL,");
            strSql.Append("INTEGRALl_MONEY=@INTEGRALl_MONEY,");
            strSql.Append("BONUS=@BONUS,");
            strSql.Append("ORDER_AMOUNT=@ORDER_AMOUNT,");
            strSql.Append("FROM_AD=@FROM_AD,");
            strSql.Append("REFERER=@REFERER,");
            strSql.Append("ADD_TIME=@ADD_TIME,");
            strSql.Append("CONFIRM_TIME=@CONFIRM_TIME,");
            strSql.Append("PAY_TIME=@PAY_TIME,");
            strSql.Append("SHIPPING_TIME=@SHIPPING_TIME,");
            strSql.Append("PACK_ID=@PACK_ID,");
            strSql.Append("CARD_ID=@CARD_ID,");
            strSql.Append("BONUS_ID=@BONUS_ID,");
            strSql.Append("INVOICE_NO=@INVOICE_NO,");
            strSql.Append("EXTENSION_CODE=@EXTENSION_CODE,");
            strSql.Append("EXTENSION_ID=@EXTENSION_ID,");
            strSql.Append("TO_BUYER=@TO_BUYER,");
            strSql.Append("PAY_NOTE=@PAY_NOTE,");
            strSql.Append("AGENCY_ID=@AGENCY_ID,");
            strSql.Append("INV_TYPE=@INV_TYPE,");
            strSql.Append("TAX=@TAX,");
            strSql.Append("IS_SEPARATE=@IS_SEPARATE,");
            strSql.Append("PARENT_ID=@PARENT_ID,");
            strSql.Append("DISCOUNT=@DISCOUNT,");
            strSql.Append("ACTUAL_AMOUNT=@ACTUAL_AMOUNT,");
            strSql.Append("PRINT_STATUS=@PRINT_STATUS");
            strSql.Append(" where ORDER_ID=@ORDER_ID and ORDER_TYPE=@ORDER_TYPE ");
            SqlParameter[] parameters = {
					new SqlParameter("@ORDER_ID", SqlDbType.Decimal,5),
					new SqlParameter("@ORDER_SN", SqlDbType.VarChar,20),
					new SqlParameter("@USER_ID", SqlDbType.Int,4),
					new SqlParameter("@ORDER_STATUS", SqlDbType.Int,4),
					new SqlParameter("@SHIPPING_STATUS", SqlDbType.Int,4),
					new SqlParameter("@PAY_STATUS", SqlDbType.Int,4),
					new SqlParameter("@CONSIGNEE", SqlDbType.VarChar,60),
					new SqlParameter("@COUNTRY", SqlDbType.VarChar,60),
					new SqlParameter("@PROVINCE", SqlDbType.VarChar,60),
					new SqlParameter("@CITY", SqlDbType.VarChar,60),
					new SqlParameter("@DISTRICT", SqlDbType.VarChar,60),
					new SqlParameter("@ADDRESS", SqlDbType.VarChar,255),
					new SqlParameter("@ZIPCODE", SqlDbType.VarChar,60),
					new SqlParameter("@TEL", SqlDbType.VarChar,60),
					new SqlParameter("@MOBILE", SqlDbType.VarChar,60),
					new SqlParameter("@EMAIL", SqlDbType.NChar,10),
					new SqlParameter("@BEST_TIME", SqlDbType.Int,4),
					new SqlParameter("@SIGN_BUILDING", SqlDbType.VarChar,120),
					new SqlParameter("@POST_SCRIPT", SqlDbType.VarChar,255),
					new SqlParameter("@SHIPPING_ID", SqlDbType.Int,4),
					new SqlParameter("@SHIPPING_NAME", SqlDbType.VarChar,120),
					new SqlParameter("@PAY_ID", SqlDbType.Int,4),
					new SqlParameter("@PAY_NAME", SqlDbType.VarChar,120),
					new SqlParameter("@HOW_OOS", SqlDbType.VarChar,120),
					new SqlParameter("@HOW_SURPLUS", SqlDbType.VarChar,120),
					new SqlParameter("@PACK_NAME", SqlDbType.VarChar,120),
					new SqlParameter("@CARD_NAME", SqlDbType.VarChar,120),
					new SqlParameter("@CARD_MESSAGE", SqlDbType.VarChar,255),
					new SqlParameter("@INV_PAYEE", SqlDbType.VarChar,120),
					new SqlParameter("@INV_CONTENT", SqlDbType.VarChar,120),
					new SqlParameter("@GOODS_AMOUNT", SqlDbType.Decimal,9),
					new SqlParameter("@SHIPPING_FEE", SqlDbType.Decimal,9),
					new SqlParameter("@INSURE_FEE", SqlDbType.Decimal,9),
					new SqlParameter("@PAY_FEE", SqlDbType.Decimal,9),
					new SqlParameter("@PACK_FEE", SqlDbType.Decimal,9),
					new SqlParameter("@CARD_FEE", SqlDbType.Decimal,9),
					new SqlParameter("@MONEY_PAID", SqlDbType.Decimal,9),
					new SqlParameter("@SURPLUS", SqlDbType.Decimal,9),
					new SqlParameter("@INTEGRAL", SqlDbType.Int,4),
					new SqlParameter("@INTEGRALl_MONEY", SqlDbType.Decimal,9),
					new SqlParameter("@BONUS", SqlDbType.Decimal,9),
					new SqlParameter("@ORDER_AMOUNT", SqlDbType.Decimal,9),
					new SqlParameter("@FROM_AD", SqlDbType.SmallInt,2),
					new SqlParameter("@REFERER", SqlDbType.VarChar,255),
					new SqlParameter("@ADD_TIME", SqlDbType.DateTime),
					new SqlParameter("@CONFIRM_TIME", SqlDbType.DateTime),
					new SqlParameter("@PAY_TIME", SqlDbType.DateTime),
					new SqlParameter("@SHIPPING_TIME", SqlDbType.DateTime),
					new SqlParameter("@PACK_ID", SqlDbType.Int,4),
					new SqlParameter("@CARD_ID", SqlDbType.Int,4),
					new SqlParameter("@BONUS_ID", SqlDbType.SmallInt,2),
					new SqlParameter("@INVOICE_NO", SqlDbType.VarChar,50),
					new SqlParameter("@EXTENSION_CODE", SqlDbType.VarChar,30),
					new SqlParameter("@EXTENSION_ID", SqlDbType.Int,4),
					new SqlParameter("@TO_BUYER", SqlDbType.VarChar,255),
					new SqlParameter("@PAY_NOTE", SqlDbType.VarChar,255),
					new SqlParameter("@AGENCY_ID", SqlDbType.SmallInt,2),
					new SqlParameter("@INV_TYPE", SqlDbType.VarChar,60),
					new SqlParameter("@TAX", SqlDbType.Decimal,9),
					new SqlParameter("@IS_SEPARATE", SqlDbType.Int,4),
					new SqlParameter("@PARENT_ID", SqlDbType.NChar,10),
					new SqlParameter("@DISCOUNT", SqlDbType.Decimal,9),
					new SqlParameter("@ORDER_TYPE", SqlDbType.Int,4),
					new SqlParameter("@ACTUAL_AMOUNT", SqlDbType.Decimal,9),
					new SqlParameter("@PRINT_STATUS", SqlDbType.Int,4)};
            parameters[0].Value = model.ORDER_ID;
            parameters[1].Value = model.ORDER_SN;
            parameters[2].Value = model.USER_ID;
            parameters[3].Value = model.ORDER_STATUS;
            parameters[4].Value = model.SHIPPING_STATUS;
            parameters[5].Value = model.PAY_STATUS;
            parameters[6].Value = model.CONSIGNEE;
            parameters[7].Value = model.COUNTRY;
            parameters[8].Value = model.PROVINCE;
            parameters[9].Value = model.CITY;
            parameters[10].Value = model.DISTRICT;
            parameters[11].Value = model.ADDRESS;
            parameters[12].Value = model.ZIPCODE;
            parameters[13].Value = model.TEL;
            parameters[14].Value = model.MOBILE;
            parameters[15].Value = model.EMAIL;
            parameters[16].Value = model.BEST_TIME;
            parameters[17].Value = model.SIGN_BUILDING;
            parameters[18].Value = model.POST_SCRIPT;
            parameters[19].Value = model.SHIPPING_ID;
            parameters[20].Value = model.SHIPPING_NAME;
            parameters[21].Value = model.PAY_ID;
            parameters[22].Value = model.PAY_NAME;
            parameters[23].Value = model.HOW_OOS;
            parameters[24].Value = model.HOW_SURPLUS;
            parameters[25].Value = model.PACK_NAME;
            parameters[26].Value = model.CARD_NAME;
            parameters[27].Value = model.CARD_MESSAGE;
            parameters[28].Value = model.INV_PAYEE;
            parameters[29].Value = model.INV_CONTENT;
            parameters[30].Value = model.GOODS_AMOUNT;
            parameters[31].Value = model.SHIPPING_FEE;
            parameters[32].Value = model.INSURE_FEE;
            parameters[33].Value = model.PAY_FEE;
            parameters[34].Value = model.PACK_FEE;
            parameters[35].Value = model.CARD_FEE;
            parameters[36].Value = model.MONEY_PAID;
            parameters[37].Value = model.SURPLUS;
            parameters[38].Value = model.INTEGRAL;
            parameters[39].Value = model.INTEGRALl_MONEY;
            parameters[40].Value = model.BONUS;
            parameters[41].Value = model.ORDER_AMOUNT;
            parameters[42].Value = model.FROM_AD;
            parameters[43].Value = model.REFERER;
            parameters[44].Value = model.ADD_TIME;
            parameters[45].Value = model.CONFIRM_TIME;
            parameters[46].Value = model.PAY_TIME;
            parameters[47].Value = model.SHIPPING_TIME;
            parameters[48].Value = model.PACK_ID;
            parameters[49].Value = model.CARD_ID;
            parameters[50].Value = model.BONUS_ID;
            parameters[51].Value = model.INVOICE_NO;
            parameters[52].Value = model.EXTENSION_CODE;
            parameters[53].Value = model.EXTENSION_ID;
            parameters[54].Value = model.TO_BUYER;
            parameters[55].Value = model.PAY_NOTE;
            parameters[56].Value = model.AGENCY_ID;
            parameters[57].Value = model.INV_TYPE;
            parameters[58].Value = model.TAX;
            parameters[59].Value = model.IS_SEPARATE;
            parameters[60].Value = model.PARENT_ID;
            parameters[61].Value = model.DISCOUNT;
            parameters[62].Value = model.ORDER_TYPE;
            parameters[63].Value = model.ACTUAL_AMOUNT;
            parameters[64].Value = model.PRINT_STATUS;

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

        #endregion  Method
    }//end class
}

