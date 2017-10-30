using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Main;
using CZZD.ERP.Bll.Product;
using CZZD.ERP.Bll;
using CZZD.ERP.Common;
using CZZD.ERP.CacheData;
using CZZD.ERP.Model;
using System.Text.RegularExpressions;
using CZZD.ERP.WinUI.Properties;

namespace CZZD.ERP.WinUI
{
    public partial class FrmProduction : FrmBase
    {
        public FrmProduction()
        {
            InitializeComponent();
        }
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        BProductionPlanSearch bProductionPlanSearch = new BProductionPlanSearch();
        private void FrmProduction_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Tag = CTag;
            this.dgvData.AutoGenerateColumns = false;
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            cboStatus.DataSource = CCacheData.STATUS;
            cboStatus.ValueMember = "CODE";
            cboStatus.DisplayMember = "NAME";
        }

        private void btnSeaarch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {

            string strWhere = GetConduction();
            DataSet ds = bProductionPlanSearch.GetProductionPlan(strWhere);
            if (ds.Tables[0].Rows.Count < 1)
            {
                txtSlipNumber.Clear();
                txtSlipType.Clear();
                txtSlipTypeName.Clear();
                cboStatus.SelectedIndex = 0;
                txtSlipDateFrom.Checked = false;
                txtSlipDateTo.Checked = false;
                dateTimePicker1.Checked = false;
                dateTimePicker2.Checked = false;

                MessageBox.Show("查询的信息不存在!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
               // dgvData.DataSource = ds.Tables[0];
                return;

            }
            else
            {
                dgvData.DataSource = ds.Tables[0];
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows[i]["PSPP_STATUS_FLAG"].ToString() == "0")
                    {
                        dgvData.Rows[i].Cells["START_DATE"].Value = DateTime.Now.ToString("yyyy-MM-dd");
                        //dgvData.Rows[i].Cells["END_DATE"].Value = DateTime.Now.ToString("yyyy-MM-dd");
                    }
                    else if (ds.Tables[0].Rows[i]["PSPP_STATUS_FLAG"].ToString() == "1")
                    {
                        dgvData.Rows[i].Cells["START_DATE"].Value = DateTime.Parse(ds.Tables[0].Rows[i]["PSPP_ACTUAL_START_TIME"].ToString()).ToString("yyyy-MM-dd");
                        dgvData.Rows[i].Cells["END_DATE"].Value = DateTime.Now.ToString("yyyy-MM-dd");
                        //dgvData.Rows[i].Cells["END_DATE"].Value = DateTime.Parse(ds.Tables[0].Rows[i]["PSPP_ACTUAL_END_TIME"].ToString()).ToString("yyyy-MM-dd");
                    }
                    else if (ds.Tables[0].Rows[i]["PSPP_STATUS_FLAG"].ToString() == "2")
                    {
                        dgvData.Rows[i].Cells["START_DATE"].Value = DateTime.Parse(ds.Tables[0].Rows[i]["PSPP_ACTUAL_START_TIME"].ToString()).ToString("yyyy-MM-dd");
                        dgvData.Rows[i].Cells["END_DATE"].Value = DateTime.Parse(ds.Tables[0].Rows[i]["PSPP_ACTUAL_END_TIME"].ToString()).ToString("yyyy-MM-dd");
                    }

                    if (dgvData.Rows[i].Cells["PRODUCTION_PROCESS_NAME"].Value.ToString() != "备料")
                    {
                        dgvData[11, i].ReadOnly = true;
                    }

                    if (ds.Tables[0].Rows[i]["PSPP_STATUS_FLAG"].ToString() == "1")
                    {
                        dgvData[9, i].ReadOnly = true;
                    }

                    if (ds.Tables[0].Rows[i]["PSPP_STATUS_FLAG"].ToString() == "2")
                    {
                        dgvData[1, i].ReadOnly = true;
                        dgvData[9, i].ReadOnly = true;
                        dgvData[10, i].ReadOnly = true;
                        dgvData[11, i].ReadOnly = true;
                    }

                }
            }
        }

        private string GetConduction()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" DEPARTMENT_CODE='{0}'", UserTable.DEPARTMENT_CODE);
            if (!string.IsNullOrEmpty(txtSlipNumber.Text.Trim()))
            {
                sb.AppendFormat("AND SLIP_NUMBER = '{0}'", txtSlipNumber.Text.Trim());
            }

            if (this.txtSlipDateFrom.Checked)
            {
                sb.AppendFormat(" AND PLAN_START_DATE >= '{0}'", txtSlipDateFrom.Value.ToString("yyyy-MM-dd"));
            }

            if (this.txtSlipDateTo.Checked)
            {
                sb.AppendFormat(" AND PLAN_START_DATE < '{0}'", txtSlipDateTo.Value.AddDays(1).ToString("yyyy-MM-dd"));
            }
            //出库预定日期From
            if (this.dateTimePicker1.Checked)
            {
                sb.AppendFormat(" AND PLAN_END_DATE >= '{0}'", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
            }
            //出库预定日期To
            if (this.dateTimePicker2.Checked)
            {
                sb.AppendFormat(" AND PLAN_END_DATE < '{0}'", dateTimePicker2.Value.AddDays(1).ToString("yyyy-MM-dd"));
            }

            if (!string.IsNullOrEmpty(txtSlipType.Text.Trim()))
            {
                sb.AppendFormat(" AND SLIP_TYPE_CODE = '{0}'", txtSlipType.Text.Trim());
            }
            if (!cboStatus.SelectedValue.ToString().Equals("4"))
            {
                sb.AppendFormat(" AND PSPP_STATUS_FLAG = '{0}'", cboStatus.SelectedValue.ToString());
            }
            return sb.ToString();

        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            BaseProductionPlanLineTable planline = new BaseProductionPlanLineTable();
            BaseProductionPlanTable PlanTable = new BaseProductionPlanTable();
            BaseProductionScheduleProductionProcessTable bpsppmodel = null;
            int CHKchooseCount = 0;
            //int CHKChoosesame = 0;
            foreach (DataGridViewRow dr in dgvData.Rows)
            {
                if (Convert.ToBoolean(dr.Cells["CHK"].Value) == true)
                {
                    CHKchooseCount++;
                }
            }
            if (CHKchooseCount < 1)
            {
                MessageBox.Show("请选择加工开始的数据!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string CHKSLIPNUMBER = "";
            for (int i = 0; i < dgvData.Rows.Count; i++)
            {
                bpsppmodel = new BaseProductionScheduleProductionProcessTable();
                if (Convert.ToBoolean(dgvData.Rows[i].Cells["CHK"].Value) == true)
                {
                    DataGridViewRow row = dgvData.Rows[i];
                    if (CHKSLIPNUMBER == "")
                    {
                        CHKSLIPNUMBER = row.Cells["SLIP_NUMBER"].Value.ToString();
                    }
                    else if (CHKSLIPNUMBER != row.Cells["SLIP_NUMBER"].Value.ToString())
                    {

                        MessageBox.Show("您选择的生产工单不相同,请重新选择!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (row.Cells["PSPP_STATUS_FLAG"].Value.ToString() == "0")
                    {

                        if (row.Cells["START_DATE"].Value.ToString() != "")
                        {
                            bpsppmodel.ACTUAL_START_TIME = Convert.ToDateTime(row.Cells["START_DATE"].Value.ToString());
                        }
                        else
                        {
                            MessageBox.Show("您选择的生产工单加工开始日期不能为空!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (row.Cells["END_DATE"].Value != null)
                        {
                            bpsppmodel.ACTUAL_END_TIME = Convert.ToDateTime(row.Cells["END_DATE"].Value.ToString());
                        }
                        else
                        { }
                        bpsppmodel.STATUS_FLAG = 1;
                        bpsppmodel.SLIP_NUMBER = row.Cells["SLIP_NUMBER"].Value.ToString();
                        bpsppmodel.SCHEDULE_LINE_NUNBER = Convert.ToInt32(row.Cells["SCHEDULE_LINE_NUNBER"].Value.ToString());
                        bpsppmodel.LINE_NUMBER = Convert.ToInt32(row.Cells["PSPP_LINE_NUMBER"].Value.ToString());
                        // model.AddProductionProcess(bpsppmodel);
                        PlanTable.AddItemProductionProcess(bpsppmodel);
                    }

                    else if (row.Cells["PSPP_STATUS_FLAG"].Value.ToString() == "1")
                    {
                        MessageBox.Show("您选择的生产工单加工已开始!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else if (row.Cells["PSPP_STATUS_FLAG"].Value.ToString() == "2")
                    {
                        MessageBox.Show("您选择的生产工单加工已结束!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    #region   更改明细中的status
                    //string strWhere = "SLIP_NUMBER=" + row.Cells["SLIP_NUMBER"].Value.ToString() + " AND SCHEDULE_LINE_NUNBER=" + Convert.ToInt32(row.Cells["SCHEDULE_LINE_NUNBER"].Value.ToString());
                    //DataSet ds = bProductionPlanSearch.GetProductionPlan(strWhere);
                    //int status = 0;
                    //int endstatus = 0;
                    //int count = ds.Tables[0].Rows.Count;
                    //foreach (DataRow dt in ds.Tables[0].Rows)
                    //{
                    //    if (Convert.ToInt32(dt["PSPP_STATUS_FLAG"]) == 0)
                    //    {
                    //        status++;
                    //    }
                    //    else if (Convert.ToInt32(dt["PSPP_STATUS_FLAG"]) == 2)
                    //    {
                    //        endstatus++;
                    //    }
                    //}
                    //if (status == count)
                    //{

                    //}
                    //else if (endstatus == count)
                    //{
                    //    planline = new BaseProductionPlanLineTable();
                    //    planline.SLIP_NUMBER = row.Cells["SLIP_NUMBER"].Value.ToString();
                    //    planline.LINE_NUMBER = Convert.ToInt32(row.Cells["SCHEDULE_LINE_NUNBER"].Value.ToString());
                    //    planline.STATUS_FLAG = 2;
                    //    PlanTable.AddItem(planline);
                    //}
                    //else
                    //{
                    //    planline = new BaseProductionPlanLineTable();
                    //    planline.SLIP_NUMBER = row.Cells["SLIP_NUMBER"].Value.ToString();
                    //    planline.LINE_NUMBER = Convert.ToInt32(row.Cells["SCHEDULE_LINE_NUNBER"].Value.ToString());
                    //    planline.STATUS_FLAG = 1;
                    //    PlanTable.AddItem(planline);
                    //}
                    //#endregion
                    //#region 更改status
                    //string strWhere1 = "SLIP_NUMBER=" + row.Cells["SLIP_NUMBER"].Value.ToString();
                    //DataSet scheduleds = bProductionPlanSearch.GetProductionPlan(strWhere1);
                    //int schedulestatus = 0;
                    //int scheduleendstatus = 0;
                    //int schedulecount = scheduleds.Tables[0].Rows.Count;
                    //foreach (DataRow dt in scheduleds.Tables[0].Rows)
                    //{
                    //    if (Convert.ToInt32(dt["PSL_STATUS_FLAG"]) == 0)
                    //    {
                    //        schedulestatus++;
                    //    }
                    //    else if (Convert.ToInt32(dt["PSL_STATUS_FLAG"]) == 2)
                    //    {
                    //        scheduleendstatus++;
                    //    }
                    //}
                    //if (schedulestatus == schedulecount)
                    //{

                    //}
                    //else if (scheduleendstatus == schedulecount)
                    //{

                    //    PlanTable.SLIP_NUMBER = row.Cells["SLIP_NUMBER"].Value.ToString();
                    //    PlanTable.STATUS_FLAG = 2;
                    //}
                    //else
                    //{
                    //    PlanTable.SLIP_NUMBER = row.Cells["SLIP_NUMBER"].Value.ToString();
                    //    PlanTable.STATUS_FLAG = 1;
                    //}
                    #endregion
                }
            }

            try
            {
                int result = bProductionPlanSearch.StartProcessing(PlanTable);
                if (result < 1)
                {
                    MessageBox.Show("您选择的生产工单加工开始失败,请检查数据。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    foreach (BaseProductionScheduleProductionProcessTable bpspptable in PlanTable.ItemsProductionProcess)
                    {// + " AND SCHEDULE_LINE_NUNBER=" + bpspptable.SCHEDULE_LINE_NUNBER
                        string strWhere = "SLIP_NUMBER=" + bpspptable.SLIP_NUMBER;
                        DataSet ds = bProductionPlanSearch.GetProductionPlan(strWhere);
                        int status = 0;
                        int endstatus = 0;
                        int count = ds.Tables[0].Rows.Count;
                        foreach (DataRow dt in ds.Tables[0].Rows)
                        {
                            if (Convert.ToInt32(dt["PSPP_STATUS_FLAG"]) == 0)
                            {
                                status++;
                            }
                            else if (Convert.ToInt32(dt["PSPP_STATUS_FLAG"]) == 2)
                            {
                                endstatus++;
                            }
                        }
                        if (status == count)
                        {

                        }
                        else if (endstatus == count)
                        {
                            planline = new BaseProductionPlanLineTable();
                            planline.SLIP_NUMBER = bpspptable.SLIP_NUMBER;
                            planline.LINE_NUMBER = Convert.ToInt32(bpspptable.SCHEDULE_LINE_NUNBER);
                            planline.STATUS_FLAG = 2;
                            PlanTable.AddItem(planline);
                        }
                        else
                        {
                            planline = new BaseProductionPlanLineTable();
                            planline.SLIP_NUMBER = bpspptable.SLIP_NUMBER;
                            planline.LINE_NUMBER = Convert.ToInt32(bpspptable.SCHEDULE_LINE_NUNBER);
                            planline.STATUS_FLAG = 1;
                            PlanTable.AddItem(planline);
                        }
                    }

                    try
                    {
                        int resultstatus = bProductionPlanSearch.LineStatus(PlanTable);
                    }
                    catch (Exception ex)
                    {

                    }
                    foreach (BaseProductionScheduleProductionProcessTable bpspptable in PlanTable.ItemsProductionProcess)
                    {
                        //更改status
                        string strWhere1 = "SLIP_NUMBER=" + bpspptable.SLIP_NUMBER;
                        DataSet scheduleds = bProductionPlanSearch.GetProductionPlan(strWhere1);
                        int schedulestatus = 0;
                        int scheduleendstatus = 0;
                        int schedulecount = scheduleds.Tables[0].Rows.Count;
                        foreach (DataRow dt in scheduleds.Tables[0].Rows)
                        {
                            if (Convert.ToInt32(dt["PSL_STATUS_FLAG"]) == 0)
                            {
                                schedulestatus++;
                            }
                            else if (Convert.ToInt32(dt["PSL_STATUS_FLAG"]) == 2)
                            {
                                scheduleendstatus++;
                            }
                        }
                        if (schedulestatus == schedulecount)
                        {

                        }
                        else if (scheduleendstatus == schedulecount)
                        {
                            PlanTable.SLIP_NUMBER = bpspptable.SLIP_NUMBER;
                            PlanTable.STATUS_FLAG = 2;
                        }
                        else
                        {
                            PlanTable.SLIP_NUMBER = bpspptable.SLIP_NUMBER;
                            PlanTable.STATUS_FLAG = 1;
                        }
                    }
                    try
                    {
                        int resultschedule = bProductionPlanSearch.Status(PlanTable);
                    }
                    catch (Exception ex)
                    {

                    }
                    MessageBox.Show("您选择的生产工单加工开始成功。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSlipNumber.Text = "";
                    cboStatus.SelectedIndex = 0;
                    Search();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("您选择的生产工单加工开始失败,请检查数据。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnEnd_Click(object sender, EventArgs e)
        {
            BaseProductionPlanLineTable planline = new BaseProductionPlanLineTable();
            BaseProductionPlanTable PlanTable = new BaseProductionPlanTable();
            BaseProductionScheduleProductionProcessTable bpsppmodel = null;
            int CHKchooseCount = 0;
            foreach (DataGridViewRow dr in dgvData.Rows)
            {
                if (Convert.ToBoolean(dr.Cells["CHK"].Value) == true)
                {
                    CHKchooseCount++;
                }
            }
            if (CHKchooseCount < 1)
            {
                MessageBox.Show("请选择加工结束的数据!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string CHKSLIPNUMBER = "";

            for (int i = 0; i < dgvData.Rows.Count; i++)
            {
                bpsppmodel = new BaseProductionScheduleProductionProcessTable();
                if (Convert.ToBoolean(dgvData.Rows[i].Cells["CHK"].Value) == true)
                {
                    DataGridViewRow row = dgvData.Rows[i];
                    if (CHKSLIPNUMBER == "")
                    {
                        CHKSLIPNUMBER = row.Cells["SLIP_NUMBER"].Value.ToString();
                    }
                    else if (CHKSLIPNUMBER != row.Cells["SLIP_NUMBER"].Value.ToString())
                    {

                        MessageBox.Show("您选择的生产工单不相同,请重新选择!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (row.Cells["PSPP_STATUS_FLAG"].Value.ToString() == "1")
                    {

                        bpsppmodel.ACTUAL_START_TIME = Convert.ToDateTime(row.Cells["START_DATE"].Value.ToString());
                        if (row.Cells["END_DATE"].Value.ToString() != "")
                        {
                            bpsppmodel.ACTUAL_END_TIME = Convert.ToDateTime(row.Cells["END_DATE"].Value.ToString());
                        }
                        else
                        {
                            MessageBox.Show("您选择的生产工单加工结束日期不能为空!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (DateTime.Compare(Convert.ToDateTime(bpsppmodel.ACTUAL_START_TIME), Convert.ToDateTime(bpsppmodel.ACTUAL_END_TIME)) > 0)
                        {
                            MessageBox.Show("您选择的生产工单加工开始日期不能大于加工结束日期!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        bpsppmodel.STATUS_FLAG = 2;
                        bpsppmodel.SLIP_NUMBER = row.Cells["SLIP_NUMBER"].Value.ToString();
                        bpsppmodel.SCHEDULE_LINE_NUNBER = Convert.ToInt32(row.Cells["SCHEDULE_LINE_NUNBER"].Value.ToString());
                        bpsppmodel.LINE_NUMBER = Convert.ToInt32(row.Cells["PSPP_LINE_NUMBER"].Value.ToString());
                        PlanTable.AddItemProductionProcess(bpsppmodel);
                    }
                    else if (row.Cells["PSPP_STATUS_FLAG"].Value.ToString() == "0")
                    {
                        MessageBox.Show("您选择的生产工单加工未开始!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else if (row.Cells["PSPP_STATUS_FLAG"].Value.ToString() == "2")
                    {
                        MessageBox.Show("您选择的生产工单加工已结束!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    #region delete
                    //更改明细中的status
                    //string strWhere = "SLIP_NUMBER=" + row.Cells["SLIP_NUMBER"].Value.ToString() + " AND SCHEDULE_LINE_NUNBER=" + Convert.ToInt32(row.Cells["SCHEDULE_LINE_NUNBER"].Value.ToString());
                    //DataSet ds = bProductionPlanSearch.GetProductionPlan(strWhere);
                    //int status = 0;
                    //int endstatus = 0;
                    //int count = ds.Tables[0].Rows.Count;
                    //foreach (DataRow dt in ds.Tables[0].Rows)
                    //{
                    //    if (Convert.ToInt32(dt["PSPP_STATUS_FLAG"]) == 0)
                    //    {
                    //        status++;
                    //    }
                    //    else if (Convert.ToInt32(dt["PSPP_STATUS_FLAG"]) == 2)
                    //    {
                    //        endstatus++;
                    //    }
                    //}
                    //if (status == count)
                    //{

                    //}
                    //else if (endstatus == count)
                    //{
                    //    planline = new BaseProductionPlanLineTable();
                    //    planline.SLIP_NUMBER = row.Cells["SLIP_NUMBER"].Value.ToString();
                    //    planline.LINE_NUMBER = Convert.ToInt32(row.Cells["SCHEDULE_LINE_NUNBER"].Value.ToString());
                    //    planline.STATUS_FLAG = 2;
                    //    PlanTable.AddItem(planline);
                    //}
                    //else
                    //{
                    //    planline = new BaseProductionPlanLineTable();
                    //    planline.SLIP_NUMBER = row.Cells["SLIP_NUMBER"].Value.ToString();
                    //    planline.LINE_NUMBER = Convert.ToInt32(row.Cells["SCHEDULE_LINE_NUNBER"].Value.ToString());
                    //    planline.STATUS_FLAG = 1;
                    //    PlanTable.AddItem(planline);
                    //}
                    ////更改status
                    //string strWhere1 = "SLIP_NUMBER=" + row.Cells["SLIP_NUMBER"].Value.ToString();
                    //DataSet scheduleds = bProductionPlanSearch.GetProductionPlan(strWhere1);
                    //int schedulestatus = 0;
                    //int scheduleendstatus = 0;
                    //int schedulecount = scheduleds.Tables[0].Rows.Count;
                    //foreach (DataRow dt in scheduleds.Tables[0].Rows)
                    //{
                    //    if (Convert.ToInt32(dt["PSL_STATUS_FLAG"]) == 0)
                    //    {
                    //        schedulestatus++;
                    //    }
                    //    else if (Convert.ToInt32(dt["PSL_STATUS_FLAG"]) == 2)
                    //    {
                    //        scheduleendstatus++;
                    //    }
                    //}
                    //if (schedulestatus == schedulecount)
                    //{

                    //}
                    //else if (scheduleendstatus == schedulecount)
                    //{
                    //    PlanTable.SLIP_NUMBER = row.Cells["SLIP_NUMBER"].Value.ToString();
                    //    PlanTable.STATUS_FLAG = 2;
                    //}
                    //else
                    //{
                    //    PlanTable.SLIP_NUMBER = row.Cells["SLIP_NUMBER"].Value.ToString();
                    //    PlanTable.STATUS_FLAG = 1;
                    //}
                    #endregion
                }
            }

            try
            {
                int result = bProductionPlanSearch.StartProcessing(PlanTable);
                if (result < 1)
                {
                    MessageBox.Show("您选择的生产工单加工结束失败,请检查数据。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    foreach (BaseProductionScheduleProductionProcessTable bpspptable in PlanTable.ItemsProductionProcess)
                    {//+ " AND SCHEDULE_LINE_NUNBER=" + bpspptable.SCHEDULE_LINE_NUNBER
                        string strWhere = "SLIP_NUMBER=" + bpspptable.SLIP_NUMBER;
                        DataSet ds = bProductionPlanSearch.GetProductionPlan(strWhere);
                        int status = 0;
                        int endstatus = 0;
                        int count = ds.Tables[0].Rows.Count;
                        foreach (DataRow dt in ds.Tables[0].Rows)
                        {
                            if (Convert.ToInt32(dt["PSPP_STATUS_FLAG"]) == 0)
                            {
                                status++;
                            }
                            else if (Convert.ToInt32(dt["PSPP_STATUS_FLAG"]) == 2)
                            {
                                endstatus++;
                            }
                        }
                        if (status == count)
                        {

                        }
                        else if (endstatus == count)
                        {
                            planline = new BaseProductionPlanLineTable();
                            planline.SLIP_NUMBER = bpspptable.SLIP_NUMBER;
                            planline.LINE_NUMBER = Convert.ToInt32(bpspptable.SCHEDULE_LINE_NUNBER);
                            planline.STATUS_FLAG = 2;
                            PlanTable.AddItem(planline);
                        }
                        else
                        {
                            planline = new BaseProductionPlanLineTable();
                            planline.SLIP_NUMBER = bpspptable.SLIP_NUMBER;
                            planline.LINE_NUMBER = Convert.ToInt32(bpspptable.SCHEDULE_LINE_NUNBER);
                            planline.STATUS_FLAG = 1;
                            PlanTable.AddItem(planline);
                        }
                    }

                    try
                    {
                        int resultstatus = bProductionPlanSearch.LineStatus(PlanTable);
                    }
                    catch (Exception ex)
                    {

                    }
                    foreach (BaseProductionScheduleProductionProcessTable bpspptable in PlanTable.ItemsProductionProcess)
                    {
                        //更改status
                        string strWhere1 = "SLIP_NUMBER=" + bpspptable.SLIP_NUMBER;
                        DataSet scheduleds = bProductionPlanSearch.GetProductionPlan(strWhere1);
                        int schedulestatus = 0;
                        int scheduleendstatus = 0;
                        int schedulecount = scheduleds.Tables[0].Rows.Count;
                        foreach (DataRow dt in scheduleds.Tables[0].Rows)
                        {
                            if (Convert.ToInt32(dt["PSL_STATUS_FLAG"]) == 0)
                            {
                                schedulestatus++;
                            }
                            else if (Convert.ToInt32(dt["PSL_STATUS_FLAG"]) == 2)
                            {
                                scheduleendstatus++;
                            }
                        }
                        if (schedulestatus == schedulecount)
                        {

                        }
                        else if (scheduleendstatus == schedulecount)
                        {
                            PlanTable.SLIP_NUMBER = bpspptable.SLIP_NUMBER;
                            PlanTable.STATUS_FLAG = 2;
                        }
                        else
                        {
                            PlanTable.SLIP_NUMBER = bpspptable.SLIP_NUMBER;
                            PlanTable.STATUS_FLAG = 1;
                        }
                    }
                    try
                    {
                        int resultschedule = bProductionPlanSearch.Status(PlanTable);
                    }
                    catch (Exception ex)
                    {

                    }

                    MessageBox.Show("您选择的生产工单加工结束成功。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSlipNumber.Text = "";
                    cboStatus.SelectedIndex = 0;
                    Search();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("您选择的生产工单加工结束失败,请检查数据。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSlipNumber_Click(object sender, EventArgs e)
        {
            FrmProductionPlanSearch frm = new FrmProductionPlanSearch();
            frm.CTag = CConstant.ORDER_MASTER_SEARCH;
            if (frm.ShowDialog(this) == DialogResult.OK)
            {

            }
            txtSlipNumber.Text = frm.SLIPNUMBER.ToString();
            frm.Dispose();
        }

        private void btnSlipType_Click(object sender, EventArgs e)
        {

            FrmMasterSearch frm = new FrmMasterSearch("SLIP_TYPE", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtSlipType.Text = frm.BaseMasterTable.Code;
                    txtSlipTypeName.Text = frm.BaseMasterTable.Name;
                }
            }

            frm.Dispose();
        }

        private void dgvData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            DataGridView dgv = (DataGridView)(sender);
            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex == 0)
                {
                    DataGridViewRow row = dgv.Rows[e.RowIndex];
                    row.Cells["No"].Value = e.RowIndex + 1;
                }
            }
        }
        static private Regex r = new Regex("^(?:(?!0000)[0-9]{4}([-/.]?)(?:(?:0?[1-9]|1[0-2])([-/.]?)(?:0?[1-9]|1[0-9]|2[0-8])|(?:0?[13-9]|1[0-2])([-/.]?)(?:29|30)|(?:0?[13578]|1[02])([-/.]?)31)|(?:[0-9]{2}(?:0[48]|[2468][048]|[13579][26])|(?:0[48]|[2468][048]|[13579][26])00)([-/.]?)0?2([-/.]?)29)");
        private void dgvData_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = dgvData.Rows[e.RowIndex];
            if (e.ColumnIndex == dgvData.Columns["START_DATE"].Index)
            {
                if (dr.Cells["START_DATE"].Value != null)
                {
                    if (!r.IsMatch(dr.Cells["START_DATE"].Value.ToString().Trim()))
                    {
                        //MessageBox.Show("请输入正确的日期");
                        MessageBox.Show("请输入正确的日期。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvData.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                    }
                }
            }
            if (e.ColumnIndex == dgvData.Columns["END_DATE"].Index)
            {
                if (dr.Cells["END_DATE"].Value != null)
                {
                    if (!r.IsMatch(dr.Cells["END_DATE"].Value.ToString().Trim()))
                    {
                        MessageBox.Show("请输入正确的日期。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // MessageBox.Show("请输入正确的日期");
                        dgvData.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                    }
                }
            }
        }

        private void btnSlipNumber_MouseEnter(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.find_over);
        }

        private void btnSlipNumber_MouseLeave(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.find);
        }

        private void btnSlipType_MouseEnter(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.find_over);
        }

        private void btnSlipType_MouseLeave(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.find);
        }
    }
}


