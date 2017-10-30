using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Main;
using CZZD.ERP.CacheData;
using CZZD.ERP.Bll.Product;
using CZZD.ERP.Common;
using CZZD.ERP.WinUI.Properties;
using CZZD.ERP.Model;
using CZZD.ERP.WinUI.Production;

namespace CZZD.ERP.WinUI
{
    public partial class FrmUpLoadProductionDrawing : FrmBase
    {
        public FrmUpLoadProductionDrawing()
        {
            InitializeComponent();
        }
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);

        BProductionDrawing bProductionDrawing = new BProductionDrawing();
        private void FrmUpLoadProductionDrawing_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Tag = CTag;
            this.dgvData.AutoGenerateColumns = false;
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            cboStatus.DataSource = CCacheData.DrawingSTATUS;
            cboStatus.ValueMember = "CODE";
            cboStatus.DisplayMember = "NAME";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string strWhere = GetConduction();
            DataSet ds = bProductionDrawing.GetProductionDrawing(strWhere);
            if (ds.Tables[0].Rows.Count < 1)
            {
                txtSlipNumber.Clear();
                txtSlipType.Clear();
                txtSlipTypeName.Clear();
                cboStatus.SelectedIndex = 0;
                dateTimePicker1.Checked = false;
                dateTimePicker2.Checked = false;
                MessageBox.Show("查询的信息不存在!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                dgvData.DataSource = ds.Tables[0];
                for (int i = 0; i < dgvData.Rows.Count; i++)
                {
                    if (dgvData.Rows[i].Cells["PSDL_ACTUAL_END_TIME"].Value.ToString() == "")
                    {
                        dgvData.Rows[i].Cells["PSDL_ACTUAL_END_TIME"].Value = DateTime.Now.ToString();
                    }
                    if (dgvData.Rows[i].Cells["PSDL_STATUS_FLAG"].Value.ToString() == "0")
                    {
                        dgvData.Rows[i].Cells["Status"].Value = "未结束";
                    }
                    else if (dgvData.Rows[i].Cells["PSDL_STATUS_FLAG"].Value.ToString() == "1")
                    {
                        dgvData.Rows[i].Cells["Status"].Value = "结束";
                        dgvData[1, i].ReadOnly = true;
                        dgvData[6, i].ReadOnly = true;
                    }
                }
            }
        }

        private string GetConduction()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" PSDL_STATUS_FLAG <> {0}", CConstant.DELETE);
            if (!string.IsNullOrEmpty(txtSlipNumber.Text.Trim()))
            {
                sb.AppendFormat("AND PSDL_SLIP_NUMBER like '{0}'", txtSlipNumber.Text.Trim());
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
                sb.AppendFormat(" AND PSDL_STATUS_FLAG = '{0}'", cboStatus.SelectedValue.ToString());
            }
            return sb.ToString();

        }

        private void btnEndDrawing_Click(object sender, EventArgs e)
        {
            BaseProductionPlanLineTable planline = new BaseProductionPlanLineTable();
            BaseProductionPlanTable planTable = new BaseProductionPlanTable();
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
                MessageBox.Show("请选择数据!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        CHKSLIPNUMBER = row.Cells["PSDL_SLIP_NUMBER"].Value.ToString();
                    }
                    else if (CHKSLIPNUMBER != row.Cells["PSDL_SLIP_NUMBER"].Value.ToString())
                    {

                        MessageBox.Show("您选择的生产工单不相同,请重新选择!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (row.Cells["PSDL_STATUS_FLAG"].Value.ToString() == "0")
                    {


                        if (row.Cells["PSDL_ACTUAL_END_TIME"].Value.ToString() != "")
                        {
                            bpsppmodel.ACTUAL_END_TIME = Convert.ToDateTime(row.Cells["PSDL_ACTUAL_END_TIME"].Value.ToString());
                        }
                        else
                        {
                            MessageBox.Show("您选择的生产工单图纸加工结束日期不能为空!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        bpsppmodel.STATUS_FLAG = 1;
                        bpsppmodel.SLIP_NUMBER = row.Cells["PSDL_SLIP_NUMBER"].Value.ToString();
                        bpsppmodel.LINE_NUMBER = Convert.ToInt32(row.Cells["PSDL_LINE_NUMBER"].Value.ToString());
                        //planTable.a
                        planline.AddProductionProcess(bpsppmodel);
                    }

                    else if (row.Cells["PSDL_STATUS_FLAG"].Value.ToString() == "1")
                    {
                        MessageBox.Show("您选择的生产工单图纸加工已结束!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
            try
            {
                int result = bProductionDrawing.EndDrawing(planline);
                if (result < 1)
                {
                    MessageBox.Show("您选择的生产工单图纸加工结束失败,请检查数据。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("您选择的生产工单图纸加工结束成功。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            { }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            DataGridView dgv = (DataGridView)(sender);
            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex == 0)
                {
                    DataGridViewRow row = dgv.Rows[e.RowIndex];
                    row.Cells["NO"].Value = e.RowIndex + 1;
                    row.Cells["BTN_UPLOAD"].Value = Resources.line_upload_over;
                }

            }
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

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dgvData.Columns["BTN_UPLOAD"].Index)
                {
                    if (dgvData.Rows[e.RowIndex].Cells["PSDL_STATUS_FLAG"].Value.ToString() == "0")
                    {
                        
                        DrawingUpLoad frm = new DrawingUpLoad();
                        frm.SLIPNUMBER= dgvData.Rows[e.RowIndex].Cells["PSDL_SLIP_NUMBER"].Value.ToString();

                        if (frm.ShowDialog(this) == DialogResult.OK)
                        {
                        }

                        frm.Dispose();
                    }
                }

            }
            catch (Exception ex)
            {


            }
        }

        private void btnSlipType_MouseEnter(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.line_find_over);
        }

        private void btnSlipType_MouseLeave(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.line_find);
        }
    }
}
