using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using CZZD.GSZX.R.Common;
using System.Net;
using CZZD.GSZX.R.Bll;
using CZZD.GSZX.R.Model;
using System.Reflection;
using log4net;
using System.Threading;
using log4net.Core;

namespace CZZD.GSZX.R.UI
{
    public partial class _Receive : Form
    {
        private static ILog _log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.Name);
        private BCommon bCommon = new BCommon();
        private MasterReceiving mdr = new MasterReceiving();


        private log4net.Appender.MemoryAppender logger;
        private bool logWatching = true;
        private Thread logWatcher;

        private string _startName = "运行中";
        private string _stopName = "己停止";

        private OrderInfoTimer _orderInfoTimer = new OrderInfoTimer();
        private ProductCategoryTimer _productCategoryTimer = new ProductCategoryTimer();
        private ProductTimer _productTimer = new ProductTimer();
        private CustomerTimer _customerTimer = new CustomerTimer();
        private CustomerAddressTimer _customerAddressTimer = new CustomerAddressTimer();


        public _Receive()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void receive_Load(object sender, EventArgs e)
        {
            logger = new log4net.Appender.MemoryAppender();
            log4net.Config.BasicConfigurator.Configure(logger);
            logWatcher = new Thread(new ThreadStart(LogWatcher));
            logWatcher.Start();
            _log.Info("Integrated System start.");

            InitTrunList();
        }

        /// <summary>
        /// 下拉列表中数据的初始化
        /// </summary>
        private void InitTrunList()
        {
            this.cboTrunList.Items.Add(new Item(CConstant.TIMER_ORDER_INFO, "销售订单同步", false, _stopName));
            this.cboTrunList.Items.Add(new Item(CConstant.TIMER_PRODUCT_CATEGORY, "商品类别信息同步", false, _stopName));
            this.cboTrunList.Items.Add(new Item(CConstant.TIMER_PRODUCT, "商品信息同步", false, _stopName));
            this.cboTrunList.Items.Add(new Item(CConstant.TIMER_CUSTOMER, "会员信息同步", false, _stopName));
            this.cboTrunList.Items.Add(new Item(CConstant.TIMER_CUSTOMER_ADDRESS, "会员收货地址同步", false, _stopName));
            this.cboTrunList.SelectedIndex = 0;
        }


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
                        _orderInfoTimer.Setup();
                        _orderInfoTimer.Start();
                        _log.Info("服务 [销售订单同步] 运行中....");
                    }
                    else
                    {
                        _orderInfoTimer.Stop();
                        _log.Info("服务 [销售订单同步] 停止.");
                    }
                    break;
                case CConstant.TIMER_PRODUCT_CATEGORY:
                    if (status)
                    {
                        _productCategoryTimer.Setup();
                        _productCategoryTimer.Start();
                        _log.Info("服务 [商品类别信息同步] 运行中....");
                    }
                    else
                    {
                        _productCategoryTimer.Stop();
                        _log.Info("服务 [商品类别信息同步] 停止.");
                    }
                    break;
                case CConstant.TIMER_PRODUCT:
                    if (status)
                    {
                        _productTimer.Setup();
                        _productTimer.Start();
                        _log.Info("服务 [商品信息同步] 运行中....");
                    }
                    else
                    {
                        _productTimer.Stop();
                        _log.Info("服务 [商品信息同步] 停止.");
                    }
                    break;
                case CConstant.TIMER_CUSTOMER:
                    if (status)
                    {
                        _customerTimer.Setup();
                        _customerTimer.Start();
                        _log.Info("服务 [会员信息同步] 运行中....");
                    }
                    else
                    {
                        _customerTimer.Stop();
                        _log.Info("服务 [会员信息同步] 停止.");
                    }
                    break;
                case CConstant.TIMER_CUSTOMER_ADDRESS:
                    if (status)
                    {
                        _customerAddressTimer.Setup();
                        _customerAddressTimer.Start();
                        _log.Info("服务 [会员收货地址同步] 运行中....");
                    }
                    else
                    {
                        _customerAddressTimer.Stop();
                        _log.Info("服务 [会员收货地址同步] 停止.");
                    }
                    break;
            }
            return true;
        }
        #endregion

        #region 页面关闭处理

        private void receive_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(" Quit system?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                logWatching = false;
                logWatcher.Join();
                _log.Info("Integrated System Quit.");
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void receive_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        #endregion
    }//end class
}
