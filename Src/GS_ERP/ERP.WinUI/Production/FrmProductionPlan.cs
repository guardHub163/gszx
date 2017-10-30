using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Main;
using CZZD.ERP.Common;
using CZZD.ERP.Bll;
using CZZD.ERP.WinUI.Properties;
using CZZD.ERP.Model;
using System.Collections;
using CZZD.ERP.Bll.Product;
using System.Text.RegularExpressions;

namespace CZZD.ERP.WinUI
{
    public partial class FrmProductionPlan : FrmBase
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        private BSlipTypeCompositionProducts bSlipTypeCompositionProducts = new BSlipTypeCompositionProducts();
        private BaseProductionPlanTable baseProductionplantable = new BaseProductionPlanTable();
        private BProductionProcess bProductionProcess = new BProductionProcess();
        private BCompositionProductsProductionProcess bCompositionProductsProductionProcess = new BCompositionProductsProductionProcess();
        private BProductionPlan bProductionPlan = new BProductionPlan();
        private BaseProductionScheduleProductionProcessTable BpsppTable = new BaseProductionScheduleProductionProcessTable();
        private BProductionPlanSearch bProductionPlanSearch = new BProductionPlanSearch();

        private string _oldSlipNumber = "";
        private DataTable dtinfo;

        public FrmProductionPlan()
        {
            InitializeComponent();
        }

        public FrmProductionPlan(string slipnumber)
        {
            InitializeComponent();
            _oldSlipNumber = slipnumber;
        }

        BaseProductionPlanTable planTable = new BaseProductionPlanTable();
        BllOrderHeaderTable bOrderHeadTable = new BllOrderHeaderTable();
        public DataTable DTINFO
        {
            get { return dtinfo; }
            set { dtinfo = value; }
        }

        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmProductionPlan_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Tag = CTag;

            if (string.IsNullOrEmpty(_oldSlipNumber))
            {
                initSlipNumber();

            }
            else if (CConstant.QUOTATION_OPERATE.Equals(CTag))
            {
                setStatus(false);
                this.btnCreatePlan.Visible = false;
                this.btnAddParts.Visible = false;
                this.btnAddDraw.Visible = false;
                this.btnSave.Visible = false;
                dgvData.Columns["PLAN_START_DATE"].ReadOnly = true;
                dgvData.Columns["PLAN_END_DATE"].ReadOnly = true;
                dgvData.Columns["PLAN_QUANTITY"].ReadOnly = true;
                dgvData.Columns["PROCESS_CHK"].ReadOnly = true;
                dgvData.Columns["BTN_DELETE"].ReadOnly = true;
                dgvDrawing.Columns["DRAWING_PLAN_END_DATE"].ReadOnly = true;
                initData();
            }

        }

        private void setStatus(bool flag)
        {
            this.txtSlipNumber.Enabled = flag;
            this.txtOrderSlipNumber.Enabled = flag;
            this.cboSlipType.Enabled = flag;
            this.txtSpec.Enabled = flag;
            this.txtOrderQuantity.Enabled = flag;
            this.txtQuantity.Enabled = flag;
            this.txtSlipDateFrom.Enabled = flag;
            this.txtDepartualDateFrom.Enabled = flag;
            this.txtProductionQuantity.Enabled = flag;
            this.dateTimePicker1.Enabled = flag;
            this.dateTimePicker2.Enabled = flag;
            this.txtMemo.Enabled = flag;
        }


        /// <summary>
        /// 生产计划数据初始化
        /// </summary>
        private void initData()
        {
            BaseProductionPlanTable BPPTable = bProductionPlan.GetModel(_oldSlipNumber);
            this.txtSlipNumber.Text = BPPTable.SLIP_NUMBER;
            txtOrderSlipNumber.Text = BPPTable.ORDER_SLIP_NUNBER;
            DataSet ds = bOrderHeader.GetModelInfo(BPPTable.ORDER_SLIP_NUNBER);
            cboSlipType.ValueMember = "PRODUCT_CODE";
            cboSlipType.DisplayMember = "SLIP_TYPE_NAME";
            cboSlipType.DataSource = ds.Tables[0].DefaultView.ToTable(true, "PRODUCT_CODE", "SLIP_TYPE_NAME");
            cboSlipType.SelectedValue = BPPTable.SLIP_TYPE_CODE;
            string productcode = cboSlipType.SelectedValue.ToString();
            DataSet ds1 = bOrderHeader.GetModelInfo(BPPTable.ORDER_SLIP_NUNBER, BPPTable.SLIP_TYPE_CODE);

            int PartCodeNullCount = 0;
            foreach (DataRow dr in ds1.Tables[0].Rows)
            {
                string partsCode = CConvert.ToString(dr["PARTS_CODE"]);
                if (partsCode == "")
                {
                    PartCodeNullCount++;
                    if (dr["ALLOATION_QUANTITY"].ToString().Trim() != "")
                    {
                        txtQuantity.Text = dr["ALLOATION_QUANTITY"].ToString();
                    }
                    else
                    {
                        txtQuantity.Text = "0";
                    }
                    txtOrderQuantity.Text = dr["QUANTITY"].ToString().Trim();
                }

                if (PartCodeNullCount == 0)
                {

                    if (dr["ALLOATION_QUANTITY"].ToString().Trim() != "" && dr["ALLOATION_QUANTITY"].ToString().Trim() != "0.00")
                    {
                        txtQuantity.Text = "1";
                    }
                    else
                    {
                        txtQuantity.Text = "0";
                    }
                    txtOrderQuantity.Text = "1";

                }
            }

            txtSpec.Text = BPPTable.SPEC;
            dateTimePicker1.Value = (DateTime)BPPTable.PLAN_START_DATE;
            dateTimePicker2.Value = (DateTime)BPPTable.PLAN_END_DATE;
            txtMemo.Text = BPPTable.MEMO;
            txtProductionQuantity.Text = BPPTable.PLAN_QUANTITY.ToString();
            foreach (BaseProductionPlanLineTable Modelline in BPPTable.Items)
            {
                int currentRowIndex = dgvData.Rows.Add(1);
                DataGridViewRow row = dgvData.Rows[currentRowIndex];
                row.Cells["TYPE_NAME"].Value = BPPTable.SLIP_TYPE_NAME;
                row.Cells["PARTS_NAME"].Value = Modelline.PARTS_NAME;
                row.Cells["PLAN_START_DATE"].Value = Modelline.PLAN_START_DATE;
                row.Cells["PLAN_END_DATE"].Value = Modelline.PLAN_END_DATE;
                row.Cells["PLAN_QUANTITY"].Value = Modelline.PLAN_NUMBER;
                row.Cells["PARTS_CODE"].Value = Modelline.PARTS_CODE;
            }
            planTable = new BaseProductionPlanTable();
            planTable.SLIP_TYPE_CODE = cboSlipType.SelectedValue.ToString();
            planTable.SLIP_TYPE_NAME = cboSlipType.Text.ToString();
            planTable.SPEC = txtSpec.Text;
            planTable.PLAN_QUANTITY = CConvert.ToDecimal(txtProductionQuantity.Text.Trim());
            planTable.SLIP_NUMBER = txtSlipNumber.Text.Trim();
            planTable.ORDER_SLIP_NUNBER = txtOrderSlipNumber.Text.Trim();
            planTable.PLAN_START_DATE = dateTimePicker1.Value;
            planTable.PLAN_END_DATE = dateTimePicker2.Value;
            planTable.MEMO = txtMemo.Text.Trim();
            planTable.CREATE_USER = UserTable.CODE;
            planTable.LAST_UPDATE_USER = UserTable.CODE;
            //bOrderHeadTable = new BllOrderHeaderTable();      
        }

        public void initSlipNumber()
        {
            //订单编号的初始化          
            string maxSlipNumber = bProductionPlan.GetMaxSlipNumber();
            int number = CConvert.ToInt32(maxSlipNumber) + 1;
            string slipNumber = DateTime.Now.ToString("yyyyMMdd") + number.ToString().PadLeft(4, '0');
            txtSlipNumber.Text = slipNumber;
        }

        /// <summary>
        /// 订单检索
        /// </summary>
        private void btnOrderSlipNumber_Click(object sender, EventArgs e)
        {
            FrmOrdersSearch frm = new FrmOrdersSearch();
            frm.CTag = CConstant.ORDER_MASTER_SEARCH;

            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.orderTable != null)
                {
                    string slipNumber = frm.orderTable.SLIP_NUMBER;
                    txtOrderSlipNumber.Text = slipNumber;
                    DataSet ds = bOrderHeader.GetModelInfo(slipNumber);
                    cboSlipType.ValueMember = "PRODUCT_CODE";
                    cboSlipType.DisplayMember = "SLIP_TYPE_NAME";
                    cboSlipType.DataSource = ds.Tables[0].DefaultView.ToTable(true, "PRODUCT_CODE", "SLIP_TYPE_NAME");
                    txtSlipDateFrom.Value = DateTime.Parse(ds.Tables[0].Rows[0]["SLIP_DATE"].ToString().Trim());
                    txtDepartualDateFrom.Value = DateTime.Parse(ds.Tables[0].Rows[0]["DEPARTUAL_DATE"].ToString().Trim());
                }
            }
            frm.Dispose();
        }

        private void txtOrderSlipNumber_Leave(object sender, EventArgs e)
        {
            string orderSlipNumber = txtOrderSlipNumber.Text.Trim();
            if (!string.IsNullOrEmpty(orderSlipNumber))
            {
                if (!bOrderHeader.Exists(orderSlipNumber))
                {
                    MessageBox.Show("订单编号不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtOrderSlipNumber.Text = "";
                    txtOrderSlipNumber.Focus();
                }
            }
        }

        #region 生成生产计划
        /// <summary>
        ///  生成生产计划
        /// </summary>
        private void btnCreatePlan_Click(object sender, EventArgs e)
        {
            if (txtProductionQuantity.Text.Trim() == "")
            {
                MessageBox.Show("计划数量不能为空。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtProductionQuantity.Text.Trim() == "0")
            {
                MessageBox.Show("计划数量不能0。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(txtOrderSlipNumber.Text.Trim()))
            {
                MessageBox.Show("订单编号不能为空。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (CConvert.ToDecimal(txtProductionQuantity.Text) > CConvert.ToDecimal(txtOrderQuantity.Text) - CConvert.ToDecimal(txtQuantity.Text))
            {
                MessageBox.Show("计划数量超出订单数量。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            planTable = new BaseProductionPlanTable();
            planTable.SLIP_TYPE_CODE = cboSlipType.SelectedValue.ToString();
            planTable.SLIP_TYPE_NAME = cboSlipType.Text.ToString();
            planTable.SPEC = txtSpec.Text;
            planTable.PLAN_QUANTITY = int.Parse(txtProductionQuantity.Text.Trim());
            planTable.SLIP_NUMBER = txtSlipNumber.Text.Trim();
            planTable.ORDER_SLIP_NUNBER = txtOrderSlipNumber.Text.Trim();
            planTable.PLAN_START_DATE = dateTimePicker1.Value;
            planTable.PLAN_END_DATE = dateTimePicker2.Value;
            planTable.MEMO = txtMemo.Text.Trim();
            planTable.CREATE_USER = UserTable.CODE;
            planTable.LAST_UPDATE_USER = UserTable.CODE;
            bOrderHeadTable = new BllOrderHeaderTable();
            try
            {
                #region 部件的整理
                string slipNumber = txtOrderSlipNumber.Text;
                string productcode = cboSlipType.SelectedValue.ToString();
                DataTable orderDt = bOrderHeader.GetModelInfo(slipNumber, productcode).Tables[0];
                int ProductionScheduleLine = 1;
                foreach (DataRow dr in orderDt.Rows)
                {
                    string partsCode = CConvert.ToString(dr["PARTS_CODE"]);
                    if (partsCode == "")
                    {
                        DataTable partsDt = bSlipTypeCompositionProducts.GetList(GetConduction()).Tables[0];

                        foreach (DataRow partsDr in partsDt.Rows)
                        {
                            decimal quantity = CConvert.ToDecimal(txtProductionQuantity.Text) * CConvert.ToDecimal(partsDr["QUANTITY"]);

                            bool isExist = false;
                            foreach (BaseProductionPlanLineTable lineTable in planTable.Items)
                            {
                                if (lineTable.PARTS_CODE.Equals(partsDr["COMPOSITION_PRODUCTS_CODE"]))
                                {
                                    lineTable.PLAN_NUMBER = CConvert.ToDecimal(lineTable.PLAN_NUMBER) + quantity;
                                    isExist = true;
                                    break;
                                }
                            }
                            if (!isExist)
                            {
                                BaseProductionPlanLineTable lineTable = new BaseProductionPlanLineTable();
                                lineTable.TYPE_CODE = CConvert.ToString(dr["PRODUCT_CODE"]);
                                lineTable.TYPE_NAME = CConvert.ToString(dr["SLIP_TYPE_NAME"]);
                                lineTable.PARTS_CODE = CConvert.ToString(partsDr["COMPOSITION_PRODUCTS_CODE"]);
                                lineTable.PARTS_NAME = CConvert.ToString(partsDr["COMPOSITION_PRODUCTS_NAME"]);
                                lineTable.PLAN_NUMBER = quantity;
                                lineTable.LINE_NUMBER = ProductionScheduleLine++;
                                planTable.AddItem(lineTable);
                            }


                        }
                        BllOrderLineTable orderLine = new BllOrderLineTable();
                        if (dr["ALLOATION_QUANTITY"].ToString().Trim() != "")
                        {
                            orderLine.ALLOATION_QUANTITY = CConvert.ToDecimal(txtProductionQuantity.Text) + CConvert.ToDecimal(dr["ALLOATION_QUANTITY"].ToString().Trim());
                        }
                        orderLine.SLIP_NUMBER = CConvert.ToString(dr["SLIP_NUMBER"]);
                        orderLine.LINE_NUMBER = CConvert.ToInt32(dr["LINE_NUMBER"]);
                        bOrderHeadTable.AddItem(orderLine);

                    }
                    else
                    {
                        if (dr["ALLOATION_QUANTITY"].ToString() != dr["QUANTITY"].ToString())
                        {
                            bool isExist = false;

                            foreach (BaseProductionPlanLineTable lineTable in planTable.Items)
                            {
                                if (lineTable.PARTS_CODE.Equals(partsCode))
                                {
                                    lineTable.PLAN_NUMBER = CConvert.ToDecimal(lineTable.PLAN_NUMBER) + CConvert.ToDecimal(dr["QUANTITY"]);
                                    isExist = true;
                                    break;
                                }
                            }
                            if (!isExist)
                            {
                                BaseProductionPlanLineTable lineTable = new BaseProductionPlanLineTable();
                                lineTable.TYPE_CODE = CConvert.ToString(dr["PRODUCT_CODE"]);
                                lineTable.TYPE_NAME = CConvert.ToString(dr["SLIP_TYPE_NAME"]);
                                lineTable.PARTS_CODE = partsCode;
                                lineTable.PARTS_NAME = CConvert.ToString(dr["COMPOSITION_PRODUCTS_NAME"]);
                                lineTable.PLAN_NUMBER = CConvert.ToDecimal(dr["QUANTITY"]);

                                lineTable.LINE_NUMBER = ProductionScheduleLine++;

                                planTable.AddItem(lineTable);
                            }
                            BllOrderLineTable orderLine = new BllOrderLineTable();
                            orderLine.ALLOATION_QUANTITY = CConvert.ToDecimal(dr["QUANTITY"]);
                            orderLine.SLIP_NUMBER = CConvert.ToString(dr["SLIP_NUMBER"]);
                            orderLine.LINE_NUMBER = CConvert.ToInt32(dr["LINE_NUMBER"]);
                            bOrderHeadTable.AddItem(orderLine);
                        }
                    }
                }

                #endregion

                #region 工序的整理
                Hashtable dwHt = new Hashtable();
                //Hashtable TechnologyHt = new Hashtable();
                foreach (BaseProductionPlanLineTable lineTable in planTable.Items)
                {
                    int SCHEDULE_LINE_NUNBER = CConvert.ToInt32(lineTable.LINE_NUMBER);
                    DateTime currentDate = txtSlipDateFrom.Value;
                    lineTable.PLAN_START_DATE = currentDate;
                    DataTable productionProcessDt = bCompositionProductsProductionProcess.GetList(" COMPOSITION_PRODUCTS_CODE = '" + lineTable.PARTS_CODE + "'").Tables[0];
                    int ProductionProcessLineNumber = 1;

                    foreach (DataRow dr in productionProcessDt.Rows)
                    {
                        BaseProductionScheduleProductionProcessTable productionProcessTable = new BaseProductionScheduleProductionProcessTable();
                        productionProcessTable.PRODUCTION_PROCESS_CODE = CConvert.ToString(dr["PRODUCTION_PROCESS_CODE"]);
                        productionProcessTable.PRODUCTION_PROCESS_NAME = CConvert.ToString(dr["PRODUCTION_PROCESS_NAME"]);
                        productionProcessTable.DEPARTMENT_CODE = CConvert.ToString(dr["DEPARTMENT_CODE"]);
                        productionProcessTable.DEPARTMENT_NAME = CConvert.ToString(dr["DEPARTMENT_NAME"]);
                        productionProcessTable.PRODUCTION_CYCLE = CConvert.ToDecimal(dr["PRODUCTION_CYCLE"]);
                        productionProcessTable.PLAN_START_DATE = currentDate;
                        productionProcessTable.LINE_NUMBER = ProductionProcessLineNumber++;
                        for (int i = 1; i <= 6; i++)
                        {
                            string dwCode = CConvert.ToString(dr["DRAWING_TYPE_CODE" + i]);
                            if (string.IsNullOrEmpty(dwCode))
                            {
                                continue;
                            }
                            if (dwHt.ContainsKey(dwCode))
                            {
                                DateTime dateTime = CConvert.ToDateTime(dwHt[dwCode]);
                                if (currentDate < dateTime)
                                {
                                    dwHt[dwCode] = currentDate;
                                }
                            }
                            else
                            {
                                dwHt.Add(dwCode, currentDate);
                            }
                        }
                        currentDate = currentDate.AddDays(CConvert.ToDouble(dr["PRODUCTION_CYCLE"]) + 0D);
                        productionProcessTable.PLAN_END_DATE = currentDate;
                        productionProcessTable.SCHEDULE_LINE_NUNBER = lineTable.LINE_NUMBER;
                        lineTable.AddProductionProcess(productionProcessTable);
                    }
                    lineTable.PLAN_END_DATE = currentDate;
                }
                #endregion

                #region 技术的整理
                foreach (BaseProductionPlanLineTable lineTable in planTable.Items)
                {
                    int SCHEDULE_LINE_NUMBER = CConvert.ToInt32(lineTable.LINE_NUMBER);
                    foreach (BaseProductionScheduleProductionProcessTable lineModel in lineTable.ProductionProcess)
                    {
                        int SCHEDULE_PRODUCTION_PROCESS_LINE_NUNBER = CConvert.ToInt32(lineModel.LINE_NUMBER);
                        DataTable productionTechnologyDt = bCompositionProductsProductionProcess.GetList(" COMPOSITION_PRODUCTS_CODE = '" + lineTable.PARTS_CODE + "'" + " AND PRODUCTION_PROCESS_CODE = '" + lineModel.PRODUCTION_PROCESS_CODE + "'").Tables[0];
                        int TechnologyNumber = 1;
                        foreach (DataRow dr in productionTechnologyDt.Rows)
                        {
                            for (int j = 1; j <= 3; j++)
                            {
                                string technologyCode = CConvert.ToString(dr["TECHNOLOGY_CODE" + j]);
                                if (technologyCode != "")
                                {
                                    BaseProductionTechnologyTable technologyTable = new BaseProductionTechnologyTable();
                                    technologyTable.PRODUCTION_PROCESS_CODE = CConvert.ToString(dr["PRODUCTION_PROCESS_CODE"]);
                                    technologyTable.COMPOSITION_PRODUCTS_CODE = CConvert.ToString(dr["COMPOSITION_PRODUCTS_CODE"]);
                                    technologyTable.PRODUCTION_PROCESS_NAME = CConvert.ToString(dr["PRODUCTION_PROCESS_NAME"]);
                                    technologyTable.COMPOSITION_PRODUCTS_NAME = CConvert.ToString(dr["COMPOSITION_PRODUCTS_NAME"]);
                                    technologyTable.LINE_NUMBER = TechnologyNumber++;
                                    technologyTable.SCHEDULE_PRODUCTION_PROCESS_LINE_NUNBER = SCHEDULE_PRODUCTION_PROCESS_LINE_NUNBER;
                                    technologyTable.SCHEDULE_LINE_NUMBER = SCHEDULE_LINE_NUMBER;
                                    technologyTable.TECHNOLOGY_CODE = technologyCode;
                                    technologyTable.TECHNOLOGY_NAME = bCommon.GetBaseMaster("TECHNOLOGY", technologyCode).Name;
                                    lineModel.AddProductionTechnology(technologyTable);
                                }
                            }
                        }
                    }
                }
                #endregion

                #region 图纸处理
                int DrawingLineNumber = 1;
                foreach (DictionaryEntry de in dwHt)
                {
                    BaseProductionPlanDrawingLineTable drawingTable = new BaseProductionPlanDrawingLineTable();
                    drawingTable.DRAWING_CODE = CConvert.ToString(de.Key);
                    drawingTable.DRAWING_NAME = bCommon.GetBaseMaster("DRAWING", drawingTable.DRAWING_CODE).Name;
                    drawingTable.PLAN_END_DATE = CConvert.ToDateTime(de.Value);
                    drawingTable.LINE_NUMBER = DrawingLineNumber++;
                    planTable.AddItemDrawing(drawingTable);
                }
                #endregion

                DataBind();
            }
            catch (Exception ex) { }
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBind()
        {
            if (planTable != null)
            {
                //部件绑定
                dgvData.Rows.Clear();
                foreach (BaseProductionPlanLineTable lineTable in planTable.Items)
                {
                    object[] dgvr = { "", lineTable.TYPE_NAME, lineTable.PARTS_NAME, lineTable.PLAN_START_DATE, lineTable.PLAN_END_DATE, lineTable.PLAN_NUMBER, planTable.SPEC, lineTable.TYPE_CODE, lineTable.PARTS_CODE };
                    dgvData.Rows.Add(dgvr);
                }
                //图纸绑定
                dgvDrawing.Rows.Clear();
                foreach (BaseProductionPlanDrawingLineTable drawingTable in planTable.ItemsDrawing)
                {
                    object[] dgvr = { "", drawingTable.DRAWING_NAME, drawingTable.PLAN_END_DATE, drawingTable.DRAWING_CODE };
                    dgvDrawing.Rows.Add(dgvr);
                }
                dgvTechnology.Rows.Clear();

                foreach (BaseProductionPlanLineTable lineTable in planTable.Items)
                {
                    foreach (BaseProductionScheduleProductionProcessTable lineModel in lineTable.ProductionProcess)
                    {
                        foreach (BaseProductionTechnologyTable technologyTable in lineModel.ProductionTechnology)
                        {
                            object[] dgvr = { "", technologyTable.COMPOSITION_PRODUCTS_NAME, technologyTable.PRODUCTION_PROCESS_NAME, technologyTable.TECHNOLOGY_NAME, technologyTable.TECHNOLOGY_CODE, technologyTable.COMPOSITION_PRODUCTS_CODE, technologyTable.PRODUCTION_PROCESS_CODE };
                            dgvTechnology.Rows.Add(dgvr);
                        }
                    }
                }
                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    row.Cells["PROCESS_CHK"].Value = 1;
                    break;
                }
            }
        }
        #endregion

        private string GetConduction()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" SLIP_TYPE_CODE = '{0}'", planTable.SLIP_TYPE_CODE);
            return sb.ToString();
        }
        /// <summary>
        /// 增加图纸类型
        /// </summary>
        private void btnAddDraw_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("DRAWING", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                for (int j = 0; j < dgvDrawing.Rows.Count; j++)
                {
                    if (frm.BaseMasterTable.Code == dgvDrawing.Rows[j].Cells["DRAWING_TYPE_CODE"].Value.ToString())
                    {
                        MessageBox.Show("图纸已存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                string DRAWINGTYPE = frm.BaseMasterTable.Name;
                object[] rows = { "", DRAWINGTYPE, dateTimePicker2.Text };
                dgvDrawing.Rows.Add(rows);

                BaseProductionPlanDrawingLineTable drawingTable = new BaseProductionPlanDrawingLineTable();
                drawingTable.DRAWING_CODE = frm.BaseMasterTable.Code;
                drawingTable.DRAWING_NAME = frm.BaseMasterTable.Name;
                drawingTable.PLAN_END_DATE = CConvert.ToDateTime(dateTimePicker2.Text);
                drawingTable.LINE_NUMBER = CConvert.ToInt32(planTable.ItemsDrawing[planTable.ItemsDrawing.Count - 1].LINE_NUMBER + 1);
                planTable.AddItemDrawing(drawingTable);
            }
            frm.Dispose();
        }

        /// <summary>
        /// 增加部件
        /// </summary>
        private void btnAddParts_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("SLIP_TYPE_COMPOSITION_PRODUCTS_VIEW", GetConduction());//SLIP_TYPE_CODE = {0}",cboSlipType.SelectedValue.ToString()
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                for (int j = 0; j < dgvData.Rows.Count; j++)
                {
                    if (frm.BaseMasterTable.Code == dgvData.Rows[j].Cells["PARTS_CODE"].Value.ToString())
                    {
                        dgvData.Rows[j].Cells["PLAN_QUANTITY"].Value = (CConvert.ToInt32(dgvData.Rows[j].Cells["PLAN_QUANTITY"].Value.ToString()) + 1);
                        MessageBox.Show("部件已存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                string compositionproductscode = frm.BaseMasterTable.Code;
                string compositionproductsname = frm.BaseMasterTable.Name;
                BaseProductionPlanLineTable lineTable = new BaseProductionPlanLineTable();
                DateTime currentDate = txtSlipDateFrom.Value;
                lineTable.PLAN_START_DATE = currentDate;
                int ProductionProcessLineNumber = 1;
                DataTable productionProcessDt = bCompositionProductsProductionProcess.GetList(" COMPOSITION_PRODUCTS_CODE = '" + compositionproductscode + "'").Tables[0];
                //lineTable.PLAN_END_DATE = currentDate;
                lineTable.PARTS_CODE = compositionproductscode;
                lineTable.PARTS_NAME = compositionproductsname;
                lineTable.PLAN_NUMBER = CConvert.ToDecimal(txtProductionQuantity.Text);
                lineTable.TYPE_CODE = cboSlipType.SelectedValue.ToString();
                lineTable.TYPE_NAME = cboSlipType.Text.ToString();
                lineTable.LINE_NUMBER = CConvert.ToInt32(planTable.Items[planTable.Items.Count - 1].LINE_NUMBER + 1);
                planTable.AddItem(lineTable);
                foreach (DataRow dr in productionProcessDt.Rows)
                {
                    BaseProductionScheduleProductionProcessTable productionProcessTable = new BaseProductionScheduleProductionProcessTable();
                    productionProcessTable.PRODUCTION_PROCESS_CODE = CConvert.ToString(dr["PRODUCTION_PROCESS_CODE"]);
                    productionProcessTable.PRODUCTION_PROCESS_NAME = CConvert.ToString(dr["PRODUCTION_PROCESS_NAME"]);
                    productionProcessTable.DEPARTMENT_CODE = CConvert.ToString(dr["DEPARTMENT_CODE"]);
                    productionProcessTable.DEPARTMENT_NAME = CConvert.ToString(dr["DEPARTMENT_NAME"]);
                    productionProcessTable.PRODUCTION_CYCLE = CConvert.ToDecimal(dr["PRODUCTION_CYCLE"]);
                    productionProcessTable.PLAN_START_DATE = currentDate;
                    currentDate = currentDate.AddDays(CConvert.ToDouble(dr["PRODUCTION_CYCLE"]) + 0D);
                    productionProcessTable.PLAN_END_DATE = currentDate;
                    productionProcessTable.LINE_NUMBER = ProductionProcessLineNumber++;
                    productionProcessTable.SCHEDULE_LINE_NUNBER = lineTable.LINE_NUMBER;
                    lineTable.AddProductionProcess(productionProcessTable);
                    lineTable.PLAN_END_DATE = currentDate;
                    DataTable productionTechnologyDt = bCompositionProductsProductionProcess.GetList(" COMPOSITION_PRODUCTS_CODE = '" + lineTable.PARTS_CODE + "'" + " AND PRODUCTION_PROCESS_CODE = '" + productionProcessTable.PRODUCTION_PROCESS_CODE + "'").Tables[0];
                    int TechnologyNumber = 1;
                    foreach (DataRow dr1 in productionTechnologyDt.Rows)
                    {
                        for (int j = 1; j <= 3; j++)
                        {
                            string technologyCode = CConvert.ToString(dr["TECHNOLOGY_CODE" + j]);
                            if (technologyCode != "")
                            {
                                BaseProductionTechnologyTable technologyTable = new BaseProductionTechnologyTable();
                                technologyTable.PRODUCTION_PROCESS_CODE = CConvert.ToString(dr1["PRODUCTION_PROCESS_CODE"]);
                                technologyTable.COMPOSITION_PRODUCTS_CODE = CConvert.ToString(dr1["COMPOSITION_PRODUCTS_CODE"]);
                                technologyTable.PRODUCTION_PROCESS_NAME = CConvert.ToString(dr1["PRODUCTION_PROCESS_NAME"]);
                                technologyTable.COMPOSITION_PRODUCTS_NAME = CConvert.ToString(dr1["COMPOSITION_PRODUCTS_NAME"]);
                                technologyTable.LINE_NUMBER = TechnologyNumber++;
                                technologyTable.SCHEDULE_LINE_NUMBER = CConvert.ToInt32(lineTable.LINE_NUMBER);
                                technologyTable.SCHEDULE_PRODUCTION_PROCESS_LINE_NUNBER = CConvert.ToInt32(lineTable.ProductionProcess[lineTable.ProductionProcess.Count - 1].LINE_NUMBER + 1);
                                technologyTable.TECHNOLOGY_CODE = technologyCode;
                                technologyTable.TECHNOLOGY_NAME = bCommon.GetBaseMaster("TECHNOLOGY", technologyCode).Name;
                                productionProcessTable.AddProductionTechnology(technologyTable);
                                object[] dgvrTechnology = { "", technologyTable.COMPOSITION_PRODUCTS_NAME, technologyTable.PRODUCTION_PROCESS_NAME, technologyTable.TECHNOLOGY_NAME, technologyTable.TECHNOLOGY_CODE, technologyTable.COMPOSITION_PRODUCTS_CODE, technologyTable.PRODUCTION_PROCESS_CODE };
                                dgvTechnology.Rows.Add(dgvrTechnology);
                            }
                        }
                    }
                }
                object[] dgvr = { "", lineTable.TYPE_NAME, lineTable.PARTS_NAME, lineTable.PLAN_START_DATE, lineTable.PLAN_END_DATE, lineTable.PLAN_NUMBER, planTable.SPEC, lineTable.TYPE_CODE, lineTable.PARTS_CODE };
                dgvData.Rows.Add(dgvr);
            }

            frm.Dispose();
        }

        /// <summary>
        /// 生产计划的保存
        /// </summary>
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
            try
            {
                string slipNumber = bProductionPlan.Add(planTable, bOrderHeadTable);
                if (slipNumber == null)
                {
                    MessageBox.Show("生产计划保存失败,请重试或与管理员联系。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    initPage();
                    MessageBox.Show("生产计划保存成功。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex) { }

        }

        #region 数据保存前的验证
        /// <summary>
        /// 数据保存前主表数据验证
        /// </summary>
        private bool CheckHeaderInput()
        {
            string message = "";
            if (string.IsNullOrEmpty(this.txtOrderSlipNumber.Text))
            {
                message += "订单编号不能为空。\r\n";
            }
            if (string.IsNullOrEmpty(this.txtProductionQuantity.Text))
            {
                message += "计划数量不能为空。\r\n";
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
            int PROCESS_CHK_COUNT = 0;
            int count = dgvData.Rows.Count;
            int i = 1;
            if (dgvData.Rows.Count == 0)
            {
                MessageBox.Show("部件明细数不能为空。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (dgvDrawing.Rows.Count == 0)
            {
                MessageBox.Show("图纸明细数不能为空。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            foreach (DataGridViewRow row in dgvData.Rows)
            {

                if (count > i)
                {
                    if (CConvert.ToString(row.Cells["PLAN_QUANTITY"].Value) == "")
                    {
                        MessageBox.Show("计划数量不能为空。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    else if (row.Cells["PLAN_START_DATE"].Value.ToString() == "")
                    {
                        MessageBox.Show("预定开始日期不能为空。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    else if (row.Cells["PLAN_END_DATE"].Value.ToString() == "")
                    {
                        MessageBox.Show("预定完成日期不能为空。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    else if ((bool)row.Cells["PROCESS_CHK"].EditedFormattedValue == true)
                    {
                        PROCESS_CHK_COUNT++;
                        if (PROCESS_CHK_COUNT > 1)
                        {
                            MessageBox.Show("跟踪进度明细只能为一条。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        }
                    }
                }
                i++;
            }

            foreach (DataGridViewRow row in dgvDrawing.Rows)
            {
                if (dgvDrawing.Rows.Count > i)
                {
                    if (CConvert.ToString(row.Cells["DRAWING_PLAN_END_DATE"].Value) == "")
                    {
                        MessageBox.Show("预定完成日期不能为空。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
                i++;
            }

            return true;
        }
        #endregion

        #region 数据保存成功后页面初始化
        /// <summary>
        /// 数据保存成功后页面初始化
        /// </summary>
        private void initPage()
        {
            DataSet ds = bOrderHeader.GetModelInfo(txtOrderSlipNumber.Text);
            ds.Tables[0].Rows.Clear();
            cboSlipType.ValueMember = "PRODUCT_CODE";
            cboSlipType.DisplayMember = "SLIP_TYPE_NAME";
            cboSlipType.DataSource = ds.Tables[0].DefaultView.ToTable(true, "PRODUCT_CODE", "SLIP_TYPE_NAME");
            this.txtOrderSlipNumber.Text = "";
            this.txtSpec.Text = "";
            this.txtOrderQuantity.Text = "";
            this.txtQuantity.Text = "";
            this.txtProductionQuantity.Text = "";
            this.txtMemo.Text = "";
            initSlipNumber();
            this.dgvData.Rows.Clear();
            this.dgvDrawing.Rows.Clear();
            this.dgvTechnology.Rows.Clear();
        }

        #endregion
        /// <summary>
        /// 关闭页面
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region DataGridView 部件处理
        private void dgvData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            DataGridView dgv = (DataGridView)(sender);
            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex == 0)
                {
                    DataGridViewRow row = dgv.Rows[e.RowIndex];
                    row.Cells["NO"].Value = e.RowIndex + 1;
                    //按钮图片 
                    row.Cells["BTN_DELETE"].Value = Resources.line_delete;
                    row.Cells["BTN_PRODUCTION_PROCESS"].Value = Resources.line_find_over;
                }
            }
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(_oldSlipNumber))
                {
                    if (e.ColumnIndex == dgvData.Columns["BTN_DELETE"].Index)
                    {
                        if (MessageBox.Show("确定要删除当前行吗？", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                        {
                            foreach (BaseProductionPlanLineTable lineTable in planTable.Items)
                            {
                                if (lineTable.PARTS_CODE == dgvData.Rows[e.RowIndex].Cells["PARTS_CODE"].Value.ToString())
                                {
                                    foreach (BaseProductionScheduleProductionProcessTable procrssTable in lineTable.ProductionProcess)
                                    {
                                        //foreach (BaseProductionTechnologyTable technologyModel in procrssTable.ProductionTechnology)
                                        for (int i = 0; i < procrssTable.ProductionTechnology.Count; i++)
                                        {
                                            BaseProductionTechnologyTable technologyModel = procrssTable.ProductionTechnology[i];

                                            if (technologyModel.COMPOSITION_PRODUCTS_CODE == dgvData.Rows[e.RowIndex].Cells["PARTS_CODE"].Value.ToString())
                                            {
                                                procrssTable.ProductionTechnology.Clear();
                                                for (int j = 0; j < dgvTechnology.Rows.Count; j++)
                                                {
                                                    if (dgvTechnology.Rows[j].Cells["COMPOSITION_PRODUCTS_CODE"].Value.ToString() == technologyModel.COMPOSITION_PRODUCTS_CODE)
                                                    {
                                                        dgvTechnology.Rows.RemoveAt(j);
                                                    }
                                                }
                                            }
                                        }
                                    }

                                    planTable.Items.Remove(lineTable);
                                    lineTable.ProductionProcess.Clear();
                                    dgvData.Rows.Remove(dgvData.Rows[e.RowIndex]);

                                }
                            }

                        }
                    }
                    else if (e.ColumnIndex == dgvData.Columns["BTN_PRODUCTION_PROCESS"].Index)
                    {
                        FrmProductionPlanDetails frm = new FrmProductionPlanDetails();
                        frm.PARTS_NAME = dgvData.Rows[e.RowIndex].Cells["PARTS_NAME"].Value.ToString();
                        frm.PLAN_START_DATE = CConvert.ToDateTime(dgvData.Rows[e.RowIndex].Cells["PLAN_START_DATE"].Value);
                        frm.PLAN_END_DATE = CConvert.ToDateTime(dgvData.Rows[e.RowIndex].Cells["PLAN_END_DATE"].Value);
                        frm.PLAN_QUANTITY = CConvert.ToDecimal(dgvData.Rows[e.RowIndex].Cells["PLAN_QUANTITY"].Value);
                        frm.PARTS_CODE = dgvData.Rows[e.RowIndex].Cells["PARTS_CODE"].Value.ToString();
                        frm.PLANTABLE = planTable;
                        if (frm.ShowDialog(this) == DialogResult.OK)
                        {
                            dgvTechnology.Rows.Clear();
                            foreach (BaseProductionPlanLineTable lineTable in planTable.Items)
                            {

                                foreach (BaseProductionScheduleProductionProcessTable lineModel in lineTable.ProductionProcess)
                                {
                                    lineModel.ProductionTechnology.Clear();
                                }
                            }
                            //lineTable.ProductionProcess.Clear();
                            foreach (BaseProductionPlanLineTable lineTable in planTable.Items)
                            {

                                int SCHEDULE_LINE_NUMBER = CConvert.ToInt32(lineTable.LINE_NUMBER);

                                //lineModel.ProductionTechnology.Clear();
                                foreach (BaseProductionScheduleProductionProcessTable lineModel in lineTable.ProductionProcess)
                                {

                                    int SCHEDULE_PRODUCTION_PROCESS_LINE_NUNBER = CConvert.ToInt32(lineModel.LINE_NUMBER);
                                    DataTable productionTechnologyDt = bCompositionProductsProductionProcess.GetList(" COMPOSITION_PRODUCTS_CODE = '" + lineTable.PARTS_CODE + "'" + " AND PRODUCTION_PROCESS_CODE = '" + lineModel.PRODUCTION_PROCESS_CODE + "'").Tables[0];
                                    int TechnologyNumber = 1;
                                    foreach (DataRow dr in productionTechnologyDt.Rows)
                                    {
                                        for (int j = 1; j <= 3; j++)
                                        {
                                            string technologyCode = CConvert.ToString(dr["TECHNOLOGY_CODE" + j]);
                                            if (technologyCode != "")
                                            {
                                                BaseProductionTechnologyTable technologyTable = new BaseProductionTechnologyTable();
                                                technologyTable.PRODUCTION_PROCESS_CODE = CConvert.ToString(dr["PRODUCTION_PROCESS_CODE"]);
                                                technologyTable.COMPOSITION_PRODUCTS_CODE = CConvert.ToString(dr["COMPOSITION_PRODUCTS_CODE"]);
                                                technologyTable.PRODUCTION_PROCESS_NAME = CConvert.ToString(dr["PRODUCTION_PROCESS_NAME"]);
                                                technologyTable.COMPOSITION_PRODUCTS_NAME = CConvert.ToString(dr["COMPOSITION_PRODUCTS_NAME"]);
                                                technologyTable.LINE_NUMBER = TechnologyNumber++;
                                                technologyTable.SCHEDULE_PRODUCTION_PROCESS_LINE_NUNBER = SCHEDULE_PRODUCTION_PROCESS_LINE_NUNBER;
                                                technologyTable.SCHEDULE_LINE_NUMBER = SCHEDULE_LINE_NUMBER;
                                                technologyTable.TECHNOLOGY_CODE = technologyCode;
                                                technologyTable.TECHNOLOGY_NAME = bCommon.GetBaseMaster("TECHNOLOGY", technologyCode).Name;
                                                lineModel.AddProductionTechnology(technologyTable);
                                                object[] dgvrTechnology = { "", technologyTable.COMPOSITION_PRODUCTS_NAME, technologyTable.PRODUCTION_PROCESS_NAME, technologyTable.TECHNOLOGY_NAME, technologyTable.TECHNOLOGY_CODE, technologyTable.COMPOSITION_PRODUCTS_CODE, technologyTable.PRODUCTION_PROCESS_CODE };
                                                dgvTechnology.Rows.Add(dgvrTechnology);
                                            }
                                        }
                                    }
                                }
                            }


                        }
                        frm.Dispose();
                    }
                }
                else if (CConstant.QUOTATION_OPERATE.Equals(CTag))
                {
                    if (e.ColumnIndex == dgvData.Columns["BTN_PRODUCTION_PROCESS"].Index)
                    {
                        FrmProductionPlanDetails frm = new FrmProductionPlanDetails();
                        frm.PARTS_NAME = dgvData.Rows[e.RowIndex].Cells["PARTS_NAME"].Value.ToString();
                        frm.PLAN_START_DATE = CConvert.ToDateTime(dgvData.Rows[e.RowIndex].Cells["PLAN_START_DATE"].Value);
                        frm.PLAN_END_DATE = CConvert.ToDateTime(dgvData.Rows[e.RowIndex].Cells["PLAN_END_DATE"].Value);
                        frm.PLAN_QUANTITY = CConvert.ToDecimal(dgvData.Rows[e.RowIndex].Cells["PLAN_QUANTITY"].Value);
                        frm.PARTS_CODE = dgvData.Rows[e.RowIndex].Cells["PARTS_CODE"].Value.ToString();
                        frm.PLANTABLE = planTable;
                        frm.CTag = CConstant.QUOTATION_OPERATE;
                        if (frm.ShowDialog(this) == DialogResult.OK)
                        { }

                        frm.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region DataGridView 图纸处理
        private void dgvDrawing_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            DataGridView dgv = (DataGridView)(sender);
            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex == 0)
                {
                    DataGridViewRow row = dgv.Rows[e.RowIndex];
                    row.Cells["DRAWING_NO"].Value = e.RowIndex + 1;
                    //按钮图片 
                    row.Cells["DRAWING_BTN_DELETE"].Value = Resources.line_delete;
                }
            }
        }

        private void dgvDrawing_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(_oldSlipNumber))
                {

                    if (e.ColumnIndex == dgvDrawing.Columns["DRAWING_BTN_DELETE"].Index)
                    {
                        if (MessageBox.Show("确定要删除当前行吗？", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                        {
                            foreach (BaseProductionPlanDrawingLineTable linedrawingTable in planTable.ItemsDrawing)
                            {
                                if (linedrawingTable.DRAWING_CODE == dgvDrawing.Rows[e.RowIndex].Cells["DRAWING_TYPE_CODE"].Value.ToString())
                                {
                                    planTable.ItemsDrawing.Remove(linedrawingTable);
                                    dgvDrawing.Rows.Remove(dgvDrawing.Rows[e.RowIndex]);
                                }
                            }
                        }
                    }
                }
                else { }
            }
            catch (Exception ex)
            {
            }
        }
        #endregion

        private void cboSlipType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string slipNumber = txtOrderSlipNumber.Text;
            string productcode = cboSlipType.SelectedValue.ToString();
            DataSet ds = bOrderHeader.GetModelInfo(slipNumber, productcode);
            txtSpec.Text = ds.Tables[0].Rows[0]["SPEC"].ToString().Trim();
            int PartCodeNullCount = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                string partsCode = CConvert.ToString(dr["PARTS_CODE"]);
                if (partsCode == "")
                {
                    PartCodeNullCount++;
                    if (dr["ALLOATION_QUANTITY"].ToString().Trim() != "")
                    {
                        txtQuantity.Text = dr["ALLOATION_QUANTITY"].ToString();
                    }
                    else
                    {
                        txtQuantity.Text = "0";
                    }
                    txtOrderQuantity.Text = dr["QUANTITY"].ToString().Trim();
                }

                if (PartCodeNullCount == 0)
                {

                    if (dr["ALLOATION_QUANTITY"].ToString().Trim() != "" && dr["ALLOATION_QUANTITY"].ToString().Trim() != "0.00")
                    {
                        txtQuantity.Text = "1";
                    }
                    else
                    {
                        txtQuantity.Text = "0";
                    }
                    txtOrderQuantity.Text = "1";
                }
            }
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtProductionQuantity.Focused)
                {
                    btnSave.Focus();
                }
                else
                {
                    System.Windows.Forms.SendKeys.Send("{Tab}");
                    //ProcessTabKey(true);
                }
            }

            if (txtProductionQuantity.Focused)
            {
                if (e.KeyChar == 46)
                {
                    if (((TextBox)sender).SelectionStart == 0)
                    {
                        e.Handled = true;
                    }
                    else if (((TextBox)sender).Text.IndexOf('.') >= 0)
                    {
                        e.Handled = true;
                    }
                }
                else if (e.KeyChar == 8)
                {
                    e.Handled = false;
                }
                else if ((e.KeyChar < 48 || e.KeyChar > 57 || e.KeyChar == 46) && e.KeyChar != 13 && e.KeyChar != 22 && e.KeyChar != 3 && e.KeyChar != 24 && e.KeyChar != 26)
                {
                    e.Handled = true;
                }
                else　 //以下为输入正确内容过虑
                {
                    string[] str = ((TextBox)sender).Text.Split('.');
                    if (str.Length > 1)
                    {
                        if (str[1].Length >= 2 && ((TextBox)sender).SelectionStart > ((TextBox)sender).Text.IndexOf('.'))
                        {
                            e.Handled = true;
                        }
                    }
                }
            }
        }

        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (txtProductionQuantity.Focused)
                {

                }
                else
                {
                    System.Windows.Forms.SendKeys.Send("+{Tab}");
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (txtProductionQuantity.Focused)
                { }
                else
                {
                    System.Windows.Forms.SendKeys.Send("{Tab}");
                }
            }
        }

        private void dgvDrawing_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        static private Regex r = new Regex("^(?:(?!0000)[0-9]{4}([-/.]?)(?:(?:0?[1-9]|1[0-2])([-/.]?)(?:0?[1-9]|1[0-9]|2[0-8])|(?:0?[13-9]|1[0-2])([-/.]?)(?:29|30)|(?:0?[13578]|1[02])([-/.]?)31)|(?:[0-9]{2}(?:0[48]|[2468][048]|[13579][26])|(?:0[48]|[2468][048]|[13579][26])00)([-/.]?)0?2([-/.]?)29)");
        private void dgvData_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = dgvData.Rows[e.RowIndex];
            if (e.ColumnIndex == dgvData.Columns["PLAN_START_DATE"].Index)
            {
                if (dr.Cells["PLAN_START_DATE"].Value != null)
                {
                    if (!r.IsMatch(dr.Cells["PLAN_START_DATE"].Value.ToString().Trim()))
                    {
                        MessageBox.Show("请输入正确的日期。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvData.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                    }
                }
            }
            if (e.ColumnIndex == dgvData.Columns["PLAN_END_DATE"].Index)
            {
                if (dr.Cells["PLAN_END_DATE"].Value != null)
                {
                    if (!r.IsMatch(dr.Cells["PLAN_END_DATE"].Value.ToString().Trim()))
                    {
                        MessageBox.Show("请输入正确的日期。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvData.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                    }
                }
            }
        }
        private void dgvDrawing_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = dgvDrawing.Rows[e.RowIndex];
            if (e.ColumnIndex == dgvDrawing.Columns["DRAWING_PLAN_END_DATE"].Index)
            {
                if (dr.Cells["DRAWING_PLAN_END_DATE"].Value != null)
                {
                    if (!r.IsMatch(dr.Cells["DRAWING_PLAN_END_DATE"].Value.ToString().Trim()))
                    {
                        MessageBox.Show("请输入正确的日期。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvDrawing.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                    }
                }
            }

        }

        private void btnOrderSlipNumber_MouseEnter(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.find_over);
        }

        private void btnOrderSlipNumber_MouseLeave(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.find);
        }

        private void dgvTechnology_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            DataGridView dgv = (DataGridView)(sender);
            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex == 0)
                {
                    DataGridViewRow row = dgv.Rows[e.RowIndex];
                    row.Cells["Technology_NO"].Value = e.RowIndex + 1;
                    //按钮图片 
                    row.Cells["TECHNOLOGY_BTN_DELETE"].Value = Resources.line_delete;
                }
            }
        }

        private void dgvTechnology_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(_oldSlipNumber))
                {
                    if (e.ColumnIndex == dgvTechnology.Columns["TECHNOLOGY_BTN_DELETE"].Index)
                    {
                        if (MessageBox.Show("确定要删除当前行吗？", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                        {
                            foreach (BaseProductionPlanLineTable lineTable in planTable.Items)
                            {
                                foreach (BaseProductionScheduleProductionProcessTable procrssTable in lineTable.ProductionProcess)
                                {
                                    foreach (BaseProductionTechnologyTable technologyModel in procrssTable.ProductionTechnology)
                                    {
                                        if (technologyModel.COMPOSITION_PRODUCTS_CODE == dgvTechnology.Rows[e.RowIndex].Cells["COMPOSITION_PRODUCTS_CODE"].Value.ToString() && technologyModel.PRODUCTION_PROCESS_CODE == dgvTechnology.Rows[e.RowIndex].Cells["PRODUCTION_PROCESS_CODE"].Value.ToString() && technologyModel.TECHNOLOGY_CODE == dgvTechnology.Rows[e.RowIndex].Cells["TECHNOLOGY_CODE"].Value.ToString())
                                        {
                                            procrssTable.ProductionTechnology.Remove(technologyModel);
                                            dgvTechnology.Rows.Remove(dgvTechnology.Rows[e.RowIndex]);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else { }
            }
            catch (Exception ex)
            {
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    btnAddDraw.Visible = false;
                    btnAddParts.Visible = true;
                    break;

                case 1:
                    btnAddParts.Visible = false;
                    btnAddDraw.Visible = true;
                    break;

                case 2:
                    btnAddParts.Visible = false;
                    btnAddDraw.Visible = false;
                    break;
            }
        }

    }//end class
}
