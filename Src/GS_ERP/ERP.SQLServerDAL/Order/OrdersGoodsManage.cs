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
    public class OrdersGoodsManage:IOrderGoods
    {
        public OrdersGoodsManage()
		{}
		#region  Method

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public BaseOrdersGoodsTable GetModel(int ORDER_TYPE,decimal ORDER_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 REC_ID,ORDER_ID,GOODS_ID,GOODS_NAME,GOODS_SN,GOODS_NUMBER,MARKET_PRICE,GOODS_PRICE,GOODS_ATTR,SEND_NUMBER,IS_REAL,EXTENSION_CODE,PARENT_ID,IS_GIFT,ORDER_TYPE,ACTUAL_AMOUNT,ACTUAL_NUMBER from BLL_ORDER_GOODS ");
			strSql.Append(" where  ORDER_TYPE=@ORDER_TYPE and ORDER_ID=@ORDER_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ORDER_TYPE", SqlDbType.Int,4),
					new SqlParameter("@ORDER_ID", SqlDbType.Int,4)};
			parameters[0].Value = ORDER_TYPE;
			parameters[1].Value = ORDER_ID;

            BaseOrdersGoodsTable model = new BaseOrdersGoodsTable();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["REC_ID"].ToString()!="")
				{
					model.REC_ID=int.Parse(ds.Tables[0].Rows[0]["REC_ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ORDER_ID"].ToString()!="")
				{
                    model.ORDER_ID = decimal.Parse(ds.Tables[0].Rows[0]["ORDER_ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["GOODS_ID"].ToString()!="")
				{
					model.GOODS_ID=int.Parse(ds.Tables[0].Rows[0]["GOODS_ID"].ToString());
				}
				model.GOODS_NAME=ds.Tables[0].Rows[0]["GOODS_NAME"].ToString();
				model.GOODS_SN=ds.Tables[0].Rows[0]["GOODS_SN"].ToString();
				if(ds.Tables[0].Rows[0]["GOODS_NUMBER"].ToString()!="")
				{
					model.GOODS_NUMBER=int.Parse(ds.Tables[0].Rows[0]["GOODS_NUMBER"].ToString());
				}
				if(ds.Tables[0].Rows[0]["MARKET_PRICE"].ToString()!="")
				{
					model.MARKET_PRICE=decimal.Parse(ds.Tables[0].Rows[0]["MARKET_PRICE"].ToString());
				}
				if(ds.Tables[0].Rows[0]["GOODS_PRICE"].ToString()!="")
				{
					model.GOODS_PRICE=decimal.Parse(ds.Tables[0].Rows[0]["GOODS_PRICE"].ToString());
				}
				model.GOODS_ATTR=ds.Tables[0].Rows[0]["GOODS_ATTR"].ToString();
				if(ds.Tables[0].Rows[0]["SEND_NUMBER"].ToString()!="")
				{
					model.SEND_NUMBER=int.Parse(ds.Tables[0].Rows[0]["SEND_NUMBER"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IS_REAL"].ToString()!="")
				{
					model.IS_REAL=int.Parse(ds.Tables[0].Rows[0]["IS_REAL"].ToString());
				}
				model.EXTENSION_CODE=ds.Tables[0].Rows[0]["EXTENSION_CODE"].ToString();
				if(ds.Tables[0].Rows[0]["PARENT_ID"].ToString()!="")
				{
					model.PARENT_ID=int.Parse(ds.Tables[0].Rows[0]["PARENT_ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IS_GIFT"].ToString()!="")
				{
					model.IS_GIFT=int.Parse(ds.Tables[0].Rows[0]["IS_GIFT"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ORDER_TYPE"].ToString()!="")
				{
					model.ORDER_TYPE=int.Parse(ds.Tables[0].Rows[0]["ORDER_TYPE"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ACTUAL_AMOUNT"].ToString()!="")
				{
					model.ACTUAL_AMOUNT=decimal.Parse(ds.Tables[0].Rows[0]["ACTUAL_AMOUNT"].ToString());
				}
                if (ds.Tables[0].Rows[0]["ACTUAL_NUMBER"].ToString() != "")
				{
                    model.ACTUAL_NUMBER = decimal.Parse(ds.Tables[0].Rows[0]["ACTUAL_NUMBER"].ToString());
				}
				return model;
			}
			else
			{
				return null;
			}
		}

        public DataSet GetGoodsInfo(int ORDER_TYPE, decimal ORDER_ID) 
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
