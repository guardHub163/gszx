using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CZZD.GSZX.R.IDAL
{
    public interface IProduct
    {

        bool Exists(int GOODS_ID);

        int Add(CZZD.GSZX.R.Model.BaseProductTable model);

        bool Update(CZZD.GSZX.R.Model.BaseProductTable model);
    }
}
