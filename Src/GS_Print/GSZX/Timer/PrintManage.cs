using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CZZD.GSZX.P.BLL;
using CZZD.GSZX.P.Model;
using CZZD.GSZX.P.Common;
using System.Threading;
using log4net.Core;
using System.Data;


namespace CZZD.GSZX.P.UI
{
    public class PrintManage
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger("打印服务");
        BOrderInfo border = new BOrderInfo();
        BOrderGoods borderGoods = new BOrderGoods();
        FastReport.Report report = new FastReport.Report();
        FastReport.Preview.PreviewControl previewControl1 = new FastReport.Preview.PreviewControl();
        [STAThreadAttribute]
        public void UpdateOrderInfo()
        {
            DataSet orderSlipDs = border.GetNoPrintSlipNumber();//获得未打印的订单
            DataTable orderDt = orderSlipDs.Tables[0];
            for (int i = 0; i < orderDt.Rows.Count; i++)
            {
                string message = "";
                DataSet goodsDs = borderGoods.GetGoodsInfo(CConvert.ToInt32(orderDt.Rows[i]["ORDER_TYPE"].ToString()), CConvert.ToDecimal(orderDt.Rows[i]["ORDER_ID"].ToString()));
                DataTable goodsdt = goodsDs.Tables[0];
                try
                {
                    Report(goodsdt, orderDt.Rows[i]);
                    message = "订单" + orderDt.Rows[i]["ORDER_SN"] + "打印成功。";
                    Logger.Error(message);

                }
                catch
                {
                    message = "订单" + orderDt.Rows[i]["ORDER_SN"] + "打印失败。";
                    Logger.Error(message);

                }

            }
        }


        private void Report(DataTable table, DataRow row)
        {
            string fileName = "";
            DataSet ds = new DataSet();
            fileName = @"Reports\print.frx";
            DataTable dt = table.Copy();
            dt.TableName = "ds";
            ds.Tables.Add(dt);
            report.Preview = previewControl1;
            report.Load(fileName);
            report.SetParameterValue("slipNumber", row["ORDER_SN"].ToString());
            report.SetParameterValue("customerName", row["CONSIGNEE"].ToString());
            report.SetParameterValue("customerAdress", row["ADDRESS"].ToString());
            report.SetParameterValue("datatime", row["BEST_TIME"].ToString());
            string Tma = row["ORDER_TYPE"].ToString() + row["ORDER_SN"].ToString();
            //((FastReport.PictureObject)report.FindObject("Barcode1")). = bmp1;
            report.SetParameterValue("barCode", Tma);
            report.RegisterData(ds);
            report.Prepare();
            report.ShowPrepared();
            //report.PrintSettings.ShowDialog = false;
            //report.Print();
            report.Export(new FastReport.Export.Pdf.PDFExport(), @"d:\" + row["ORDER_TYPE"].ToString() + row["ORDER_SN"].ToString() + ".pdf");
            int result = border.UpdatePrintStatus(CConvert.ToInt32(row["ORDER_TYPE"].ToString()), row["ORDER_SN"].ToString());
            if (result > 0)
            {
                // MessageBox.Show("打印成功", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

    }
}
