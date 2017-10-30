using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.Model;
using System.Data.SqlClient;
using CZZD.ERP.IDAL;
using System.Data;

namespace CZZD.ERP.IDAL
{
    public interface IDelivery
    {
        int Add(BaseDeliveryTable model);
        DataSet GetDeliveryTable(string strWhere);

        bool Update(string SlipNumber, BaseSendOrderStatusTable sendTable);
    }
}
