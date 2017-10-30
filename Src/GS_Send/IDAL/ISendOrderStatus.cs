using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CZZD.GSZX.S.IDAL
{
    public interface ISendOrderStatus
    {
        System.Data.DataSet GetDataList(string strWhere);

        bool Update(decimal orderId, int statusType);

        CZZD.GSZX.S.Model.BllSendOrderStatusTable GetModelByOrderId(decimal orderId);
    }//end class
}
