using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CZZD.GSZX.S.IDAL
{
    public interface IProduct
    {

        bool Exists(int GOODS_ID);

        int Add(CZZD.GSZX.S.Model.BaseProductTable model);

        bool Update(CZZD.GSZX.S.Model.BaseProductTable model);
    }
}
