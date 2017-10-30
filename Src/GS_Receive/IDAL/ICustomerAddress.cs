using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CZZD.GSZX.R.IDAL
{
    public interface ICustomerAddress
    {
        bool Exists(decimal addressId);

        int Add(CZZD.GSZX.R.Model.BaseCustomerAddressTable model);

        bool Update(CZZD.GSZX.R.Model.BaseCustomerAddressTable model);
    }
}
