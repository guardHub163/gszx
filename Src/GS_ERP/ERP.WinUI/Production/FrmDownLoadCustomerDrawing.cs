using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Main;

namespace CZZD.ERP.WinUI
{
    public partial class FrmDownLoadCustomerDrawing : FrmBase
    {
        public FrmDownLoadCustomerDrawing()
        {
            InitializeComponent();
        }

        private void FrmDownLoadCustomerDrawing_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Tag = CTag;
        }
    }
}
