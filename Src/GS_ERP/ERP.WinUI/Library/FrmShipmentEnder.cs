using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Main;
using CZZD.ERP.Model;
using CZZD.ERP.CacheData;
using System.Collections;
using CZZD.ERP.Common;
using System.IO;
using System.Text.RegularExpressions;
using CZZD.ERP.Bll;
using CZZD.ERP.WinUI.Properties;

namespace CZZD.ERP.WinUI
{
    public partial class FrmShipmentEnder : FrmBase
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        BOrderInfo border = new BOrderInfo();
        DataTable AreaTables = null;
        FastReport.Report report = new FastReport.Report();
        FastReport.Preview.PreviewControl previewControl1 = new FastReport.Preview.PreviewControl();
        public FrmShipmentEnder()
        {
            InitializeComponent();
        }


        private void FrmShipmentEnder_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Tag = CTag;
            AreaTables = border.GetAreaInfo().Tables[0];
            DataTable bregTable = AreatableInfo(AreaTables, 1);
            cmbSheng.ValueMember = "ID";
            cmbSheng.DisplayMember = "NAME";
            cmbSheng.DataSource = bregTable;
        }


        public DataTable AreaTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", Type.GetType("System.Int32"));
            dt.Columns.Add("NAME", Type.GetType("System.String"));
            return dt;
        }


        public DataTable AreatableInfo(DataTable dt, int id)
        {
            DataTable bregTable = AreaTable();
            DataRow[] SAreatable = null;
            SAreatable = dt.Select("PARENT_ID=" + id);
            for (int i = 0; i < SAreatable.Length; i++)
            {
                DataRow row = bregTable.NewRow();
                row["ID"] = CConvert.ToInt32(SAreatable[i]["REGION_ID"]);
                row["NAME"] = SAreatable[i]["REGION_NAME"];
                bregTable.Rows.Add(row);
            }
            return bregTable;
        }

        private void cmdShi_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable bregTable = AreatableInfo(AreaTables, CConvert.ToInt32(cmdShi.SelectedValue));
            cmbQu.ValueMember = "ID";
            cmbQu.DisplayMember = "NAME";
            cmbQu.DataSource = bregTable;
        }

        private void cmbQu_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable bregTable = AreatableInfo(AreaTables, CConvert.ToInt32(cmbQu.SelectedValue));
            cmbJied.ValueMember = "ID";
            cmbJied.DisplayMember = "NAME";
            cmbJied.DataSource = bregTable;
        }

        private void cmbSheng_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable bregTable = AreatableInfo(AreaTables, CConvert.ToInt32(cmbSheng.SelectedValue));
            cmdShi.ValueMember = "ID";
            cmdShi.DisplayMember = "NAME";
            cmdShi.DataSource = bregTable;
        }

        private void btnOutProduct_Click(object sender, EventArgs e)
        {
            if (dgvData.Rows.Count < 0)
            {
                MessageBox.Show("没有可出货的订单", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                string message = "";
                int i = 0;
                foreach (DataGridViewRow Drow in dgvData.Rows)
                {
                    BaseOrderInfoTable orderTable = new BaseOrderInfoTable();
                    orderTable.ORDER_SN = Drow.Cells["ORDER_SN"].Value.ToString();
                    orderTable.ORDER_TYPE = CConvert.ToInt32(Drow.Cells["ORDER_TYPE"].Value);
                    orderTable.ORDER_STATUS = CConstant.ShIPPING_THREE;

                    BaseDeliveryTable bdtatble = new BaseDeliveryTable();
                    bdtatble.DELIVERY_CODE = border.GetMaxDeliveryCode();
                    bdtatble.COMMUNITY_CODE = CConvert.ToInt32(Drow.Cells["COMMUNITY_CODE"].Value.ToString());
                    bdtatble.CONSIGNEE = Drow.Cells["CONSIGNEE"].Value.ToString();
                    bdtatble.ORDER_ID = CConvert.ToDecimal(Drow.Cells["ORDER_SN"].Value.ToString());
                    bdtatble.STATUS_FLAG = 0;

                    BaseSendOrderStatusTable sendStatusTable = new BaseSendOrderStatusTable();
                    sendStatusTable.CREATE_DATE_TIME = DateTime.Now;
                    sendStatusTable.ORDER_ID = CConvert.ToDecimal(Drow.Cells["ORDER_ID"]);
                    sendStatusTable.ORDER_SN = Drow.Cells["ORDER_SN"].Value.ToString();
                    sendStatusTable.ORDER_STATUS = CConstant.SEND_ORDER_STATUS_FA;
                    sendStatusTable.SEND_STATUS = 0;

                    if (border.AddDeliveryInfo(orderTable, bdtatble,sendStatusTable) < 0)
                    {
                        message += "订单" + Drow.Cells["ORDER_ID"].Value + "出货失败 \r\n";
                    }
                }
                if (message.Length > 0)
                {
                    MessageBox.Show(message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    MessageBox.Show("出货成功", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvData.AutoGenerateColumns = false;
            DataSet ds = border.GetOrderTable(GetQustring());
            if (ds.Tables[0] != null)
            {
                dgvData.DataSource = ds.Tables[0];
            }
        }


        public string GetQustring()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" ORDER_STATUS={0} ", CConstant.ShIPPING_TWO);
            if (txtSlipDateFrom.Checked)
            {
                sql.AppendFormat(" AND BEST_TIME>'{0}'", txtSlipDateFrom.Value);
            }
            if (txtSlipDateTo.Checked)
            {
                sql.AppendFormat(" AND BEST_TIME<'{0}'", txtSlipDateTo.Value);
            }
            //sql.AppendFormat(" AND PROVINCE='{0}' AND CITY='{1}' AND DISTRICT='{2}' AND COMMUNITY='{3}' ", cmbSheng.Text, cmdShi.Text, cmbQu.Text, cmbJied.Text);
            sql.AppendFormat(" AND PROVINCE='{0}' AND CITY='{1}' AND DISTRICT='{2}'", cmbSheng.Text, cmdShi.Text, cmbQu.Text);
            return sql.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnOutPrint_Click(object sender, EventArgs e)
        {
            string fileName = "";
            fileName = @"Reports\printOut.frx";
            int type = 0;
            if (dgvData.Rows.Count == 0)
            {
                MessageBox.Show("没有可打印的订单！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("CODE", Type.GetType("System.String"));
            dt.Columns.Add("SLIP_CODE", Type.GetType("System.String"));
            dt.Columns.Add("CUSTOMER_NAME", Type.GetType("System.String"));
            dt.Columns.Add("CUSTOMER_ADDRESS", Type.GetType("System.String"));
            foreach (DataGridViewRow item in dgvData.Rows)
            {
                DataRow ndt = dt.NewRow();
                ndt["CODE"] = item.Cells["COMMUNITY_CODE"].Value.ToString();
                ndt["SLIP_CODE"] = item.Cells["ORDER_SN"].Value.ToString();
                ndt["CUSTOMER_NAME"] = item.Cells["CONSIGNEE"].Value.ToString();
                ndt["CUSTOMER_ADDRESS"] = item.Cells["ADDRESS"].Value.ToString();
                dt.Rows.Add(ndt);
            }
            DataTable dt1 = dt.Copy();
            dt1.TableName = "ds";
            DataSet ds = new DataSet();
            ds.Tables.Add(dt1);
            report.Preview = previewControl1;
            report.Load(fileName);
            report.SetParameterValue("address", cmbSheng.Text + cmdShi.Text + cmbQu.Text + cmbJied.Text);
            report.SetParameterValue("Fromdatatime", DateTime.Now.ToString("yyyy-MM-dd"));
            report.SetParameterValue("SuserName", UserTable.NAME);
            report.RegisterData(ds);
            report.Prepare();
            report.ShowPrepared();
            report.Export(new FastReport.Export.Pdf.PDFExport(), @"d:\a.pdf");
            //report.PrintSettings.ShowDialog = false;
            //report.Print();
        }
    }
}
