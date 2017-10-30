using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CZZD.GSZX.S.IDAL
{
    public interface ISendOrder
    {
        System.Data.DataSet GetSendOrderData(string strWhere);

        bool UpdateSendStatus(string orderID, int sendStatus);
    }
}
