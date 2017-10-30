using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Main;
using CZZD.ERP.Bll;
using CZZD.ERP.Model;
using System.IO;
using CZZD.ERP.WinUI.Properties;
using CZZD.ERP.Common;
using CZZD.ERP.CacheData;
using System.Xml;

namespace CZZD.ERP.WinUI
{
    public partial class OrderPrintSetting : FrmBase
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        private string _slipNumber = "";
        BCompany bCompany = new BCompany();
        BCustomer bCustomer = new BCustomer();
       // BOrderHeader bOrderH = new BOrderHeader();
       // BBank bBank = new BBank();
        FastReport.Report report = new FastReport.Report();
        FastReport.Preview.PreviewControl previewControl1 = new FastReport.Preview.PreviewControl();


        public OrderPrintSetting()
        {
            InitializeComponent();
        }
        XmlDocument doc = new XmlDocument();

        public OrderPrintSetting(string slipNumber)
        {
            InitializeComponent();
            _slipNumber = slipNumber;
        }

        /// <summary>
        /// OrderPrintSetting_Load
        /// </summary>
        private void OrderPrintSetting_Load(object sender, EventArgs e)
        {
            cboLanguage.DataSource = CCacheData.Order;
            cboLanguage.ValueMember = "CODE";
            cboLanguage.DisplayMember = "NAME";
        }

        /// <summary>
        ///  公司选择按钮事件
        /// </summary>
        private void btnCompany_Click(object sender, EventArgs e)
        {
            //FrmMasterSearch frm = new FrmMasterSearch("COMPANY", "");
            //if (frm.ShowDialog(this) == DialogResult.OK)
            //{
            //    if (frm.BaseMasterTable != null)
            //    {
            //        txtCompanyName.Text = frm.BaseMasterTable.Name;
            //        txtCompanyCode.Text = frm.BaseMasterTable.Code;
            //    }
            //}
            //frm.Dispose();
            //DataSet ds = bBank.GetBank(" COMPANY_CODE = '" + txtCompanyCode.Text + "'");
            //DataTable dt = new DataTable();
            //dt.Columns.Add("NAME", Type.GetType("System.String"));
            //foreach (DataRow dr in ds.Tables[0].Rows)
            //{
            //    dt.Rows.Add(dr["BANK_NAME"].ToString());
            //}
            //cobBank.DataSource = dt;
            //cobBank.DisplayMember = "NAME";

            //txtBankEn.Text = ds.Tables[0].Rows[0]["FULL_NAME_EN"].ToString();
            //rtxtDetail.Text = ds.Tables[0].Rows[0]["DETAIL_EN"].ToString();

        }

        /// <summary>
        /// 文件路径选择
        /// </summary>
        private void btnFileName_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            if (folder.ShowDialog() == DialogResult.OK)
            {
                this.txtFilePath.Text = folder.SelectedPath.ToString();
            }
        }

        /// <summary>
        /// 导出
        /// </summary>
        private void btnExport_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(txtCompanyCode.Text))
            //{
            //    MessageBox.Show("请选择公司。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //if (string.IsNullOrEmpty(txtFilePath.Text))
            //{
            //    MessageBox.Show("请选择保存路径。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //BaseCompanyTable companyTable = bCompany.GetModel(txtCompanyCode.Text.Trim());
            //BllOrderHeaderTable orderTable = bOrderH.GetModel(_slipNumber);
            //BaseCustomerTable customerTable = bCustomer.GetModel(orderTable.ENDER_CUSTOMER_CODE);
            //report.Preview = previewControl1;
            //DataTable dt = new DataTable();
            //dt.TableName = "ds";
            //dt.Columns.Add("i", System.Type.GetType("System.Decimal"));
            //dt.Columns.Add("SPEC", System.Type.GetType("System.String"));
            //dt.Columns.Add("QUANTITY", System.Type.GetType("System.Decimal"));
            //dt.Columns.Add("PRICE", System.Type.GetType("System.Decimal"));
            //dt.Columns.Add("DISCOUNT", System.Type.GetType("System.Decimal"));
            //dt.Columns.Add("AMOUNT", System.Type.GetType("System.Decimal"));
            //dt.Columns.Add("MATERIAL", System.Type.GetType("System.String"));
            //dt.Columns.Add("MEMO", System.Type.GetType("System.String"));
            //dt.Columns.Add("DESCRIPTION", System.Type.GetType("System.String"));
            //int j = 1;
            //foreach (BllOrderLineTable lineModel in orderTable.Items)
            //{
            //    object[] rows = { j++, lineModel.SPEC, lineModel.QUANTITY, lineModel.PRICE, 0 - lineModel.PRICE_DISCOUNT, lineModel.AMOUNT, lineModel.METERIAL, lineModel.MEMO, lineModel.DESCRIPTION };
            //    dt.Rows.Add(rows);
            //}

            //DataSet ds = new DataSet();
            //ds.Tables.Add(dt);

            //string fileName = "";
            //string amountName = "";
            //if (CConstant.LANGUAGE_CN.Equals(cboLanguage.SelectedValue))
            //{
            //    fileName = @"Reports\Proforma_Invoice.frx";
            //    amountName = NumberConvert.NumberToEnglish(CConvert.ToString(orderTable.AMOUNT_INCLUDED_TAX), false);
            //}
            //else if (CConstant.LANGUAGE_EN.Equals(cboLanguage.SelectedValue))
            //{
            //    fileName = @"Reports\Order_EN.frx";
            //    amountName = NumberConvert.NumberToEnglish(CConvert.ToString(orderTable.AMOUNT_INCLUDED_TAX), false);
            //}

            //try
            //{
            //    if (File.Exists(fileName))
            //    {
            //        report.Load(fileName);
            //        report.SetParameterValue("CompanyName", companyTable.NAME);
            //        report.SetParameterValue("EnglishCompanyName", companyTable.NAME_ENGLISH);
            //        report.SetParameterValue("CompanyTel", companyTable.PHONE_NUMBER);
            //        report.SetParameterValue("CompanyFax", companyTable.FAX_NUMBER);
            //        report.SetParameterValue("CompanyAddress", companyTable.ADDRESS_FIRST);
            //        report.SetParameterValue("CompanyUrl", companyTable.URL);
            //        report.SetParameterValue("CompanyEmail", companyTable.EMAIL);
            //        report.SetParameterValue("SlipNumber", _slipNumber);
            //        report.SetParameterValue("SlipDate", CConvert.ToDateTime(orderTable.SLIP_DATE).ToString("yyyy/MM/dd"));
            //        report.SetParameterValue("Currency", orderTable.CURRENCY_NAME);
            //        report.SetParameterValue("CustomerName", customerTable.NAME);
            //        report.SetParameterValue("CustomerTel", customerTable.PHONE_NUMBER);
            //        report.SetParameterValue("CustomerFax", customerTable.FAX_NUMBER);
            //        report.SetParameterValue("CustomerAddress", customerTable.ADDRESS_FIRST);
            //        report.SetParameterValue("CustomerMessage", txtMessage.Text);
            //        report.SetParameterValue("DeliveryTerms", orderTable.DELIVERY_TERMS);
            //        report.SetParameterValue("PaymentTerms", orderTable.PAYMENT_TERMS);
            //        report.SetParameterValue("DiscountRate", orderTable.DISCOUNT_RATE);
            //        report.SetParameterValue("AmountName", amountName);
            //        report.SetParameterValue("DiscountAmount", orderTable.AMOUNT_INCLUDED_TAX);
            //        report.SetParameterValue("FullNameEn", txtBankEn.Text);
            //        report.SetParameterValue("DetailEn", rtxtDetail.Text);
            //        report.RegisterData(ds);
            //        report.Prepare();
            //        if (fileName.Equals(@"Reports\Proforma_Invoice.frx"))
            //        {
            //            report.Export(new FastReport.Export.Pdf.PDFExport(), this.txtFilePath.Text + "\\Proforma_Invoice" + _slipNumber + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf");
            //        }
            //        else
            //        {
            //            report.Export(new FastReport.Export.Pdf.PDFExport(), this.txtFilePath.Text + "\\Order_" + _slipNumber + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf");
            //        }
            //        MessageBox.Show("导出成功。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}

            //catch (Exception ex)
            //{
            //    Logger.Error("", ex);
            //}
        }

        /// <summary>
        /// 取消
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region  按钮图片变化
        /// <summary>
        /// 
        /// </summary>
        private void btn_MouseEnter(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.find_over);
        }

        /// <summary>
        /// 
        /// </summary>
        private void btn_MouseLeave(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.find);
        }
        #endregion

        private void cobBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txtBankEn.Text = "";
            //rtxtDetail.Text = "";
            //DataSet ds = bBank.GetBank(" BANK_NAME = '" + cobBank.Text + "'");
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    txtBankEn.Text = ds.Tables[0].Rows[0]["FULL_NAME_EN"].ToString();
            //    rtxtDetail.Text = ds.Tables[0].Rows[0]["DETAIL_EN"].ToString();
            //}
        }

        private void cobBank_SelectedValueChanged(object sender, EventArgs e)
        {

        }

    }//end class
}
