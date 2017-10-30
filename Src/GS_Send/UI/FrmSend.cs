using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using CZZD.GSZX.S.Common;
using System.Net;
using CZZD.GSZX.S.Bll;
using CZZD.GSZX.S.Model;
using log4net;
using System.Reflection;
using System.Threading;
using log4net.Core;

namespace CZZD.GSZX.S.UI
{
    public partial class _Send : Form
    {
        //private static ILog _log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.Name);
        private static ILog _log = log4net.LogManager.GetLogger("M");
        private log4net.Appender.MemoryAppender logger;
        private bool logWatching = true;
        private Thread logWatcher;

        private string _startName = "己启动";
        private string _stopName = "己停止";

        private OrderInfoTimerManage orderInfoTimer = new OrderInfoTimerManage();
        private OrderReceiptTimerManage orderReceiptTimer = new OrderReceiptTimerManage();


        public _Send()
        {
            InitializeComponent();
        }

        #region 页面加载初始化
        /// <summary>
        /// 
        /// </summary>
        private void send_Load(object sender, EventArgs e)
        {
            logger = new log4net.Appender.MemoryAppender();
            log4net.Config.BasicConfigurator.Configure(logger);
            logWatcher = new Thread(new ThreadStart(LogWatcher));
            logWatcher.Start();
            _log.Info("System start.");

            InitTrunList();
        }

        /// <summary>
        /// 下拉列表中数据的初始化
        /// </summary>
        private void InitTrunList()
        {
            this.cboTrunList.Items.Add(new Item(CConstant.TIMER_ORDER_INFO, "订单拣货确认送信", false, _stopName));
            this.cboTrunList.Items.Add(new Item(CConstant.TIMER_ORDER_DELIVERY, "订单送货确认送信", false, _stopName));
            this.cboTrunList.Items.Add(new Item(CConstant.TIMER_ORDER_RECEIPT, "订单收货确认送信", false, _stopName));
            this.cboTrunList.SelectedIndex = 0;
        }
        #endregion

        #region LOG4NET显示处理
        /// <summary>
        /// 对LOG4NET进行监听
        /// </summary>
        private void LogWatcher()
        {
            while (logWatching)
            {
                LoggingEvent[] events = logger.GetEvents();
                if (events != null && events.Length > 0)
                {
                    logger.Clear();
                    foreach (LoggingEvent ev in events)
                    {
                        string line = ev.TimeStamp + "[" + ev.Level + "][" + ev.LoggerName + "] - " + ev.RenderedMessage + "\r\n";
                        AppendLog(line);
                    }
                }
                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// 将LOG4NET的监听内容写入Txtbox
        /// </summary>
        delegate void delOneStr(string log);
        void AppendLog(string _log)
        {
            if (txtLog.InvokeRequired)
            {
                delOneStr dd = new delOneStr(AppendLog);
                txtLog.Invoke(dd, new object[] { _log });
            }
            else
            {
                StringBuilder builder;
                if (txtLog.Lines.Length > 99)
                {
                    builder = new StringBuilder(txtLog.Text);
                    builder.Remove(0, txtLog.Text.IndexOf('\r', txtLog.Text.Length) + 2);
                    builder.Append(_log);
                    txtLog.Clear();
                    txtLog.AppendText(builder.ToString());
                }
                else
                {
                    txtLog.AppendText(_log);
                }
            }
        }

        #endregion

        #region 计划任务的选择变更
        /// <summary>
        /// 计划任务的选择变更
        /// </summary>
        private void cboTrunList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblStatus.Text = ((Item)cboTrunList.SelectedItem).STATUS_NAME;
        }
        #endregion

        #region 计划任务的启动/停止
        /// <summary>
        /// 计划任务启动
        /// </summary>
        private void btnStart_Click(object sender, EventArgs e)
        {
            Item item = (Item)cboTrunList.SelectedItem;
            if (!item.STATUS)
            {
                ExecuteTimer(item.VALUE, true);
                item.STATUS = true;
                item.STATUS_NAME = _startName;
                this.lblStatus.Text = item.STATUS_NAME;
            }
        }

        /// <summary>
        /// 计划任务停止
        /// </summary>
        private void btnStop_Click(object sender, EventArgs e)
        {
            Item item = (Item)cboTrunList.SelectedItem;
            if (item.STATUS)
            {
                ExecuteTimer(item.VALUE, false);
                item.STATUS = false;
                item.STATUS_NAME = _stopName;
                this.lblStatus.Text = item.STATUS_NAME;
            }
        }

        /// <summary>
        /// 启动所有的计划任务
        /// </summary>
        private void btnStartAll_Click(object sender, EventArgs e)
        {
            foreach (Item item in cboTrunList.Items)
            {
                if (!item.STATUS)
                {
                    ExecuteTimer(item.VALUE, true);
                    item.STATUS = true;
                    item.STATUS_NAME = _startName;
                    this.lblStatus.Text = item.STATUS_NAME;
                }
            }
        }

        /// <summary>
        /// 停止所有的计划任务
        /// </summary>
        private void btnStopAll_Click(object sender, EventArgs e)
        {
            foreach (Item item in cboTrunList.Items)
            {
                if (item.STATUS)
                {
                    ExecuteTimer(item.VALUE, false);
                    item.STATUS = false;
                    item.STATUS_NAME = _stopName;
                    this.lblStatus.Text = item.STATUS_NAME;
                }
            }
        }
        #endregion

        #region 定时计划任务的执行
        /// <summary>
        /// 定时计划任务的执行
        /// </summary>
        private bool ExecuteTimer(string type, bool status)
        {
            switch (type)
            {
                case CConstant.TIMER_ORDER_INFO:
                    if (status)
                    {
                        orderInfoTimer.Setup();
                        orderInfoTimer.Start();
                        _log.Info("服务 [订单拣货确认送信] －－－－启动");
                    }
                    else
                    {
                        orderInfoTimer.Stop();
                        _log.Info("服务 [订单拣货确认送信] －－－－停止");
                    }
                    break;
                case CConstant.TIMER_ORDER_DELIVERY:
                    if (status)
                    {
                        orderReceiptTimer.Setup();
                        orderReceiptTimer.Start();
                        _log.Info("服务 [订单送货确认送信] －－－－启动");
                    }
                    else
                    {
                        orderReceiptTimer.Stop();
                        _log.Info("服务 [订单送货确认送信]  －－－－停止");
                    }
                    break;
                case CConstant.TIMER_ORDER_RECEIPT:
                    if (status)
                    {
                        orderReceiptTimer.Setup();
                        orderReceiptTimer.Start();
                        _log.Info("服务 [订单收货确认送信] －－－－启动");
                    }
                    else
                    {
                        orderReceiptTimer.Stop();
                        _log.Info("服务 [订单收货确认送信]  －－－－停止");
                    }
                    break;
            }
            return true;
        }
        #endregion

        #region 页面关闭处理

        private void send_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(" 确定要退出吗?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                logWatching = false;
                logWatcher.Join();
                _log.Info("System Quit.");
            }
            else
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void send_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        #endregion




    }//end class
}
