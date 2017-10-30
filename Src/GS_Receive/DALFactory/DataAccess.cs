using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Configuration;
using CZZD.GSZX.R.IDAL;

namespace CZZD.GSZX.R.DALFactory
{
    public sealed class DataAccess
    {
        private static readonly string AssemblyPath = ConfigurationManager.AppSettings["AppDAL"];
        public DataAccess()
        { }

        #region　创建
        //不使用缓存
        private static object CreateObjectNoCache(string AssemblyPath, string classNamespace)
        {
            classNamespace = "CZZD.GSZX.R." + classNamespace;
            try
            {
                object objType = Assembly.Load(AssemblyPath).CreateInstance(classNamespace);
                return objType;
            }
            catch//(System.Exception ex)
            {
                //string str=ex.Message;// 记录错误日志
                return null;
            }

        }
        //使用缓存
        private static object CreateObject(string AssemblyPath, string classNamespace)
        {
            classNamespace = "CZZD.GSZX.R." + classNamespace;
            object objType = DataCache.GetCache(classNamespace);
            if (objType == null)
            {
                try
                {
                    objType = Assembly.Load(AssemblyPath).CreateInstance(classNamespace);
                    DataCache.SetCache(classNamespace, objType);// 写入缓存
                }
                catch (System.Exception ex)
                {
                    //string str=ex.Message;// 记录错误日志
                }
            }
            return objType;
        }
        #endregion

        #region CreateCommonManage　共通
        /// <summary>
        /// 共通
        /// </summary>
        public static ICommon CreateCommonManage()
        {
            string classNamespace = AssemblyPath + ".CommonManage";
            object objType = CreateObject(AssemblyPath, classNamespace);
            return (ICommon)objType;
        }
        #endregion

        #region CreateProductCategoryManage　商品分类
        /// <summary>
        /// 商品分类
        /// </summary>
        public static IProductCategory CreateProductCategoryManage()
        {
            string classNamespace = AssemblyPath + ".ProductCategoryManage";
            object objType = CreateObject(AssemblyPath, classNamespace);
            return (IProductCategory)objType;
        }
        #endregion

        #region CreateProductManage　商品
        /// <summary>
        /// 商品
        /// </summary>
        public static IProduct CreateProductManage()
        {
            string classNamespace = AssemblyPath + ".ProductManage";
            object objType = CreateObject(AssemblyPath, classNamespace);
            return (IProduct)objType;
        }
        #endregion

        #region CreateProductManage　客户
        /// <summary>
        /// 客户
        /// </summary>
        public static ICustomer CreateCustomerManage()
        {
            string classNamespace = AssemblyPath + ".CustomerManage";
            object objType = CreateObject(AssemblyPath, classNamespace);
            return (ICustomer)objType;
        }
        #endregion

        #region CreateProductManage　客户地址
        /// <summary>
        /// 客户地址
        /// </summary>
        public static ICustomerAddress CreateCustomerAddressManage()
        {
            string classNamespace = AssemblyPath + ".CustomerAddressManage";
            object objType = CreateObject(AssemblyPath, classNamespace);
            return (ICustomerAddress)objType;
        }
        #endregion

        #region CreateOrderInfoManage 销售订单
        /// <summary>
        /// 销售订单
        /// </summary>
        public static IOrderInfo CreateOrderInfoManage()
        {
            string classNamespace = AssemblyPath + ".OrderInfoManage";
            object objType = CreateObject(AssemblyPath, classNamespace);
            return (IOrderInfo)objType;
        }
        #endregion
    }//end class
}
