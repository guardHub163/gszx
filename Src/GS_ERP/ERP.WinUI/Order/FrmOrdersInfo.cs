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
    public partial class FrmOrdersInfo : FrmBase
    {
        private DataTable _currentDt = new DataTable();
        public BOrderInfo orderTable = new BOrderInfo();
        BOrderInfo border = new BOrderInfo();
        BOrderGoods bordergoods = new BOrderGoods();
        public string slipNumber = "";
        public string order_type = "";

        public FrmOrdersInfo()
        {
            InitializeComponent();
        }

        public FrmOrdersInfo(string Number, string type)
        {
            InitializeComponent();
            slipNumber = Number;
            order_type = type;
        }

        private void FrmOrdersSearch_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Tag = CTag;
            BaseOrderInfoTable orderTable = border.GetModel(CConvert.ToDecimal(slipNumber), CConvert.ToInt32(order_type));
            if (orderTable != null)
            {
                txtSlipNumber.Text = orderTable.ORDER_SN;
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
                DataTable orderGoodsTable = bordergoods.GetGoodsInfo(CConvert.ToInt32(order_type), CConvert.ToDecimal(slipNumber)).Tables[0];
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
                }
                txtTotal.Text = CConvert.ToString(GetTotal());
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

        public decimal GetTotal() //获得这张订单的总金额
        {
            decimal total = 0;
            for (int i = 0; i < dgvData.Rows.Count; i++)
            {
                total += CConvert.ToDecimal(dgvData.Rows[i].Cells["Product_money"].Value);
            }
            return total;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }//end class
}
