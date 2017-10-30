using System;
using System.Collections.Generic;
using System.Text;
using CZZD.GSZX.P.Model;
using System.Data;

namespace CZZD.GSZX.P.IDAL
{
    public interface IOrderGoods
    {
        DataSet GetGoodsInfo(int ORDER_TYPE, decimal ORDER_ID);
    }
}
