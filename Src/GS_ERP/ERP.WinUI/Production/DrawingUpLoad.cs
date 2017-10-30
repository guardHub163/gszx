using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Bll.Product;
using CZZD.ERP.Common;
using CZZD.ERP.Model.Product;
using System.IO;
using CZZD.ERP.CacheData;

namespace CZZD.ERP.WinUI.Production
{
    public partial class DrawingUpLoad : Form
    {
        private string _slipnumber;

        public string SLIPNUMBER
        {
            set { _slipnumber = value; }
            get { return _slipnumber; }
        }
        public DrawingUpLoad()
        {
            InitializeComponent();
        }
        private DataTable _currentDt = new DataTable();
        BProductionDrawing bProductionDrawing = new BProductionDrawing();
        BaseProductionDrawingTable productionDrawing = new BaseProductionDrawingTable();
        OpenFileDialog openFileDialog = new OpenFileDialog();
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "文本文件|*.*|C#文件|*.cs|所有文件|*.*";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFileName.Text = openFileDialog.FileName;
            }
        }

        private void DrawingUpLoad_Load(object sender, EventArgs e)
        {
            string _tmpAttachedDirectoryName = SLIPNUMBER;
            string _attachedDirectory = CCacheData.GetAttacheDirectory(CConstant.ATTACHE_DIRECTORY_PRODUCTION);
            this.dgvData.AutoGenerateColumns = false;
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            DataSet ds = bProductionDrawing.GetProductionDrawing(" PSDL_SLIP_NUMBER = '" + SLIPNUMBER + "'");
            clbDrawing.DataSource = ds.Tables[0];
            clbDrawing.ValueMember = "PSDL_DRAWING_CODE";
            clbDrawing.DisplayMember = "NAME";
            DataSet dsUpload = bProductionDrawing.GetProductionDrawingUpload(" SLIP_NUMBER = '" + SLIPNUMBER + "'");
            dgvData.DataSource = dsUpload.Tables[0];


           
            //    for (int i = 0; i < this.clbDrawing.Items.Count; i++)
            //    {
            //        foreach (DataGridViewRow dr in dgvData.Rows)
            //        {
            //        if (dr.Cells["DRAWINGCODE"].Value.ToString() == clbDrawing.SelectedValue.ToString())
            //        {
            //            clbDrawing.SetItemCheckState(i, CheckState.Indeterminate);
            //        }
                
            //    }
            //}


            _currentDt.Columns.Add("NAME", Type.GetType("System.String"));

            try
            {
                if (Directory.Exists(_attachedDirectory + _tmpAttachedDirectoryName + "\\"))
                {
                    DirectoryInfo di = new DirectoryInfo(_attachedDirectory + _tmpAttachedDirectoryName + "\\");
                    FileInfo[] files = di.GetFiles();

                    foreach (FileInfo file in files)
                    {
                        AddAttached(file);
                    }
                }
            }
            catch (IOException ex)
            {

            }

        }

        private void btnUpLoad_Click(object sender, EventArgs e)
        {
            string _tmpAttachedDirectoryName = SLIPNUMBER;
            string _attachedDirectory = CCacheData.GetAttacheDirectory(CConstant.ATTACHE_DIRECTORY_PRODUCTION);
        
            if (txtFileName.Text.Trim() == "")
            {
                MessageBox.Show("文件名不能为空！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                if (!Directory.Exists(_attachedDirectory + _tmpAttachedDirectoryName + "\\"))
                {
                    Directory.CreateDirectory(_attachedDirectory + _tmpAttachedDirectoryName + "\\");
                }
                foreach (DataRow dr in _currentDt.Rows)
                {
                    if (openFileDialog.SafeFileName.Equals(dr["NAME"]))
                    {
                        MessageBox.Show("文件己经存在，请确认！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                AddAttached(new FileInfo(openFileDialog.FileName));



                File.Copy(openFileDialog.FileName, _attachedDirectory + _tmpAttachedDirectoryName + "\\" + openFileDialog.SafeFileName);
            }

            catch (IOException ex) { }
            int result = 0;
            for (int i = 0; i < this.clbDrawing.Items.Count; i++)
            {
                BaseProductionDrawingTable productionDrawing1 = new BaseProductionDrawingTable();
                if (clbDrawing.GetItemChecked(i))
                {
                    productionDrawing1.SLIPNUMBER = SLIPNUMBER;
                    productionDrawing1.FILENAME = txtFileName.Text.Trim();
                    clbDrawing.SelectedIndex = i;
                    productionDrawing1.DRAWINGCODE = clbDrawing.SelectedValue.ToString();
                    productionDrawing.AddItem(productionDrawing1);
                }
            }
            result = bProductionDrawing.Add(productionDrawing);
            if (result < 1)
            {
                MessageBox.Show("上传失败！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                MessageBox.Show("上传成功！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
          
        }

        /// <summary>
        /// 附件增加
        /// </summary>
        private void AddAttached(FileInfo file)
        {
            DataRow dr = _currentDt.NewRow();
            dr["NAME"] = file.Name;
            _currentDt.Rows.Add(dr);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

            DataGridView dgv = (DataGridView)(sender);
            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex == 0)
                {
                    DataGridViewRow row = dgv.Rows[e.RowIndex];
                    //
                    row.Cells["No"].Value = e.RowIndex + 1;
                }

            }
        }


    }
}
