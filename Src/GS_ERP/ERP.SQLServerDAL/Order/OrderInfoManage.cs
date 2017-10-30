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
    public class OrderInfoManage : IOrderInfo
    {
        public OrderInfoManage()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(BaseOrderInfoTable model)
        {
            int i = 0;
            int result = 0;
            while (i < 10)
            {
                try
                {
                    List<CommandInfo> listSql = new List<CommandInfo>();
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("insert into BLL_ORDER_INFO(");
                    strSql.Append("ORDER_ID,ORDER_SN,USER_ID,ORDER_STATUS,SHIPPING_STATUS,PAY_STATUS,CONSIGNEE,COUNTRY,PROVINCE,CITY,DISTRICT,ADDRESS,ZIPCODE,TEL,MOBILE,EMAIL,BEST_TIME,SIGN_BUILDING,POST_SCRIPT,SHIPPING_ID,SHIPPING_NAME,PAY_ID,PAY_NAME,HOW_OOS,HOW_SURPLUS,PACK_NAME,CARD_NAME,CARD_MESSAGE,INV_PAYEE,INV_CONTENT,GOODS_AMOUNT,SHIPPING_FEE,INSURE_FEE,PAY_FEE,PACK_FEE,CARD_FEE,MONEY_PAID,SURPLUS,INTEGRAL,INTEGRALl_MONEY,BONUS,ORDER_AMOUNT,FROM_AD,REFERER,ADD_TIME,CONFIRM_TIME,PAY_TIME,SHIPPING_TIME,PACK_ID,CARD_ID,BONUS_ID,INVOICE_NO,EXTENSION_CODE,EXTENSION_ID,TO_BUYER,PAY_NOTE,AGENCY_ID,INV_TYPE,TAX,IS_SEPARATE,PARENT_ID,DISCOUNT,ORDER_TYPE,SEND_FLAG,ACTUAL_GOODS_AMOUNT,PRINT_STATUS,COMMUNITY,COMMUNITY_CODE)");
                    strSql.Append(" values (");
                    strSql.Append("@ORDER_ID,@ORDER_SN,@USER_ID,@ORDER_STATUS,@SHIPPING_STATUS,@PAY_STATUS,@CONSIGNEE,@COUNTRY,@PROVINCE,@CITY,@DISTRICT,@ADDRESS,@ZIPCODE,@TEL,@MOBILE,@EMAIL,@BEST_TIME,@SIGN_BUILDING,@POST_SCRIPT,@SHIPPING_ID,@SHIPPING_NAME,@PAY_ID,@PAY_NAME,@HOW_OOS,@HOW_SURPLUS,@PACK_NAME,@CARD_NAME,@CARD_MESSAGE,@INV_PAYEE,@INV_CONTENT,@GOODS_AMOUNT,@SHIPPING_FEE,@INSURE_FEE,@PAY_FEE,@PACK_FEE,@CARD_FEE,@MONEY_PAID,@SURPLUS,@INTEGRAL,@INTEGRALl_MONEY,@BONUS,@ORDER_AMOUNT,@FROM_AD,@REFERER,@ADD_TIME,@CONFIRM_TIME,@PAY_TIME,@SHIPPING_TIME,@PACK_ID,@CARD_ID,@BONUS_ID,@INVOICE_NO,@EXTENSION_CODE,@EXTENSION_ID,@TO_BUYER,@PAY_NOTE,@AGENCY_ID,@INV_TYPE,@TAX,@IS_SEPARATE,@PARENT_ID,@DISCOUNT,@ORDER_TYPE,@SEND_FLAG,@ACTUAL_GOODS_AMOUNT,@PRINT_STATUS,@COMMUNITY,@COMMUNITY_CODE)");
                    SqlParameter[] parameters = {
					new SqlParameter("@ORDER_ID", SqlDbType.Decimal,9),
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
					new SqlParameter("@BEST_TIME", SqlDbType.DateTime),
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
					new SqlParameter("@BONUS_ID", SqlDbType.Int,4),
					new SqlParameter("@INVOICE_NO", SqlDbType.VarChar,50),
					new SqlParameter("@EXTENSION_CODE", SqlDbType.VarChar,30),
					new SqlParameter("@EXTENSION_ID", SqlDbType.Int,4),
					new SqlParameter("@TO_BUYER", SqlDbType.VarChar,255),
					new SqlParameter("@PAY_NOTE", SqlDbType.VarChar,255),
					new SqlParameter("@AGENCY_ID", SqlDbType.Int,4),
					new SqlParameter("@INV_TYPE", SqlDbType.VarChar,60),
					new SqlParameter("@TAX", SqlDbType.Decimal,9),
					new SqlParameter("@IS_SEPARATE", SqlDbType.Int,4),
					new SqlParameter("@PARENT_ID", SqlDbType.NChar,10),
					new SqlParameter("@DISCOUNT", SqlDbType.Decimal,9),
					new SqlParameter("@ORDER_TYPE", SqlDbType.Int,4),
					new SqlParameter("@SEND_FLAG", SqlDbType.Int,4),
					new SqlParameter("@ACTUAL_GOODS_AMOUNT", SqlDbType.Decimal,9),
					new SqlParameter("@PRINT_STATUS", SqlDbType.Int,4),
					new SqlParameter("@COMMUNITY", SqlDbType.VarChar,50),
					new SqlParameter("@COMMUNITY_CODE", SqlDbType.Int,4)};
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
                    parameters[63].Value = model.SEND_FLAG;
                    parameters[64].Value = model.ACTUAL_GOODS_AMOUNT;
                    parameters[65].Value = model.PRINT_STATUS;
                    parameters[66].Value = model.COMMUNITY;
                    parameters[67].Value = model.COMMUNITY_CODE;
                    listSql.Add(new CommandInfo(strSql.ToString(), parameters));

                    //明细插入
                    foreach (BaseOrdersGoodsTable lineModel in model.ITEMS)
                    {
                        strSql = new StringBuilder();
                        strSql.Append("insert into BLL_ORDER_GOODS(");
                        strSql.Append("REC_ID,ORDER_ID,GOODS_ID,GOODS_NAME,GOODS_SN,GOODS_NUMBER,MARKET_PRICE,GOODS_PRICE,GOODS_ATTR,SEND_NUMBER,IS_REAL,EXTENSION_CODE,PARENT_ID,IS_GIFT,ORDER_TYPE,ACTUAL_AMOUNT,ACTUAL_NUMBER)");
                        strSql.Append(" values (");
                        strSql.Append("@REC_ID,@ORDER_ID,@GOODS_ID,@GOODS_NAME,@GOODS_SN,@GOODS_NUMBER,@MARKET_PRICE,@GOODS_PRICE,@GOODS_ATTR,@SEND_NUMBER,@IS_REAL,@EXTENSION_CODE,@PARENT_ID,@IS_GIFT,@ORDER_TYPE,@ACTUAL_AMOUNT,@ACTUAL_NUMBER)");
                        SqlParameter[] lineparameters = {
                    new SqlParameter("@REC_ID", SqlDbType.Int,4),
                    new SqlParameter("@ORDER_ID", SqlDbType.Int,4),
                    new SqlParameter("@GOODS_ID", SqlDbType.Int,4),
                    new SqlParameter("@GOODS_NAME", SqlDbType.VarChar,120),
                    new SqlParameter("@GOODS_SN", SqlDbType.VarChar,60),
                    new SqlParameter("@GOODS_NUMBER", SqlDbType.Int,4),
                    new SqlParameter("@MARKET_PRICE", SqlDbType.Decimal,9),
                    new SqlParameter("@GOODS_PRICE", SqlDbType.Decimal,9),
                    new SqlParameter("@GOODS_ATTR", SqlDbType.Text),
                    new SqlParameter("@SEND_NUMBER", SqlDbType.Int,4),
                    new SqlParameter("@IS_REAL", SqlDbType.Int,4),
                    new SqlParameter("@EXTENSION_CODE", SqlDbType.VarChar,30),
                    new SqlParameter("@PARENT_ID", SqlDbType.Int,4),
                    new SqlParameter("@IS_GIFT", SqlDbType.Int,4),
                    new SqlParameter("@ORDER_TYPE", SqlDbType.Int,4),
                    new SqlParameter("@ACTUAL_AMOUNT", SqlDbType.Decimal,9),
                    new SqlParameter("@ACTUAL_NUMBER", SqlDbType.Decimal)};
                        lineparameters[0].Value = lineModel.REC_ID;
                        lineparameters[1].Value = lineModel.ORDER_ID;
                        lineparameters[2].Value = lineModel.GOODS_ID;
                        lineparameters[3].Value = lineModel.GOODS_NAME;
                        lineparameters[4].Value = lineModel.GOODS_SN;
                        lineparameters[5].Value = lineModel.GOODS_NUMBER;
                        lineparameters[6].Value = lineModel.MARKET_PRICE;
                        lineparameters[7].Value = lineModel.GOODS_PRICE;
                        lineparameters[8].Value = lineModel.GOODS_ATTR;
                        lineparameters[9].Value = lineModel.SEND_NUMBER;
                        lineparameters[10].Value = lineModel.IS_REAL;
                        lineparameters[11].Value = lineModel.EXTENSION_CODE;
                        lineparameters[12].Value = lineModel.PARENT_ID;
                        lineparameters[13].Value = lineModel.IS_GIFT;
                        lineparameters[14].Value = lineModel.ORDER_TYPE;
                        lineparameters[15].Value = lineModel.ACTUAL_AMOUNT;
                        lineparameters[16].Value = lineModel.ACTUAL_NUMBER;
                        listSql.Add(new CommandInfo(strSql.ToString(), lineparameters));
                    }
                    result = DbHelperSQL.ExecuteSqlTran(listSql);
                    break;
                }
                catch (SqlException ex)
                {
                    model.ORDER_ID = (CConvert.ToInt32(GetMaxCode()) + 1);
                    i++;
                    if (i == 10)
                    {
                        throw ex;
                    }
                    continue;
                }
                //break;
            }
            if (result <= 0)
            {
                return null;
            }

            return model.ORDER_ID.ToString();
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(BaseOrderInfoTable model)
        {
            int i = 0;

            List<CommandInfo> listSql = new List<CommandInfo>();
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
            strSql.Append("SEND_FLAG=@SEND_FLAG,");
            strSql.Append("ACTUAL_GOODS_AMOUNT=@ACTUAL_GOODS_AMOUNT,");
            strSql.Append("PRINT_STATUS=@PRINT_STATUS,");
            strSql.Append("COMMUNITY=@COMMUNITY,");
            strSql.Append("COMMUNITY_CODE=@COMMUNITY_CODE");
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
					new SqlParameter("@BEST_TIME", SqlDbType.DateTime),
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
					new SqlParameter("@BONUS_ID", SqlDbType.Int,4),
					new SqlParameter("@INVOICE_NO", SqlDbType.VarChar,50),
					new SqlParameter("@EXTENSION_CODE", SqlDbType.VarChar,30),
					new SqlParameter("@EXTENSION_ID", SqlDbType.Int,4),
					new SqlParameter("@TO_BUYER", SqlDbType.VarChar,255),
					new SqlParameter("@PAY_NOTE", SqlDbType.VarChar,255),
					new SqlParameter("@AGENCY_ID", SqlDbType.Int,4),
					new SqlParameter("@INV_TYPE", SqlDbType.VarChar,60),
					new SqlParameter("@TAX", SqlDbType.Decimal,9),
					new SqlParameter("@IS_SEPARATE", SqlDbType.Int,4),
					new SqlParameter("@PARENT_ID", SqlDbType.NChar,10),
					new SqlParameter("@DISCOUNT", SqlDbType.Decimal,9),
					new SqlParameter("@ORDER_TYPE", SqlDbType.Int,4),
					new SqlParameter("@SEND_FLAG", SqlDbType.Int,4),
					new SqlParameter("@ACTUAL_GOODS_AMOUNT", SqlDbType.Decimal,9),
					new SqlParameter("@PRINT_STATUS", SqlDbType.Int,4),
					new SqlParameter("@COMMUNITY", SqlDbType.VarChar,50),
					new SqlParameter("@COMMUNITY_CODE", SqlDbType.Int,4)};
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
            parameters[63].Value = model.SEND_FLAG;
            parameters[64].Value = model.ACTUAL_GOODS_AMOUNT;
            parameters[65].Value = model.PRINT_STATUS;
            parameters[66].Value = model.COMMUNITY;
            parameters[67].Value = model.COMMUNITY_CODE;
            listSql.Add(new CommandInfo(strSql.ToString(), parameters));

            strSql = new StringBuilder();
            strSql.Append("delete from BLL_ORDER_GOODS where ORDER_ID=@ORDER_ID and ORDER_TYPE=@ORDER_TYPE");
            SqlParameter[] deleteParameters = {
					new SqlParameter("@ORDER_ID", SqlDbType.Decimal),
					new SqlParameter("@ORDER_TYPE", SqlDbType.Int)};
            deleteParameters[0].Value = model.ORDER_SN;
            deleteParameters[1].Value = model.ORDER_TYPE;
            listSql.Add(new CommandInfo(strSql.ToString(), deleteParameters));

            foreach (BaseOrdersGoodsTable lineModel in model.ITEMS)
            {
                strSql = new StringBuilder();
                strSql.Append("insert into BLL_ORDER_GOODS(");
                strSql.Append("REC_ID,ORDER_ID,GOODS_ID,GOODS_NAME,GOODS_SN,GOODS_NUMBER,MARKET_PRICE,GOODS_PRICE,GOODS_ATTR,SEND_NUMBER,IS_REAL,EXTENSION_CODE,PARENT_ID,IS_GIFT,ORDER_TYPE,ACTUAL_AMOUNT,ACTUAL_NUMBER)");
                strSql.Append(" values (");
                strSql.Append("@REC_ID,@ORDER_ID,@GOODS_ID,@GOODS_NAME,@GOODS_SN,@GOODS_NUMBER,@MARKET_PRICE,@GOODS_PRICE,@GOODS_ATTR,@SEND_NUMBER,@IS_REAL,@EXTENSION_CODE,@PARENT_ID,@IS_GIFT,@ORDER_TYPE,@ACTUAL_AMOUNT,@ACTUAL_NUMBER)");
                SqlParameter[] lineparameters = {
					            new SqlParameter("@REC_ID", SqlDbType.Int,4),
					            new SqlParameter("@ORDER_ID", SqlDbType.Int,4),
					            new SqlParameter("@GOODS_ID", SqlDbType.Int,4),
					            new SqlParameter("@GOODS_NAME", SqlDbType.VarChar,120),
					            new SqlParameter("@GOODS_SN", SqlDbType.VarChar,60),
					            new SqlParameter("@GOODS_NUMBER", SqlDbType.Int,4),
					            new SqlParameter("@MARKET_PRICE", SqlDbType.Decimal,9),
					            new SqlParameter("@GOODS_PRICE", SqlDbType.Decimal,9),
					            new SqlParameter("@GOODS_ATTR", SqlDbType.Text),
					            new SqlParameter("@SEND_NUMBER", SqlDbType.Int,4),
					            new SqlParameter("@IS_REAL", SqlDbType.Int,4),
					            new SqlParameter("@EXTENSION_CODE", SqlDbType.VarChar,30),
					            new SqlParameter("@PARENT_ID", SqlDbType.Int,4),
					            new SqlParameter("@IS_GIFT", SqlDbType.Int,4),
					            new SqlParameter("@ORDER_TYPE", SqlDbType.Int,4),
					            new SqlParameter("@ACTUAL_AMOUNT", SqlDbType.Decimal,9),
					            new SqlParameter("@ACTUAL_NUMBER", SqlDbType.Decimal)};
                lineparameters[0].Value = lineModel.REC_ID;
                lineparameters[1].Value = lineModel.ORDER_ID;
                lineparameters[2].Value = lineModel.GOODS_ID;
                lineparameters[3].Value = lineModel.GOODS_NAME;
                lineparameters[4].Value = lineModel.GOODS_SN;
                lineparameters[5].Value = lineModel.GOODS_NUMBER;
                lineparameters[6].Value = lineModel.MARKET_PRICE;
                lineparameters[7].Value = lineModel.GOODS_PRICE;
                lineparameters[8].Value = lineModel.GOODS_ATTR;
                lineparameters[9].Value = lineModel.SEND_NUMBER;
                lineparameters[10].Value = lineModel.IS_REAL;
                lineparameters[11].Value = lineModel.EXTENSION_CODE;
                lineparameters[12].Value = lineModel.PARENT_ID;
                lineparameters[13].Value = lineModel.IS_GIFT;
                lineparameters[14].Value = lineModel.ORDER_TYPE;
                lineparameters[15].Value = lineModel.ACTUAL_AMOUNT;
                lineparameters[16].Value = lineModel.ACTUAL_NUMBER;
                listSql.Add(new CommandInfo(strSql.ToString(), lineparameters));
            }
            return DbHelperSQL.ExecuteSqlTran(listSql);
        }

        /// <summary>
        /// 删除一条数据 
        /// </summary>
        public bool Delete(int ORDER_ID, int ORDER_TYPE)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BLL_ORDER_INFO ");
            strSql.Append(" where ORDER_ID=@ORDER_ID and ORDER_TYPE=@ORDER_TYPE ");
            SqlParameter[] parameters = {
					new SqlParameter("@ORDER_ID", SqlDbType.Int,4),
					new SqlParameter("@ORDER_TYPE", SqlDbType.Int,4)};
            parameters[0].Value = ORDER_ID;
            parameters[1].Value = ORDER_TYPE;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public BaseOrderInfoTable GetModel(decimal ORDER_ID, int ORDER_TYPE)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ORDER_ID,ORDER_SN,USER_ID,ORDER_STATUS,SHIPPING_STATUS,PAY_STATUS,CONSIGNEE,COUNTRY,PROVINCE,CITY,DISTRICT,ADDRESS,ZIPCODE,TEL,MOBILE,EMAIL,BEST_TIME,SIGN_BUILDING,POST_SCRIPT,SHIPPING_ID,SHIPPING_NAME,PAY_ID,PAY_NAME,HOW_OOS,HOW_SURPLUS,PACK_NAME,CARD_NAME,CARD_MESSAGE,INV_PAYEE,INV_CONTENT,GOODS_AMOUNT,SHIPPING_FEE,INSURE_FEE,PAY_FEE,PACK_FEE,CARD_FEE,MONEY_PAID,SURPLUS,INTEGRAL,INTEGRALl_MONEY,BONUS,ORDER_AMOUNT,FROM_AD,REFERER,ADD_TIME,CONFIRM_TIME,PAY_TIME,SHIPPING_TIME,PACK_ID,CARD_ID,BONUS_ID,INVOICE_NO,EXTENSION_CODE,EXTENSION_ID,TO_BUYER,PAY_NOTE,AGENCY_ID,INV_TYPE,TAX,IS_SEPARATE,PARENT_ID,DISCOUNT,ORDER_TYPE,ACTUAL_GOODS_AMOUNT,PRINT_STATUS from BLL_ORDER_INFO ");
            strSql.Append(" where ORDER_ID=@ORDER_ID and ORDER_TYPE=@ORDER_TYPE ");
            SqlParameter[] parameters = {
					new SqlParameter("@ORDER_ID", SqlDbType.Decimal),
					new SqlParameter("@ORDER_TYPE", SqlDbType.Int,4)};
            parameters[0].Value = ORDER_ID;
            parameters[1].Value = ORDER_TYPE;

            BaseOrderInfoTable model = new BaseOrderInfoTable();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ORDER_ID"].ToString() != "")
                {
                    model.ORDER_ID = decimal.Parse(ds.Tables[0].Rows[0]["ORDER_ID"].ToString());
                }
                model.ORDER_SN = ds.Tables[0].Rows[0]["ORDER_SN"].ToString();
                if (ds.Tables[0].Rows[0]["USER_ID"].ToString() != "")
                {
                    model.USER_ID = int.Parse(ds.Tables[0].Rows[0]["USER_ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ORDER_STATUS"].ToString() != "")
                {
                    model.ORDER_STATUS = int.Parse(ds.Tables[0].Rows[0]["ORDER_STATUS"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SHIPPING_STATUS"].ToString() != "")
                {
                    model.SHIPPING_STATUS = int.Parse(ds.Tables[0].Rows[0]["SHIPPING_STATUS"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PAY_STATUS"].ToString() != "")
                {
                    model.PAY_STATUS = int.Parse(ds.Tables[0].Rows[0]["PAY_STATUS"].ToString());
                }
                model.CONSIGNEE = ds.Tables[0].Rows[0]["CONSIGNEE"].ToString();
                model.COUNTRY = ds.Tables[0].Rows[0]["COUNTRY"].ToString();
                model.PROVINCE = ds.Tables[0].Rows[0]["PROVINCE"].ToString();
                model.CITY = ds.Tables[0].Rows[0]["CITY"].ToString();
                model.DISTRICT = ds.Tables[0].Rows[0]["DISTRICT"].ToString();
                model.ADDRESS = ds.Tables[0].Rows[0]["ADDRESS"].ToString();
                model.ZIPCODE = ds.Tables[0].Rows[0]["ZIPCODE"].ToString();
                model.TEL = ds.Tables[0].Rows[0]["TEL"].ToString();
                model.MOBILE = ds.Tables[0].Rows[0]["MOBILE"].ToString();
                model.EMAIL = ds.Tables[0].Rows[0]["EMAIL"].ToString();
                if (ds.Tables[0].Rows[0]["BEST_TIME"].ToString() != "")
                {
                    model.BEST_TIME = DateTime.Parse(ds.Tables[0].Rows[0]["BEST_TIME"].ToString());
                }
                model.SIGN_BUILDING = ds.Tables[0].Rows[0]["SIGN_BUILDING"].ToString();
                model.POST_SCRIPT = ds.Tables[0].Rows[0]["POST_SCRIPT"].ToString();
                if (ds.Tables[0].Rows[0]["SHIPPING_ID"].ToString() != "")
                {
                    model.SHIPPING_ID = int.Parse(ds.Tables[0].Rows[0]["SHIPPING_ID"].ToString());
                }
                model.SHIPPING_NAME = ds.Tables[0].Rows[0]["SHIPPING_NAME"].ToString();
                if (ds.Tables[0].Rows[0]["PAY_ID"].ToString() != "")
                {
                    model.PAY_ID = int.Parse(ds.Tables[0].Rows[0]["PAY_ID"].ToString());
                }
                model.PAY_NAME = ds.Tables[0].Rows[0]["PAY_NAME"].ToString();
                model.HOW_OOS = ds.Tables[0].Rows[0]["HOW_OOS"].ToString();
                model.HOW_SURPLUS = ds.Tables[0].Rows[0]["HOW_SURPLUS"].ToString();
                model.PACK_NAME = ds.Tables[0].Rows[0]["PACK_NAME"].ToString();
                model.CARD_NAME = ds.Tables[0].Rows[0]["CARD_NAME"].ToString();
                model.CARD_MESSAGE = ds.Tables[0].Rows[0]["CARD_MESSAGE"].ToString();
                model.INV_PAYEE = ds.Tables[0].Rows[0]["INV_PAYEE"].ToString();
                model.INV_CONTENT = ds.Tables[0].Rows[0]["INV_CONTENT"].ToString();
                if (ds.Tables[0].Rows[0]["GOODS_AMOUNT"].ToString() != "")
                {
                    model.GOODS_AMOUNT = decimal.Parse(ds.Tables[0].Rows[0]["GOODS_AMOUNT"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SHIPPING_FEE"].ToString() != "")
                {
                    model.SHIPPING_FEE = decimal.Parse(ds.Tables[0].Rows[0]["SHIPPING_FEE"].ToString());
                }
                if (ds.Tables[0].Rows[0]["INSURE_FEE"].ToString() != "")
                {
                    model.INSURE_FEE = decimal.Parse(ds.Tables[0].Rows[0]["INSURE_FEE"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PAY_FEE"].ToString() != "")
                {
                    model.PAY_FEE = decimal.Parse(ds.Tables[0].Rows[0]["PAY_FEE"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PACK_FEE"].ToString() != "")
                {
                    model.PACK_FEE = decimal.Parse(ds.Tables[0].Rows[0]["PACK_FEE"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CARD_FEE"].ToString() != "")
                {
                    model.CARD_FEE = decimal.Parse(ds.Tables[0].Rows[0]["CARD_FEE"].ToString());
                }
                if (ds.Tables[0].Rows[0]["MONEY_PAID"].ToString() != "")
                {
                    model.MONEY_PAID = decimal.Parse(ds.Tables[0].Rows[0]["MONEY_PAID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SURPLUS"].ToString() != "")
                {
                    model.SURPLUS = decimal.Parse(ds.Tables[0].Rows[0]["SURPLUS"].ToString());
                }
                if (ds.Tables[0].Rows[0]["INTEGRAL"].ToString() != "")
                {
                    model.INTEGRAL = int.Parse(ds.Tables[0].Rows[0]["INTEGRAL"].ToString());
                }
                if (ds.Tables[0].Rows[0]["INTEGRALl_MONEY"].ToString() != "")
                {
                    model.INTEGRALl_MONEY = decimal.Parse(ds.Tables[0].Rows[0]["INTEGRALl_MONEY"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BONUS"].ToString() != "")
                {
                    model.BONUS = decimal.Parse(ds.Tables[0].Rows[0]["BONUS"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ORDER_AMOUNT"].ToString() != "")
                {
                    model.ORDER_AMOUNT = decimal.Parse(ds.Tables[0].Rows[0]["ORDER_AMOUNT"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FROM_AD"].ToString() != "")
                {
                    model.FROM_AD = int.Parse(ds.Tables[0].Rows[0]["FROM_AD"].ToString());
                }
                model.REFERER = ds.Tables[0].Rows[0]["REFERER"].ToString();
                if (ds.Tables[0].Rows[0]["ADD_TIME"].ToString() != "")
                {
                    model.ADD_TIME = DateTime.Parse(ds.Tables[0].Rows[0]["ADD_TIME"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CONFIRM_TIME"].ToString() != "")
                {
                    model.CONFIRM_TIME = DateTime.Parse(ds.Tables[0].Rows[0]["CONFIRM_TIME"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PAY_TIME"].ToString() != "")
                {
                    model.PAY_TIME = DateTime.Parse(ds.Tables[0].Rows[0]["PAY_TIME"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SHIPPING_TIME"].ToString() != "")
                {
                    model.SHIPPING_TIME = DateTime.Parse(ds.Tables[0].Rows[0]["SHIPPING_TIME"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PACK_ID"].ToString() != "")
                {
                    model.PACK_ID = int.Parse(ds.Tables[0].Rows[0]["PACK_ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CARD_ID"].ToString() != "")
                {
                    model.CARD_ID = int.Parse(ds.Tables[0].Rows[0]["CARD_ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BONUS_ID"].ToString() != "")
                {
                    model.BONUS_ID = int.Parse(ds.Tables[0].Rows[0]["BONUS_ID"].ToString());
                }
                model.INVOICE_NO = ds.Tables[0].Rows[0]["INVOICE_NO"].ToString();
                model.EXTENSION_CODE = ds.Tables[0].Rows[0]["EXTENSION_CODE"].ToString();
                if (ds.Tables[0].Rows[0]["EXTENSION_ID"].ToString() != "")
                {
                    model.EXTENSION_ID = int.Parse(ds.Tables[0].Rows[0]["EXTENSION_ID"].ToString());
                }
                model.TO_BUYER = ds.Tables[0].Rows[0]["TO_BUYER"].ToString();
                model.PAY_NOTE = ds.Tables[0].Rows[0]["PAY_NOTE"].ToString();
                if (ds.Tables[0].Rows[0]["AGENCY_ID"].ToString() != "")
                {
                    model.AGENCY_ID = int.Parse(ds.Tables[0].Rows[0]["AGENCY_ID"].ToString());
                }
                model.INV_TYPE = ds.Tables[0].Rows[0]["INV_TYPE"].ToString();
                if (ds.Tables[0].Rows[0]["TAX"].ToString() != "")
                {
                    model.TAX = decimal.Parse(ds.Tables[0].Rows[0]["TAX"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IS_SEPARATE"].ToString() != "")
                {
                    model.IS_SEPARATE = int.Parse(ds.Tables[0].Rows[0]["IS_SEPARATE"].ToString());
                }
                model.PARENT_ID = ds.Tables[0].Rows[0]["PARENT_ID"].ToString();
                if (ds.Tables[0].Rows[0]["DISCOUNT"].ToString() != "")
                {
                    model.DISCOUNT = decimal.Parse(ds.Tables[0].Rows[0]["DISCOUNT"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ORDER_TYPE"].ToString() != "")
                {
                    model.ORDER_TYPE = int.Parse(ds.Tables[0].Rows[0]["ORDER_TYPE"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ACTUAL_GOODS_AMOUNT"].ToString() != "")
                {
                    model.ACTUAL_GOODS_AMOUNT = decimal.Parse(ds.Tables[0].Rows[0]["ACTUAL_GOODS_AMOUNT"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PRINT_STATUS"].ToString() != "")
                {
                    model.PRINT_STATUS = int.Parse(ds.Tables[0].Rows[0]["PRINT_STATUS"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }


        public BaseOrderInfoTable GetOrderSnModel(decimal ORDER_SN, int ORDER_TYPE)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ORDER_ID,ORDER_SN,USER_ID,ORDER_STATUS,SHIPPING_STATUS,PAY_STATUS,CONSIGNEE,COUNTRY,PROVINCE,CITY,DISTRICT,ADDRESS,ZIPCODE,TEL,MOBILE,EMAIL,BEST_TIME,SIGN_BUILDING,POST_SCRIPT,SHIPPING_ID,SHIPPING_NAME,PAY_ID,PAY_NAME,HOW_OOS,HOW_SURPLUS,PACK_NAME,CARD_NAME,CARD_MESSAGE,INV_PAYEE,INV_CONTENT,GOODS_AMOUNT,SHIPPING_FEE,INSURE_FEE,PAY_FEE,PACK_FEE,CARD_FEE,MONEY_PAID,SURPLUS,INTEGRAL,INTEGRALl_MONEY,BONUS,ORDER_AMOUNT,FROM_AD,REFERER,ADD_TIME,CONFIRM_TIME,PAY_TIME,SHIPPING_TIME,PACK_ID,CARD_ID,BONUS_ID,INVOICE_NO,EXTENSION_CODE,EXTENSION_ID,TO_BUYER,PAY_NOTE,AGENCY_ID,INV_TYPE,TAX,IS_SEPARATE,PARENT_ID,DISCOUNT,ORDER_TYPE,ACTUAL_GOODS_AMOUNT,PRINT_STATUS from BLL_ORDER_INFO ");
            strSql.Append(" where ORDER_SN=@ORDER_SN and ORDER_TYPE=@ORDER_TYPE ");
            SqlParameter[] parameters = {
					new SqlParameter("@ORDER_SN", SqlDbType.Decimal),
					new SqlParameter("@ORDER_TYPE", SqlDbType.Int,4)};
            parameters[0].Value = ORDER_SN;
            parameters[1].Value = ORDER_TYPE;

            BaseOrderInfoTable model = new BaseOrderInfoTable();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ORDER_ID"].ToString() != "")
                {
                    model.ORDER_ID = decimal.Parse(ds.Tables[0].Rows[0]["ORDER_ID"].ToString());
                }
                model.ORDER_SN = ds.Tables[0].Rows[0]["ORDER_SN"].ToString();
                if (ds.Tables[0].Rows[0]["USER_ID"].ToString() != "")
                {
                    model.USER_ID = int.Parse(ds.Tables[0].Rows[0]["USER_ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ORDER_STATUS"].ToString() != "")
                {
                    model.ORDER_STATUS = int.Parse(ds.Tables[0].Rows[0]["ORDER_STATUS"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SHIPPING_STATUS"].ToString() != "")
                {
                    model.SHIPPING_STATUS = int.Parse(ds.Tables[0].Rows[0]["SHIPPING_STATUS"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PAY_STATUS"].ToString() != "")
                {
                    model.PAY_STATUS = int.Parse(ds.Tables[0].Rows[0]["PAY_STATUS"].ToString());
                }
                model.CONSIGNEE = ds.Tables[0].Rows[0]["CONSIGNEE"].ToString();
                model.COUNTRY = ds.Tables[0].Rows[0]["COUNTRY"].ToString();
                model.PROVINCE = ds.Tables[0].Rows[0]["PROVINCE"].ToString();
                model.CITY = ds.Tables[0].Rows[0]["CITY"].ToString();
                model.DISTRICT = ds.Tables[0].Rows[0]["DISTRICT"].ToString();
                model.ADDRESS = ds.Tables[0].Rows[0]["ADDRESS"].ToString();
                model.ZIPCODE = ds.Tables[0].Rows[0]["ZIPCODE"].ToString();
                model.TEL = ds.Tables[0].Rows[0]["TEL"].ToString();
                model.MOBILE = ds.Tables[0].Rows[0]["MOBILE"].ToString();
                model.EMAIL = ds.Tables[0].Rows[0]["EMAIL"].ToString();
                if (ds.Tables[0].Rows[0]["BEST_TIME"].ToString() != "")
                {
                    model.BEST_TIME = DateTime.Parse(ds.Tables[0].Rows[0]["BEST_TIME"].ToString());
                }
                model.SIGN_BUILDING = ds.Tables[0].Rows[0]["SIGN_BUILDING"].ToString();
                model.POST_SCRIPT = ds.Tables[0].Rows[0]["POST_SCRIPT"].ToString();
                if (ds.Tables[0].Rows[0]["SHIPPING_ID"].ToString() != "")
                {
                    model.SHIPPING_ID = int.Parse(ds.Tables[0].Rows[0]["SHIPPING_ID"].ToString());
                }
                model.SHIPPING_NAME = ds.Tables[0].Rows[0]["SHIPPING_NAME"].ToString();
                if (ds.Tables[0].Rows[0]["PAY_ID"].ToString() != "")
                {
                    model.PAY_ID = int.Parse(ds.Tables[0].Rows[0]["PAY_ID"].ToString());
                }
                model.PAY_NAME = ds.Tables[0].Rows[0]["PAY_NAME"].ToString();
                model.HOW_OOS = ds.Tables[0].Rows[0]["HOW_OOS"].ToString();
                model.HOW_SURPLUS = ds.Tables[0].Rows[0]["HOW_SURPLUS"].ToString();
                model.PACK_NAME = ds.Tables[0].Rows[0]["PACK_NAME"].ToString();
                model.CARD_NAME = ds.Tables[0].Rows[0]["CARD_NAME"].ToString();
                model.CARD_MESSAGE = ds.Tables[0].Rows[0]["CARD_MESSAGE"].ToString();
                model.INV_PAYEE = ds.Tables[0].Rows[0]["INV_PAYEE"].ToString();
                model.INV_CONTENT = ds.Tables[0].Rows[0]["INV_CONTENT"].ToString();
                if (ds.Tables[0].Rows[0]["GOODS_AMOUNT"].ToString() != "")
                {
                    model.GOODS_AMOUNT = decimal.Parse(ds.Tables[0].Rows[0]["GOODS_AMOUNT"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SHIPPING_FEE"].ToString() != "")
                {
                    model.SHIPPING_FEE = decimal.Parse(ds.Tables[0].Rows[0]["SHIPPING_FEE"].ToString());
                }
                if (ds.Tables[0].Rows[0]["INSURE_FEE"].ToString() != "")
                {
                    model.INSURE_FEE = decimal.Parse(ds.Tables[0].Rows[0]["INSURE_FEE"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PAY_FEE"].ToString() != "")
                {
                    model.PAY_FEE = decimal.Parse(ds.Tables[0].Rows[0]["PAY_FEE"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PACK_FEE"].ToString() != "")
                {
                    model.PACK_FEE = decimal.Parse(ds.Tables[0].Rows[0]["PACK_FEE"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CARD_FEE"].ToString() != "")
                {
                    model.CARD_FEE = decimal.Parse(ds.Tables[0].Rows[0]["CARD_FEE"].ToString());
                }
                if (ds.Tables[0].Rows[0]["MONEY_PAID"].ToString() != "")
                {
                    model.MONEY_PAID = decimal.Parse(ds.Tables[0].Rows[0]["MONEY_PAID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SURPLUS"].ToString() != "")
                {
                    model.SURPLUS = decimal.Parse(ds.Tables[0].Rows[0]["SURPLUS"].ToString());
                }
                if (ds.Tables[0].Rows[0]["INTEGRAL"].ToString() != "")
                {
                    model.INTEGRAL = int.Parse(ds.Tables[0].Rows[0]["INTEGRAL"].ToString());
                }
                if (ds.Tables[0].Rows[0]["INTEGRALl_MONEY"].ToString() != "")
                {
                    model.INTEGRALl_MONEY = decimal.Parse(ds.Tables[0].Rows[0]["INTEGRALl_MONEY"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BONUS"].ToString() != "")
                {
                    model.BONUS = decimal.Parse(ds.Tables[0].Rows[0]["BONUS"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ORDER_AMOUNT"].ToString() != "")
                {
                    model.ORDER_AMOUNT = decimal.Parse(ds.Tables[0].Rows[0]["ORDER_AMOUNT"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FROM_AD"].ToString() != "")
                {
                    model.FROM_AD = int.Parse(ds.Tables[0].Rows[0]["FROM_AD"].ToString());
                }
                model.REFERER = ds.Tables[0].Rows[0]["REFERER"].ToString();
                if (ds.Tables[0].Rows[0]["ADD_TIME"].ToString() != "")
                {
                    model.ADD_TIME = DateTime.Parse(ds.Tables[0].Rows[0]["ADD_TIME"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CONFIRM_TIME"].ToString() != "")
                {
                    model.CONFIRM_TIME = DateTime.Parse(ds.Tables[0].Rows[0]["CONFIRM_TIME"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PAY_TIME"].ToString() != "")
                {
                    model.PAY_TIME = DateTime.Parse(ds.Tables[0].Rows[0]["PAY_TIME"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SHIPPING_TIME"].ToString() != "")
                {
                    model.SHIPPING_TIME = DateTime.Parse(ds.Tables[0].Rows[0]["SHIPPING_TIME"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PACK_ID"].ToString() != "")
                {
                    model.PACK_ID = int.Parse(ds.Tables[0].Rows[0]["PACK_ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CARD_ID"].ToString() != "")
                {
                    model.CARD_ID = int.Parse(ds.Tables[0].Rows[0]["CARD_ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BONUS_ID"].ToString() != "")
                {
                    model.BONUS_ID = int.Parse(ds.Tables[0].Rows[0]["BONUS_ID"].ToString());
                }
                model.INVOICE_NO = ds.Tables[0].Rows[0]["INVOICE_NO"].ToString();
                model.EXTENSION_CODE = ds.Tables[0].Rows[0]["EXTENSION_CODE"].ToString();
                if (ds.Tables[0].Rows[0]["EXTENSION_ID"].ToString() != "")
                {
                    model.EXTENSION_ID = int.Parse(ds.Tables[0].Rows[0]["EXTENSION_ID"].ToString());
                }
                model.TO_BUYER = ds.Tables[0].Rows[0]["TO_BUYER"].ToString();
                model.PAY_NOTE = ds.Tables[0].Rows[0]["PAY_NOTE"].ToString();
                if (ds.Tables[0].Rows[0]["AGENCY_ID"].ToString() != "")
                {
                    model.AGENCY_ID = int.Parse(ds.Tables[0].Rows[0]["AGENCY_ID"].ToString());
                }
                model.INV_TYPE = ds.Tables[0].Rows[0]["INV_TYPE"].ToString();
                if (ds.Tables[0].Rows[0]["TAX"].ToString() != "")
                {
                    model.TAX = decimal.Parse(ds.Tables[0].Rows[0]["TAX"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IS_SEPARATE"].ToString() != "")
                {
                    model.IS_SEPARATE = int.Parse(ds.Tables[0].Rows[0]["IS_SEPARATE"].ToString());
                }
                model.PARENT_ID = ds.Tables[0].Rows[0]["PARENT_ID"].ToString();
                if (ds.Tables[0].Rows[0]["DISCOUNT"].ToString() != "")
                {
                    model.DISCOUNT = decimal.Parse(ds.Tables[0].Rows[0]["DISCOUNT"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ORDER_TYPE"].ToString() != "")
                {
                    model.ORDER_TYPE = int.Parse(ds.Tables[0].Rows[0]["ORDER_TYPE"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ACTUAL_GOODS_AMOUNT"].ToString() != "")
                {
                    model.ACTUAL_GOODS_AMOUNT = decimal.Parse(ds.Tables[0].Rows[0]["ACTUAL_GOODS_AMOUNT"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PRINT_STATUS"].ToString() != "")
                {
                    model.PRINT_STATUS = int.Parse(ds.Tables[0].Rows[0]["PRINT_STATUS"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        //获得省份
        public DataSet GetAreaInfo()
        {
            StringBuilder strql = new StringBuilder();
            strql.Append("select * from BASE_REGION");
            return DbHelperSQL.Query(strql.ToString());
        }

        public string GetMaxCode()
        {
            string code = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ISNULL(max(CONVERT(DECIMAL,ORDER_ID)), 0) AS ORDER_SN from BLL_ORDER_INFO");

            code = DbHelperSQL.GetSingle(strSql.ToString()).ToString();
            if (code == "")
            {
                code = "1";
            }
            else
            {
                code = (CConvert.ToInt32(code) + 1).ToString();
            }
            return code;
        }


        public string GetMaxOrderSn()
        {
            string aa = DateTime.Now.ToString("yyyyMMdd").Substring(2);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ISNULL(max(CONVERT(DECIMAL,ORDER_SN)), 0) AS ORDER_SN from BLL_ORDER_INFO where order_sn like '" + aa + "'%");

            int obj = CConvert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()).ToString());

            string orderSn = "";

            if (obj == 0)
            {
                orderSn = aa + "0001";
            }
            else
            {
                orderSn = (obj + 1).ToString();
            }
            return orderSn;
        }


        /// <summary>
        /// 获得分页数据总的记录条数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BLL_ORDER_INFO");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 获得分页数据列表
        /// </summary>
        public DataSet GetList(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.ORDER_ID DESC");
            }
            strSql.Append(")AS Row, T.* from BLL_ORDER_INFO T");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        //不分页的情况下获得订单信息
        public DataSet GetOrderTable(string strWhre)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("SELECT * FROM BLL_ORDER_INFO WHERE {0}", strWhre);
            return DbHelperSQL.Query(strSql.ToString());
        }

        public int DeleteOrderInfo(int ORDER_ID, int ORDER_TYPE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update BLL_ORDER_INFO set ORDER_STATUS={0} where ORDER_ID={1} and ORDER_TYPE={2}", CConstant.ORDER_STATUS_DELETE, ORDER_ID, ORDER_TYPE);
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            return rows;
        }

        public int UpdatePrintStatus(int ORDER_ID, int ORDER_TYPE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update BLL_ORDER_INFO set PRINT_STATUS={0} where ORDER_ID={1} and ORDER_TYPE={2}", CConstant.PRINT_TYPE_TWO, ORDER_ID, ORDER_TYPE);
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            return rows;
        }

        public int LibraryDeter(BaseOrderInfoTable orderInfotable, BaseSendOrderTable sendTable)
        {
            StringBuilder strSql = new StringBuilder();
            List<CommandInfo> listSql = new List<CommandInfo>();
            strSql.Append("UPDATE BLL_ORDER_INFO SET SHIPPING_STATUS=@SHIPPING_STATUS,ACTUAL_GOODS_AMOUNT=@ACTUAL_GOODS_AMOUNT WHERE ORDER_SN=@ORDER_SN AND ORDER_TYPE=@ORDER_TYPE");
            SqlParameter[] orederInfoParameters = {
                    new SqlParameter("@SHIPPING_STATUS",SqlDbType.Int),
                    new SqlParameter("@ACTUAL_GOODS_AMOUNT",SqlDbType.Decimal),
					new SqlParameter("@ORDER_SN",  SqlDbType.VarChar,20),                    
					new SqlParameter("@ORDER_TYPE", SqlDbType.Int)};
            orederInfoParameters[0].Value = orderInfotable.SHIPPING_STATUS;
            orederInfoParameters[1].Value = orderInfotable.ACTUAL_GOODS_AMOUNT;
            orederInfoParameters[2].Value = orderInfotable.ORDER_SN;
            orederInfoParameters[3].Value = orderInfotable.ORDER_TYPE;
            listSql.Add(new CommandInfo(strSql.ToString(), orederInfoParameters));

            if (orderInfotable.ORDER_TYPE != CConstant.SLIPNUMBER_LOCAL_TYPE)
            {
                strSql = new StringBuilder();
                strSql.Append("insert into BLL_SEND_ORDER(");
                strSql.Append("ORDER_ID,ORDER_SN,ACTUAL_GOODS_AMOUNT,SEND_STATUS,CREATE_DATE_TIME,COMMUNITY_CODE,GOODS_AMOUNT)");
                strSql.Append(" values (");
                strSql.Append("@ORDER_ID,@ORDER_SN,@ACTUAL_GOODS_AMOUNT,@SEND_STATUS,@CREATE_DATE_TIME,@COMMUNITY_CODE,@GOODS_AMOUNT)");
                SqlParameter[] sendParameters = {
					new SqlParameter("@ORDER_ID", SqlDbType.Decimal),
					new SqlParameter("@ORDER_SN", SqlDbType.VarChar,20),
					new SqlParameter("@ACTUAL_GOODS_AMOUNT", SqlDbType.Decimal),
					new SqlParameter("@SEND_STATUS", SqlDbType.Int),
					new SqlParameter("@CREATE_DATE_TIME", SqlDbType.DateTime),
                    new SqlParameter("@COMMUNITY_CODE", SqlDbType.Int),
                    new SqlParameter("@GOODS_AMOUNT", SqlDbType.Decimal)};
                sendParameters[0].Value = sendTable.ORDER_ID;
                sendParameters[1].Value = sendTable.ORDER_SN;
                sendParameters[2].Value = sendTable.ACTUAL_GOODS_AMOUNT;
                sendParameters[3].Value = sendTable.SEND_STATUS;
                sendParameters[4].Value = sendTable.CREATE_DATE_TIME;
                sendParameters[5].Value = sendTable.COMMUNITY_CODE;
                sendParameters[6].Value = sendTable.GOODS_AMOUNT;
                listSql.Add(new CommandInfo(strSql.ToString(), sendParameters));

                foreach (BaseSendOrderInfoTable sendOrderInfoTable in sendTable.ITEMS)
                {
                    strSql = new StringBuilder();
                    strSql.Append("insert into BLL_SEND_ORDER_LINE(");
                    strSql.Append("REC_ID,ORDER_ID,GOODS_ID,GOODS_SN,ACTUAL_NUMBER,GOODS_PRICE,ACTUAL_AMOUNT)");
                    strSql.Append(" values (");
                    strSql.Append("@REC_ID,@ORDER_ID,@GOODS_ID,@GOODS_SN,@ACTUAL_NUMBER,@GOODS_PRICE,@ACTUAL_AMOUNT)");
                    SqlParameter[] sendInfoParameters = {
					new SqlParameter("@REC_ID", SqlDbType.Int),
					new SqlParameter("@ORDER_ID", SqlDbType.Decimal),
					new SqlParameter("@GOODS_ID", SqlDbType.Int),
					new SqlParameter("@GOODS_SN", SqlDbType.VarChar,50),
					new SqlParameter("@ACTUAL_NUMBER", SqlDbType.Decimal),
					new SqlParameter("@GOODS_PRICE", SqlDbType.Decimal),
					new SqlParameter("@ACTUAL_AMOUNT", SqlDbType.Decimal)};
                    sendInfoParameters[0].Value = sendOrderInfoTable.REC_ID;
                    sendInfoParameters[1].Value = sendOrderInfoTable.ORDER_ID;
                    sendInfoParameters[2].Value = sendOrderInfoTable.GOODS_ID;
                    sendInfoParameters[3].Value = sendOrderInfoTable.GOODS_SN;
                    sendInfoParameters[4].Value = sendOrderInfoTable.ACTUAL_NUMBER;
                    sendInfoParameters[5].Value = sendOrderInfoTable.GOODS_PRICE;
                    sendInfoParameters[6].Value = sendOrderInfoTable.ACTUAL_AMOUNT;
                    listSql.Add(new CommandInfo(strSql.ToString(), sendInfoParameters));
                }
            }
            int i = DbHelperSQL.ExecuteSqlTran(listSql);
            return i;
        }

        //获得这个小区的最大编号
        public string GetMaxQuCode(string COMMUNITY)
        {
            string code = "";
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select ISNULL(max(COMMUNITY_CODE), 0) AS COMMUNITY_CODE from BLL_ORDER_INFO where SHIPPING_STATUS={0} AND COMMUNITY='{1}'", CConstant.ShIPPING_TWO, COMMUNITY);

            code = DbHelperSQL.GetSingle(strSql.ToString()).ToString();
            if (code == "")
            {
                code = "1";
            }
            else
            {
                code = (CConvert.ToInt32(code) + 1).ToString();
            }
            return code;
        }

        //修改订单的出货状态并在出货表插入数据
        public int AddDeliveryInfo(BaseOrderInfoTable model, BaseDeliveryTable deTable,BaseSendOrderStatusTable sendTable)
        {
            List<CommandInfo> listSql = new List<CommandInfo>();
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
            strSql.Append("ACTUAL_GOODS_AMOUNT=@ACTUAL_GOODS_AMOUNT,");
            strSql.Append("PRINT_STATUS=@PRINT_STATUS,");
            strSql.Append("COMMUNITY=@COMMUNITY,");
            strSql.Append("COMMUNITY_CODE=@COMMUNITY_CODE");
            strSql.Append(" where ORDER_ID=@ORDER_ID and ORDER_TYPE=@ORDER_TYPE ");
            SqlParameter[] parametersSend = {
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
					new SqlParameter("@BEST_TIME", SqlDbType.DateTime),
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
					new SqlParameter("@BONUS_ID", SqlDbType.Int,4),
					new SqlParameter("@INVOICE_NO", SqlDbType.VarChar,50),
					new SqlParameter("@EXTENSION_CODE", SqlDbType.VarChar,30),
					new SqlParameter("@EXTENSION_ID", SqlDbType.Int,4),
					new SqlParameter("@TO_BUYER", SqlDbType.VarChar,255),
					new SqlParameter("@PAY_NOTE", SqlDbType.VarChar,255),
					new SqlParameter("@AGENCY_ID", SqlDbType.Int,4),
					new SqlParameter("@INV_TYPE", SqlDbType.VarChar,60),
					new SqlParameter("@TAX", SqlDbType.Decimal,9),
					new SqlParameter("@IS_SEPARATE", SqlDbType.Int,4),
					new SqlParameter("@PARENT_ID", SqlDbType.NChar,10),
					new SqlParameter("@DISCOUNT", SqlDbType.Decimal,9),
					new SqlParameter("@ORDER_TYPE", SqlDbType.Int,4),
					new SqlParameter("@ACTUAL_GOODS_AMOUNT", SqlDbType.Decimal),
					new SqlParameter("@PRINT_STATUS", SqlDbType.Int,4),
                    new SqlParameter("@COMMUNITY",SqlDbType.VarChar,50),
                    new SqlParameter("@COMMUNITY_CODE",SqlDbType.Int)};
            parametersSend[0].Value = model.ORDER_ID;
            parametersSend[1].Value = model.ORDER_SN;
            parametersSend[2].Value = model.USER_ID;
            parametersSend[3].Value = model.ORDER_STATUS;
            parametersSend[4].Value = model.SHIPPING_STATUS;
            parametersSend[5].Value = model.PAY_STATUS;
            parametersSend[6].Value = model.CONSIGNEE;
            parametersSend[7].Value = model.COUNTRY;
            parametersSend[8].Value = model.PROVINCE;
            parametersSend[9].Value = model.CITY;
            parametersSend[10].Value = model.DISTRICT;
            parametersSend[11].Value = model.ADDRESS;
            parametersSend[12].Value = model.ZIPCODE;
            parametersSend[13].Value = model.TEL;
            parametersSend[14].Value = model.MOBILE;
            parametersSend[15].Value = model.EMAIL;
            parametersSend[16].Value = model.BEST_TIME;
            parametersSend[17].Value = model.SIGN_BUILDING;
            parametersSend[18].Value = model.POST_SCRIPT;
            parametersSend[19].Value = model.SHIPPING_ID;
            parametersSend[20].Value = model.SHIPPING_NAME;
            parametersSend[21].Value = model.PAY_ID;
            parametersSend[22].Value = model.PAY_NAME;
            parametersSend[23].Value = model.HOW_OOS;
            parametersSend[24].Value = model.HOW_SURPLUS;
            parametersSend[25].Value = model.PACK_NAME;
            parametersSend[26].Value = model.CARD_NAME;
            parametersSend[27].Value = model.CARD_MESSAGE;
            parametersSend[28].Value = model.INV_PAYEE;
            parametersSend[29].Value = model.INV_CONTENT;
            parametersSend[30].Value = model.GOODS_AMOUNT;
            parametersSend[31].Value = model.SHIPPING_FEE;
            parametersSend[32].Value = model.INSURE_FEE;
            parametersSend[33].Value = model.PAY_FEE;
            parametersSend[34].Value = model.PACK_FEE;
            parametersSend[35].Value = model.CARD_FEE;
            parametersSend[36].Value = model.MONEY_PAID;
            parametersSend[37].Value = model.SURPLUS;
            parametersSend[38].Value = model.INTEGRAL;
            parametersSend[39].Value = model.INTEGRALl_MONEY;
            parametersSend[40].Value = model.BONUS;
            parametersSend[41].Value = model.ORDER_AMOUNT;
            parametersSend[42].Value = model.FROM_AD;
            parametersSend[43].Value = model.REFERER;
            parametersSend[44].Value = model.ADD_TIME;
            parametersSend[45].Value = model.CONFIRM_TIME;
            parametersSend[46].Value = model.PAY_TIME;
            parametersSend[47].Value = model.SHIPPING_TIME;
            parametersSend[48].Value = model.PACK_ID;
            parametersSend[49].Value = model.CARD_ID;
            parametersSend[50].Value = model.BONUS_ID;
            parametersSend[51].Value = model.INVOICE_NO;
            parametersSend[52].Value = model.EXTENSION_CODE;
            parametersSend[53].Value = model.EXTENSION_ID;
            parametersSend[54].Value = model.TO_BUYER;
            parametersSend[55].Value = model.PAY_NOTE;
            parametersSend[56].Value = model.AGENCY_ID;
            parametersSend[57].Value = model.INV_TYPE;
            parametersSend[58].Value = model.TAX;
            parametersSend[59].Value = model.IS_SEPARATE;
            parametersSend[60].Value = model.PARENT_ID;
            parametersSend[61].Value = model.DISCOUNT;
            parametersSend[62].Value = model.ORDER_TYPE;
            parametersSend[63].Value = model.ACTUAL_GOODS_AMOUNT;
            parametersSend[64].Value = model.PRINT_STATUS;
            parametersSend[65].Value = model.COMMUNITY;
            parametersSend[66].Value = model.COMMUNITY_CODE;
            listSql.Add(new CommandInfo(strSql.ToString(), parametersSend));

            strSql = new StringBuilder();
            strSql.Append("insert into BLL_DELIVERY(");
            strSql.Append("DELIVERY_CODE,ORDER_ID,CONSIGNEE,COMMUNITY_CODE,STATUS_FLAG)");
            strSql.Append(" values (");
            strSql.Append("@DELIVERY_CODE,@ORDER_ID,@CONSIGNEE,@COMMUNITY_CODE,@STATUS_FLAG)");
            SqlParameter[] parametersDetable = {
					new SqlParameter("@DELIVERY_CODE", SqlDbType.VarChar,50),
					new SqlParameter("@ORDER_ID", SqlDbType.Decimal,5),
					new SqlParameter("@CONSIGNEE", SqlDbType.VarChar,50),
					new SqlParameter("@COMMUNITY_CODE", SqlDbType.Int,4),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4)};
            parametersDetable[0].Value = deTable.DELIVERY_CODE;
            parametersDetable[1].Value = deTable.ORDER_ID;
            parametersDetable[2].Value = deTable.CONSIGNEE;
            parametersDetable[3].Value = deTable.COMMUNITY_CODE;
            parametersDetable[4].Value = deTable.STATUS_FLAG;
            listSql.Add(new CommandInfo(strSql.ToString(), parametersDetable));

            strSql = new StringBuilder();
            strSql.Append("insert into BLL_SEND_ORDER_STATUS(");
            strSql.Append("ORDER_ID,ORDER_SN,ORDER_STATUS,SEND_STATUS,CREATE_DATE_TIME)");
            strSql.Append(" values (");
            strSql.Append("@ORDER_ID,@ORDER_SN,@ORDER_STATUS,@SEND_STATUS,@CREATE_DATE_TIME)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parametersSendStatus = {
					new SqlParameter("@ORDER_ID", SqlDbType.Decimal,5),
					new SqlParameter("@ORDER_SN", SqlDbType.VarChar,20),
					new SqlParameter("@ORDER_STATUS", SqlDbType.Int,4),
					new SqlParameter("@SEND_STATUS", SqlDbType.Int,4),
					new SqlParameter("@CREATE_DATE_TIME", SqlDbType.DateTime)};
            parametersSendStatus[0].Value = sendTable.ORDER_ID;
            parametersSendStatus[1].Value = sendTable.ORDER_SN;
            parametersSendStatus[2].Value = sendTable.ORDER_STATUS;
            parametersSendStatus[3].Value = sendTable.SEND_STATUS;
            parametersSendStatus[4].Value = sendTable.CREATE_DATE_TIME;
            listSql.Add(new CommandInfo(strSql.ToString(), parametersSendStatus));

            return DbHelperSQL.ExecuteSqlTran(listSql);
        }

        //获得出货表最大的出货编号
        public string GetMaxDeliveryCode()
        {
            string code = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ISNULL(max(DELIVERY_CODE), 0) AS DELIVERY_CODE from BLL_DELIVERY ");

            code = DbHelperSQL.GetSingle(strSql.ToString()).ToString();
            if (code == "0")
            {
                code = "GS_" + DateTime.Now.ToString("yyyyMMdd");
            }
            else
            {
                string[] AllCode = code.Split('_');
                string Code1 = AllCode[1].ToString();
                code = AllCode[0] + "_" + (CConvert.ToInt32(Code1) + 1).ToString();
            }
            return code;
        }
        #endregion  Method
    }
}
