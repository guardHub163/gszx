namespace CZZD.ERP.WinUI
{
    partial class FrmLibrary
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLibrary));
            this.label2 = new System.Windows.Forms.Label();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.pTotal = new System.Windows.Forms.Panel();
            this.label21 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnOut = new System.Windows.Forms.Button();
            this.pleft = new System.Windows.Forms.Panel();
            this.txtdistrict = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.pLeftTitle = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtProvince = new System.Windows.Forms.TextBox();
            this.txtSlipNumber = new System.Windows.Forms.TextBox();
            this.txtCountry = new System.Windows.Forms.TextBox();
            this.txtCustomercode = new System.Windows.Forms.TextBox();
            this.txtpayType = new System.Windows.Forms.TextBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.txtShipp_status = new System.Windows.Forms.TextBox();
            this.txtSlipNumberType = new System.Windows.Forms.TextBox();
            this.pRight = new System.Windows.Forms.Panel();
            this.txtInvInfo = new System.Windows.Forms.TextBox();
            this.pRightTitle = new System.Windows.Forms.Panel();
            this.label28 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtInvHead = new System.Windows.Forms.TextBox();
            this.txtAdress = new System.Windows.Forms.TextBox();
            this.txtInvType = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtDemo = new System.Windows.Forms.TextBox();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.txtEndTime = new System.Windows.Forms.TextBox();
            this.pBody = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNeedTotal = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.txtChAAmonut = new System.Windows.Forms.TextBox();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.product_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.product_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NeedWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Need_Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Actual_wegiht = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Actual_Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GOODS_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.pTotal.SuspendLayout();
            this.pleft.SuspendLayout();
            this.pLeftTitle.SuspendLayout();
            this.pRight.SuspendLayout();
            this.pRightTitle.SuspendLayout();
            this.pBody.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.SteelBlue;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 263);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "　商品编码";
            // 
            // txtProductCode
            // 
            this.txtProductCode.BackColor = System.Drawing.SystemColors.Info;
            this.txtProductCode.Location = new System.Drawing.Point(127, 263);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(297, 24);
            this.txtProductCode.TabIndex = 2;
            this.txtProductCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProductCode_KeyDown);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToResizeRows = false;
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            this.dgvData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.product_code,
            this.product_name,
            this.price,
            this.NeedWeight,
            this.Need_Amount,
            this.Actual_wegiht,
            this.Actual_Amount,
            this.GOODS_ID});
            this.dgvData.Location = new System.Drawing.Point(3, 290);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowHeadersWidth = 25;
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(1018, 255);
            this.dgvData.TabIndex = 4;
            this.dgvData.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvData_RowStateChanged);
            // 
            // pTotal
            // 
            this.pTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pTotal.Controls.Add(this.label21);
            this.pTotal.Controls.Add(this.txtTotal);
            this.pTotal.Location = new System.Drawing.Point(519, 548);
            this.pTotal.Name = "pTotal";
            this.pTotal.Size = new System.Drawing.Size(248, 31);
            this.pTotal.TabIndex = 10;
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.SteelBlue;
            this.label21.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label21.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(0, -1);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(109, 30);
            this.label21.TabIndex = 0;
            this.label21.Text = "  实际总计金额";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.Color.Gainsboro;
            this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotal.Enabled = false;
            this.txtTotal.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtTotal.Location = new System.Drawing.Point(113, 2);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(130, 25);
            this.txtTotal.TabIndex = 0;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnClear
            // 
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnClear.Location = new System.Drawing.Point(931, 582);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(90, 30);
            this.btnClear.TabIndex = 13;
            this.btnClear.Text = "清空";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnOut
            // 
            this.btnOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOut.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnOut.Location = new System.Drawing.Point(837, 582);
            this.btnOut.Name = "btnOut";
            this.btnOut.Size = new System.Drawing.Size(90, 30);
            this.btnOut.TabIndex = 12;
            this.btnOut.Text = "拣货";
            this.btnOut.UseVisualStyleBackColor = true;
            this.btnOut.Click += new System.EventHandler(this.btnOut_Click);
            // 
            // pleft
            // 
            this.pleft.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pleft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pleft.Controls.Add(this.txtdistrict);
            this.pleft.Controls.Add(this.txtCity);
            this.pleft.Controls.Add(this.pLeftTitle);
            this.pleft.Controls.Add(this.txtProvince);
            this.pleft.Controls.Add(this.txtSlipNumber);
            this.pleft.Controls.Add(this.txtCountry);
            this.pleft.Controls.Add(this.txtCustomercode);
            this.pleft.Controls.Add(this.txtpayType);
            this.pleft.Controls.Add(this.txtCustomerName);
            this.pleft.Controls.Add(this.txtShipp_status);
            this.pleft.Controls.Add(this.txtSlipNumberType);
            this.pleft.Location = new System.Drawing.Point(3, 1);
            this.pleft.Margin = new System.Windows.Forms.Padding(0);
            this.pleft.Name = "pleft";
            this.pleft.Size = new System.Drawing.Size(505, 260);
            this.pleft.TabIndex = 2;
            // 
            // txtdistrict
            // 
            this.txtdistrict.BackColor = System.Drawing.Color.Gainsboro;
            this.txtdistrict.Enabled = false;
            this.txtdistrict.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.txtdistrict.Location = new System.Drawing.Point(123, 205);
            this.txtdistrict.Name = "txtdistrict";
            this.txtdistrict.Size = new System.Drawing.Size(297, 24);
            this.txtdistrict.TabIndex = 8;
            // 
            // txtCity
            // 
            this.txtCity.BackColor = System.Drawing.Color.Gainsboro;
            this.txtCity.Enabled = false;
            this.txtCity.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.txtCity.Location = new System.Drawing.Point(123, 180);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(297, 24);
            this.txtCity.TabIndex = 7;
            // 
            // pLeftTitle
            // 
            this.pLeftTitle.BackColor = System.Drawing.Color.SteelBlue;
            this.pLeftTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pLeftTitle.Controls.Add(this.label8);
            this.pLeftTitle.Controls.Add(this.label1);
            this.pLeftTitle.Controls.Add(this.label7);
            this.pLeftTitle.Controls.Add(this.label9);
            this.pLeftTitle.Controls.Add(this.label10);
            this.pLeftTitle.Controls.Add(this.label11);
            this.pLeftTitle.Controls.Add(this.label12);
            this.pLeftTitle.Controls.Add(this.label14);
            this.pLeftTitle.Controls.Add(this.label16);
            this.pLeftTitle.Controls.Add(this.label15);
            this.pLeftTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.pLeftTitle.Location = new System.Drawing.Point(0, 0);
            this.pLeftTitle.Margin = new System.Windows.Forms.Padding(0);
            this.pLeftTitle.Name = "pLeftTitle";
            this.pLeftTitle.Size = new System.Drawing.Size(120, 258);
            this.pLeftTitle.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(5, 130);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 20);
            this.label8.TabIndex = 7;
            this.label8.Text = "  支付状态";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(5, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "  订单编号";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(5, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 20);
            this.label7.TabIndex = 8;
            this.label7.Text = "  商品配送情况";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(5, 205);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(120, 20);
            this.label9.TabIndex = 10;
            this.label9.Text = "  地址(区域)";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(5, 180);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(120, 20);
            this.label10.TabIndex = 9;
            this.label10.Text = "  地址(城市)";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(5, 80);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(120, 20);
            this.label11.TabIndex = 2;
            this.label11.Text = "  订单状态";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(5, 155);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(120, 20);
            this.label12.TabIndex = 1;
            this.label12.Text = "  地址(省份)";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(5, 55);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(120, 20);
            this.label14.TabIndex = 3;
            this.label14.Text = "  客户名称";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label16.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(5, 30);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(120, 20);
            this.label16.TabIndex = 4;
            this.label16.Text = "  客户编号";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label15.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(5, 230);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(120, 20);
            this.label15.TabIndex = 5;
            this.label15.Text = "  地址(小区)";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtProvince
            // 
            this.txtProvince.BackColor = System.Drawing.Color.Gainsboro;
            this.txtProvince.Enabled = false;
            this.txtProvince.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.txtProvince.Location = new System.Drawing.Point(123, 155);
            this.txtProvince.Name = "txtProvince";
            this.txtProvince.Size = new System.Drawing.Size(297, 24);
            this.txtProvince.TabIndex = 9;
            // 
            // txtSlipNumber
            // 
            this.txtSlipNumber.BackColor = System.Drawing.SystemColors.Info;
            this.txtSlipNumber.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.txtSlipNumber.Location = new System.Drawing.Point(123, 5);
            this.txtSlipNumber.Name = "txtSlipNumber";
            this.txtSlipNumber.Size = new System.Drawing.Size(297, 24);
            this.txtSlipNumber.TabIndex = 1;
            this.txtSlipNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSlipNumber_KeyDown);
            // 
            // txtCountry
            // 
            this.txtCountry.BackColor = System.Drawing.Color.Gainsboro;
            this.txtCountry.Enabled = false;
            this.txtCountry.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.txtCountry.Location = new System.Drawing.Point(123, 230);
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(297, 24);
            this.txtCountry.TabIndex = 11;
            // 
            // txtCustomercode
            // 
            this.txtCustomercode.BackColor = System.Drawing.Color.Gainsboro;
            this.txtCustomercode.Enabled = false;
            this.txtCustomercode.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.txtCustomercode.Location = new System.Drawing.Point(123, 30);
            this.txtCustomercode.Name = "txtCustomercode";
            this.txtCustomercode.Size = new System.Drawing.Size(297, 24);
            this.txtCustomercode.TabIndex = 6;
            // 
            // txtpayType
            // 
            this.txtpayType.BackColor = System.Drawing.Color.Gainsboro;
            this.txtpayType.Enabled = false;
            this.txtpayType.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.txtpayType.Location = new System.Drawing.Point(123, 130);
            this.txtpayType.Name = "txtpayType";
            this.txtpayType.Size = new System.Drawing.Size(297, 24);
            this.txtpayType.TabIndex = 10;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtCustomerName.Enabled = false;
            this.txtCustomerName.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.txtCustomerName.Location = new System.Drawing.Point(123, 55);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(297, 24);
            this.txtCustomerName.TabIndex = 4;
            // 
            // txtShipp_status
            // 
            this.txtShipp_status.BackColor = System.Drawing.Color.Gainsboro;
            this.txtShipp_status.Enabled = false;
            this.txtShipp_status.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.txtShipp_status.Location = new System.Drawing.Point(123, 105);
            this.txtShipp_status.Name = "txtShipp_status";
            this.txtShipp_status.Size = new System.Drawing.Size(297, 24);
            this.txtShipp_status.TabIndex = 3;
            // 
            // txtSlipNumberType
            // 
            this.txtSlipNumberType.BackColor = System.Drawing.Color.Gainsboro;
            this.txtSlipNumberType.Enabled = false;
            this.txtSlipNumberType.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.txtSlipNumberType.Location = new System.Drawing.Point(123, 80);
            this.txtSlipNumberType.Name = "txtSlipNumberType";
            this.txtSlipNumberType.Size = new System.Drawing.Size(297, 24);
            this.txtSlipNumberType.TabIndex = 2;
            // 
            // pRight
            // 
            this.pRight.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pRight.Controls.Add(this.txtInvInfo);
            this.pRight.Controls.Add(this.pRightTitle);
            this.pRight.Controls.Add(this.txtInvHead);
            this.pRight.Controls.Add(this.txtAdress);
            this.pRight.Controls.Add(this.txtInvType);
            this.pRight.Controls.Add(this.txtPhone);
            this.pRight.Controls.Add(this.txtDemo);
            this.pRight.Controls.Add(this.txtTel);
            this.pRight.Controls.Add(this.txtEndTime);
            this.pRight.Location = new System.Drawing.Point(515, 1);
            this.pRight.Name = "pRight";
            this.pRight.Size = new System.Drawing.Size(505, 260);
            this.pRight.TabIndex = 2;
            // 
            // txtInvInfo
            // 
            this.txtInvInfo.BackColor = System.Drawing.Color.Gainsboro;
            this.txtInvInfo.Enabled = false;
            this.txtInvInfo.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.txtInvInfo.Location = new System.Drawing.Point(123, 203);
            this.txtInvInfo.Multiline = true;
            this.txtInvInfo.Name = "txtInvInfo";
            this.txtInvInfo.Size = new System.Drawing.Size(297, 47);
            this.txtInvInfo.TabIndex = 7;
            // 
            // pRightTitle
            // 
            this.pRightTitle.BackColor = System.Drawing.Color.SteelBlue;
            this.pRightTitle.Controls.Add(this.label28);
            this.pRightTitle.Controls.Add(this.label17);
            this.pRightTitle.Controls.Add(this.label27);
            this.pRightTitle.Controls.Add(this.label26);
            this.pRightTitle.Controls.Add(this.label25);
            this.pRightTitle.Controls.Add(this.label23);
            this.pRightTitle.Controls.Add(this.label22);
            this.pRightTitle.Controls.Add(this.label3);
            this.pRightTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.pRightTitle.Location = new System.Drawing.Point(0, 0);
            this.pRightTitle.Name = "pRightTitle";
            this.pRightTitle.Size = new System.Drawing.Size(120, 258);
            this.pRightTitle.TabIndex = 14;
            // 
            // label28
            // 
            this.label28.BackColor = System.Drawing.Color.Transparent;
            this.label28.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label28.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.label28.ForeColor = System.Drawing.Color.White;
            this.label28.Location = new System.Drawing.Point(3, 178);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(120, 20);
            this.label28.TabIndex = 6;
            this.label28.Text = "  发票抬头";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label17.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(3, 3);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(120, 20);
            this.label17.TabIndex = 5;
            this.label17.Text = "  详细地址";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label27
            // 
            this.label27.BackColor = System.Drawing.Color.Transparent;
            this.label27.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label27.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.label27.ForeColor = System.Drawing.Color.White;
            this.label27.Location = new System.Drawing.Point(3, 153);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(120, 20);
            this.label27.TabIndex = 8;
            this.label27.Text = "  发票类型";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label26
            // 
            this.label26.BackColor = System.Drawing.Color.Transparent;
            this.label26.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label26.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.label26.ForeColor = System.Drawing.Color.White;
            this.label26.Location = new System.Drawing.Point(3, 103);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(120, 20);
            this.label26.TabIndex = 7;
            this.label26.Text = "  订单附言";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label25
            // 
            this.label25.BackColor = System.Drawing.Color.Transparent;
            this.label25.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label25.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.label25.ForeColor = System.Drawing.Color.White;
            this.label25.Location = new System.Drawing.Point(3, 78);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(120, 20);
            this.label25.TabIndex = 2;
            this.label25.Text = "  收货时间";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label23
            // 
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label23.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(3, 53);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(120, 20);
            this.label23.TabIndex = 1;
            this.label23.Text = "  联系手机";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label22.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.label22.ForeColor = System.Drawing.Color.White;
            this.label22.Location = new System.Drawing.Point(3, 203);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(120, 20);
            this.label22.TabIndex = 4;
            this.label22.Text = "  发票内容";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "  联系电话";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtInvHead
            // 
            this.txtInvHead.BackColor = System.Drawing.Color.Gainsboro;
            this.txtInvHead.Enabled = false;
            this.txtInvHead.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.txtInvHead.Location = new System.Drawing.Point(123, 178);
            this.txtInvHead.Name = "txtInvHead";
            this.txtInvHead.Size = new System.Drawing.Size(297, 24);
            this.txtInvHead.TabIndex = 6;
            // 
            // txtAdress
            // 
            this.txtAdress.BackColor = System.Drawing.Color.Gainsboro;
            this.txtAdress.Enabled = false;
            this.txtAdress.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.txtAdress.Location = new System.Drawing.Point(123, 3);
            this.txtAdress.Name = "txtAdress";
            this.txtAdress.Size = new System.Drawing.Size(297, 24);
            this.txtAdress.TabIndex = 4;
            // 
            // txtInvType
            // 
            this.txtInvType.BackColor = System.Drawing.Color.Gainsboro;
            this.txtInvType.Enabled = false;
            this.txtInvType.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.txtInvType.Location = new System.Drawing.Point(123, 153);
            this.txtInvType.Name = "txtInvType";
            this.txtInvType.Size = new System.Drawing.Size(297, 24);
            this.txtInvType.TabIndex = 9;
            // 
            // txtPhone
            // 
            this.txtPhone.BackColor = System.Drawing.Color.Gainsboro;
            this.txtPhone.Enabled = false;
            this.txtPhone.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.txtPhone.Location = new System.Drawing.Point(123, 28);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(297, 24);
            this.txtPhone.TabIndex = 5;
            // 
            // txtDemo
            // 
            this.txtDemo.BackColor = System.Drawing.Color.Gainsboro;
            this.txtDemo.Enabled = false;
            this.txtDemo.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.txtDemo.Location = new System.Drawing.Point(123, 103);
            this.txtDemo.Multiline = true;
            this.txtDemo.Name = "txtDemo";
            this.txtDemo.Size = new System.Drawing.Size(297, 49);
            this.txtDemo.TabIndex = 8;
            // 
            // txtTel
            // 
            this.txtTel.BackColor = System.Drawing.Color.Gainsboro;
            this.txtTel.Enabled = false;
            this.txtTel.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.txtTel.Location = new System.Drawing.Point(123, 53);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(297, 24);
            this.txtTel.TabIndex = 2;
            // 
            // txtEndTime
            // 
            this.txtEndTime.BackColor = System.Drawing.Color.Gainsboro;
            this.txtEndTime.Enabled = false;
            this.txtEndTime.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.txtEndTime.Location = new System.Drawing.Point(123, 78);
            this.txtEndTime.Name = "txtEndTime";
            this.txtEndTime.Size = new System.Drawing.Size(297, 24);
            this.txtEndTime.TabIndex = 3;
            // 
            // pBody
            // 
            this.pBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBody.Controls.Add(this.pRight);
            this.pBody.Controls.Add(this.pleft);
            this.pBody.Controls.Add(this.panel1);
            this.pBody.Controls.Add(this.panel2);
            this.pBody.Controls.Add(this.pTotal);
            this.pBody.Controls.Add(this.btnClear);
            this.pBody.Controls.Add(this.txtProductCode);
            this.pBody.Controls.Add(this.btnOut);
            this.pBody.Controls.Add(this.dgvData);
            this.pBody.Controls.Add(this.label2);
            this.pBody.Location = new System.Drawing.Point(0, 0);
            this.pBody.Name = "pBody";
            this.pBody.Size = new System.Drawing.Size(1027, 620);
            this.pBody.TabIndex = 14;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtNeedTotal);
            this.panel1.Location = new System.Drawing.Point(266, 548);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(248, 31);
            this.panel1.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.SteelBlue;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, -1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 30);
            this.label4.TabIndex = 0;
            this.label4.Text = "  需求总计金额";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNeedTotal
            // 
            this.txtNeedTotal.BackColor = System.Drawing.Color.Gainsboro;
            this.txtNeedTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNeedTotal.Enabled = false;
            this.txtNeedTotal.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtNeedTotal.Location = new System.Drawing.Point(113, 2);
            this.txtNeedTotal.Name = "txtNeedTotal";
            this.txtNeedTotal.Size = new System.Drawing.Size(130, 25);
            this.txtNeedTotal.TabIndex = 0;
            this.txtNeedTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtChAAmonut);
            this.panel2.Location = new System.Drawing.Point(772, 548);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(248, 31);
            this.panel2.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.SteelBlue;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(0, -1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 30);
            this.label5.TabIndex = 0;
            this.label5.Text = "    差异金额";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtChAAmonut
            // 
            this.txtChAAmonut.BackColor = System.Drawing.Color.Gainsboro;
            this.txtChAAmonut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtChAAmonut.Enabled = false;
            this.txtChAAmonut.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtChAAmonut.Location = new System.Drawing.Point(113, 2);
            this.txtChAAmonut.Name = "txtChAAmonut";
            this.txtChAAmonut.Size = new System.Drawing.Size(130, 25);
            this.txtChAAmonut.TabIndex = 0;
            this.txtChAAmonut.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // No
            // 
            this.No.DataPropertyName = "No";
            this.No.HeaderText = "No";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            // 
            // product_code
            // 
            this.product_code.DataPropertyName = "product_code";
            this.product_code.HeaderText = "商品编号";
            this.product_code.Name = "product_code";
            this.product_code.ReadOnly = true;
            // 
            // product_name
            // 
            this.product_name.DataPropertyName = "product_name";
            this.product_name.HeaderText = "商品名称";
            this.product_name.Name = "product_name";
            this.product_name.ReadOnly = true;
            // 
            // price
            // 
            this.price.DataPropertyName = "price";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.price.DefaultCellStyle = dataGridViewCellStyle1;
            this.price.HeaderText = "单价";
            this.price.Name = "price";
            this.price.ReadOnly = true;
            // 
            // NeedWeight
            // 
            this.NeedWeight.DataPropertyName = "NeedWeight";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N3";
            dataGridViewCellStyle2.NullValue = null;
            this.NeedWeight.DefaultCellStyle = dataGridViewCellStyle2;
            this.NeedWeight.HeaderText = "需求重量";
            this.NeedWeight.Name = "NeedWeight";
            this.NeedWeight.ReadOnly = true;
            // 
            // Need_Amount
            // 
            this.Need_Amount.DataPropertyName = "Need_Amount";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.Need_Amount.DefaultCellStyle = dataGridViewCellStyle3;
            this.Need_Amount.HeaderText = "需求金额";
            this.Need_Amount.Name = "Need_Amount";
            this.Need_Amount.ReadOnly = true;
            // 
            // Actual_wegiht
            // 
            this.Actual_wegiht.DataPropertyName = "Actual_wegiht";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N3";
            this.Actual_wegiht.DefaultCellStyle = dataGridViewCellStyle4;
            this.Actual_wegiht.HeaderText = "实际重量";
            this.Actual_wegiht.Name = "Actual_wegiht";
            this.Actual_wegiht.ReadOnly = true;
            // 
            // Actual_Amount
            // 
            this.Actual_Amount.DataPropertyName = "Actual_Amount";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.Actual_Amount.DefaultCellStyle = dataGridViewCellStyle5;
            this.Actual_Amount.HeaderText = "实际金额";
            this.Actual_Amount.Name = "Actual_Amount";
            this.Actual_Amount.ReadOnly = true;
            // 
            // GOODS_ID
            // 
            this.GOODS_ID.DataPropertyName = "GOODS_ID";
            this.GOODS_ID.HeaderText = "GOODS_ID";
            this.GOODS_ID.Name = "GOODS_ID";
            this.GOODS_ID.ReadOnly = true;
            this.GOODS_ID.Visible = false;
            // 
            // FrmLibrary
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1028, 635);
            this.Controls.Add(this.pBody);
            this.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmLibrary";
            this.Text = "拣货确认";
            this.Load += new System.EventHandler(this.FrmLibrary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.pTotal.ResumeLayout(false);
            this.pTotal.PerformLayout();
            this.pleft.ResumeLayout(false);
            this.pleft.PerformLayout();
            this.pLeftTitle.ResumeLayout(false);
            this.pRight.ResumeLayout(false);
            this.pRight.PerformLayout();
            this.pRightTitle.ResumeLayout(false);
            this.pBody.ResumeLayout(false);
            this.pBody.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Panel pTotal;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnOut;
        private System.Windows.Forms.Panel pleft;
        private System.Windows.Forms.Panel pRight;
        private System.Windows.Forms.Panel pLeftTitle;
        private System.Windows.Forms.Panel pRightTitle;
        private System.Windows.Forms.Panel pBody;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtdistrict;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.TextBox txtProvince;
        private System.Windows.Forms.TextBox txtCountry;
        private System.Windows.Forms.TextBox txtpayType;
        private System.Windows.Forms.TextBox txtShipp_status;
        private System.Windows.Forms.TextBox txtSlipNumberType;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.TextBox txtCustomercode;
        private System.Windows.Forms.TextBox txtSlipNumber;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtInvInfo;
        private System.Windows.Forms.TextBox txtInvHead;
        private System.Windows.Forms.TextBox txtInvType;
        private System.Windows.Forms.TextBox txtDemo;
        private System.Windows.Forms.TextBox txtEndTime;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtAdress;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNeedTotal;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtChAAmonut;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn product_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn product_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn NeedWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn Need_Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Actual_wegiht;
        private System.Windows.Forms.DataGridViewTextBoxColumn Actual_Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn GOODS_ID;
    }
}