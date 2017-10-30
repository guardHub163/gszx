using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;
using CZZD.GSZX.DBUtility;
using CZZD.GSZX.Common;

namespace CZZD.GSZX.DAL
{
    /// <summary>
    ///CommonManage 的摘要说明
    /// </summary>
    public class CommonManage
    {
        public CommonManage()
        { }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetExportList(string tableName, string dateTime)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" select * FROM ecs_{0} ", tableName);

            if (!string.IsNullOrEmpty(dateTime))
            {
                if ("goods".Equals(tableName))
                {
                    string fileds = "goods_id,cat_id,goods_sn,goods_name,''as goods_name_style,click_count,brand_id,provider_name,goods_number,goods_weight,market_price,shop_price,promote_price,promote_start_date,promote_end_date,warn_number,''as keywords,''as goods_brief,''as goods_desc,''as goods_thumb,''as goods_img,''as original_img,is_real,extension_code,is_on_sale,is_alone_sale,is_shipping,integral,add_time,sort_order,is_delete,is_best,is_new,is_hot,is_promote,bonus_type_id,last_update,goods_type,seller_note,give_integral,rank_integral,suppliers_id,is_check ";
                    strSql = new StringBuilder();
                    strSql.AppendFormat(" select {0} FROM ecs_{1} ", fileds, tableName);
                    strSql.AppendFormat(" where last_update >= {0} ", CCommon.DateTimeToUnixTime(CConvert.ToDateTime(dateTime)));
                }
                else if ("users".Equals(tableName))
                {
                    strSql.AppendFormat(" where last_time >= '{0}' ", dateTime);
                }
            }
            return MySqlDBHelper.Query(strSql.ToString());
        }

        //获得当前当户信息
    }//end class
}
