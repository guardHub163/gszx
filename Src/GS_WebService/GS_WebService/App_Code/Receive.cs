using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using CZZD.GSZX.Common;
using CZZD.GSZX.BLL;
using System.Data;
using log4net;
using System.Reflection;
using CZZD.GSZX.Model;

namespace CZZD.GSZX.Web
{
    /// <summary>
    ///ReceiveWebService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://czzd.gszx.web.receive")]
    //[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    //若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。 
    // [System.Web.Script.Services.ScriptService]
    public class _Receive : System.Web.Services.WebService
    {
        private static ILog _log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public _Receive()
        {

            //如果使用设计的组件，请取消注释以下行 
            //InitializeComponent(); 
        }

        //[WebMethod]
        //public string HelloWorld()
        //{
        //    return "Hello World";
        //}

        /// <summary>
        /// 获得系统时间
        /// </summary>
        [WebMethod]
        public string GetSystemTime()
        {
            return DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        }

        #region 订单送信状态[订单确认]/结束[订单结束]的回写
        /// <summary>
        /// 订单送信状态[订单确认]/结束[订单结束]的回写
        /// </summary>
        /// <param name="type"></param>
        /// <param name="orderIDs">用'|'分隔　例(1|2|3|4|5|6)</param>
        /// <param name="time"></param>
        /// <param name="keys"></param>
        /// <returns></returns>
        [WebMethod]
        public string ReceiveOrderStatus(string type, string orderIds, string time, string keys)
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
                    DataSet ds = bll.ReceiveOrderStatus(type, orderIds);
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

        #region 订单实际金额，实际重量及账户余额的更新
        /// <summary>
        /// 订单实际金额，实际重量及账户余额的更新
        /// </summary>
        [WebMethod]
        public string ReceiveOrderInfos(string type, string xmlData, string time, string keys)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("orderId", Type.GetType("System.String"));
            dt.Columns.Add("orderSn", Type.GetType("System.String"));
            dt.Columns.Add("status", Type.GetType("System.String"));
            DataRow retDr = null;
            BllSendOrderTable sendOrderTable = null;
            BllSendOrderLineTable sendOrderLineTable = null;

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
                    DataSet ds = CCommon.XmlToDataSet(xmlData);
                    int currentOrderId = 0;

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        int orderId = CConvert.ToInt32(dr["ORDER_ID"]);

                        if (currentOrderId != orderId)
                        {
                            if (currentOrderId != 0)
                            {
                                retDr = dt.NewRow();
                                retDr["orderId"] = sendOrderTable.ORDER_ID;
                                retDr["orderSn"] = sendOrderTable.ORDER_SN;
                                //更新
                                try
                                {
                                    retDr["status"] = bll.ReceiveOrderInfo(sendOrderTable);
                                }
                                catch (Exception ex)
                                {
                                    retDr["status"] = CConstant.ERROR;
                                    _log.Error(currentOrderId, ex);
                                }
                                dt.Rows.Add(retDr);
                            }

                            currentOrderId = orderId;
                            sendOrderTable = new BllSendOrderTable();
                            sendOrderTable.ORDER_ID = orderId;
                            sendOrderTable.ORDER_SN = CConvert.ToString(dr["ORDER_SN"]);
                            sendOrderTable.GOODS_AMOUNT = CConvert.ToDecimal(dr["GOODS_AMOUNT"]);
                            sendOrderTable.ACTUAL_GOODS_AMOUNT = CConvert.ToDecimal(dr["ACTUAL_GOODS_AMOUNT"]);
                            sendOrderTable.COMMUNITY_CODE = CConvert.ToInt32(dr["COMMUNITY_CODE"]);

                        }

                        sendOrderLineTable = new BllSendOrderLineTable();
                        sendOrderLineTable.REC_ID = CConvert.ToInt32(dr["REC_ID"]);
                        sendOrderLineTable.ACTUAL_NUMBER = CConvert.ToDecimal(dr["ACTUAL_NUMBER"]);
                        sendOrderLineTable.ACTUAL_AMOUNT = CConvert.ToDecimal(dr["ACTUAL_AMOUNT"]);
                        sendOrderTable.AddLine(sendOrderLineTable);
                    }

                    if (sendOrderTable != null)
                    {
                        retDr = dt.NewRow();
                        retDr["orderId"] = sendOrderTable.ORDER_ID;
                        retDr["orderSn"] = sendOrderTable.ORDER_SN;
                        //更新
                        try
                        {
                            retDr["status"] = bll.ReceiveOrderInfo(sendOrderTable);
                        }
                        catch (Exception ex)
                        {
                            retDr["status"] = CConstant.ERROR;
                            _log.Error(currentOrderId, ex);
                        }
                        dt.Rows.Add(retDr);
                    }
                    ret = CConstant.SUCCESS;
                }
            }
            catch (Exception ex)
            {
                ret = CConstant.ERROR;　//系统异常
            }

            return ret + CCommon.DataSetToXml("order_info", dt);
        }
        #endregion

        #region 单张/多张订单的消息更新
        /// <summary>
        /// 单张/多张订单的消息更新
        /// </summary>
        [WebMethod]
        public string ReceiveMessage(string type, string values, string time, string keys)
        {
            string ret = "";

            try
            {
                if (!DESEncrypt.Decrypt(keys, CConstant.KEYS).Equals(type + time + CConstant.E_COMMERCE_KEYS))
                {
                    ret = CConstant.NO_DATA;
                }
                else
                {
                    switch (type)
                    {
                        case "single":
                            break;
                        case "list":
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                ret = CConstant.ERROR;　//系统异常
            }
            return ret;
        }
        #endregion

    } //end class
}

