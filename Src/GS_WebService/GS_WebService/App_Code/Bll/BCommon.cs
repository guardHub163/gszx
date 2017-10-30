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
using CZZD.GSZX.DAL;

namespace CZZD.GSZX.BLL
{
    /// <summary>
    ///BCommon 的摘要说明
    /// </summary>
    public class BCommon
    {
        private readonly CommonManage dal = new CommonManage();
        public BCommon()
        { }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetExportList(string tableName, string dateTime)
        {
            return dal.GetExportList(tableName, dateTime);
        }
    }
}
