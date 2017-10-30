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
    public class OrderInfoManage : IOrderInfo
    {
        public OrderInfoManage()
        { }
        #region  Method


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BaseOrderInfoTable GetModel(int ORDER_ID, int ORDER_TYPE)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ORDER_ID,ORDER_SN,USER_ID,ORDER_STATUS,SHIPPING_STATUS,PAY_STATUS,CONSIGNEE,COUNTRY,PROVINCE,CITY,DISTRICT,ADDRESS,ZIPCODE,TEL,MOBILE,EMAIL,BEST_TIME,SIGN_BUILDING,POST_SCRIPT,SHIPPING_ID,SHIPPING_NAME,PAY_ID,PAY_NAME,HOW_OOS,HOW_SURPLUS,PACK_NAME,CARD_NAME,CARD_MESSAGE,INV_PAYEE,INV_CONTENT,GOODS_AMOUNT,SHIPPING_FEE,INSURE_FEE,PAY_FEE,PACK_FEE,CARD_FEE,MONEY_PAID,SURPLUS,INTEGRAL,INTEGRALl_MONEY,BONUS,ORDER_AMOUNT,FROM_AD,REFERER,ADD_TIME,CONFIRM_TIME,PAY_TIME,SHIPPING_TIME,PACK_ID,CARD_ID,BONUS_ID,INVOICE_NO,EXTENSION_CODE,EXTENSION_ID,TO_BUYER,PAY_NOTE,AGENCY_ID,INV_TYPE,TAX,IS_SEPARATE,PARENT_ID,DISCOUNT,ORDER_TYPE,ACTUAL_AMOUNT,PRINT_STATUS from BLL_ORDER_INFO ");
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
                if (ds.Tables[0].Rows[0]["ACTUAL_AMOUNT"].ToString() != "")
                {
                    model.ACTUAL_AMOUNT = decimal.Parse(ds.Tables[0].Rows[0]["ACTUAL_AMOUNT"].ToString());
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

        //获得未打印的订单
        public DataSet GetNoPrintSlipNumber() 
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("SELECT * FROM BLL_ORDER_INFO WHERE PRINT_STATUS={0}", CConstant.PRINT_TYPE_ONE);
            return DbHelperSQL.Query(strSql.ToString());
        }

        public int UpdatePrintStatus(int ORDER_TYPE, string ORDER_SN)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update BLL_ORDER_INFO set PRINT_STATUS={0} where ORDER_TYPE={1} and ORDER_SN={2}", CConstant.PRINT_TYPE_TWO, ORDER_TYPE, ORDER_SN);
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            return rows;
        }
        #endregion  Method
    }
}
