using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CZZD.GSZX.S.Common;
using log4net;
using System.Reflection;
using System.Threading;
using CZZD.GSZX.S.Bll;
using System.Data;
using System.Net;

namespace CZZD.GSZX.S.UI
{
    public class OrderInfoTimerManage : ITimer
    {
        //private static ILog _log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.Name);
        private static ILog _log = log4net.LogManager.GetLogger("O");
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
                            this.SendOrderShipment();
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

        #region 订单拣货确认
        /// <summary>
        ///  订单拣货确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SendOrderShipment()
        {
            _log.Info("[拣货确认]－－－－开始.");
            BSendOrder bll = new BSendOrder();
            //订单己拣货未送信数据的取得
            string sendXmlData = "";
            DataSet ds = bll.GetSendOrderData(" O.SEND_STATUS = " + CConstant.ORDER_UNSEND);
            if (ds.Tables[0].Rows.Count > 0)
            {
                sendXmlData = CCommon.DataSetToXml("SEND_ORDER", ds.Tables[0]);
            }
            if (sendXmlData.Length <= 0)
            {
                //没有需要送信的数据
                _log.Info("[拣货确认]没有需要送信的数据。");
            }
            else
            {
                //订单拣货的送信
                try
                {
                    //送信服务
                    czzd.gszx.web.receive._Receive receive = new czzd.gszx.web.receive._Receive();
                    //服务器时间的取得
                    string serverTime = receive.GetSystemTime();
                    //简单加密用
                    string keys = DESEncrypt.Encrypt(CConstant.TYPE_LIST + serverTime + CConstant.E_COMMERCE_KEYS, CConstant.KEYS);
                    //调用WebService
                    string retXmlData = receive.ReceiveOrderInfos(CConstant.TYPE_LIST, sendXmlData, serverTime, keys);
                    //返回值处理
                    string status = CConstant.CONN_ERROR;
                    try
                    {
                        status = retXmlData.Substring(0, 2);
                    }
                    catch { }

                    if (status == CConstant.SUCCESS)
                    {
                        //所有订单返回信息的取得
                        DataSet retDs = CCommon.XmlToDataSet(retXmlData.Substring(2));
                        //订单拣货送信状态的更新
                        foreach (DataRow dr in retDs.Tables[0].Rows)
                        {
                            string orderId = CConvert.ToString(dr["orderId"]);
                            string orderSn = CConvert.ToString(dr["orderSn"]);

                            if (CConstant.SUCCESS.Equals(dr["status"]))
                            {
                                try
                                {
                                    if (bll.UpdateSendStatus(orderId, CConstant.ORDER_SEND))
                                    {
                                        _log.Info("[拣货确认][" + orderSn + "]送信成功。");
                                    }
                                    else
                                    {
                                        _log.Info("[拣货确认][" + orderSn + "]送信状态回写失败。");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    _log.Error("[拣货确认][" + orderSn + "]送信状态回写失败。", ex);
                                }
                            }
                            else
                            {
                                _log.Info("[拣货确认][" + orderSn + "]送信失败。");
                            }
                        }
                    }
                    else if (status == CConstant.ERROR)
                    {
                        _log.Info("[拣货确认]服务器数据处理异常。");
                    }
                    else if (status == CConstant.CONN_ERROR)
                    {
                        _log.Info("[拣货确认]服务器连接失败。");
                    }
                }
                catch (WebException wex)
                {
                    _log.Info("[拣货确认]服务器连接失败。", wex);
                }
                catch (Exception ex)
                {
                    _log.Info("[拣货确认]系统异常。", ex);
                }
            }
            _log.Info("[拣货确认]－－－－结束.");
        }
        #endregion

    }//end class
}
