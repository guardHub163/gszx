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
    public partial class FrmLibrary : FrmBase
    {
        private DataTable _currentDt = new DataTable();
        public BOrderInfo orderTable = new BOrderInfo();
        BOrderInfo border = new BOrderInfo();
        BOrderGoods bordergoods = new BOrderGoods();
        public string order_sn = "";
        public string order_type = "";
        public FrmLibrary()
        {
            InitializeComponent();
        }

        private void FrmLibrary_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Tag = CTag;
        }

        private void txtSlipNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //if (txtSlipNumber.Text.Length != 13)
                //{
                //    MessageBox.Show("非本类订单！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    this.txtSlipNumber.Text = "";
                //    return;
                //}
                try
                {
                    order_type = txtSlipNumber.Text.ToString().Substring(0, 1);
                    order_sn = txtSlipNumber.Text.ToString().Substring(1);
                }
                catch
                {
                    MessageBox.Show("订单不存在", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtSlipNumber.Text = "";
                    return;
                }

                BaseOrderInfoTable orderTable = border.GetOrderSnModel(CConvert.ToDecimal(order_sn), CConvert.ToInt32(order_type));
                if (orderTable == null)
                {
                    MessageBox.Show("订单不存在", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtSlipNumber.Text = "";
                    return;
                }
                if (orderTable.ORDER_STATUS == CConstant.ORDER_STATUS_DELETE)
                {
                    MessageBox.Show("此订单已取消,无法进行操作！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtSlipNumber.Text = "";
                    return;
                }
                if (orderTable.SHIPPING_STATUS == CConstant.ShIPPING_TWO)
                {
                    MessageBox.Show("此订单已出货", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtSlipNumber.Text = "";
                    return;
                }
                txtSlipNumber.Enabled = false;

                if (orderTable != null)
                {
                    txtCustomercode.Text = orderTable.USER_ID.ToString();
                    txtCustomerName.Text = orderTable.CONSIGNEE;
                    if (orderTable.ORDER_STATUS == CConstant.ORDER_STATUS_ENDER)
                    {
                        txtSlipNumberType.Text = "已确认";
                    }
                    else
                    {
                        txtSlipNumberType.Text = "已取消";
                    }
                    if (orderTable.SHIPPING_STATUS == CConstant.ShIPPING_ONE)
                    {
                        txtShipp_status.Text = "未发货";
                    }
                    else
                    {
                        txtShipp_status.Text = "已发货";
                    }
                    if (orderTable.PAY_STATUS == 0)
                    {
                        txtpayType.Text = "未付款";
                    }
                    else
                    {
                        txtpayType.Text = "已付款";
                    }
                    txtCountry.Text = getAreaName(orderTable.COMMUNITY);
                    txtProvince.Text = getAreaName(orderTable.PROVINCE);
                    txtCity.Text = getAreaName(orderTable.CITY);
                    txtdistrict.Text = getAreaName(orderTable.DISTRICT);
                    txtAdress.Text = orderTable.ADDRESS;
                    txtPhone.Text = orderTable.TEL;
                    txtTel.Text = orderTable.MOBILE;
                    txtEndTime.Text = CConvert.ToDateTime(orderTable.BEST_TIME.ToString()).ToString("yyyy-MM-dd");
                    txtDemo.Text = orderTable.POST_SCRIPT;
                    if (orderTable.INV_TYPE == CConstant.INV_Z.ToString())
                    {
                        txtInvType.Text = "增值税发票";
                    }
                    else
                    {
                        txtInvType.Text = "个人发票";
                    }
                    txtInvInfo.Text = orderTable.INV_CONTENT;
                    txtInvHead.Text = orderTable.INV_PAYEE;
                    DataTable orderGoodsTable = bordergoods.GetGoodsInfo(CConvert.ToInt32(order_type), CConvert.ToDecimal(orderTable.ORDER_ID)).Tables[0];
                    foreach (DataRow row in orderGoodsTable.Rows)
                    {
                        int numcode = dgvData.RowCount;
                        int currentRowID = dgvData.Rows.Add(1);
                        DataGridViewRow dgvr = dgvData.Rows[currentRowID];
                        dgvr.Cells["No"].Value = (numcode + 1).ToString();
                        dgvr.Cells["product_code"].Value = row["GOODS_SN"].ToString();
                        dgvr.Cells["product_name"].Value = row["GOODS_NAME"].ToString();
                        dgvr.Cells["NeedWeight"].Value = row["GOODS_NUMBER"].ToString();
                        dgvr.Cells["price"].Value = row["MARKET_PRICE"].ToString();
                        dgvr.Cells["GOODS_ID"].Value = row["GOODS_ID"].ToString();
                        dgvr.Cells["Need_Amount"].Value = CConvert.ToString(CConvert.ToDecimal(row["GOODS_NUMBER"].ToString()) * CConvert.ToDecimal(row["MARKET_PRICE"].ToString())); ;
                        dgvr.Cells["Actual_wegiht"].Value = "0";
                        dgvr.Cells["Actual_Amount"].Value = "0";
                    }
                    txtTotal.Text = GetTotal().ToString("0.00");
                    txtNeedTotal.Text = GetNeedTotal().ToString("0.00");
                    txtChAAmonut.Text = (CConvert.ToDecimal(txtTotal.Text) - CConvert.ToDecimal(txtNeedTotal.Text)).ToString("0.00");
                }
            }

        }

        public string getAreaName(string code)
        {
            string name = "";
            if (code != null)
            {
                DataRow[] row = border.GetAreaInfo().Tables[0].Select("REGION_ID=" + code);
                if (row != null)
                {
                    foreach (DataRow drow in row)
                    {
                        name = drow["REGION_NAME"].ToString();
                    }
                }
            }
            return name;
        }

        public decimal GetTotal() //获得这张订单的实际总金额
        {
            decimal total = 0;
            for (int i = 0; i < dgvData.Rows.Count; i++)
            {
                total += CConvert.ToDecimal(dgvData.Rows[i].Cells["Actual_Amount"].Value);
            }
            return total;
        }


        public decimal GetNeedTotal() //获得这张订单的需求总金额
        {
            decimal total = 0;
            for (int i = 0; i < dgvData.Rows.Count; i++)
            {
                total += CConvert.ToDecimal(dgvData.Rows[i].Cells["Need_Amount"].Value);
            }
            return total;
        }

        private void txtProductCode_KeyDown(object sender, KeyEventArgs e)
        {
            string productSn;//商品编号
            decimal weight = 0;//商品实际重量

            if (e.KeyCode == Keys.Enter)
            {
                //if (txtProductCode.Text.Length != 13)
                //{
                //    MessageBox.Show("此商品编码有误！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return;
                //}
                try
                {
                    productSn = txtProductCode.Text.ToString().Substring(1, 6);
                    weight = CConvert.ToDecimal(txtProductCode.Text.ToString().Substring(7)) / 1000;
                }
                catch
                {
                    MessageBox.Show("订单不存在", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                int a = 0;//用来判定商品是否在这个订单中
                for (int i = 0; i < dgvData.Rows.Count; i++)
                {
                    if (productSn == dgvData.Rows[i].Cells["product_code"].Value.ToString())
                    {
                        if ((CConvert.ToDecimal(dgvData.Rows[i].Cells["NeedWeight"].Value) - weight) < CConvert.ToDecimal(0.5) && (CConvert.ToDecimal(dgvData.Rows[i].Cells["NeedWeight"].Value) - weight) > CConvert.ToDecimal(-0.5))
                        {
                            a++;
                            dgvData.Rows[i].Cells["Actual_wegiht"].Value = weight;
                            dgvData.Rows[i].DefaultCellStyle.BackColor = COLOR_DIFF_ROW;
                            dgvData.Rows[i].Cells["Actual_Amount"].Value = CConvert.ToDecimal(dgvData.Rows[i].Cells["Actual_wegiht"].Value) * CConvert.ToDecimal(dgvData.Rows[i].Cells["price"].Value);
                        }
                        else
                        {
                            MessageBox.Show("此商品实际重量已超需求重量太多，请重新拣货", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }
                if (a == 0)
                {
                    MessageBox.Show("此商品不在这个订单的需求中，请重新拣货", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

            }
            txtTotal.Text = GetTotal().ToString("0.00");
            txtChAAmonut.Text = (CConvert.ToDecimal(txtTotal.Text) - CConvert.ToDecimal(txtNeedTotal.Text)).ToString("0.00");
        }

        private void dgvData_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.Row.Index >= 0)
            {
                DataGridViewRow row = dgvData.Rows[e.Row.Index];
                if (dgvData.Rows.Count > 0)
                {
                    row.Selected = false;
                }
            }
        }

        private void btnOut_Click(object sender, EventArgs e)
        {

            string message = "";
            foreach (DataGridViewRow rows in dgvData.Rows)
            {
                if (rows.Cells["Actual_wegiht"].Value.ToString() == "0")
                {
                    message += "商品" + rows.Cells["product_name"].Value + "实际重量不能为0 \r\n";
                }
            }
            if (message.Length > 0)
            {
                MessageBox.Show(message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            BaseOrderInfoTable orderInfoTable = new BaseOrderInfoTable();
            orderInfoTable.ORDER_SN = order_sn;
            orderInfoTable.ORDER_TYPE = CConvert.ToInt32(order_type);
            orderInfoTable.SHIPPING_STATUS = CConstant.ShIPPING_TWO;
            orderInfoTable.COMMUNITY_CODE = CConvert.ToInt32(border.GetMaxQuCode(txtCountry.Text));
            orderInfoTable.ACTUAL_GOODS_AMOUNT = CConvert.ToDecimal(txtTotal.Text);

            BaseOrderInfoTable orderTab = border.GetOrderSnModel(CConvert.ToDecimal(order_sn), CConvert.ToInt32(order_type));
            if (orderTab == null) 
            {
                MessageBox.Show("订单不存在！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            BaseSendOrderTable sendOrderTable = new BaseSendOrderTable();
            sendOrderTable.ORDER_ID = CConvert.ToDecimal(orderTab.ORDER_ID);
            sendOrderTable.ORDER_SN = order_sn;
            sendOrderTable.SEND_STATUS = 0;
            sendOrderTable.ACTUAL_GOODS_AMOUNT = CConvert.ToDecimal(txtTotal.Text);
            sendOrderTable.CREATE_DATE_TIME = CConvert.ToDateTime(DateTime.Now.ToString());
            sendOrderTable.GOODS_AMOUNT = CConvert.ToDecimal(txtNeedTotal.Text);
            sendOrderTable.COMMUNITY_CODE = orderInfoTable.COMMUNITY_CODE;

            BaseSendOrderInfoTable sendOrderInfoTable = null;
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                sendOrderInfoTable = new BaseSendOrderInfoTable();
                sendOrderInfoTable.REC_ID = CConvert.ToInt32(row.Cells["No"].Value.ToString());
                sendOrderInfoTable.ORDER_ID = CConvert.ToDecimal(orderTab.ORDER_ID);
                sendOrderInfoTable.GOODS_ID = CConvert.ToInt32(row.Cells["GOODS_ID"].Value.ToString());
                sendOrderInfoTable.GOODS_PRICE = CConvert.ToDecimal(row.Cells["price"].Value.ToString());
                sendOrderInfoTable.GOODS_SN = row.Cells["product_code"].Value.ToString();
                sendOrderInfoTable.ACTUAL_AMOUNT = CConvert.ToDecimal(row.Cells["Actual_Amount"].Value);
                sendOrderInfoTable.ACTUAL_NUMBER = CConvert.ToDecimal(row.Cells["Actual_wegiht"].Value);
                sendOrderTable.ITEMS.Add(sendOrderInfoTable);
            }
            try
            {

                if (border.LibraryDeter(orderInfoTable, sendOrderTable) > 0)
                {
                    MessageBox.Show("出库成功！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnClear_Click(sender, e);
                }
            }
            catch { }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSlipNumber.Enabled = true;
            txtSlipNumber.Text = "";
            txtCustomercode.Text = "";
            txtCustomerName.Text = "";
            txtSlipNumberType.Text = "";
            txtShipp_status.Text = "";
            txtpayType.Text = "";
            txtCountry.Text = "";
            txtProvince.Text = "";
            txtCity.Text = "";
            txtdistrict.Text = "";
            txtAdress.Text = "";
            txtPhone.Text = "";
            txtTel.Text = "";
            txtEndTime.Text = "";
            txtDemo.Text = "";
            txtInvType.Text = "";
            txtInvInfo.Text = "";
            txtInvHead.Text = "";
            txtTotal.Text = "";
            txtNeedTotal.Text = "";
            txtProductCode.Text = "";
            dgvData.Rows.Clear();
        }
    }
}
