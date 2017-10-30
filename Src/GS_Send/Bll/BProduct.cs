using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CZZD.GSZX.S.IDAL;
using CZZD.GSZX.S.DALFactory;
using CZZD.GSZX.S.Model;

namespace CZZD.GSZX.S.Bll
{
    public class BProduct
    {
        private IProduct dal = DataAccess.CreateProductManage();

        public BProduct()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int GOODS_ID)
        {
            return dal.Exists(GOODS_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BaseProductTable model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(BaseProductTable model)
        {
            return dal.Update(model);
        }

        #endregion  Method

    }//end class
}
