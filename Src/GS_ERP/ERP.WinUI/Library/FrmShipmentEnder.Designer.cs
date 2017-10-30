namespace CZZD.ERP.WinUI
{
    partial class FrmShipmentEnder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnClose = new System.Windows.Forms.Button();
            this.pleft_2 = new System.Windows.Forms.Panel();
            this.cmbJied = new System.Windows.Forms.ComboBox();
            this.cmbQu = new System.Windows.Forms.ComboBox();
            this.cmdShi = new System.Windows.Forms.ComboBox();
            this.cmbSheng = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSlipDateTo = new System.Windows.Forms.DateTimePicker();
            this.txtSlipDateFrom = new System.Windows.Forms.DateTimePicker();
            this.pRight_1 = new System.Windows.Forms.Panel();
            this.pRight = new System.Windows.Forms.Panel();
            this.pRight_2 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnOutProduct = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.pInfo = new System.Windows.Forms.Panel();
            this.pLeft = new System.Windows.Forms.Panel();
            this.pLeft_1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.BtnOutPrint = new System.Windows.Forms.Button();
            this.COMMUNITY_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ORDER_SN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USER_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CONSIGNEE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BEST_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ADDRESS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ORDER_TYPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ORDER_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pleft_2.SuspendLayout();
            this.pRight.SuspendLayout();
            this.pRight_2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.pInfo.SuspendLayout();
            this.pLeft.SuspendLayout();
            this.pLeft_1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnClose.Location = new System.Drawing.Point(925, 502);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 30);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "关　闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pleft_2
            // 
            this.pleft_2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pleft_2.Controls.Add(this.cmbJied);
            this.pleft_2.Controls.Add(this.cmbQu);
            this.pleft_2.Controls.Add(this.cmdShi);
            this.pleft_2.Controls.Add(this.cmbSheng);
            this.pleft_2.Controls.Add(this.label2);
            this.pleft_2.Controls.Add(this.txtSlipDateTo);
            this.pleft_2.Controls.Add(this.txtSlipDateFrom);
            this.pleft_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pleft_2.Location = new System.Drawing.Point(120, 0);
            this.pleft_2.Name = "pleft_2";
            this.pleft_2.Size = new System.Drawing.Size(388, 194);
            this.pleft_2.TabIndex = 5;
            // 
            // cmbJied
            // 
            this.cmbJied.FormattingEnabled = true;
            this.cmbJied.Location = new System.Drawing.Point(272, 34);
            this.cmbJied.Name = "cmbJied";
            this.cmbJied.Size = new System.Drawing.Size(95, 20);
            this.cmbJied.TabIndex = 11;
            // 
            // cmbQu
            // 
            this.cmbQu.FormattingEnabled = true;
            this.cmbQu.Location = new System.Drawing.Point(180, 33);
            this.cmbQu.Name = "cmbQu";
            this.cmbQu.Size = new System.Drawing.Size(79, 20);
            this.cmbQu.TabIndex = 11;
            this.cmbQu.SelectedIndexChanged += new System.EventHandler(this.cmbQu_SelectedIndexChanged);
            // 
            // cmdShi
            // 
            this.cmdShi.FormattingEnabled = true;
            this.cmdShi.Location = new System.Drawing.Point(88, 33);
            this.cmdShi.Name = "cmdShi";
            this.cmdShi.Size = new System.Drawing.Size(82, 20);
            this.cmdShi.TabIndex = 11;
            this.cmdShi.SelectedIndexChanged += new System.EventHandler(this.cmdShi_SelectedIndexChanged);
            // 
            // cmbSheng
            // 
            this.cmbSheng.FormattingEnabled = true;
            this.cmbSheng.Location = new System.Drawing.Point(5, 33);
            this.cmbSheng.Name = "cmbSheng";
            this.cmbSheng.Size = new System.Drawing.Size(77, 20);
            this.cmbSheng.TabIndex = 11;
            this.cmbSheng.SelectedIndexChanged += new System.EventHandler(this.cmbSheng_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(176, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 19);
            this.label2.TabIndex = 9;
            this.label2.Text = "~";
            // 
            // txtSlipDateTo
            // 
            this.txtSlipDateTo.CalendarFont = new System.Drawing.Font("微软雅黑", 12F);
            this.txtSlipDateTo.Checked = false;
            this.txtSlipDateTo.CustomFormat = "yyyy/MM/dd HH:mm";
            this.txtSlipDateTo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtSlipDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtSlipDateTo.Location = new System.Drawing.Point(203, 5);
            this.txtSlipDateTo.Name = "txtSlipDateTo";
            this.txtSlipDateTo.ShowCheckBox = true;
            this.txtSlipDateTo.Size = new System.Drawing.Size(165, 23);
            this.txtSlipDateTo.TabIndex = 10;
            // 
            // txtSlipDateFrom
            // 
            this.txtSlipDateFrom.CalendarFont = new System.Drawing.Font("微软雅黑", 12F);
            this.txtSlipDateFrom.Checked = false;
            this.txtSlipDateFrom.CustomFormat = "yyyy/MM/dd HH:mm";
            this.txtSlipDateFrom.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtSlipDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtSlipDateFrom.Location = new System.Drawing.Point(5, 5);
            this.txtSlipDateFrom.Name = "txtSlipDateFrom";
            this.txtSlipDateFrom.ShowCheckBox = true;
            this.txtSlipDateFrom.Size = new System.Drawing.Size(165, 23);
            this.txtSlipDateFrom.TabIndex = 9;
            // 
            // pRight_1
            // 
            this.pRight_1.BackColor = System.Drawing.Color.SteelBlue;
            this.pRight_1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pRight_1.Location = new System.Drawing.Point(0, 0);
            this.pRight_1.Name = "pRight_1";
            this.pRight_1.Size = new System.Drawing.Size(120, 193);
            this.pRight_1.TabIndex = 3;
            // 
            // pRight
            // 
            this.pRight.BackColor = System.Drawing.Color.Transparent;
            this.pRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pRight.Controls.Add(this.pRight_2);
            this.pRight.Controls.Add(this.pRight_1);
            this.pRight.Location = new System.Drawing.Point(515, 3);
            this.pRight.Name = "pRight";
            this.pRight.Size = new System.Drawing.Size(500, 195);
            this.pRight.TabIndex = 7;
            // 
            // pRight_2
            // 
            this.pRight_2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pRight_2.Controls.Add(this.btnSearch);
            this.pRight_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pRight_2.Location = new System.Drawing.Point(120, 0);
            this.pRight_2.Name = "pRight_2";
            this.pRight_2.Size = new System.Drawing.Size(378, 193);
            this.pRight_2.TabIndex = 4;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnSearch.Location = new System.Drawing.Point(285, 151);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 30);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "查　询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnOutProduct
            // 
            this.btnOutProduct.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnOutProduct.Location = new System.Drawing.Point(829, 502);
            this.btnOutProduct.Name = "btnOutProduct";
            this.btnOutProduct.Size = new System.Drawing.Size(90, 30);
            this.btnOutProduct.TabIndex = 13;
            this.btnOutProduct.Text = "出货";
            this.btnOutProduct.UseVisualStyleBackColor = true;
            this.btnOutProduct.Click += new System.EventHandler(this.btnOutProduct_Click);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            this.dgvData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.COMMUNITY_CODE,
            this.ORDER_SN,
            this.USER_ID,
            this.CONSIGNEE,
            this.BEST_TIME,
            this.ADDRESS,
            this.ORDER_TYPE,
            this.ORDER_ID});
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.Location = new System.Drawing.Point(3, 203);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowHeadersWidth = 45;
            this.dgvData.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SkyBlue;
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(1012, 290);
            this.dgvData.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(5, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "  送货时间";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pInfo
            // 
            this.pInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pInfo.Controls.Add(this.pLeft);
            this.pInfo.Controls.Add(this.pRight);
            this.pInfo.Controls.Add(this.btnClose);
            this.pInfo.Controls.Add(this.BtnOutPrint);
            this.pInfo.Controls.Add(this.btnOutProduct);
            this.pInfo.Controls.Add(this.dgvData);
            this.pInfo.Location = new System.Drawing.Point(0, 0);
            this.pInfo.Name = "pInfo";
            this.pInfo.Size = new System.Drawing.Size(1020, 547);
            this.pInfo.TabIndex = 1;
            // 
            // pLeft
            // 
            this.pLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pLeft.Controls.Add(this.pleft_2);
            this.pLeft.Controls.Add(this.pLeft_1);
            this.pLeft.Location = new System.Drawing.Point(3, 3);
            this.pLeft.Name = "pLeft";
            this.pLeft.Size = new System.Drawing.Size(510, 196);
            this.pLeft.TabIndex = 8;
            // 
            // pLeft_1
            // 
            this.pLeft_1.BackColor = System.Drawing.Color.SteelBlue;
            this.pLeft_1.Controls.Add(this.label5);
            this.pLeft_1.Controls.Add(this.label7);
            this.pLeft_1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pLeft_1.Location = new System.Drawing.Point(0, 0);
            this.pLeft_1.Name = "pLeft_1";
            this.pLeft_1.Size = new System.Drawing.Size(120, 194);
            this.pLeft_1.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(5, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "  客户地址";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtnOutPrint
            // 
            this.BtnOutPrint.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.BtnOutPrint.Location = new System.Drawing.Point(733, 502);
            this.BtnOutPrint.Name = "BtnOutPrint";
            this.BtnOutPrint.Size = new System.Drawing.Size(90, 30);
            this.BtnOutPrint.TabIndex = 13;
            this.BtnOutPrint.Text = "出货单打印";
            this.BtnOutPrint.UseVisualStyleBackColor = true;
            this.BtnOutPrint.Click += new System.EventHandler(this.BtnOutPrint_Click);
            // 
            // COMMUNITY_CODE
            // 
            this.COMMUNITY_CODE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.COMMUNITY_CODE.DataPropertyName = "COMMUNITY_CODE";
            dataGridViewCellStyle2.NullValue = null;
            this.COMMUNITY_CODE.DefaultCellStyle = dataGridViewCellStyle2;
            this.COMMUNITY_CODE.Frozen = true;
            this.COMMUNITY_CODE.HeaderText = "No";
            this.COMMUNITY_CODE.Name = "COMMUNITY_CODE";
            this.COMMUNITY_CODE.ReadOnly = true;
            this.COMMUNITY_CODE.Width = 50;
            // 
            // ORDER_SN
            // 
            this.ORDER_SN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ORDER_SN.DataPropertyName = "ORDER_SN";
            this.ORDER_SN.HeaderText = "订单编号";
            this.ORDER_SN.Name = "ORDER_SN";
            this.ORDER_SN.ReadOnly = true;
            this.ORDER_SN.Width = 200;
            // 
            // USER_ID
            // 
            this.USER_ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.USER_ID.DataPropertyName = "USER_ID";
            this.USER_ID.HeaderText = "客户编号";
            this.USER_ID.Name = "USER_ID";
            this.USER_ID.ReadOnly = true;
            this.USER_ID.Width = 108;
            // 
            // CONSIGNEE
            // 
            this.CONSIGNEE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CONSIGNEE.DataPropertyName = "CONSIGNEE";
            this.CONSIGNEE.HeaderText = "客户名称";
            this.CONSIGNEE.Name = "CONSIGNEE";
            this.CONSIGNEE.ReadOnly = true;
            this.CONSIGNEE.Width = 200;
            // 
            // BEST_TIME
            // 
            this.BEST_TIME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.BEST_TIME.DataPropertyName = "BEST_TIME";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "yyyy-MM-dd";
            dataGridViewCellStyle3.NullValue = null;
            this.BEST_TIME.DefaultCellStyle = dataGridViewCellStyle3;
            this.BEST_TIME.HeaderText = "配送日期";
            this.BEST_TIME.Name = "BEST_TIME";
            this.BEST_TIME.ReadOnly = true;
            this.BEST_TIME.Width = 200;
            // 
            // ADDRESS
            // 
            this.ADDRESS.DataPropertyName = "ADDRESS";
            this.ADDRESS.HeaderText = "配送地址";
            this.ADDRESS.Name = "ADDRESS";
            this.ADDRESS.ReadOnly = true;
            // 
            // ORDER_TYPE
            // 
            this.ORDER_TYPE.DataPropertyName = "ORDER_TYPE";
            this.ORDER_TYPE.HeaderText = "ORDER_TYPE";
            this.ORDER_TYPE.Name = "ORDER_TYPE";
            this.ORDER_TYPE.ReadOnly = true;
            this.ORDER_TYPE.Visible = false;
            // 
            // ORDER_ID
            // 
            this.ORDER_ID.DataPropertyName = "ORDER_ID";
            this.ORDER_ID.HeaderText = "ORDER_ID";
            this.ORDER_ID.Name = "ORDER_ID";
            this.ORDER_ID.ReadOnly = true;
            this.ORDER_ID.Visible = false;
            // 
            // FrmShipmentEnder
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1026, 550);
            this.Controls.Add(this.pInfo);
            this.Name = "FrmShipmentEnder";
            this.Text = "送货确认";
            this.Load += new System.EventHandler(this.FrmShipmentEnder_Load);
            this.pleft_2.ResumeLayout(false);
            this.pleft_2.PerformLayout();
            this.pRight.ResumeLayout(false);
            this.pRight_2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.pInfo.ResumeLayout(false);
            this.pLeft.ResumeLayout(false);
            this.pLeft_1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pleft_2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker txtSlipDateTo;
        private System.Windows.Forms.DateTimePicker txtSlipDateFrom;
        private System.Windows.Forms.Panel pRight_1;
        private System.Windows.Forms.Panel pRight;
        private System.Windows.Forms.Panel pRight_2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnOutProduct;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pInfo;
        private System.Windows.Forms.Panel pLeft;
        private System.Windows.Forms.Panel pLeft_1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbJied;
        private System.Windows.Forms.ComboBox cmbQu;
        private System.Windows.Forms.ComboBox cmdShi;
        private System.Windows.Forms.ComboBox cmbSheng;
        private System.Windows.Forms.Button BtnOutPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn COMMUNITY_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn ORDER_SN;
        private System.Windows.Forms.DataGridViewTextBoxColumn USER_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CONSIGNEE;
        private System.Windows.Forms.DataGridViewTextBoxColumn BEST_TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn ADDRESS;
        private System.Windows.Forms.DataGridViewTextBoxColumn ORDER_TYPE;
        private System.Windows.Forms.DataGridViewTextBoxColumn ORDER_ID;


    }
}