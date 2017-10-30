using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CZZD.GSZX.R.IDAL
{
    public interface IProductCategory
    {
        bool Exists(int CAT_ID);

        int Add(CZZD.GSZX.R.Model.BaseProductCategoryTable model);

        bool Update(CZZD.GSZX.R.Model.BaseProductCategoryTable model);
    }
}
