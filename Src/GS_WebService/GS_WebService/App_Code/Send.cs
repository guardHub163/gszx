using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using CZZD.GSZX.Common;
using System.Data;
using CZZD.GSZX.BLL;
using log4net;
using System.Reflection;

namespace CZZD.GSZX.Web
{
    /// <summary>
    ///SendWebService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://czzd.gszx.web.send")]
    //[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    //若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。 
    // [System.Web.Script.Services.ScriptService]
    public class _Send : System.Web.Services.WebService
    {
        private static ILog _log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public _Send()
        {
            //如果使用设计的组件，请取消注释以下行 
            //InitializeComponent(); 
        }

        #region 获得系统时间
        /// <summary>
        /// 获得系统时间
        /// </summary>
        [WebMethod]
        public string GetSystemTime()
        {
            return DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        }
        #endregion

        #region 获得基础数据
        /// <summary>
        /// 获得基础数据
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="time"></param>
        /// <param name="keys"></param>
        /// <returns></returns>
        [WebMethod]
        public string GetMasterDataInfo(string tableName, string lastUpdateTime, string time, string keys)
        {
            string ret = CConstant.CONN_ERROR;
            try
            {
                if (!DESEncrypt.Decrypt(keys, CConstant.KEYS).Equals(tableName + time + CConstant.E_COMMERCE_KEYS))
                {
                    ret = CConstant.CONN_ERROR;
                }
                else
                {

                    BCommon bll = new BCommon();
                    DataSet ds = new DataSet();
                    try
                    {
                        ds = bll.GetExportList(tableName, lastUpdateTime);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            //ret = CConstant.SUCCESS + ds.GetXml();　//成功
                            ret = CConstant.SUCCESS + CCommon.DataSetToXml(tableName, ds.Tables[0]);
                        }
                        else
                        {
                            ret = CConstant.NO_DATA; //记录不存在
                        }
                    }
                    catch (Exception ex)
                    {
                        ret = CConstant.ERROR;　//系统异常
                        _log.Error(ex.Message, ex);
                    }
                }

            }
            catch (Exception ex)
            {
                ret = CConstant.ERROR;
                _log.Error(ex.Message, ex);
            }
            return ret;
        }
        #endregion

        #region 订单信息的取得　--　根据查询条件返回查询到的订单编号/订单编号的统计数量
        /// <summary>
        /// 订单信息的取得　--　根据查询条件返回查询到的订单编号/订单编号的统计数量
        /// </summary>
        /// <param name="type">count/list</param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="sendStatus"></param>
        /// <param name="strWhere"></param>
        /// <param name="time"></param>
        /// <param name="keys"></param>
        /// <returns></returns>
        [WebMethod]
        public string GetOrderIds(string type, string startTime, string endTime, string sendStatus, string strWhere, string time, string keys)
        {
            string ret = CConstant.CONN_ERROR;

            try
            {
                if (!DESEncrypt.Decrypt(keys, CConstant.KEYS).Equals(type + time + CConstant.E_COMMERCE_KEYS))
                {
                    ret = CConstant.CONN_ERROR;
                }
                else
                {
                    BBllOrderInfo bll = new BBllOrderInfo();
                    DataSet ds = bll.GetOrderIds(type, startTime, endTime, sendStatus, strWhere);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ret = CConstant.SUCCESS + CCommon.DataSetToXml("order_info", ds.Tables[0]);
                    }
                    else
                    {
                        ret = CConstant.NO_DATA; //记录不存在
                    }
                }
            }
            catch (Exception ex)
            {
                ret = CConstant.ERROR;　//系统异常
                _log.Error(ex.Message, ex);
            }
            return ret;
        }
        #endregion

        #region 订单信息的取得　--　根据订单编号返回一个/多个订单的所有信息
        /// <summary>
        /// 订单信息的取得　--　根据订单编号返回一个/多个订单的所有信息
        /// </summary>
        ///  <param name="type">single/list</param>
        /// <param name="orderID">用'|'分隔　例(1|2|3|4|5|6)</param>
        /// <param name="time"></param>
        /// <param name="keys"></param>
        /// <returns></returns>
        [WebMethod]
        public string GetOrders(string type, string orderIds, string time, string keys)
        {
            string ret = CConstant.CONN_ERROR;

            try
            {
                if (!DESEncrypt.Decrypt(keys, CConstant.KEYS).Equals(type + time + CConstant.E_COMMERCE_KEYS))
                {
                    ret = CConstant.CONN_ERROR;
                }
                else
                {
                    BBllOrderInfo bll = new BBllOrderInfo();
                    DataSet ds = bll.GetOrders(type, orderIds.Replace('|', ','));
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ret = CConstant.SUCCESS + CCommon.DataSetToXml("order_info", ds.Tables[0]);
                    }
                    else
                    {
                        ret = CConstant.NO_DATA; //记录不存在
                    }
                }
            }
            catch (Exception ex)
            {
                ret = CConstant.ERROR;　//系统异常
                _log.Error(ex.Message, ex);
            }
            return ret;
        }

        #endregion

        #region 订单信息的取得　--　根据查询条件返回查询到的订单数据
        /// <summary>
        /// 订单信息的取得　--　根据查询条件返回查询到的订单数据
        /// </summary>
        /// <param name="type">count/list</param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="sendStatus"></param>
        /// <param name="strWhere"></param>
        /// <param name="time"></param>
        /// <param name="keys"></param>
        /// <returns></returns>
        [WebMethod]
        public string SelectOrders(string type, string startTime, string endTime, string sendStatus, string strWhere, string time, string keys)
        {
            string ret = CConstant.CONN_ERROR;

            try
            {
                if (!DESEncrypt.Decrypt(keys, CConstant.KEYS).Equals(type + time + CConstant.E_COMMERCE_KEYS))
                {
                    ret = CConstant.CONN_ERROR;
                }
                else
                {
                    BBllOrderInfo bll = new BBllOrderInfo();
                    DataSet ds = bll.SelectOrders(type, startTime, endTime, sendStatus, strWhere);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ret = CConstant.SUCCESS + CCommon.DataSetToXml("order_info", ds.Tables[0]);
                    }
                    else
                    {
                        ret = CConstant.NO_DATA; //记录不存在
                    }
                }
            }
            catch (Exception ex)
            {
                ret = CConstant.ERROR;　//系统异常
                _log.Error(ex.Message, ex);
            }
            return ret;
        }
        #endregion

    }//end class
}

