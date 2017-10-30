using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CZZD.GSZX.R.Common;
using log4net;
using System.Reflection;
using System.Threading;
using CZZD.GSZX.R.Bll;
using System.Data;
using System.Net;
using CZZD.GSZX.R.Model;

namespace CZZD.GSZX.R.UI
{
    public class OrderInfoTimer : ITimer
    {
        private static ILog _log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.Name);
        private int _orderInfoInterval;

        private Timer _orderInfoTimer;

        private Timer _timer;
        private int _interval;

        private Object _cookie = null;
        private Object _lock = new Object();

        #region 定时计划任务的执行初始化
        /// <summary>
        /// 定时计划任务的执行初始化
        /// </summary>
        public void Setup()
        {
            _orderInfoInterval = CConvert.ToInt32(XmlHelp.ReadXmlFile(CConstant.TIMER_ORDER_INFO)) * 1000;
        }
        #endregion

        #region 服务开始
        /// <summary>
        /// 服务开始
        /// </summary>
        public void Start()
        {
            _cookie = new Object();
            _orderInfoTimer = new Timer(new TimerCallback(Execute), new TimerInfo(CConstant.TIMER_ORDER_INFO), _orderInfoInterval, Timeout.Infinite);
        }
        #endregion

        #region 服务停止
        /// <summary>
        /// 服务停止
        /// </summary>
        public void Stop()
        {
            lock (this._lock)
            {
                _cookie = null;
                if (this._orderInfoTimer != null)
                {
                    this._orderInfoTimer.Dispose();
                    this._orderInfoTimer = null;
                }
            }
        }
        #endregion

        #region 业务处理
        /// <summary>
        /// 业务处理
        /// </summary>
        private void Execute(Object info)
        {
            lock (_lock)
            {
                try
                {

                    TimerInfo tInfo = (TimerInfo)info;
                    switch (tInfo.TYPE)
                    {
                        case CConstant.TIMER_ORDER_INFO:
                            this.GetOrderData();
                            this._timer = this._orderInfoTimer;
                            this._interval = this._orderInfoInterval;
                            break;
                    }
                    Thread.Sleep(500);
                }
                catch (Exception ex)
                {
                    this._timer = null;
                    _log.Error("", ex);
                }
                finally
                {
                    if (_cookie != null && this._timer != null)
                    {
                        this._timer.Change(this._interval, Timeout.Infinite);
                    }
                }
            }//end lock
        }
        #endregion

        #region 订单数据的同步
        /// <summary>
        ///  订单数据的同步
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetOrderData()
        {
            try
            {
                //送信服务
                czzd.gszx.web.send._Send send = new czzd.gszx.web.send._Send();
                //服务器时间的取得
                string serverTime = send.GetSystemTime();
                //简单加密用
                string keys = DESEncrypt.Encrypt(CConstant.TYPE_LIST + serverTime + CConstant.E_COMMERCE_KEYS, CConstant.KEYS);
                //调用WebService
                string xmlData = send.GetOrderIds(CConstant.TYPE_LIST, "", "", CConstant.ORDER_UNSEND.ToString(), "pay_status=" + CConstant.ORDER_PAID, serverTime, keys);
                //返回值处理
                string status = CConstant.CONN_ERROR;
                try
                {
                    status = xmlData.Substring(0, 2);
                }
                catch { }

                if (status == CConstant.SUCCESS)
                {
                    //所有订单编号的取得
                    DataSet ds = CCommon.XmlToDataSet(xmlData.Substring(2));
                    //根据订单编号取得订单详细信息
                    int i = 1;
                    string orderIds = "";
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        if (i == 10) //每10条取一次信息。
                        {
                            orderIds = orderIds.Substring(0, orderIds.Length - 1);
                            GetOrdersInfo(send, orderIds, serverTime);
                            i = 0;
                            orderIds = "";
                        }
                        i++;
                        orderIds += CConvert.ToString(dr["order_id"]) + "|";
                    }
                    if (orderIds.Length > 0)
                    {
                        orderIds = orderIds.Substring(0, orderIds.Length - 1);
                        GetOrdersInfo(send, orderIds, serverTime);
                        i = 1;
                        orderIds = "";
                    }
                }
                else if (status == CConstant.NO_DATA)
                {
                    _log.Info("[销售订单]没有需要同步的信息。");
                }
            }
            catch (WebException wex)
            {
                _log.Error("[销售订单]收信连接失败。", wex);
            }
            catch (Exception ex)
            {
                _log.Error("[销售订单]系统异常。", ex);
            }
        }

        /// <summary>
        /// 订单详细信息的取得
        /// </summary>
        /// <param name="serverTime"></param>
        /// <param name="orderIds"></param>
        private void GetOrdersInfo(czzd.gszx.web.send._Send send, string orderIds, string serverTime)
        {
            BOrderInfo bll = new BOrderInfo();
            string retOrderIds = "";
            //简单加密用
            string keys = DESEncrypt.Encrypt(CConstant.TYPE_LIST + serverTime + CConstant.E_COMMERCE_KEYS, CConstant.KEYS);
            //调用WebService
            string xmlData = send.GetOrders(CConstant.TYPE_LIST, orderIds, serverTime, keys);
            //返回值处理
            string status = CConstant.CONN_ERROR;
            try
            {
                status = xmlData.Substring(0, 2);
            }
            catch { }

            if (status == CConstant.SUCCESS)
            {
                //所有订单详细信息的取得
                DataSet ds = CCommon.XmlToDataSet(xmlData.Substring(2));
                List<BllOrderInfoTable> orderInfoList = CreateOrderInfoTable(ds);
                //订单详细信息的保存
                foreach (BllOrderInfoTable orderInfoTable in orderInfoList)
                {
                    try
                    {
                        if (bll.Exists(orderInfoTable.ORDER_ID, CConstant.DEFAULT_ORDER_TYPE))
                        {
                            retOrderIds += orderInfoTable.ORDER_ID + "|";
                        }
                        else
                        {
                            if (bll.Add(orderInfoTable) > 0)
                            {
                                retOrderIds += orderInfoTable.ORDER_ID + "|";
                            }
                            else
                            {
                                _log.Info("[销售订单]订单编号：" + orderInfoTable.ORDER_SN + "同步失败。");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        _log.Error("[销售订单]订单编号：" + orderInfoTable.ORDER_SN + "同步失败,系统异常。", ex);
                    }
                }
            }

            //收信服务
            czzd.gszx.web.receive._Receive receive = new czzd.gszx.web.receive._Receive();
            //订单状态的回写
            if (retOrderIds.Length > 0)
            {
                retOrderIds = orderIds.Substring(0, orderIds.Length - 1);
                receive.ReceiveOrderStatus(CConstant.TYPE_SEND_STATUS, retOrderIds, serverTime, keys);
            }
        }

        /// <summary>
        /// 订单LIST对象的转换
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        private List<BllOrderInfoTable> CreateOrderInfoTable(DataSet ds)
        {
            List<BllOrderInfoTable> orderInfoList = new List<BllOrderInfoTable>();
            decimal currentOrderId = 0;
            BllOrderInfoTable orderInfoTable = null;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                decimal orderId = CConvert.ToDecimal(dr["order_id"]);
                if (currentOrderId != orderId)
                {
                    if (currentOrderId != 0)
                    {
                        orderInfoList.Add(orderInfoTable);
                    }

                    currentOrderId = orderId;

                    orderInfoTable = new BllOrderInfoTable();
                    orderInfoTable.ORDER_ID = orderId;
                    orderInfoTable.ORDER_SN = CConvert.ToString(dr["order_sn"]);
                    orderInfoTable.USER_ID = CConvert.ToInt32(dr["user_id"]);
                    orderInfoTable.ORDER_STATUS = CConvert.ToInt32(dr["order_status"]);
                    orderInfoTable.SHIPPING_STATUS = CConvert.ToInt32(dr["shipping_status"]);
                    orderInfoTable.PAY_STATUS = CConvert.ToInt32(dr["pay_status"]);
                    orderInfoTable.CONSIGNEE = CConvert.ToString(dr["consignee"]);
                    orderInfoTable.COUNTRY = CConvert.ToString(dr["country"]);
                    orderInfoTable.PROVINCE = CConvert.ToString(dr["province"]);
                    orderInfoTable.CITY = CConvert.ToString(dr["city"]);
                    orderInfoTable.DISTRICT = CConvert.ToString(dr["district"]);
                    orderInfoTable.ADDRESS = CConvert.ToString(dr["address"]);
                    orderInfoTable.ZIPCODE = CConvert.ToString(dr["zipcode"]);
                    orderInfoTable.TEL = CConvert.ToString(dr["tel"]);
                    orderInfoTable.MOBILE = CConvert.ToString(dr["mobile"]);
                    orderInfoTable.EMAIL = CConvert.ToString(dr["email"]);
                    orderInfoTable.BEST_TIME = CConvert.ToInt32(dr["best_time"]);
                    orderInfoTable.SIGN_BUILDING = CConvert.ToString(dr["sign_building"]);
                    orderInfoTable.POST_SCRIPT = CConvert.ToString(dr["postscript"]);
                    orderInfoTable.SHIPPING_ID = CConvert.ToInt32(dr["shipping_id"]);
                    orderInfoTable.SHIPPING_NAME = CConvert.ToString(dr["shipping_name"]);
                    orderInfoTable.PAY_ID = CConvert.ToInt32(dr["pay_id"]);
                    orderInfoTable.PAY_NAME = CConvert.ToString(dr["pay_name"]);
                    orderInfoTable.HOW_OOS = CConvert.ToString(dr["how_oos"]);
                    orderInfoTable.HOW_SURPLUS = CConvert.ToString(dr["how_surplus"]);
                    orderInfoTable.PACK_NAME = CConvert.ToString(dr["pack_name"]);
                    orderInfoTable.CARD_NAME = CConvert.ToString(dr["card_name"]);
                    orderInfoTable.CARD_MESSAGE = CConvert.ToString(dr["card_message"]);
                    orderInfoTable.INV_PAYEE = CConvert.ToString(dr["inv_payee"]);
                    orderInfoTable.INV_CONTENT = CConvert.ToString(dr["inv_content"]);
                    orderInfoTable.GOODS_AMOUNT = CConvert.ToDecimal(dr["goods_amount"]);
                    orderInfoTable.SHIPPING_FEE = CConvert.ToDecimal(dr["shipping_fee"]);
                    orderInfoTable.INSURE_FEE = CConvert.ToDecimal(dr["insure_fee"]);
                    orderInfoTable.PAY_FEE = CConvert.ToDecimal(dr["pay_fee"]);
                    orderInfoTable.PACK_FEE = CConvert.ToDecimal(dr["pack_fee"]);
                    orderInfoTable.CARD_FEE = CConvert.ToDecimal(dr["card_fee"]);
                    orderInfoTable.MONEY_PAID = CConvert.ToDecimal(dr["money_paid"]);
                    orderInfoTable.SURPLUS = CConvert.ToDecimal(dr["surplus"]);
                    orderInfoTable.INTEGRAL = CConvert.ToInt32(dr["integral"]);
                    orderInfoTable.INTEGRALl_MONEY = CConvert.ToDecimal(dr["integral_money"]);
                    orderInfoTable.BONUS = CConvert.ToDecimal(dr["bonus"]);
                    orderInfoTable.ORDER_AMOUNT = CConvert.ToDecimal(dr["order_amount"]);
                    orderInfoTable.FROM_AD = CConvert.ToInt32(dr["from_ad"]);
                    orderInfoTable.REFERER = CConvert.ToString(dr["referer"]);
                    orderInfoTable.ADD_TIME = CCommon.UnixTimeToDateTime(CConvert.ToInt32(dr["add_time"]));//
                    orderInfoTable.CONFIRM_TIME = CCommon.UnixTimeToDateTime(CConvert.ToInt32(dr["confirm_time"]));//
                    orderInfoTable.PAY_TIME = CCommon.UnixTimeToDateTime(CConvert.ToInt32(dr["pay_time"]));//
                    orderInfoTable.SHIPPING_TIME = CCommon.UnixTimeToDateTime(CConvert.ToInt32(dr["shipping_time"]));//
                    orderInfoTable.PACK_ID = CConvert.ToInt32(dr["pack_id"]);
                    orderInfoTable.CARD_ID = CConvert.ToInt32(dr["card_id"]);
                    orderInfoTable.BONUS_ID = CConvert.ToInt32(dr["bonus_id"]);
                    orderInfoTable.INVOICE_NO = CConvert.ToString(dr["invoice_no"]);
                    orderInfoTable.EXTENSION_CODE = CConvert.ToString(dr["extension_code"]);
                    orderInfoTable.EXTENSION_ID = CConvert.ToInt32(dr["extension_id"]);
                    orderInfoTable.TO_BUYER = CConvert.ToString(dr["to_buyer"]);
                    orderInfoTable.PAY_NOTE = CConvert.ToString(dr["pay_note"]);
                    orderInfoTable.AGENCY_ID = CConvert.ToInt32(dr["agency_id"]);
                    orderInfoTable.INV_TYPE = CConvert.ToString(dr["inv_type"]);
                    orderInfoTable.TAX = CConvert.ToDecimal(dr["tax"]);
                    orderInfoTable.IS_SEPARATE = CConvert.ToInt32(dr["is_separate"]);
                    orderInfoTable.PARENT_ID = CConvert.ToString(dr["parent_id"]);
                    orderInfoTable.DISCOUNT = CConvert.ToDecimal(dr["discount"]);
                    orderInfoTable.ORDER_TYPE = CConstant.DEFAULT_ORDER_TYPE;
                    orderInfoTable.ACTUAL_GOODS_AMOUNT = CConvert.ToDecimal(0);
                    orderInfoTable.PRINT_STATUS = 0;
                }

                BllOrderGoodsTable orderGoodsTable = new BllOrderGoodsTable();
                orderGoodsTable.REC_ID = CConvert.ToInt32(dr["rec_id"]);
                orderGoodsTable.ORDER_ID = CConvert.ToInt32(dr["order_id"]);
                orderGoodsTable.GOODS_ID = CConvert.ToInt32(dr["goods_id"]);
                orderGoodsTable.GOODS_NAME = CConvert.ToString(dr["goods_name"]);
                orderGoodsTable.GOODS_SN = CConvert.ToString(dr["goods_sn"]);
                orderGoodsTable.GOODS_NUMBER = CConvert.ToInt32(dr["goods_number"]);
                orderGoodsTable.MARKET_PRICE = CConvert.ToDecimal(dr["market_price"]);
                orderGoodsTable.GOODS_PRICE = CConvert.ToDecimal(dr["goods_price"]);
                orderGoodsTable.GOODS_ATTR = CConvert.ToString(dr["goods_attr"]);
                orderGoodsTable.SEND_NUMBER = CConvert.ToInt32(dr["send_number"]);
                orderGoodsTable.IS_REAL = CConvert.ToInt32(dr["is_real"]);
                orderGoodsTable.EXTENSION_CODE = CConvert.ToString(dr["extension_code"]);
                orderGoodsTable.PARENT_ID = CConvert.ToInt32(dr["parent_id"]);
                orderGoodsTable.IS_GIFT = CConvert.ToInt32(dr["is_gift"]);
                orderGoodsTable.ORDER_TYPE = CConstant.DEFAULT_ORDER_TYPE;
                orderGoodsTable.ACTUAL_AMOUNT = CConvert.ToDecimal(0);
                orderGoodsTable.ACTUAL_NUMBER = CConvert.ToDecimal(0);
                orderInfoTable.AddItems(orderGoodsTable);
            }

            if (orderInfoTable != null)
            {
                orderInfoList.Add(orderInfoTable);
            }

            return orderInfoList;
        }

        #endregion

    }//end class
}
