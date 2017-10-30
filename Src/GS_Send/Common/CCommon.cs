using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Xml;

namespace CZZD.GSZX.S.Common
{
    public class CCommon
    {
        #region 将DataSet的Xml格式
        /// <summary>
        /// /// 将DataSet的Xml格式 
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

        #region 将DateTime转换成UnixTime
        /// <summary>
        /// 将DateTime转换成UnixTime
        /// </summary>
        /// <returns></returns>
        public static int DateTimeToUnixTime(DateTime value)
        {
            TimeSpan span = (value - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime());
            return (int)span.TotalSeconds;
        }
        #endregion

        #region 将UnixTime转换成DateTime
        /// <summary>
        /// 将UnixTime转换成DateTime
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
