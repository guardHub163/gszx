using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.Model;
using CZZD.ERP.IDAL;
using System.Data;
using CZZD.ERP.DALFactory;

namespace CZZD.ERP.Bll
{
    public class BDelivery
    {
        private readonly IDelivery dal = DALFactory.DataAccess.CreatDeliveryManage();
        public BDelivery()
        { }
        public int Add(BaseDeliveryTable model)
        {
            return dal.Add(model);
        }

        public DataSet GetDeliveryTable(string strWhere) 
        {
            return dal.GetDeliveryTable(strWhere);
        }

        public bool Update(string SlipNumber,BaseSendOrderStatusTable sendTable) 
        {
            return dal.Update(SlipNumber,sendTable);
        }
    }
}
