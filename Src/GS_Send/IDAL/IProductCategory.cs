using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CZZD.GSZX.S.IDAL
{
    public interface IProductCategory
    {
        bool Exists(int CAT_ID);

        int Add(CZZD.GSZX.S.Model.BaseProductCategoryTable model);

        bool Update(CZZD.GSZX.S.Model.BaseProductCategoryTable model);
    }
}
