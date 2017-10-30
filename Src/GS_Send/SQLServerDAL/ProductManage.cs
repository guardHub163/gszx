using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CZZD.GSZX.S.DBUtility;
using CZZD.GSZX.S.Model;

namespace CZZD.GSZX.S.SQLServerDAL
{
    public class ProductManage
    {
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int goodsId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_PRODUCT");
            strSql.Append(" where GOODS_ID=@GOODS_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@GOODS_ID", SqlDbType.Int,4)};
            parameters[0].Value = goodsId;

            return DbHelperSqlServer.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BaseProductTable model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BASE_PRODUCT(");
            strSql.Append("GOODS_ID,CAT_ID,GOODS_SN,GOODS_NAME,GOODS_NAME_STYLE,CLICK_COUNT,BRAND_ID,PROVIDER_NAME,GOODS_NUMBER,GOODS_WEIGHT,MARKET_PRICE,SHOP_PRICE,PROMOTE_PRICE,PROMOTE_START_DATE,PROMOTE_END_DATE,WARN_NUMBER,KEYWORDS,GOODS_BRIEF,GOODS_DESC,GOODS_THUMB,GOODS_IMG,ORIGINAL_IMG,IS_REAL,EXTENSION_CODE,IS_ON_SALE,IS_ALONE_SALE,INTEGRAL,ADD_TIME,SORT_ORDER,IS_BEST,IS_DELETE,IS_NEW,IS_HOT,IS_PROMOTE,BONUS_TYPE_ID,LAST_UPDATE,GOODS_TYPE,SELLER_NOTE,GIVE_INTEGRAL)");
            strSql.Append(" values (");
            strSql.Append("@GOODS_ID,@CAT_ID,@GOODS_SN,@GOODS_NAME,@GOODS_NAME_STYLE,@CLICK_COUNT,@BRAND_ID,@PROVIDER_NAME,@GOODS_NUMBER,@GOODS_WEIGHT,@MARKET_PRICE,@SHOP_PRICE,@PROMOTE_PRICE,@PROMOTE_START_DATE,@PROMOTE_END_DATE,@WARN_NUMBER,@KEYWORDS,@GOODS_BRIEF,@GOODS_DESC,@GOODS_THUMB,@GOODS_IMG,@ORIGINAL_IMG,@IS_REAL,@EXTENSION_CODE,@IS_ON_SALE,@IS_ALONE_SALE,@INTEGRAL,@ADD_TIME,@SORT_ORDER,@IS_BEST,@IS_DELETE,@IS_NEW,@IS_HOT,@IS_PROMOTE,@BONUS_TYPE_ID,@LAST_UPDATE,@GOODS_TYPE,@SELLER_NOTE,@GIVE_INTEGRAL)");
            SqlParameter[] parameters = {
					new SqlParameter("@GOODS_ID", SqlDbType.Int,4),
					new SqlParameter("@CAT_ID", SqlDbType.Int,4),
					new SqlParameter("@GOODS_SN", SqlDbType.VarChar,60),
					new SqlParameter("@GOODS_NAME", SqlDbType.VarChar,120),
					new SqlParameter("@GOODS_NAME_STYLE", SqlDbType.VarChar,60),
					new SqlParameter("@CLICK_COUNT", SqlDbType.Int,4),
					new SqlParameter("@BRAND_ID", SqlDbType.Int,4),
					new SqlParameter("@PROVIDER_NAME", SqlDbType.VarChar,100),
					new SqlParameter("@GOODS_NUMBER", SqlDbType.Int,4),
					new SqlParameter("@GOODS_WEIGHT", SqlDbType.Decimal,9),
					new SqlParameter("@MARKET_PRICE", SqlDbType.Decimal,9),
					new SqlParameter("@SHOP_PRICE", SqlDbType.Decimal,9),
					new SqlParameter("@PROMOTE_PRICE", SqlDbType.Decimal,9),
					new SqlParameter("@PROMOTE_START_DATE", SqlDbType.Int,4),
					new SqlParameter("@PROMOTE_END_DATE", SqlDbType.Int,4),
					new SqlParameter("@WARN_NUMBER", SqlDbType.Int,4),
					new SqlParameter("@KEYWORDS", SqlDbType.VarChar,255),
					new SqlParameter("@GOODS_BRIEF", SqlDbType.VarChar,255),
					new SqlParameter("@GOODS_DESC", SqlDbType.Text),
					new SqlParameter("@GOODS_THUMB", SqlDbType.VarChar,255),
					new SqlParameter("@GOODS_IMG", SqlDbType.VarChar,255),
					new SqlParameter("@ORIGINAL_IMG", SqlDbType.VarChar,255),
					new SqlParameter("@IS_REAL", SqlDbType.Int,4),
					new SqlParameter("@EXTENSION_CODE", SqlDbType.VarChar,30),
					new SqlParameter("@IS_ON_SALE", SqlDbType.Int,4),
					new SqlParameter("@IS_ALONE_SALE", SqlDbType.Int,4),
					new SqlParameter("@INTEGRAL", SqlDbType.Int,4),
					new SqlParameter("@ADD_TIME", SqlDbType.Int,4),
					new SqlParameter("@SORT_ORDER", SqlDbType.Int,4),
					new SqlParameter("@IS_BEST", SqlDbType.Int,4),
					new SqlParameter("@IS_DELETE", SqlDbType.Int,4),
					new SqlParameter("@IS_NEW", SqlDbType.Int,4),
					new SqlParameter("@IS_HOT", SqlDbType.Int,4),
					new SqlParameter("@IS_PROMOTE", SqlDbType.Int,4),
					new SqlParameter("@BONUS_TYPE_ID", SqlDbType.Int,4),
					new SqlParameter("@LAST_UPDATE", SqlDbType.Int,4),
					new SqlParameter("@GOODS_TYPE", SqlDbType.Int,4),
					new SqlParameter("@SELLER_NOTE", SqlDbType.VarChar,255),
					new SqlParameter("@GIVE_INTEGRAL", SqlDbType.Int,4)};
            parameters[0].Value = model.GOODS_ID;
            parameters[1].Value = model.CAT_ID;
            parameters[2].Value = model.GOODS_SN;
            parameters[3].Value = model.GOODS_NAME;
            parameters[4].Value = model.GOODS_NAME_STYLE;
            parameters[5].Value = model.CLICK_COUNT;
            parameters[6].Value = model.BRAND_ID;
            parameters[7].Value = model.PROVIDER_NAME;
            parameters[8].Value = model.GOODS_NUMBER;
            parameters[9].Value = model.GOODS_WEIGHT;
            parameters[10].Value = model.MARKET_PRICE;
            parameters[11].Value = model.SHOP_PRICE;
            parameters[12].Value = model.PROMOTE_PRICE;
            parameters[13].Value = model.PROMOTE_START_DATE;
            parameters[14].Value = model.PROMOTE_END_DATE;
            parameters[15].Value = model.WARN_NUMBER;
            parameters[16].Value = model.KEYWORDS;
            parameters[17].Value = model.GOODS_BRIEF;
            parameters[18].Value = model.GOODS_DESC;
            parameters[19].Value = model.GOODS_THUMB;
            parameters[20].Value = model.GOODS_IMG;
            parameters[21].Value = model.ORIGINAL_IMG;
            parameters[22].Value = model.IS_REAL;
            parameters[23].Value = model.EXTENSION_CODE;
            parameters[24].Value = model.IS_ON_SALE;
            parameters[25].Value = model.IS_ALONE_SALE;
            parameters[26].Value = model.INTEGRAL;
            parameters[27].Value = model.ADD_TIME;
            parameters[28].Value = model.SORT_ORDER;
            parameters[29].Value = model.IS_BEST;
            parameters[30].Value = model.IS_DELETE;
            parameters[31].Value = model.IS_NEW;
            parameters[32].Value = model.IS_HOT;
            parameters[33].Value = model.IS_PROMOTE;
            parameters[34].Value = model.BONUS_TYPE_ID;
            parameters[35].Value = model.LAST_UPDATE;
            parameters[36].Value = model.GOODS_TYPE;
            parameters[37].Value = model.SELLER_NOTE;
            parameters[38].Value = model.GIVE_INTEGRAL;

            return DbHelperSqlServer.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(BaseProductTable model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BASE_PRODUCT set ");
            strSql.Append("CAT_ID=@CAT_ID,");
            strSql.Append("GOODS_SN=@GOODS_SN,");
            strSql.Append("GOODS_NAME=@GOODS_NAME,");
            strSql.Append("GOODS_NAME_STYLE=@GOODS_NAME_STYLE,");
            strSql.Append("CLICK_COUNT=@CLICK_COUNT,");
            strSql.Append("BRAND_ID=@BRAND_ID,");
            strSql.Append("PROVIDER_NAME=@PROVIDER_NAME,");
            strSql.Append("GOODS_NUMBER=@GOODS_NUMBER,");
            strSql.Append("GOODS_WEIGHT=@GOODS_WEIGHT,");
            strSql.Append("MARKET_PRICE=@MARKET_PRICE,");
            strSql.Append("SHOP_PRICE=@SHOP_PRICE,");
            strSql.Append("PROMOTE_PRICE=@PROMOTE_PRICE,");
            strSql.Append("PROMOTE_START_DATE=@PROMOTE_START_DATE,");
            strSql.Append("PROMOTE_END_DATE=@PROMOTE_END_DATE,");
            strSql.Append("WARN_NUMBER=@WARN_NUMBER,");
            strSql.Append("KEYWORDS=@KEYWORDS,");
            strSql.Append("GOODS_BRIEF=@GOODS_BRIEF,");
            strSql.Append("GOODS_DESC=@GOODS_DESC,");
            strSql.Append("GOODS_THUMB=@GOODS_THUMB,");
            strSql.Append("GOODS_IMG=@GOODS_IMG,");
            strSql.Append("ORIGINAL_IMG=@ORIGINAL_IMG,");
            strSql.Append("IS_REAL=@IS_REAL,");
            strSql.Append("EXTENSION_CODE=@EXTENSION_CODE,");
            strSql.Append("IS_ON_SALE=@IS_ON_SALE,");
            strSql.Append("IS_ALONE_SALE=@IS_ALONE_SALE,");
            strSql.Append("INTEGRAL=@INTEGRAL,");
            strSql.Append("ADD_TIME=@ADD_TIME,");
            strSql.Append("SORT_ORDER=@SORT_ORDER,");
            strSql.Append("IS_BEST=@IS_BEST,");
            strSql.Append("IS_DELETE=@IS_DELETE,");
            strSql.Append("IS_NEW=@IS_NEW,");
            strSql.Append("IS_HOT=@IS_HOT,");
            strSql.Append("IS_PROMOTE=@IS_PROMOTE,");
            strSql.Append("BONUS_TYPE_ID=@BONUS_TYPE_ID,");
            strSql.Append("LAST_UPDATE=@LAST_UPDATE,");
            strSql.Append("GOODS_TYPE=@GOODS_TYPE,");
            strSql.Append("SELLER_NOTE=@SELLER_NOTE,");
            strSql.Append("GIVE_INTEGRAL=@GIVE_INTEGRAL");
            strSql.Append(" where GOODS_ID=@GOODS_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@GOODS_ID", SqlDbType.Int,4),
					new SqlParameter("@CAT_ID", SqlDbType.Int,4),
					new SqlParameter("@GOODS_SN", SqlDbType.VarChar,60),
					new SqlParameter("@GOODS_NAME", SqlDbType.VarChar,120),
					new SqlParameter("@GOODS_NAME_STYLE", SqlDbType.VarChar,60),
					new SqlParameter("@CLICK_COUNT", SqlDbType.Int,4),
					new SqlParameter("@BRAND_ID", SqlDbType.Int,4),
					new SqlParameter("@PROVIDER_NAME", SqlDbType.VarChar,100),
					new SqlParameter("@GOODS_NUMBER", SqlDbType.Int,4),
					new SqlParameter("@GOODS_WEIGHT", SqlDbType.Decimal,9),
					new SqlParameter("@MARKET_PRICE", SqlDbType.Decimal,9),
					new SqlParameter("@SHOP_PRICE", SqlDbType.Decimal,9),
					new SqlParameter("@PROMOTE_PRICE", SqlDbType.Decimal,9),
					new SqlParameter("@PROMOTE_START_DATE", SqlDbType.Int,4),
					new SqlParameter("@PROMOTE_END_DATE", SqlDbType.Int,4),
					new SqlParameter("@WARN_NUMBER", SqlDbType.Int,4),
					new SqlParameter("@KEYWORDS", SqlDbType.VarChar,255),
					new SqlParameter("@GOODS_BRIEF", SqlDbType.VarChar,255),
					new SqlParameter("@GOODS_DESC", SqlDbType.Text),
					new SqlParameter("@GOODS_THUMB", SqlDbType.VarChar,255),
					new SqlParameter("@GOODS_IMG", SqlDbType.VarChar,255),
					new SqlParameter("@ORIGINAL_IMG", SqlDbType.VarChar,255),
					new SqlParameter("@IS_REAL", SqlDbType.Int,4),
					new SqlParameter("@EXTENSION_CODE", SqlDbType.VarChar,30),
					new SqlParameter("@IS_ON_SALE", SqlDbType.Int,4),
					new SqlParameter("@IS_ALONE_SALE", SqlDbType.Int,4),
					new SqlParameter("@INTEGRAL", SqlDbType.Int,4),
					new SqlParameter("@ADD_TIME", SqlDbType.Int,4),
					new SqlParameter("@SORT_ORDER", SqlDbType.Int,4),
					new SqlParameter("@IS_BEST", SqlDbType.Int,4),
					new SqlParameter("@IS_DELETE", SqlDbType.Int,4),
					new SqlParameter("@IS_NEW", SqlDbType.Int,4),
					new SqlParameter("@IS_HOT", SqlDbType.Int,4),
					new SqlParameter("@IS_PROMOTE", SqlDbType.Int,4),
					new SqlParameter("@BONUS_TYPE_ID", SqlDbType.Int,4),
					new SqlParameter("@LAST_UPDATE", SqlDbType.Int,4),
					new SqlParameter("@GOODS_TYPE", SqlDbType.Int,4),
					new SqlParameter("@SELLER_NOTE", SqlDbType.VarChar,255),
					new SqlParameter("@GIVE_INTEGRAL", SqlDbType.Int,4)};
            parameters[0].Value = model.GOODS_ID;
            parameters[1].Value = model.CAT_ID;
            parameters[2].Value = model.GOODS_SN;
            parameters[3].Value = model.GOODS_NAME;
            parameters[4].Value = model.GOODS_NAME_STYLE;
            parameters[5].Value = model.CLICK_COUNT;
            parameters[6].Value = model.BRAND_ID;
            parameters[7].Value = model.PROVIDER_NAME;
            parameters[8].Value = model.GOODS_NUMBER;
            parameters[9].Value = model.GOODS_WEIGHT;
            parameters[10].Value = model.MARKET_PRICE;
            parameters[11].Value = model.SHOP_PRICE;
            parameters[12].Value = model.PROMOTE_PRICE;
            parameters[13].Value = model.PROMOTE_START_DATE;
            parameters[14].Value = model.PROMOTE_END_DATE;
            parameters[15].Value = model.WARN_NUMBER;
            parameters[16].Value = model.KEYWORDS;
            parameters[17].Value = model.GOODS_BRIEF;
            parameters[18].Value = model.GOODS_DESC;
            parameters[19].Value = model.GOODS_THUMB;
            parameters[20].Value = model.GOODS_IMG;
            parameters[21].Value = model.ORIGINAL_IMG;
            parameters[22].Value = model.IS_REAL;
            parameters[23].Value = model.EXTENSION_CODE;
            parameters[24].Value = model.IS_ON_SALE;
            parameters[25].Value = model.IS_ALONE_SALE;
            parameters[26].Value = model.INTEGRAL;
            parameters[27].Value = model.ADD_TIME;
            parameters[28].Value = model.SORT_ORDER;
            parameters[29].Value = model.IS_BEST;
            parameters[30].Value = model.IS_DELETE;
            parameters[31].Value = model.IS_NEW;
            parameters[32].Value = model.IS_HOT;
            parameters[33].Value = model.IS_PROMOTE;
            parameters[34].Value = model.BONUS_TYPE_ID;
            parameters[35].Value = model.LAST_UPDATE;
            parameters[36].Value = model.GOODS_TYPE;
            parameters[37].Value = model.SELLER_NOTE;
            parameters[38].Value = model.GIVE_INTEGRAL;

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
