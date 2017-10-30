using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CZZD.GSZX.S.IDAL;
using CZZD.GSZX.S.DALFactory;
using CZZD.GSZX.S.Model;

namespace CZZD.GSZX.S.Bll
{
    public class BProductCategory
    {
        private IProductCategory dal = DataAccess.CreateProductCategoryManage();

        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int CAT_ID)
        {
            return dal.Exists(CAT_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BaseProductCategoryTable model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(BaseProductCategoryTable model)
        {
            return dal.Update(model);
        }

        #endregion  Method

    }//end class
}
