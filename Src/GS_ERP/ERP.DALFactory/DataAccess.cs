using System;
using System.Reflection;
using System.Configuration;
using CZZD.ERP.IDAL;

namespace CZZD.ERP.DALFactory
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
                classNamespace = "CZZD." + classNamespace;
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
            classNamespace = "CZZD." + classNamespace;
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
        #endregion


        /// <summary>
        /// 创建CommonManage数据层接口。
        /// </summary>
        public static CZZD.ERP.IDAL.ICommon CreateCommonManage()
        {
            string ClassNamespace = AssemblyPath + ".CommonManage";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (CZZD.ERP.IDAL.ICommon)objType;
        }



        /// <summary>
        /// 创建WarehouseManage数据层接口。
        /// </summary>
        public static CZZD.ERP.IDAL.IWarehouse CreateWarehouseManage()
        {
            string ClassNamespace = AssemblyPath + ".WarehouseManage";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (CZZD.ERP.IDAL.IWarehouse)objType;
        }

        /// <summary>
        /// 创建UserManage数据层接口。
        /// </summary>
        public static CZZD.ERP.IDAL.IUser CreateUserManage()
        {
            string ClassNamespace = AssemblyPath + ".UserManage";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (CZZD.ERP.IDAL.IUser)objType;
        }

        /// <summary>
        /// 创建UserManage数据层接口。
        /// </summary>
        public static CZZD.ERP.IDAL.IRoles CreateRolesManage()
        {
            string ClassNamespace = AssemblyPath + ".RolesManage";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (CZZD.ERP.IDAL.IRoles)objType;
        }

        /// <summary>
        /// 创建SysCommonManage数据层接口。
        /// </summary>
        public static CZZD.ERP.IDAL.ISysCommon CreateSysCommonManage()
        {
            string ClassNamespace = AssemblyPath + ".SysCommonManage";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (CZZD.ERP.IDAL.ISysCommon)objType;
        }

        /// <summary>
        /// 创建CompanyManage数据层接口。
        /// </summary>
        public static CZZD.ERP.IDAL.ICompany CreatCompanyManage()
        {
            string ClassNamespace = AssemblyPath + ".CompanyManage";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (CZZD.ERP.IDAL.ICompany)objType;
        }

        /// <summary>
        /// 创建DepartmentManage数据层接口。
        /// </summary>
        public static CZZD.ERP.IDAL.IDepartment CreatDepartmenManage()
        {
            string ClassNamespace = AssemblyPath + ".DepartmentManage";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (CZZD.ERP.IDAL.IDepartment)objType;
        }

        /// <summary>
        /// 创建LocatoinManage数据层接口。货位信息
        /// </summary>
        public static CZZD.ERP.IDAL.ILocation CreateLocationManage()
        {

            string ClassNamespace = AssemblyPath + ".LocationManage";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (CZZD.ERP.IDAL.ILocation)objType;
        }

        /// <summary>
        /// 创建ProductManage数据层接口。商品信息
        /// </summary>
        public static CZZD.ERP.IDAL.IProduct CreateProductManage()
        {

            string ClassNamespace = AssemblyPath + ".ProductManage";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (CZZD.ERP.IDAL.IProduct)objType;
        }

        /// <summary>
        /// 创建BaseHsCodeTable数据层接口。海关编码
        /// </summary>
        public static CZZD.ERP.IDAL.IHsCode CreateHsCodeManage()
        {

            string ClassNamespace = AssemblyPath + ".HsCodeManage";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (CZZD.ERP.IDAL.IHsCode)objType;
        }

        /// <summary>
        /// 创建BaseProductGroup数据层接口。商品分类信息
        /// </summary>
        public static CZZD.ERP.IDAL.IProductGroup CreateProductGroupManage()
        {

            string ClassNamespace = AssemblyPath + ".ProductGroupManage";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (CZZD.ERP.IDAL.IProductGroup)objType;
        }

        /// <summary>
        /// 创建BASE_CURRENCY数据层接口。货币基础信息
        /// </summary>
        public static CZZD.ERP.IDAL.ICurrency CreatCurrencyManage()
        {

            string ClassNamespace = AssemblyPath + ".CurrencyManage";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (CZZD.ERP.IDAL.ICurrency)objType;
        }

        /// <summary>
        /// 创建BASE_UNIT数据层接口。单位信息
        /// </summary>
        public static CZZD.ERP.IDAL.IUnit CreateUnitManage()
        {

            string ClassNamespace = AssemblyPath + ".UnitManage";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (CZZD.ERP.IDAL.IUnit)objType;
        }

        /// <summary>
        /// 创建TaxAtionManage数据层接口。税率信息
        /// </summary>
        public static CZZD.ERP.IDAL.ITaxAtion CreateTaxAtionManage()
        {

            string ClassNamespace = AssemblyPath + ".TaxAtionManage";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (CZZD.ERP.IDAL.ITaxAtion)objType;
        }

        /// <summary>
        /// 创建BASE_PRODUCT_UNIT数据层接口。产品单位信息
        /// </summary>
        public static CZZD.ERP.IDAL.IProductUnit CreateProductUnitManage()
        {

            string ClassNamespace = AssemblyPath + ".ProductUnitManage";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (CZZD.ERP.IDAL.IProductUnit)objType;
        }

        /// <summary>
        /// 创建BaseProductPartsTable数据层接口。材料构成信息
        /// </summary>
        public static CZZD.ERP.IDAL.IProductParts CreateProductPartsManage()
        {

            string ClassNamespace = AssemblyPath + ".ProductPartsManage";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (CZZD.ERP.IDAL.IProductParts)objType;
        }

        /// <summary>
        /// 创建SafetyStockManage数据层接口。安全在库信息
        /// </summary>
        public static CZZD.ERP.IDAL.ISafetyStock CreateSafetyStockManage()
        {

            string ClassNamespace = AssemblyPath + ".SafetyStockManage";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (CZZD.ERP.IDAL.ISafetyStock)objType;
        }

        /// <summary>
        /// 创建SupplierManage数据层接口。供应商信息
        /// </summary>
        public static CZZD.ERP.IDAL.ISupplier CreateSupplierManage()
        {

            string ClassNamespace = AssemblyPath + ".SupplierManage";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (CZZD.ERP.IDAL.ISupplier)objType;
        }

        /// <summary>
        /// 创建SupplierPriceManage数据层接口。供应商价格表
        /// </summary>
        public static CZZD.ERP.IDAL.ISupplierPrice CreateSupplierPriceManage()
        {

            string ClassNamespace = AssemblyPath + ".SupplierPriceManage";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (CZZD.ERP.IDAL.ISupplierPrice)objType;
        }

        /// <summary>
        /// 创建CustomerManage数据层接口。客户信息
        /// </summary>
        public static CZZD.ERP.IDAL.ICustomer CreateCustomerManage()
        {

            string ClassNamespace = AssemblyPath + ".CustomerManage";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (CZZD.ERP.IDAL.ICustomer)objType;
        }

        /// <summary>
        /// 创建CustomerPriceManage数据层接口。客户价格表
        /// </summary>
        public static CZZD.ERP.IDAL.ICustomerPrice CreateCustomerPriceManage()
        {

            string ClassNamespace = AssemblyPath + ".CustomerPriceManage";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (CZZD.ERP.IDAL.ICustomerPrice)objType;
        }

        /// <summary>
        /// 创建CustomerReportedManage数据层接口。客户报备信息
        /// </summary>
        public static CZZD.ERP.IDAL.ICustomerReported CreateCustomerReportedManage()
        {
            string ClassNamespace = AssemblyPath + ".CustomerReportedManage";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (CZZD.ERP.IDAL.ICustomerReported)objType;
        }



        /// <summary>
        /// 创建SlipTypeManage数据层接口。
        /// </summary>
        public static CZZD.ERP.IDAL.ISlipType CreateSlipTypeManage()
        {

            string ClassNamespace = AssemblyPath + ".SlipTypeManage";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (CZZD.ERP.IDAL.ISlipType)objType;
        }


      


        public static CZZD.ERP.IDAL.ISlipTypeCompositionProducts CreateSlipTypeCompositionProductsManage()
        {
            string ClassNamespace = AssemblyPath + ".SlipTypeCompositionProductsManage";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (CZZD.ERP.IDAL.ISlipTypeCompositionProducts)objType;
        }

        public static CZZD.ERP.IDAL.ICompositionProducts CreateCompositionProductsManage()
        {
            string ClassNamespace = AssemblyPath + ".CompositionProductsManage";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (CZZD.ERP.IDAL.ICompositionProducts)objType;
        }

        public static IProductionProcess CreateProductionProcessManage()
        {
            string ClassNamespace = AssemblyPath + ".ProductionProcessManage";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (CZZD.ERP.IDAL.IProductionProcess)objType;
        }


        public static ITechnology CreatTechnologyManage()
        {
            string ClassNamespace = AssemblyPath + ".TechnologyManage";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (CZZD.ERP.IDAL.ITechnology)objType;
        }

        public static IOrderInfo CreatOrderInfoManage()
        {
            string ClassNamespace = AssemblyPath + ".OrderInfoManage";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (CZZD.ERP.IDAL.IOrderInfo)objType;
        }

        public static IOrderGoods CreatOrdersGoodsManage()
        {
            string ClassNamespace = AssemblyPath + ".OrdersGoodsManage";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (CZZD.ERP.IDAL.IOrderGoods)objType;
        }

        public static IDelivery CreatDeliveryManage() 
        {
            string ClassNamespace = AssemblyPath + ".DeliveryManage";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (CZZD.ERP.IDAL.IDelivery)objType;
        }
    }
}