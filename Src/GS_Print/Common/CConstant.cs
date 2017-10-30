using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.GSZX.P.Common
{
    public class CConstant
    {
        #region 数据库数据状态
        //初始
        public static int INIT = 0;

        //正常
        public static int NORMAL = 1;

        //删除
        public static int DELETE = 9;
        #endregion

        //订单来源（本地）
        public static int  SLIPNUMBER_LOCAL_TYPE=0;

        //订单来源（网络）
        public static int  SLIPNUMBER_ONLINE_TYPE = 1;


        //发货状态
        public static int ShIPPING_ONE = 0;//未发货
        public static int ShIPPING_TWO =1;//已发货

        //订单状态
        public static int ORDER_STATUS_ENDER = 1;//已确认

        public static int ORDER_STATUS_DELETE= 2;//已取消

        //发票种类
        public static int INV_Z = 0;//增值税发票

        public static int INV_G = 1;//个人税发票

        //打印状态
        public static int PRINT_TYPE_ONE = 0;//未打印

        public static int PRINT_TYPE_TWO = 1;//打印过

         

    }//end class
}
