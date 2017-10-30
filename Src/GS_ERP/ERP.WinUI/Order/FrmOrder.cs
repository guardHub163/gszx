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
    public partial class FrmOrder : FrmBase
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        BCommon bcom = new BCommon();
        BProduct bprodcut = new BProduct();
        BOrderInfo border = new BOrderInfo();
        BCustomer bcustomer = new BCustomer();
        BOrderGoods bordergoods = new BOrderGoods();
        DataTable AreaTables = null;
        public string slipNumber = "";
        public int order_type = 0;
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmOrder()
        {
            InitializeComponent();
        }

        public FrmOrder(string number, int type)
        {
            InitializeComponent();
            slipNumber = number;
            order_type = type;
        }

        #endregion

        private void FrmOrder_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Tag = CTag;

            if (G_Invoice.Checked)
            {
                txtInvoiceHead.Enabled = false;
                txtInvoiceInfo.Enabled = false;
            }
            else
            {
                txtInvoiceHead.Enabled = true;
                txtInvoiceInfo.Enabled = true;
            }

            AutoCompleteStringCollection strings = new AutoCompleteStringCollection();
            strings = new AutoCompleteStringCollection();
            strings.AddRange(CCacheData.GetBaseProductNamesData());
            txtProductName.AutoCompleteCustomSource = strings;
            txtProductName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtProductName.AutoCompleteMode = AutoCompleteMode.Suggest;

            if (CConstant.ORDER_NEW.Equals(CTag))
            {
                this.Text = "订单输入";
                AreaTables = border.GetAreaInfo().Tables[0];
                DataTable bregTable = AreatableInfo(AreaTables, 1);
                CmbSH.ValueMember = "ID";
                CmbSH.DisplayMember = "NAME";
                CmbSH.DataSource = bregTable;
                txtSlipNumber.Text = border.GetMaxCode();
                btnOrderDelete.Visible = false;
            }
            else
            {
                this.Text = "订单修正";
                BaseOrderInfoTable orderTable = border.GetModel(CConvert.ToInt32(slipNumber), order_type);
                txtSlipNumber.Text = orderTable.ORDER_ID.ToString();
                txtCustomerCode.Text = orderTable.USER_ID.ToString();
                txtCustomerName.Text = orderTable.CONSIGNEE.ToString();
                CmbSH.Text = orderTable.PROVINCE.ToString();
                CmbSI.Text = orderTable.CITY.ToString();
                CmbX.Text = orderTable.DISTRICT.ToString();
                txtCustomerAdress.Text = orderTable.ADDRESS.ToString();
                txtDatetime.Text = orderTable.SHIPPING_TIME.ToString();
                txtPhone.Text = orderTable.MOBILE;
                txtTel.Text = orderTable.TEL;
                if (orderTable.PAY_STATUS == 0)
                {
                    pay_status_1.Checked = true;
                }
                else if (orderTable.PAY_STATUS == 1)
                {
                    pay_status_2.Checked = true;
                }
                else if (orderTable.PAY_STATUS == 0)
                {
                    pay_status_3.Checked = true;
                }
                txtInvoiceInfo.Text = orderTable.INV_CONTENT;
                txtInvoiceHead.Text = orderTable.INV_PAYEE;
                if (orderTable.INV_TYPE.ToString() == CConstant.INV_G.ToString())
                {
                    G_Invoice.Checked = true;
                }
                else 
                {
                    Z_Invoice.Checked = true;
                }
                DataTable orderGoodsTable = bordergoods.GetGoodsInfo(order_type, CConvert.ToInt32(slipNumber)).Tables[0];
                foreach (DataRow row in orderGoodsTable.Rows)
                {
                    int numcode = dgvData.RowCount;
                    int currentRowID = dgvData.Rows.Add(1);
                    DataGridViewRow dgvr = dgvData.Rows[currentRowID];
                    dgvr.Cells["No"].Value = (numcode + 1).ToString();
                    dgvr.Cells["Product_code"].Value = row["GOODS_ID"].ToString();
                    dgvr.Cells["Product_name"].Value = row["GOODS_NAME"].ToString();
                    dgvr.Cells["Product_number"].Value = row["GOODS_NUMBER"].ToString();
                    dgvr.Cells["Product_price"].Value = row["MARKET_PRICE"].ToString();
                    dgvr.Cells["Product_money"].Value = CConvert.ToString(CConvert.ToDecimal(row["GOODS_NUMBER"].ToString()) * CConvert.ToDecimal(row["MARKET_PRICE"].ToString()));
                    dgvr.Cells["CaoZ"].Value = "删除";
                }
                txtTotal.Text = CConvert.ToString(GetTotal());
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtProductName.Text.Trim() == "")
            {
                MessageBox.Show("商品不能为空！");
                return;
            }
            if (txtNumber.Text.Trim() == "")
            {
                MessageBox.Show("数量不能为空！");
                return;
            }
            if (!PageValidate.IsNumber(txtNumber.Text))
            {
                MessageBox.Show("数量格式错误！");
                txtNumber.Text = "";
                return;
            }
            string code = "";
            string name = "";
            try
            {
                string[] CodeName = txtProductName.Text.Split('|');
                code = CodeName[0].ToString();
                name = CodeName[1].ToString();
            }
            catch
            {
                MessageBox.Show("商品不存在！");
                txtProductName.Text = "";
                return;
            }
            BaseProductTable ptable = bprodcut.GetModel(CConvert.ToInt32(code));
            if (ptable == null)
            {
                MessageBox.Show("商品不存在！");
                txtProductName.Text = "";
                return;
            }
            for (int i = 0; i < dgvData.Rows.Count; i++)
            {
                if (code == CConvert.ToString(dgvData.Rows[i].Cells["Product_code"].Value))
                {
                    MessageBox.Show("商品已存在，不能重复添加！如需请修改数量！");
                    txtProductName.Text = "";
                    txtNumber.Text = "";
                    return;
                }
            }

            int numcode = dgvData.RowCount;
            int currentRowID = dgvData.Rows.Add(1);
            DataGridViewRow dgvr = dgvData.Rows[currentRowID];
            dgvr.Cells["No"].Value = (numcode + 1).ToString();
            dgvr.Cells["Product_code"].Value = code;
            dgvr.Cells["Product_name"].Value = ptable.GOODS_NAME;
            dgvr.Cells["Product_number"].Value = txtNumber.Text;
            dgvr.Cells["Product_price"].Value = ptable.MARKET_PRICE;
            dgvr.Cells["Product_money"].Value = CConvert.ToString(CConvert.ToDecimal(txtNumber.Text) * CConvert.ToDecimal(ptable.MARKET_PRICE));
            dgvr.Cells["CaoZ"].Value = "删除";

            txtTotal.Text = CConvert.ToString(GetTotal());
            txtProductName.Text = "";

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

        #region DataGridView 行点击事件



        private void dgvData_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            dgvData.Rows[e.RowIndex].Cells["Product_money"].Value = CConvert.ToDecimal(dgvData.Rows[e.RowIndex].Cells["Product_number"].Value) * CConvert.ToDecimal(dgvData.Rows[e.RowIndex].Cells["Product_price"].Value);
            txtTotal.Text = CConvert.ToString(GetTotal());
        }



        #endregion

        public decimal GetTotal() //获得这张订单的总金额
        {
            decimal total = 0;
            for (int i = 0; i < dgvData.Rows.Count; i++)
            {
                total += CConvert.ToDecimal(dgvData.Rows[i].Cells["Product_money"].Value);
            }
            return total;
        }


        /// <summary>
        /// 客户选择按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCustomer_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("CUSTOMER", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtCustomerCode.Text = frm.BaseMasterTable.Code;
                    txtCustomerName.Text = frm.BaseMasterTable.Name;
                }
                string code = txtCustomerCode.Text.Trim();
                BaseCustomerTable dt = bcustomer.GetModel(CConvert.ToDecimal(code));
            }

            frm.Dispose();
        }

        private void G_Invoice_CheckedChanged(object sender, EventArgs e)
        {
            if (G_Invoice.Checked)
            {
                txtInvoiceHead.Enabled = false;
                txtInvoiceInfo.Enabled = false;
            }
            else
            {
                txtInvoiceHead.Enabled = true;
                txtInvoiceInfo.Enabled = true;
            }
        }

        private void CmbSH_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable bregTable = AreatableInfo(AreaTables, CConvert.ToInt32(CmbSH.SelectedValue));
            CmbSI.ValueMember = "ID";
            CmbSI.DisplayMember = "NAME";
            CmbSI.DataSource = bregTable;
        }

        private void CmbSI_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable bregTable = AreatableInfo(AreaTables, CConvert.ToInt32(CmbSI.SelectedValue));
            CmbX.ValueMember = "ID";
            CmbX.DisplayMember = "NAME";
            CmbX.DataSource = bregTable;
        }

        //订单取消
        private void btnOrderDelete_Click(object sender, EventArgs e)
        {
            int row = border.DeleteOrderInfo(CConvert.ToInt32(slipNumber), order_type);
            if (row > 0)
            {
                MessageBox.Show("订单取消成功！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要关闭吗？", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                this.Close();
            }
        }

        #region 数据保存前的验证
        /// <summary>
        /// 数据保存前主表数据验证
        /// </summary>
        private bool CheckHeaderInput()
        {
            string message = "";
            if (string.IsNullOrEmpty(this.txtCustomerCode.Text))
            {
                message += "客户编号不能为空。\r\n";
            }
            if (string.IsNullOrEmpty(this.txtCustomerAdress.Text))
            {
                message += "客户地址不能为空。\r\n";
            }
            if (string.IsNullOrEmpty(this.txtPhone.Text))
            {
                message += "联系不能为空。\r\n";
            }
            if (!PageValidate.IsToPhone(txtPhone.Text)) 
            {
                message += "电话号码格式有误。\r\n";
            }
            if (!PageValidate.IsTel(txtTel.Text)) 
            {
                message += "手机号码格式有误。\r\n";
            }
            if (message.Length > 0)
            {
                MessageBox.Show(message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        /// <summary>
        /// 数据保存前明细数据验证
        /// </summary>
        private bool CheckLineInput()
        {
            int count = dgvData.Rows.Count;
            int i = 1;
            if (dgvData.Rows.Count == 0)
            {
                MessageBox.Show("明细数不能为空。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (count > i)
                {
                    if (CConvert.ToString(row.Cells["Product_number"].Value) == "")
                    {
                        MessageBox.Show("销售数量不能为空。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    else if (CConvert.ToString(row.Cells["Product_price"].Value) == "")
                    {
                        MessageBox.Show("销售单价不能为空。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    else if (CConvert.ToDecimal(row.Cells["Product_number"].Value) == 0)
                    {
                        MessageBox.Show("销售数量不能为零。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    else if (CConvert.ToString(row.Cells["Product_price"].Value) == "")
                    {
                        MessageBox.Show("销售单价不能为空。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
                i++;

            }

            return true;
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!CheckHeaderInput())
            {
                return;
            }

            if (!CheckLineInput())
            {
                return;
            }
            BaseOrderInfoTable orderTable = new BaseOrderInfoTable();
            orderTable.ORDER_ID = CConvert.ToDecimal(txtSlipNumber.Text);
            orderTable.ORDER_SN = border.GetMaxOrderSn();
            orderTable.USER_ID = CConvert.ToInt32(txtCustomerCode.Text);
            orderTable.ORDER_STATUS = CConstant.ORDER_STATUS_ENDER;
            orderTable.SHIPPING_STATUS = CConvert.ToInt32(0);
            orderTable.PAY_STATUS = 0;
            orderTable.CONSIGNEE = txtCustomerName.Text;
            orderTable.COUNTRY = "中国";
            orderTable.PROVINCE = CmbSH.Text;
            orderTable.CITY = CmbSI.Text;
            orderTable.DISTRICT = CmbX.Text;
            orderTable.COMMUNITY = CmbQu.Text;
            orderTable.ADDRESS = txtCustomerAdress.Text;
            orderTable.TEL = txtTel.Text;
            orderTable.MOBILE = txtPhone.Text;
            orderTable.ORDER_TYPE = 0;
            orderTable.BEST_TIME = CConvert.ToDateTime(txtDatetime.Text);
            orderTable.ADD_TIME = CConvert.ToDateTime(DateTime.Now.ToString());
            orderTable.PRINT_STATUS = CConstant.PRINT_TYPE_ONE;
            if (Z_Invoice.Checked == true)
            {
                orderTable.INV_TYPE = CConstant.INV_Z.ToString();
            }
            else 
            {
                orderTable.INV_TYPE = CConstant.INV_G.ToString();
            }
            orderTable.INV_PAYEE = txtInvoiceHead.Text;
            orderTable.INV_CONTENT = txtInvoiceInfo.Text;

            BaseOrdersGoodsTable orderGoodtable = null;
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                orderGoodtable = new BaseOrdersGoodsTable();
                orderGoodtable.REC_ID = CConvert.ToInt32(row.Cells["No"].Value);
                orderGoodtable.ORDER_ID = CConvert.ToInt32(orderTable.ORDER_SN);
                orderGoodtable.GOODS_ID = CConvert.ToInt32(row.Cells["Product_code"].Value);
                orderGoodtable.GOODS_NAME = row.Cells["Product_name"].Value.ToString();
                orderGoodtable.GOODS_NUMBER = CConvert.ToInt32(row.Cells["Product_number"].Value);
                orderGoodtable.MARKET_PRICE = CConvert.ToDecimal(row.Cells["Product_price"].Value);
                orderGoodtable.SEND_NUMBER = 0;
                orderGoodtable.ORDER_TYPE = orderTable.ORDER_TYPE;

                orderTable.AddItem(orderGoodtable);
            }

            if (CConstant.ORDER_NEW.Equals(CTag) || CConstant.ORDER_COPY.Equals(CTag) || CConstant.ORDER_QOUTATION.Equals(CTag))　// 订单输入
            {
                if (CConvert.ToDecimal(txtTotal.Text) == 0)
                {
                    if (MessageBox.Show("【警告】含税金额为0；", "订单保存提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != DialogResult.OK)
                    {
                        return;
                    }
                }

                try
                {
                    string slipNumber = border.Add(orderTable);
                    if (slipNumber == null)
                    {
                        MessageBox.Show("订单保存失败,请重试或与管理员联系。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("订单保存成功。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MessageBox.Show("订单保存失败,请重试或与管理员联系。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Logger.Error("新建订单保存失败。", ex);
                }
            }
            else  //订单修正
            {
                try
                {
                    int result = border.Update(orderTable);
                    if (result == 0)
                    {
                        MessageBox.Show("订单保存失败,请重试或与管理员联系。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("订单保存成功。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                       // _dialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("订单保存失败,系统错误,请与管理员联系。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Logger.Error("订单修改保存失败。", ex);
                }
            }
        }

        private void CmbX_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable bregTable = AreatableInfo(AreaTables, CConvert.ToInt32(CmbX.SelectedValue));
            CmbQu.ValueMember = "ID";
            CmbQu.DisplayMember = "NAME";
            CmbQu.DataSource = bregTable;
        }





    }//end class
}
