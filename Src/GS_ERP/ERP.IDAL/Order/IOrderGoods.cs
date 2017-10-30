using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.Model;
using System.Data;

namespace CZZD.ERP.IDAL
{
    public interface IOrderGoods
    {
        BaseOrdersGoodsTable GetModel(int ORDER_TYPE, decimal ORDER_ID);

        DataSet GetGoodsInfo(int ORDER_TYPE, decimal ORDER_ID);
    }
}
