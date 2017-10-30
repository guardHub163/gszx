using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Main;
using CZZD.ERP.Bll.Product;
using CZZD.ERP.Common;
using CZZD.ERP.Bll;

namespace CZZD.ERP.WinUI
{
    public partial class FrmProductionScheduleDetails : FrmBase
    {
        public FrmProductionScheduleDetails()
        {
            InitializeComponent();
        }

        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        BProductionSchedule bProductionSchedule = new BProductionSchedule();
        BProductionPlanSearch bProductionPlanSearch = new BProductionPlanSearch();
        private string _oldSlipNumber = "";
        public FrmProductionScheduleDetails(string slipnumber)
        {
            InitializeComponent();
            _oldSlipNumber = slipnumber;
        }
        private void FrmProductionScheduleDetails_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Tag = CTag;
            this.dgvData.AutoGenerateColumns = false;
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvProduction.AutoGenerateColumns = false;
            this.dgvProduction.AllowUserToAddRows = false;
            this.dgvProduction.AllowUserToDeleteRows = false;
            DataSet ds = bProductionSchedule.GetProductionScheduleLine(" SLIP_NUMBER = '" + _oldSlipNumber + "'");
            dgvData.DataSource = ds.Tables[0];
            foreach (DataGridViewRow dr in dgvData.Rows)
            {
                if (dr.Cells["PSPP_ACTUAL_END_TIME"].Value.ToString() != "")
                {
                    if (Convert.ToDateTime(dr.Cells["END_DATE"].Value.ToString()) == Convert.ToDateTime(dr.Cells["PSPP_ACTUAL_END_TIME"].Value.ToString()))
                    {
                        dr.Cells["DelayTime"].Value = "0天";
                    }
                    else if (Convert.ToDateTime(dr.Cells["END_DATE"].Value.ToString()) > Convert.ToDateTime(dr.Cells["PSPP_ACTUAL_END_TIME"].Value.ToString()))
                    {
                        dr.Cells["DelayTime"].Value = "0天";
                    }
                    else if (Convert.ToDateTime(dr.Cells["END_DATE"].Value.ToString()) < Convert.ToDateTime(dr.Cells["PSPP_ACTUAL_END_TIME"].Value.ToString()))
                    {
                        string dateDiff = null;

                        TimeSpan ts1 = new TimeSpan(Convert.ToDateTime(dr.Cells["END_DATE"].Value.ToString()).Ticks);
                        TimeSpan ts2 = new TimeSpan(Convert.ToDateTime(dr.Cells["PSPP_ACTUAL_END_TIME"].Value.ToString()).Ticks);
                        TimeSpan ts = ts1.Subtract(ts2).Duration();
                        dateDiff = ts.Days.ToString() + "天";
                        //+ ts.Hours.ToString() + "小时"
                        // + ts.Minutes.ToString() + "分钟"
                        // + ts.Seconds.ToString() + "秒";
                        dr.Cells["DelayTime"].Value = dateDiff;
                    }
                }
                else
                {
                    if (Convert.ToDateTime(dr.Cells["END_DATE"].Value.ToString()) == Convert.ToDateTime(DateTime.Now.ToString()))
                    {
                        dr.Cells["DelayTime"].Value = "0天";
                    }
                    else if (Convert.ToDateTime(dr.Cells["END_DATE"].Value.ToString()) > Convert.ToDateTime(DateTime.Now.ToString()))
                    {
                        dr.Cells["DelayTime"].Value = "0天";
                    }
                    else if (Convert.ToDateTime(dr.Cells["END_DATE"].Value.ToString()) < Convert.ToDateTime(DateTime.Now.ToString()))
                    {
                        string dateDiff = null;

                        TimeSpan ts1 = new TimeSpan(Convert.ToDateTime(dr.Cells["END_DATE"].Value.ToString()).Ticks);
                        TimeSpan ts2 = new TimeSpan(Convert.ToDateTime(DateTime.Now.ToString()).Ticks);
                        TimeSpan ts = ts1.Subtract(ts2).Duration();
                        dateDiff = ts.Days.ToString() + "天";
                        dr.Cells["DelayTime"].Value = dateDiff;
                    }
                }
            }
        }
        private void dgvData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            DataGridView dgv = (DataGridView)(sender);
            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex == 0)
                {
                    DataGridViewRow row = dgv.Rows[e.RowIndex];
                    //
                    row.Cells["NO"].Value = e.RowIndex + 1;
                }
                //dgvProduction绑定数据
                DataGridViewRow rowline = dgvData.CurrentRow;
                label4.Text = rowline.Cells["TYPE_NAME"].Value.ToString();
                DataSet ds = bProductionPlanSearch.GetProductionPlan(" SLIP_NUMBER = '" + rowline.Cells["SLIP_NUMBER"].Value.ToString() + "'" + " AND LINE_NUMBER = '" + rowline.Cells["LINE_NUMBER"].Value.ToString() + "'");
                dgvProduction.DataSource = ds.Tables[0];
                foreach (DataGridViewRow dr in dgvProduction.Rows)
                {
                    if (dr.Cells["PSPP_ACTUAL_END_DATE"].Value.ToString() != "")
                    {
                        if (Convert.ToDateTime(dr.Cells["PSPP_PLAN_END_DATE"].Value.ToString()) == Convert.ToDateTime(dr.Cells["PSPP_ACTUAL_END_DATE"].Value.ToString()))
                        {
                            dr.Cells["DelayTimeProduction"].Value = "0天";
                        }
                        else if (Convert.ToDateTime(dr.Cells["PSPP_PLAN_END_DATE"].Value.ToString()) > Convert.ToDateTime(dr.Cells["PSPP_ACTUAL_END_DATE"].Value.ToString()))
                        {
                            dr.Cells["DelayTimeProduction"].Value = "0天";
                        }
                        else if (Convert.ToDateTime(dr.Cells["PSPP_PLAN_END_DATE"].Value.ToString()) < Convert.ToDateTime(dr.Cells["PSPP_ACTUAL_END_DATE"].Value.ToString()))
                        {
                            string dateDiff = null;

                            TimeSpan ts1 = new TimeSpan(Convert.ToDateTime(dr.Cells["PSPP_PLAN_END_DATE"].Value.ToString()).Ticks);
                            TimeSpan ts2 = new TimeSpan(Convert.ToDateTime(dr.Cells["PSPP_ACTUAL_END_DATE"].Value.ToString()).Ticks);
                            TimeSpan ts = ts1.Subtract(ts2).Duration();
                            dateDiff = ts.Days.ToString() + "天";
                            //+ ts.Hours.ToString() + "小时"
                            // + ts.Minutes.ToString() + "分钟"
                            // + ts.Seconds.ToString() + "秒";
                            dr.Cells["DelayTimeProduction"].Value = dateDiff;
                        }
                    }
                    else
                    {
                        if (Convert.ToDateTime(dr.Cells["PSPP_PLAN_END_DATE"].Value.ToString()) == Convert.ToDateTime(DateTime.Now.ToString()))
                        {
                            dr.Cells["DelayTimeProduction"].Value = "0天";
                        }
                        else if (Convert.ToDateTime(dr.Cells["PSPP_PLAN_END_DATE"].Value.ToString()) > Convert.ToDateTime(DateTime.Now.ToString()))
                        {
                            dr.Cells["DelayTimeProduction"].Value = "0天";
                        }
                        else if (Convert.ToDateTime(dr.Cells["PSPP_PLAN_END_DATE"].Value.ToString()) < Convert.ToDateTime(DateTime.Now.ToString()))
                        {
                            string dateDiff = null;

                            TimeSpan ts1 = new TimeSpan(Convert.ToDateTime(dr.Cells["PSPP_PLAN_END_DATE"].Value.ToString()).Ticks);
                            TimeSpan ts2 = new TimeSpan(Convert.ToDateTime(DateTime.Now.ToString()).Ticks);
                            TimeSpan ts = ts1.Subtract(ts2).Duration();
                            dateDiff = ts.Days.ToString() + "天";
                            dr.Cells["DelayTimeProduction"].Value = dateDiff;
                        }
                    }
                }




            }
        }

        private void dgvData_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.Row.Index >= 0)
            {
                DataGridViewRow row = dgvData.Rows[e.Row.Index];
                if ("".Equals(CConvert.ToString(row.Cells["SLIP_NUMBER"].Value)))
                {
                    row.Selected = false;
                }
            }

        }

        private void dgvProduction_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            DataGridView dgv = (DataGridView)(sender);
            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex == 0)
                {
                    DataGridViewRow row = dgv.Rows[e.RowIndex];
                    //
                    row.Cells["row"].Value = e.RowIndex + 1;
                }

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
