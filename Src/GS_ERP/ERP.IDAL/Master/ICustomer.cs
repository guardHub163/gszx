using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.Model;

namespace CZZD.ERP.IDAL
{
    public interface ICustomer
    {

        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(decimal USER_ID);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        void Add(BaseCustomerTable model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(BaseCustomerTable model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(decimal USER_ID);        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        BaseCustomerTable GetModel(decimal USER_ID);
        #endregion  成员方法

       // System.Data.DataSet GetList(string strWhere);

        int GetRecordCount(string strWhere);

        System.Data.DataSet GetList(string strWhere, string orderby, int startIndex, int endIndex);
    }
}
