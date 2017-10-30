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
    public class OrderDeliveryTimerManage : ITimer
    {
        //private static ILog _log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.Name);
        private static ILog _log = log4net.LogManager.GetLogger("D");
        private int _orderDeliveryInterval;

        private Timer _orderDeliveryTimer;

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
            _orderDeliveryInterval = CConvert.ToInt32(XmlHelp.ReadXmlFile(CConstant.TIMER_ORDER_DELIVERY)) * 1000;
        }
        #endregion

        #region 服务开始
        /// <summary>
        /// 服务开始
        /// </summary>
        public void Start()
        {
            _cookie = new Object();
            _orderDeliveryTimer = new Timer(new TimerCallback(Execute), new TimerInfo(CConstant.TIMER_ORDER_DELIVERY), _orderDeliveryInterval, Timeout.Infinite);
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

                if (this._orderDeliveryTimer != null)
                {
                    this._orderDeliveryTimer.Dispose();
                    this._orderDeliveryTimer = null;
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
                        case CConstant.TIMER_ORDER_DELIVERY:
                            this.SendnOrderDelivery();
                            this._timer = this._orderDeliveryTimer;
                            this._interval = this._orderDeliveryInterval;
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

        #region 订单收货确认
        /// <summary>
        /// 订单收货确认 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SendnOrderDelivery()
        {
            _log.Info("[订单送货确认]－－－－－开始。");
            BSendOrderStatus bll = new BSendOrderStatus();
            string orderIds = "";
            //己送货订单的获得
            DataSet ds = bll.GetDataList(" STATUS_TYPE =" + CConstant.ORDER_DELIVERY + " AND SEND_STATUS=" + CConstant.ORDER_UNSEND);
            if (ds.Tables[0].Rows.Count <= 0)
            {
                _log.Info("[订单送货确认]没有需要送信的数据。");
            }
            else
            {
                //订单编号的整理
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    orderIds += CConvert.ToString(dr["ORDER_ID"]) + ",";
                }

                //订单收货状态送信
                try
                {
                    czzd.gszx.web.receive._Receive receive = new czzd.gszx.web.receive._Receive();
                    //服务器时间的取得
                    string serverTime = receive.GetSystemTime();
                    //简单加密用
                    string keys = DESEncrypt.Encrypt(CConstant.TIMER_ORDER_DELIVERY + serverTime + CConstant.E_COMMERCE_KEYS, CConstant.KEYS);
                    //调用WebService
                    string xmlData = receive.ReceiveOrderStatus(CConstant.TYPE_ORDER_RECEIPT, orderIds, serverTime, keys);
                    //返回值处理
                    string status = CConstant.CONN_ERROR;
                    try
                    {
                        status = xmlData.Substring(0, 2);
                    }
                    catch { }

                    if (status == CConstant.SUCCESS)
                    {
                        DataSet retDs = CCommon.XmlToDataSet(xmlData.Substring(2));
                        //本地数据库的更新
                        foreach (DataRow dr in retDs.Tables[0].Rows)
                        {
                            decimal orderId = CConvert.ToDecimal(dr["orderId"]);
                            string orderSn = "";
                            foreach (DataRow row in ds.Tables[0].Rows)
                            {
                                if (CConvert.ToDecimal(row["ORDER_ID"]) == orderId)
                                {
                                    orderSn = CConvert.ToString(row["ORDER_SN"]);
                                    break;
                                }
                            }
                            if (CConstant.SUCCESS.Equals(dr["status"]))
                            {
                                try
                                {
                                    if (bll.Update(orderId, CConstant.ORDER_DELIVERY))
                                    {
                                        _log.Info("[订单送货确认][" + orderSn + "]：送信成功。");
                                    }
                                    else
                                    {
                                        _log.Info("[订单送货确认][" + orderSn + "]：送信状态回写失败。");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    _log.Error("[订单送货确认][" + orderSn + "]：送信状态回写失败。", ex);
                                }
                            }
                            else
                            {
                                _log.Info("[订单送货确认][" + orderSn + "]：送信失败。");
                            }
                        }
                    }
                    else if (status == CConstant.ERROR)
                    {
                        _log.Info("[订单送货确认]服务器数据处理异常。");
                    }
                    else if (status == CConstant.CONN_ERROR)
                    {
                        _log.Info("[订单送货确认]服务器连接失败。");
                    }
                }
                catch (WebException wex)
                {
                    _log.Error("[订单送货确认]服务器连接失败。", wex);
                }
                catch (Exception ex)
                {
                    _log.Error("[订单送货确认]系统异常。", ex);
                }
            }
            _log.Info("[订单送货确认]－－－－－结束。");
        }
        #endregion

    }//end class
}
