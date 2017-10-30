using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CZZD.GSZX.R.IDAL
{
    public interface IOrderInfo
    {

        bool Exists(decimal orderId, int orderType);

        int Add(CZZD.GSZX.R.Model.BllOrderInfoTable model);

        bool Update(CZZD.GSZX.R.Model.BllOrderInfoTable model);
    }
}
