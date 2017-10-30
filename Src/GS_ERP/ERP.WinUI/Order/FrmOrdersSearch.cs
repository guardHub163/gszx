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
    public partial class FrmOrdersSearch : FrmBase
    {
        private DataTable _currentDt = new DataTable();
        public BOrderInfo orderTable = new BOrderInfo();
        BOrderGoods orderGoods = new BOrderGoods();
        private bool isSearch = false;
        private string _currentConduction = "";
        FastReport.Report report = new FastReport.Report();
        FastReport.Preview.PreviewControl previewControl1 = new FastReport.Preview.PreviewControl();

        public FrmOrdersSearch()
        {
            InitializeComponent();
        }

        #region init
        private void FrmOrdersSearch_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Tag = CTag;

            init();
            PageSize = 12;
            dgvData.Rows.Add(PageSize);
            dgvData.Rows[0].Selected = true;
        }

        /// <summary>
        /// 页面初始化
        /// </summary>
        private void init()
        {
            #region dgvData
            this.dgvData.AutoGenerateColumns = false;
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            #endregion
        }
        #endregion

        #region 窗口关闭
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 查询分页
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>    
        private void btnSearch_Click(object sender, EventArgs e)
        {
            _currentConduction = GetConduction();
            int currentPage = 1;
            int recordCount = orderTable.GetRecordCount(_currentConduction);
            if (recordCount <= 0)
            {
                MessageBox.Show("查询的信息不存在!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            //分页标签初始化
            this.pgControl.init(GetTotalPage(recordCount), currentPage);

            //数据绑定
            BindData(currentPage);
            isSearch = true;


        }

        /// <summary>
        /// 数据查询,绑定
        /// </summary>
        private void BindData(int currentPage)
        {
            DataSet ds = orderTable.GetList(_currentConduction, "", (currentPage - 1) * PageSize + 1, currentPage * PageSize);
            _currentDt = ds.Tables[0];
            _currentDt.Columns.Add("S_TYPE", Type.GetType("System.String"));
            _currentDt.Columns.Add("No", Type.GetType("System.String"));
            for (int i = 0; i < _currentDt.Rows.Count; i++)
            {
                _currentDt.Rows[i]["No"] = (i + 1).ToString();
                if (CConvert.ToInt32(_currentDt.Rows[i]["ORDER_TYPE"]) == CConstant.SLIPNUMBER_LOCAL_TYPE)
                {
                    _currentDt.Rows[i]["S_TYPE"] = "本地";
                }
                else
                {
                    _currentDt.Rows[i]["S_TYPE"] = "网络";
                }

            }
            this.dgvData.DataSource = _currentDt;
        }

        /// <summary>
        /// 获得查询条件
        /// </summary>
        private string GetConduction()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" 1=1 ", CConstant.DELETE);
            //订单编号
            if (!string.IsNullOrEmpty(txtSlipNumber.Text.Trim()))
            {
                sb.AppendFormat(" AND ORDER_SN = '{0}'", txtSlipNumber.Text.Trim());
                //return sb.ToString();
            }

            //客户
            if (!string.IsNullOrEmpty(txtEndCustomerCode.Text.Trim()))
            {
                sb.AppendFormat(" AND USER_ID = '{0}'", txtEndCustomerCode.Text.Trim());
            }

            //配送日期From
            if (this.txtSlipDateFrom.Checked)
            {
                sb.AppendFormat(" AND SHIPPING_TIME >= '{0}'", txtSlipDateFrom.Value.ToString("yyyy-MM-dd"));
            }
            //订单日期To
            if (this.txtSlipDateTo.Checked)
            {
                sb.AppendFormat(" AND SHIPPING_TIME < '{0}'", txtSlipDateTo.Value.AddDays(1).ToString("yyyy-MM-dd"));
            }
            //订单状况

            if (rdoAllLibrary.Checked)
            {
                sb.AppendFormat(" AND SHIPPING_STATUS = {0}", CConstant.ShIPPING_ONE);
            }
            else if (rdoVerifyOk.Checked)
            {
                sb.AppendFormat(" AND SHIPPING_STATUS = {0}", CConstant.ShIPPING_TWO);
            }


            if (radioLocal.Checked)
            {
                sb.AppendFormat(" AND ORDER_TYPE = {0}", CConstant.SLIPNUMBER_LOCAL_TYPE);
            }
            else if (radioExplorer.Checked)
            {
                sb.AppendFormat(" AND ORDER_TYPE = {0} ", CConstant.SLIPNUMBER_LOCAL_TYPE);
            }

            return sb.ToString();
        }

        /// <summary>
        /// 当前页码发生变化时的操作
        /// </summary>
        private void pgControl_PageChanged(object sender, EventArgs e, int currentPage)
        {
            BindData(currentPage);
        }

        #endregion

        /// <summary>
        ///　控制空行不能被点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvData_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.Row.Index >= 0)
            {
                DataGridViewRow row = dgvData.Rows[e.Row.Index];
                //if ("".Equals(CConvert.ToString(row.Cells["SLIP_NUMBER"].Value)))
                //{
                //    row.Selected = false;
                //}
            }
        }

        #region datagridview 行点击事件
        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvData.Rows[e.RowIndex];

            }
        }
        #endregion

        #region 客户
        /// <summary>
        /// 客户选择按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEndCustomer_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("CUSTOMER", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtEndCustomerCode.Text = frm.BaseMasterTable.Code;
                    txtEndCustomerName.Text = frm.BaseMasterTable.Name;
                    //txtWarehouseCode.Focus();
                }
            }
            frm.Dispose();
        }

        /// <summary>
        /// 客户输入验证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtEndCustomerCode_Leave(object sender, EventArgs e)
        {
            string endCustomerCode = txtEndCustomerCode.Text.Trim();
            if (endCustomerCode != "")
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("CUSTOMER", endCustomerCode);
                if (baseMaster != null)
                {
                    txtEndCustomerCode.Text = baseMaster.Code;
                    txtEndCustomerName.Text = baseMaster.Name;
                    //txtWarehouseCode.Focus();
                }
                else
                {
                    MessageBox.Show("客户编号不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEndCustomerCode.Text = "";
                    txtEndCustomerName.Text = "";
                    txtEndCustomerCode.Focus();
                }
            }
            else
            {
                txtEndCustomerName.Text = "";
            }
        }
        #endregion

        private void btnOperate_Click(object sender, EventArgs e)
        {
            if (dgvData.Rows[0].Cells[0].Value != null)
            {
                int type = 0;
                string slipNumber = dgvData.Rows[dgvData.CurrentCell.RowIndex].Cells["ORDER_ID"].Value.ToString();
                string orderType = dgvData.Rows[dgvData.CurrentCell.RowIndex].Cells[5].Value.ToString();
                string order_status = dgvData.Rows[dgvData.CurrentCell.RowIndex].Cells["ORDER_STATUS"].Value.ToString();
                string shipping_Status = dgvData.Rows[dgvData.CurrentCell.RowIndex].Cells["SHIPPING_STATUS"].Value.ToString();
                if (orderType != "本地")
                {
                    MessageBox.Show("订单来源于网络无法修改", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                {
                    type = CConstant.SLIPNUMBER_LOCAL_TYPE;
                }
                if (order_status == CConstant.ORDER_STATUS_DELETE.ToString())
                {
                    MessageBox.Show("该订单已取消无法修改", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (shipping_Status != "0")
                {
                    MessageBox.Show("此订单货物已送出无法修改", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                FrmOrder frm = new FrmOrder(slipNumber, type);
                frm.ShowDialog();
            }
            else 
            {
                MessageBox.Show("没有商品！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            int type = 0;
            if (dgvData.Rows[0].Cells[0].Value == null)
            {
                MessageBox.Show("请选择订单。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string slipNumber = dgvData.Rows[dgvData.CurrentCell.RowIndex].Cells["ORDER_ID"].Value.ToString();
            string orderType = dgvData.Rows[dgvData.CurrentCell.RowIndex].Cells[5].Value.ToString();
            if (orderType != "本地")
            {
                type = CConstant.SLIPNUMBER_ONLINE_TYPE;
            }
            else
            {
                type = CConstant.SLIPNUMBER_LOCAL_TYPE;
            }
            FrmOrdersInfo frm = new FrmOrdersInfo(slipNumber, CConvert.ToString(type));
            frm.ShowDialog();
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            string fileName = "";
            fileName = @"Reports\print.frx";
            int type = 0;
            if (dgvData.Rows[0].Cells[0].Value == null)
            {
                MessageBox.Show("请选择订单。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string orderSn = dgvData.Rows[dgvData.CurrentCell.RowIndex].Cells["ORDER_SN"].Value.ToString();
            string orderId = dgvData.Rows[dgvData.CurrentCell.RowIndex].Cells["ORDER_ID"].Value.ToString();
            string orderType = dgvData.Rows[dgvData.CurrentCell.RowIndex].Cells[5].Value.ToString();
            if (orderType != "本地")
            {
                type = CConstant.SLIPNUMBER_ONLINE_TYPE;
            }
            else
            {
                type = CConstant.SLIPNUMBER_LOCAL_TYPE;
            }
            BaseOrderInfoTable infoTable = orderTable.GetModel(CConvert.ToDecimal(orderId), CConvert.ToInt32(type));
            DataTable orderDt = orderGoods.GetGoodsInfo(CConvert.ToInt32(type), CConvert.ToDecimal(orderId)).Tables[0];
            DataTable dt = orderDt.Copy();
            dt.TableName = "ds";
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            report.Preview = previewControl1;
            report.Load(fileName);
            report.SetParameterValue("slipNumber", orderSn);
            report.SetParameterValue("customerName", infoTable.CONSIGNEE.ToString());
            report.SetParameterValue("customerAdress", infoTable.ADDRESS);
            report.SetParameterValue("datatime", infoTable.BEST_TIME);
            string Tma = infoTable.ORDER_TYPE + orderSn.ToString();
            //((FastReport.PictureObject)report.FindObject("Barcode1")). = bmp1;
            report.SetParameterValue("barCode", Tma);
            report.RegisterData(ds);
            report.Prepare();
            report.ShowPrepared();
            report.Export(new FastReport.Export.Pdf.PDFExport(), @"d:\a.pdf");
            //int result = orderTable.UpdatePrintStatus(CConvert.ToInt32(slipNumber), CConvert.ToInt32(orderType));//修改打印状态
            //if (result > 0) 
            //{
            //    MessageBox.Show("打印成功", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //report.PrintSettings.ShowDialog = false;
            //report.Print();

        }

    }//end class
}
