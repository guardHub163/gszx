using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CZZD.GSZX.S.IDAL
{
    public interface ICustomer
    {

        bool Exists(decimal USER_ID);

        int Add(CZZD.GSZX.S.Model.BaseCustomerTable model);

        bool Update(CZZD.GSZX.S.Model.BaseCustomerTable model);
    }
}
