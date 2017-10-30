using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.IDAL
{
    public interface IProduct
    {
    //    bool Exists(string CODE);

    //    bool Add(CZZD.ERP.Model.BaseProductTable model);

    //    bool Update(CZZD.ERP.Model.BaseProductTable model);

    //    bool Delete(string CODE);

    //    CZZD.ERP.Model.BaseProductTable GetModel(string CODE);

    //    System.Data.DataSet GetList(string strWhere);

    //    int GetRecordCount(string strWhere);

    //    System.Data.DataSet GetList(string strWhere, string orderby, int startIndex, int endIndex);

        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int GOODS_ID);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(CZZD.ERP.Model.BaseProductTable model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(CZZD.ERP.Model.BaseProductTable model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(int GOODS_ID);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        CZZD.ERP.Model.BaseProductTable GetModel(int GOODS_ID);
        #endregion  成员方法

    }
}
