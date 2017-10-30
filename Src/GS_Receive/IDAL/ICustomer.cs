using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CZZD.GSZX.R.IDAL
{
    public interface ICustomer
    {

        bool Exists(decimal USER_ID);

        int Add(CZZD.GSZX.R.Model.BaseCustomerTable model);

        bool Update(CZZD.GSZX.R.Model.BaseCustomerTable model);
    }
}
