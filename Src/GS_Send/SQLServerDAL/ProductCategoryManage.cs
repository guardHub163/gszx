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
    public class ProductCategoryManage : IProductCategory
    {
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int catId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_PRODUCT_CATEGORY");
            strSql.Append(" where CAT_ID=@CAT_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CAT_ID", SqlDbType.Int,4)};
            parameters[0].Value = catId;

            return DbHelperSqlServer.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BaseProductCategoryTable model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BASE_PRODUCT_CATEGORY(");
            strSql.Append("CAT_ID,CAT_NAME,KEYWORDS,CAT_DESC,PARENT_ID,SORT_ORDER,TEMPLATE_FILE,MEASURE_UNIT,SHOW_IN_NAV,STYLE,IS_SHOW,GRADE,FILTER_ATTR)");
            strSql.Append(" values (");
            strSql.Append("@CAT_ID,@CAT_NAME,@KEYWORDS,@CAT_DESC,@PARENT_ID,@SORT_ORDER,@TEMPLATE_FILE,@MEASURE_UNIT,@SHOW_IN_NAV,@STYLE,@IS_SHOW,@GRADE,@FILTER_ATTR)");
            SqlParameter[] parameters = {
					new SqlParameter("@CAT_ID", SqlDbType.Int,4),
					new SqlParameter("@CAT_NAME", SqlDbType.VarChar,90),
					new SqlParameter("@KEYWORDS", SqlDbType.VarChar,225),
					new SqlParameter("@CAT_DESC", SqlDbType.VarChar,225),
					new SqlParameter("@PARENT_ID", SqlDbType.Int,4),
					new SqlParameter("@SORT_ORDER", SqlDbType.Int,4),
					new SqlParameter("@TEMPLATE_FILE", SqlDbType.VarChar,50),
					new SqlParameter("@MEASURE_UNIT", SqlDbType.VarChar,15),
					new SqlParameter("@SHOW_IN_NAV", SqlDbType.Int,4),
					new SqlParameter("@STYLE", SqlDbType.VarChar,150),
					new SqlParameter("@IS_SHOW", SqlDbType.Int,4),
					new SqlParameter("@GRADE", SqlDbType.Int,4),
					new SqlParameter("@FILTER_ATTR", SqlDbType.Int,4)};
            parameters[0].Value = model.CAT_ID;
            parameters[1].Value = model.CAT_NAME;
            parameters[2].Value = model.KEYWORDS;
            parameters[3].Value = model.CAT_DESC;
            parameters[4].Value = model.PARENT_ID;
            parameters[5].Value = model.SORT_ORDER;
            parameters[6].Value = model.TEMPLATE_FILE;
            parameters[7].Value = model.MEASURE_UNIT;
            parameters[8].Value = model.SHOW_IN_NAV;
            parameters[9].Value = model.STYLE;
            parameters[10].Value = model.IS_SHOW;
            parameters[11].Value = model.GRADE;
            parameters[12].Value = model.FILTER_ATTR;

            return DbHelperSqlServer.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(BaseProductCategoryTable model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BASE_PRODUCT_CATEGORY set ");
            strSql.Append("CAT_NAME=@CAT_NAME,");
            strSql.Append("KEYWORDS=@KEYWORDS,");
            strSql.Append("CAT_DESC=@CAT_DESC,");
            strSql.Append("PARENT_ID=@PARENT_ID,");
            strSql.Append("SORT_ORDER=@SORT_ORDER,");
            strSql.Append("TEMPLATE_FILE=@TEMPLATE_FILE,");
            strSql.Append("MEASURE_UNIT=@MEASURE_UNIT,");
            strSql.Append("SHOW_IN_NAV=@SHOW_IN_NAV,");
            strSql.Append("STYLE=@STYLE,");
            strSql.Append("IS_SHOW=@IS_SHOW,");
            strSql.Append("GRADE=@GRADE,");
            strSql.Append("FILTER_ATTR=@FILTER_ATTR");
            strSql.Append(" where CAT_ID=@CAT_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@CAT_ID", SqlDbType.Int,4),
					new SqlParameter("@CAT_NAME", SqlDbType.VarChar,90),
					new SqlParameter("@KEYWORDS", SqlDbType.VarChar,225),
					new SqlParameter("@CAT_DESC", SqlDbType.VarChar,225),
					new SqlParameter("@PARENT_ID", SqlDbType.Int,4),
					new SqlParameter("@SORT_ORDER", SqlDbType.Int,4),
					new SqlParameter("@TEMPLATE_FILE", SqlDbType.VarChar,50),
					new SqlParameter("@MEASURE_UNIT", SqlDbType.VarChar,15),
					new SqlParameter("@SHOW_IN_NAV", SqlDbType.Int,4),
					new SqlParameter("@STYLE", SqlDbType.VarChar,150),
					new SqlParameter("@IS_SHOW", SqlDbType.Int,4),
					new SqlParameter("@GRADE", SqlDbType.Int,4),
					new SqlParameter("@FILTER_ATTR", SqlDbType.Int,4)};
            parameters[0].Value = model.CAT_ID;
            parameters[1].Value = model.CAT_NAME;
            parameters[2].Value = model.KEYWORDS;
            parameters[3].Value = model.CAT_DESC;
            parameters[4].Value = model.PARENT_ID;
            parameters[5].Value = model.SORT_ORDER;
            parameters[6].Value = model.TEMPLATE_FILE;
            parameters[7].Value = model.MEASURE_UNIT;
            parameters[8].Value = model.SHOW_IN_NAV;
            parameters[9].Value = model.STYLE;
            parameters[10].Value = model.IS_SHOW;
            parameters[11].Value = model.GRADE;
            parameters[12].Value = model.FILTER_ATTR;

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
