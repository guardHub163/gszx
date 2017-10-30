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

namespace CZZD.GSZX.R.UI
{
    public class CustomerAddressTimer : ITimer
    {
        private static ILog _log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.Name);
        private int _customerAddressInterval;

        private Timer _customerAddressTimer;

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
            _customerAddressInterval = CConvert.ToInt32(XmlHelp.ReadXmlFile(CConstant.TIMER_CUSTOMER_ADDRESS)) * 1000;
        }
        #endregion

        #region 服务开始
        /// <summary>
        /// 服务开始
        /// </summary>
        public void Start()
        {
            _cookie = new Object();
            _customerAddressTimer = new Timer(new TimerCallback(Execute), new TimerInfo(CConstant.TIMER_CUSTOMER_ADDRESS), _customerAddressInterval, Timeout.Infinite);
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
               
                if (this._customerAddressTimer != null)
                {
                    this._customerAddressTimer.Dispose();
                    this._customerAddressTimer = null;
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
                        case CConstant.TIMER_CUSTOMER_ADDRESS:
                            new MasterReceiving().Receiving(tInfo.TYPE);
                            this._timer = this._customerAddressTimer;
                            this._interval = this._customerAddressInterval;
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

    }//end class
}
