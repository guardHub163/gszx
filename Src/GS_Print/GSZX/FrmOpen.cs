using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.GSZX.P.BLL;
using CZZD.GSZX.P.Model;
using CZZD.GSZX.P.Common;
using System.Threading;
using log4net.Core;

namespace CZZD.GSZX.P.UI
{
    public partial class FrmOpen : Form
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger("打印服务");
        private bool logWatching = true;
        private log4net.Appender.MemoryAppender logger;
        private Thread logWatcher;

        private PrintTimerManage printTimerManage = new PrintTimerManage();

        //private string _start = "START";
        //private string _stop = "STOP";

        public FrmOpen()
        {
            InitializeComponent();
        }
      
        private void Form1_Load(object sender, EventArgs e)
        {
            this.comboBox1.Text = "打印订单";
            logger = new log4net.Appender.MemoryAppender();
            log4net.Config.BasicConfigurator.Configure(logger);
            logWatcher = new Thread(new ThreadStart(LogWatcher));
            logWatcher.Start();
            btnOpen_Click(sender,e);
        }

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

        #region 定时计划任务的执行

        private void btnOpen_Click(object sender, EventArgs e)
        {
            this.lblType.Text = "开启";
            printTimerManage.Setup();
            printTimerManage.Start();
            Logger.Info("打印订单服务已开启");
        }
        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.lblType.Text = "关闭";
            printTimerManage.Stop();
            Logger.Info("打印订单服务已关闭");
        }

        private void FrmOpen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(" 确定退出?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                logWatching = false;
                logWatcher.Join();
                Logger.Info("已退出.");
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void FrmOpen_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
