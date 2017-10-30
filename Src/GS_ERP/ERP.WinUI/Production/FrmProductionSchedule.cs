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
using CZZD.ERP.WinUI.Properties;

namespace CZZD.ERP.WinUI
{
    public partial class FrmProductionSchedule : FrmBase
    {
        public FrmProductionSchedule()
        {
            InitializeComponent();
        }
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        private DataTable _currentDt = new DataTable();
        private string _currentConduction = "";
        BProductionSchedule bProductionSchedule = new BProductionSchedule();
        BOrderHeader bOrderheader = new BOrderHeader();
        BCustomer bCustomer = new BCustomer();
        BSlipType bSlipType = new BSlipType();
        private bool isSearch = false;

        private void FrmProductionSchedule_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Tag = CTag;
            this.dgvData.AutoGenerateColumns = false;
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            PageSize = 15;
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvData.CurrentRow;
            string slipNumber = CConvert.ToString(row.Cells["SLIP_NUMBER"].Value);
            //string orderSlipNumber = CConvert.ToString(row.Cells["ORDER_SLIP_NUMBER"].Value);  
            FrmBase frm = new FrmProductionScheduleDetails(slipNumber);
               
            frm.ShowDialog(this);
            frm.Dispose();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _currentConduction = GetConduction();
            int currentPage = 1;
            int recordCount = bProductionSchedule.GetRecordCount(_currentConduction);
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
            DataSet ds = bProductionSchedule.GetList(_currentConduction, "", (currentPage - 1) * PageSize + 1, currentPage * PageSize);
            _currentDt = ds.Tables[0];
            //reSetCurrentDt();
            this.dgvData.DataSource = _currentDt;

            foreach (DataGridViewRow dr in dgvData.Rows)
            {
                //String ActualEndTime = bProductionSchedule.GetMaxActualEndTime("SLIP_NUMBER=" + "'" + dr.Cells["SLIP_NUMBER"].Value.ToString() + "'");
                if (dr.Cells["PSPP_ACTUAL_END_TIME"].Value.ToString() == "")
                {
                    if (Convert.ToDateTime(DateTime.Now.ToString()) <= Convert.ToDateTime(dr.Cells["PLAN_END_DATE"].Value.ToString()))
                    {
                        dr.Cells["PRODUCTION_STATUS"].Value = "未延期";
                    }
                    else
                    {
                        dr.Cells["PRODUCTION_STATUS"].Value = "延期";
                    }
                }
                else
                {
                    if (Convert.ToDateTime(dr.Cells["PSPP_ACTUAL_END_TIME"].Value.ToString()) <= Convert.ToDateTime(dr.Cells["PLAN_END_DATE"].Value.ToString()))
                    {
                        dr.Cells["PRODUCTION_STATUS"].Value = "未延期";
                    }
                    else
                    {
                        dr.Cells["PRODUCTION_STATUS"].Value = "延期";
                    }
                }

            }
        }

        /// <summary>
        /// 当前页码发生变化时的操作
        /// </summary>

        private void pgControl_PageChanged(object sender, EventArgs e, int currentPage)
        {
            BindData(currentPage);
        }
        /// <summary>
        /// 当前数据集的重新整理
        /// </summary>
        private void reSetCurrentDt()
        {
            for (int i = 0; i < _currentDt.Rows.Count; i++)
            {
                #region 是否生成销售订单

                #endregion
            }

            for (int i = _currentDt.Rows.Count; i < PageSize; i++)
            {
                _currentDt.Rows.Add(_currentDt.NewRow());
            }
        }

        private string GetConduction()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" STATUS_FLAG <> {0}", CConstant.DELETE);
            if (!string.IsNullOrEmpty(txtOrderSlipNumber.Text.Trim()))
            {
                sb.AppendFormat(" AND ORDER_SLIP_NUNBER like '{0}'", txtOrderSlipNumber.Text.Trim());
            }

            if (this.txtSlipDate.Checked)
            {
                sb.AppendFormat(" AND SLIP_DATE >= '{0}'", txtSlipDate.Value.ToString("yyyy-MM-dd"));
            }

            if (this.txtSlipDateTo.Checked)
            {
                sb.AppendFormat(" AND SLIP_DATE < '{0}'", txtSlipDateTo.Value.AddDays(1).ToString("yyyy-MM-dd"));
            }

            if (!string.IsNullOrEmpty(txtSlipType.Text.Trim()))
            {
                sb.AppendFormat(" AND SLIP_TYPE_CODE = '{0}'", txtSlipType.Text.Trim());
            }
            if (!string.IsNullOrEmpty(txtSlipNumber.Text.Trim()))
            {
                sb.AppendFormat(" AND SLIP_NUMBER = '{0}'", txtSlipNumber.Text.Trim());
            }
            if (!string.IsNullOrEmpty(txtCustmerCode.Text.Trim()))
            {
                sb.AppendFormat(" AND CUSTOMER_CODE = '{0}'", txtCustmerCode.Text.Trim());
            }

            if (radioButton2.Checked)
            {
                sb.AppendFormat(" AND ISNUll(PSPP_ACTUAL_END_TIME,GETDATE()) <= PLAN_END_DATE ");
            }
            if (radioButton1.Checked)
            {
                sb.AppendFormat(" AND ISNUll(PSPP_ACTUAL_END_TIME,GETDATE()) > PLAN_END_DATE ");
            }

            return sb.ToString();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void btnSlipNumber_Click(object sender, EventArgs e)
        {
            FrmProductionPlanSearch frm = new FrmProductionPlanSearch();
            // frm.CTag = CConstant.ORDER_MASTER_SEARCH;
            if (frm.ShowDialog(this) == DialogResult.OK)
            {

            }
            txtSlipNumber.Text = frm.SLIPNUMBER.ToString();
            frm.Dispose();
        }

        private void btnCustmer_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("CUSTOMER", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtCustmerCode.Text = frm.BaseMasterTable.Code;
                    txtCustmerName.Text = frm.BaseMasterTable.Name;
                }
            }

            frm.Dispose();
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

        private void btnCustmer_MouseEnter(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.find_over);
        }

        private void btnCustmer_MouseLeave(object sender, EventArgs e)
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

        private void btnSlipNumber_MouseEnter(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.find_over);
        }

        private void btnSlipNumber_MouseLeave(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.find);
        }


    }
}
