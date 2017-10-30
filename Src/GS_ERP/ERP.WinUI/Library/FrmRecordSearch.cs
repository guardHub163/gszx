using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Main;
using CZZD.ERP.Common;
using CZZD.ERP.CacheData;
using CZZD.ERP.Model;
using System.Collections;
using CZZD.ERP.Bll;
using CZZD.ERP.WinUI.Properties;

namespace CZZD.ERP.WinUI
{
    public partial class FrmRecordSearch : FrmBase
    {
        BDelivery bdelivery = new BDelivery();
        public FrmRecordSearch()
        {
            InitializeComponent();
        }

        private void FrmRecordSearch_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Tag = CTag;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataSet ds = bdelivery.GetDeliveryTable(GetQustring());
            if (ds.Tables[0] != null)
            {
                ds.Tables[0].Columns.Add("NO", Type.GetType("System.Int32"));
                ds.Tables[0].Columns.Add("STATUS_NAME", Type.GetType("System.String"));
                int i = 0;
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    row["NO"] = i;
                    i++;
                    if (CConvert.ToInt32(row["STATUS_FLAG"]) == CConstant.LIBRARY_OUT)
                    {
                        row["STATUS_NAME"] = "已出货";
                    }
                    else
                    {
                        row["STATUS_NAME"] = "已收货";
                    }
                }
                dgvData.AutoGenerateColumns = false;
                dgvData.DataSource = ds.Tables[0];

            }
        }

        public string GetQustring()
        {
            StringBuilder str = new StringBuilder();
            str.Append(" 1=1 ");
            if (txtSlipNumber.Text != "")
            {
                str.AppendFormat(" AND ORDER_ID={0} ", txtSlipNumber.Text);
            }
            if (rdoOut.Checked)
            {
                str.AppendFormat(" AND STATUS_FLAG={0}", CConstant.LIBRARY_OUT);
            }
            else if (rdoInt.Checked)
            {
                str.AppendFormat(" AND STATUS_FLAG={0}", CConstant.LIBRARY_INT);
            }
            return str.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnenterOk_Click(object sender, EventArgs e)
        {
            if (dgvData.Rows.Count > 0)
            {
                string slipNumber = dgvData.Rows[dgvData.CurrentCell.RowIndex].Cells["ORDER_ID"].Value.ToString();
                string typeName = dgvData.Rows[dgvData.CurrentCell.RowIndex].Cells["STATUS_NAME"].Value.ToString();
                if (typeName != "已收货")
                {
                    try
                    {
                        BaseSendOrderStatusTable sendStatusTable = new BaseSendOrderStatusTable();
                        sendStatusTable.CREATE_DATE_TIME = DateTime.Now;
                        sendStatusTable.ORDER_ID = Convert.ToDecimal(dgvData.Rows[dgvData.CurrentCell.RowIndex].Cells["ORDER_ID"].Value.ToString());
                        sendStatusTable.ORDER_SN = dgvData.Rows[dgvData.CurrentCell.RowIndex].Cells["ORDER_SN"].Value.ToString();
                        sendStatusTable.ORDER_STATUS = CConstant.SEND_ORDER_STATUS_SHOU;
                        sendStatusTable.SEND_STATUS = 0;

                        if (bdelivery.Update(slipNumber, sendStatusTable))
                        {
                            MessageBox.Show("订单更新成功！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnSearch_Click(sender, e);
                            return;
                        }
                        else
                        {
                            MessageBox.Show("订单更新失败！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("订单更新失败！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("此订单已签收", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }


    }
}
