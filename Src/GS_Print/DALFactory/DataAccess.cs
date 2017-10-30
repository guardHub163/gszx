using System;
using System.Reflection;
using System.Configuration;
using CZZD.GSZX.P.IDAL;

namespace CZZD.GSZX.P.DALFactory
{

    public sealed class DataAccess
    {
        private static readonly string AssemblyPath = ConfigurationManager.AppSettings["AppDAL"];
        public DataAccess()
        { }

        #region CreateObject

        //不使用缓存
        private static object CreateObjectNoCache(string AssemblyPath, string classNamespace)
        {
            try
            {
                classNamespace = "CZZD.GSZX.P." + classNamespace;
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
            classNamespace = "CZZD.GSZX.P." + classNamespace;
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

        #region 泛型生成
        ///// <summary>
        ///// 创建数据层接口。
        ///// </summary>
        //public static t Create(string ClassName)
        //{

        //    string ClassNamespace = AssemblyPath + "." + ClassName;
        //    object objType = CreateObject(AssemblyPath, ClassNamespace);
        //    return (t)objType;
        //}

        public static IOrderInfo CreatOrderInfoManage()
        {
            string ClassNamespace = AssemblyPath + ".OrderInfoManage";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IOrderInfo)objType;
        }

        public static IOrderGoods CreatOrdersGoodsManage()
        {
            string ClassNamespace = AssemblyPath + ".OrdersGoodsManage";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IOrderGoods)objType;
        }
        #endregion

    }
}