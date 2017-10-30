using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;

namespace CZZD.GSZX.P.UI
{
    public class PrintTimerManage : ITimer
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        private int gszxDepositInterval;
        //private int con2vtSalesInterval;
        //private string con2vtPath;

        private Timer _depositSendTimer;
        private Timer _timer;
        private int _interval;
        private Object _cookie = null;
        private Object _lock = new Object();

        /// <summary>
        /// 定时计划任务的执行初始化
        /// </summary>
        public void Setup()
        {
            gszxDepositInterval = Convert.ToInt32(XmlHelp.gszxSalesInterval) * 1000;
           // con2vtSalesInterval = Convert.ToInt32(XmlHelp.con2vtSalesInterval) * 1000;
            //con2vtPath = XmlHelp.con2vtPath;

        }

        public void Start()
        {
            _cookie = new Object();
            _depositSendTimer = new Timer(new TimerCallback(Execute), new TimerInfo("CON2VT_DEPOSIT_SEND"), gszxDepositInterval, Timeout.Infinite);
            
        }

        public void Stop()
        {
            lock (this._lock)
            {
                _cookie = null;
                if (this._depositSendTimer != null)
                {
                    this._depositSendTimer.Dispose();
                    this._depositSendTimer = null;
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        private void Execute(Object info)
        {
            lock (_lock)
            {
                try
                {

                    TimerInfo tInfo = (TimerInfo)info;
                    switch (tInfo.TYPE)
                    {
                        case "CON2VT_DEPOSIT_SEND":
                            this.Send("DEPOSIT");
                            this._timer = this._depositSendTimer;
                            this._interval = this.gszxDepositInterval;
                            break;
                    }
                    Thread.Sleep(500);

                }
                catch (Exception ex)
                {
                    this._timer = null;
                    Logger.Error(ex.ToString());
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

        private void Send(string type)
        {
          
            if (type.Equals("DEPOSIT"))
            {
                PrintManage print= new PrintManage();
                print.UpdateOrderInfo();
            }
            else if (type.Equals("SALES"))
            {
                //send = new Con2VtSalesSend();
            }

            //if (send != null)
            //{
            //    send.Send();
            //}
        }

      
    
    }//end class
}
