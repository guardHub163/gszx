using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CZZD.GSZX.S.IDAL
{
    public interface IOrderInfo
    {

        bool Exists(decimal orderId, int orderType);

        int Add(CZZD.GSZX.S.Model.BllOrderInfoTable model);

        bool Update(CZZD.GSZX.S.Model.BllOrderInfoTable model);
    }
}
