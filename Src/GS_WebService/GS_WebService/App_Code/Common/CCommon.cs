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
using System.IO;
using System.Xml;

namespace CZZD.GSZX.Common
{
    /// <summary>
    ///CCommon 的摘要说明
    /// </summary>
    public class CCommon
    {
        public CCommon()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        #region 将dataset转换成xml
        /// <summary>
        /// 将dataset转换成xml
        /// </summary> 
        /// <param name="tableName">名称 Table1</param>        
        /// <param name="table">DataTable</param>        
        public static string DataSetToXml(string tableName, DataTable table)
        {
            string str = string.Empty;
            str += "<" + tableName + ">";
            for (int i = 0; i < table.Rows.Count; i++)
            {
                str += "<ds>";
                for (int j = 0; j < table.Columns.Count; j++)
                {
                    string clName = table.Columns[j].ColumnName;
                    str += "<" + clName + ">" + table.Rows[i][clName].ToString() + "</" + clName + ">";
                }
                str += "</ds>";
            }
            str += "</" + tableName + ">";
            return str;
        }
        #endregion

        #region 将xml转换成dataset
        /// <summary>
        /// 将xml转换成dataset
        /// </summary>
        /// <param name="xmlData"></param>
        /// <returns></returns>
        public static DataSet XmlToDataSet(string xmlData)
        {
            StringReader stream = null;
            XmlTextReader reader = null;
            try
            {
                DataSet ds = new DataSet();
                stream = new StringReader(xmlData);
                reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                return ds;
            }
            catch (Exception ex)
            {
                string strTest = ex.Message;
                return null;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }
        #endregion

        #region
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static int DateTimeToUnixTime(DateTime value)
        {
            TimeSpan span = (value - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime());

            return (int)span.TotalSeconds;
        }
        #endregion


        #region
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime UnixTimeToDateTime(int value)
        {
            DateTime converted = new DateTime(1970, 1, 1, 0, 0, 0, 0);

            DateTime newdatetime = converted.AddSeconds(value);

            return newdatetime.ToLocalTime();
        }
        #endregion
    }//end class
}
