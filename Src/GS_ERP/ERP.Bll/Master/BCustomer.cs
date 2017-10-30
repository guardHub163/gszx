using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL;
using CZZD.ERP.Model;
using System.Data;
using CZZD.ERP.Model;

namespace CZZD.ERP.Bll
{
    public class BCustomer
    {
         ICustomer dal = DALFactory.DataAccess.CreateCustomerManage();
         public BCustomer()
		{}

         /// <summary>
         /// 是否存在该记录
         /// </summary>
         public bool Exists(decimal USER_ID)
         {
             return dal.Exists(USER_ID);
         }

         /// <summary>
         /// 增加一条数据
         /// </summary>
         public void Add(BaseCustomerTable model)
         {
             dal.Add(model);
         }

         /// <summary>
         /// 更新一条数据
         /// </summary>
         public bool Update(BaseCustomerTable model)
         {
             return dal.Update(model);
         }

         /// <summary>
         /// 删除一条数据
         /// </summary>
         public bool Delete(decimal USER_ID)
         {

             return dal.Delete(USER_ID);
         }

         /// <summary>
         /// 得到一个对象实体
         /// </summary>
         public BaseCustomerTable GetModel(decimal USER_ID)
         {

             return dal.GetModel(USER_ID);
         }


        // <summary>
        // 获得数据列表
        // </summary>
        //public DataSet GetList(string strWhere)
        //{
        //    return dal.GetList(strWhere);
        //}

        /// <summary>
        /// 获得分页数据总的记录条数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }

        /// <summary>
        /// 获得分页数据列表
        /// </summary>
        public DataSet GetList(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetList(strWhere, orderby, startIndex, endIndex);
        }
		
    }
}
