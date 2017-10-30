using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CZZD.GSZX.S.IDAL
{
    public interface ICustomerAddress
    {
        bool Exists(decimal addressId);

        int Add(CZZD.GSZX.S.Model.BaseCustomerAddressTable model);

        bool Update(CZZD.GSZX.S.Model.BaseCustomerAddressTable model);
    }
}
