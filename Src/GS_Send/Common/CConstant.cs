using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace CZZD.GSZX.S.Common
{
    /// <summary>
    ///CConstant 的摘要说明
    /// </summary>
    public class CConstant
    {
        public CConstant() { }

        //初始，未处理
        public static int INIT = 0;

        //己经处理完成
        public static int NORMAL = 1;

        //删除
        public static int DELETE = 9;

        //db keys
        public static string DB_KEYS = "A8199740DEAA849B35C24983A04D38D5";

        //send keys
        public static string KEYS = "dx96321";

        //
        public static string E_COMMERCE_KEYS = "CZZDINFO_GSZX";

        //导入导出　成功
        public static string SUCCESS = "00";

        //导入导出　没有数据
        public static string NO_DATA = "01";

        //导入导出　失败
        public static string ERROR = "02";

        //导入导出  连接失败
        public static string CONN_ERROR = "03";

        //统计
        public static string TYPE_COUNT = "count";

        //数据集
        public static string TYPE_LIST = "list";

        //单条数据
        public static string TYPE_SINGLE = "single";

        //订单送信状态的回写
        public static string TYPE_ORDER_SEND_STATUS = "send_status";

        //订单送货确认状态的回写
        public static string TYPE_ORDER_DELIVERY = "order_delivery";

        //订单收货确认状态的回写
        public static string TYPE_ORDER_RECEIPT = "order_receipt";


        // '订单状态。0，未确认；1，已确认；2，已取消；3，无效；

        public static int ORDER_INIT = 0;

        public static int ORDER_NORMAL = 1;

        public static int ORDER_CANCEL = 2;

        public static int ORDER_DELETE = 3;

        // '商品配送情况，0，未发货；1，已发货；2，已收货；3，备货中'

        public static int ORDER_UNSHIPPED = 0;

        public static int ORDER_DELIVERY = 1;

        public static int ORDER_RECEIPT = 2;

        public static int ORDER_STOCKING = 3;

        //'支付状态；0，未付款；1，付款中；2，已付款'

        public static int ORDER_UNPAID = 0;

        public static int ORDER_PAYMENTS = 1;

        public static int ORDER_PAID = 2;

        /// <summary>
        /// 送信状态　0:未送信;　
        /// </summary>
        public static int ORDER_UNSEND = 0;

        /// <summary>
        /// 1:送信
        /// </summary>
        public static int ORDER_SEND = 1;

        //默认的系统操作员
        public static string DEFAULT_USER_CODE = "admin";

        //默认的网络订单来源
        public static int DEFAULT_ORDER_TYPE = 1;


        #region timer
        /// <summary>
        /// 订单信息
        /// </summary>
        public const string TIMER_ORDER_INFO = "order_info";
        /// <summary>
        /// 送货信息
        /// </summary>
        public const string TIMER_ORDER_DELIVERY = "order_delivery";
        /// <summary>
        /// 收货确认
        /// </summary>
        public const string TIMER_ORDER_RECEIPT = "order_receipt";
        #endregion

    }//end class
}
