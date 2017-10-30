using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CZZD.GSZX.S.Bll;
using CZZD.GSZX.S.Common;
using CZZD.GSZX.S.Model;

namespace CZZD.GSZX.S.UI
{
    public class MasterDataReceiving
    {

        public MasterDataReceiving() { }


        /// <summary>
        /// 基础数据的更新
        /// </summary>
        public DataTable InsertMasterData(string tableName, DataSet ds)
        {
            tableName = tableName.ToLower();
            DataTable dt = new DataTable();
            dt.Columns.Add("code", Type.GetType("System.String"));
            dt.Columns.Add("status", Type.GetType("System.String"));
            dt.Columns.Add("errorMessage", Type.GetType("System.String"));
            switch (tableName)
            {
                case "ecs_category": //商品分类
                    InsertProductCategory(ds, dt);
                    break;
                case "ecs_goods":    //商品
                    InsertProduct(ds, dt);
                    break;
                case "ecs_users":    //用户
                    InsertCustomer(ds, dt);
                    break;
                case "ecs_user_address":　//用户地址
                    InsertCustomerAddress(ds, dt);
                    break;
                default:
                    break;
            }
            return dt;
        }

        #region 商品分类表的更新
        /// <summary>
        /// 商品分类表的更新
        /// </summary>
        private void InsertProductCategory(DataSet ds, DataTable dt)
        {
            BProductCategory bll = new BProductCategory();
            BaseProductCategoryTable productCategoryTable = null;
            bool b = false;
            string errorMessage = "";
            DataRow row = null;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                productCategoryTable = new BaseProductCategoryTable();
                GetProductCategoryTable(productCategoryTable, dr);
                b = false;
                errorMessage = "";
                row = dt.NewRow();
                row["code"] = productCategoryTable.CAT_ID;
                try
                {
                    if (bll.Exists(productCategoryTable.CAT_ID))
                    {
                        b = bll.Update(productCategoryTable);
                    }
                    else
                    {
                        if (bll.Add(productCategoryTable) > 0)
                        {
                            b = true;
                        }
                        else
                        {
                            b = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    b = false;
                    errorMessage = ex.Message;
                }

                if (b)
                {
                    row["status"] = CConstant.SUCCESS;
                }
                else
                {
                    row["status"] = CConstant.ERROR;
                }
                row["errorMessage"] = errorMessage;
                dt.Rows.Add(row);
            }
        }

        /// <summary>
        /// 商品分类表信息的组装
        /// </summary>
        private void GetProductCategoryTable(BaseProductCategoryTable productCategoryTable, DataRow dr)
        {
            productCategoryTable.CAT_ID = CConvert.ToInt32(dr["cat_id"]);
            productCategoryTable.CAT_NAME = CConvert.ToString(dr["cat_name"]);
            productCategoryTable.KEYWORDS = CConvert.ToString(dr["keywords"]);
            productCategoryTable.CAT_DESC = CConvert.ToString(dr["cat_desc"]);
            productCategoryTable.PARENT_ID = CConvert.ToInt32(dr["parent_id"]);
            productCategoryTable.SORT_ORDER = CConvert.ToInt32(dr["sort_order"]);
            productCategoryTable.TEMPLATE_FILE = CConvert.ToString(dr["template_file"]);
            productCategoryTable.MEASURE_UNIT = CConvert.ToString(dr["measure_unit"]);
            productCategoryTable.SHOW_IN_NAV = CConvert.ToInt32(dr["show_in_nav"]);
            productCategoryTable.STYLE = CConvert.ToString(dr["style"]);
            productCategoryTable.IS_SHOW = CConvert.ToInt32(dr["is_show"]);
            productCategoryTable.GRADE = CConvert.ToInt32(dr["grade"]);
            productCategoryTable.FILTER_ATTR = CConvert.ToInt32(dr["filter_attr"]);
        }
        #endregion

        #region 商品信息更新
        /// <summary>
        /// 商品
        /// </summary>
        private void InsertProduct(DataSet ds, DataTable dt)
        {
            BProduct bll = new BProduct();
            BaseProductTable productTable = null;
            bool b = false;
            string errorMessage = "";
            DataRow row = null;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                productTable = new BaseProductTable();

                GetProductTable(productTable, dr);

                b = false;
                errorMessage = "";
                row = dt.NewRow();
                row["code"] = productTable.GOODS_ID;
                try
                {
                    if (bll.Exists(productTable.GOODS_ID))
                    {
                        b = bll.Update(productTable);
                    }
                    else
                    {
                        if (bll.Add(productTable) > 0)
                        {
                            b = true;
                        }
                        else
                        {
                            b = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    b = false;
                    errorMessage = ex.Message;
                }

                if (b)
                {
                    row["status"] = CConstant.SUCCESS;
                }
                else
                {
                    row["status"] = CConstant.ERROR;
                }
                row["errorMessage"] = errorMessage;
                dt.Rows.Add(row);
            }
        }

        /// <summary>
        /// 商品表信息的组装
        /// </summary>
        private void GetProductTable(BaseProductTable productTable, DataRow dr)
        {
            productTable.GOODS_ID = CConvert.ToInt32(dr["goods_id"]);
            productTable.CAT_ID = CConvert.ToInt32(dr["cat_id"]);
            productTable.GOODS_SN = CConvert.ToString(dr["goods_sn"]);
            productTable.GOODS_NAME = CConvert.ToString(dr["goods_name"]);
            productTable.GOODS_NAME_STYLE = CConvert.ToString(dr["goods_name_style"]);
            productTable.CLICK_COUNT = CConvert.ToInt32(dr["click_count"]);
            productTable.BRAND_ID = CConvert.ToInt32(dr["brand_id"]);
            productTable.PROVIDER_NAME = CConvert.ToString(dr["provider_name"]);
            productTable.GOODS_NUMBER = CConvert.ToInt32(dr["goods_number"]);
            productTable.GOODS_WEIGHT = CConvert.ToDecimal(dr["goods_weight"]);
            productTable.MARKET_PRICE = CConvert.ToDecimal(dr["market_price"]);
            productTable.SHOP_PRICE = CConvert.ToDecimal(dr["shop_price"]);
            productTable.PROMOTE_PRICE = CConvert.ToDecimal(dr["promote_price"]);
            productTable.PROMOTE_START_DATE = CConvert.ToInt32(dr["promote_start_date"]);
            productTable.PROMOTE_END_DATE = CConvert.ToInt32(dr["promote_end_date"]);
            productTable.WARN_NUMBER = CConvert.ToInt32(dr["warn_number"]);
            productTable.KEYWORDS = CConvert.ToString(dr["keywords"]);
            productTable.GOODS_BRIEF = CConvert.ToString(dr["goods_brief"]);
            productTable.GOODS_DESC = CConvert.ToString(dr["goods_desc"]);
            productTable.GOODS_THUMB = CConvert.ToString(dr["goods_thumb"]);
            productTable.GOODS_IMG = CConvert.ToString(dr["goods_img"]);
            productTable.ORIGINAL_IMG = CConvert.ToString(dr["original_img"]);
            productTable.IS_REAL = CConvert.ToInt32(dr["is_real"]);
            productTable.EXTENSION_CODE = CConvert.ToString(dr["extension_code"]);
            productTable.IS_ON_SALE = CConvert.ToInt32(dr["is_on_sale"]);
            productTable.IS_ALONE_SALE = CConvert.ToInt32(dr["is_alone_sale"]);
            productTable.INTEGRAL = CConvert.ToInt32(dr["integral"]);
            productTable.ADD_TIME = CConvert.ToInt32(dr["add_time"]);
            productTable.SORT_ORDER = CConvert.ToInt32(dr["sort_order"]);
            productTable.IS_BEST = CConvert.ToInt32(dr["is_delete"]);
            productTable.IS_DELETE = CConvert.ToInt32(dr["is_best"]);
            productTable.IS_NEW = CConvert.ToInt32(dr["is_new"]);
            productTable.IS_HOT = CConvert.ToInt32(dr["is_hot"]);
            productTable.IS_PROMOTE = CConvert.ToInt32(dr["is_promote"]);
            productTable.BONUS_TYPE_ID = CConvert.ToInt32(dr["bonus_type_id"]);
            productTable.LAST_UPDATE = CConvert.ToInt32(dr["last_update"]);
            productTable.GOODS_TYPE = CConvert.ToInt32(dr["goods_type"]);
            productTable.SELLER_NOTE = CConvert.ToString(dr["seller_note"]);
            productTable.GIVE_INTEGRAL = CConvert.ToInt32(dr["give_integral"]);
        }
        #endregion

        #region 会员（一些会员信息）
        /// <summary>
        /// 会员（一些会员信息）
        /// </summary>
        private void InsertCustomer(DataSet ds, DataTable dt)
        {
            BCustomer bll = new BCustomer();
            BaseCustomerTable customerTable = null;
            bool b = false;
            string errorMessage = "";
            DataRow row = null;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                customerTable = new BaseCustomerTable();
                GetCustomerTable(customerTable, dr);
                b = false;
                errorMessage = "";
                row = dt.NewRow();
                row["code"] = customerTable.USER_ID;
                try
                {
                    if (bll.Exists(customerTable.USER_ID))
                    {
                        b = bll.Update(customerTable);
                    }
                    else
                    {
                        if (bll.Add(customerTable) > 0)
                        {
                            b = true;
                        }
                        else
                        {
                            b = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    b = false;
                    errorMessage = ex.Message;
                }

                if (b)
                {
                    row["status"] = CConstant.SUCCESS;
                }
                else
                {
                    row["status"] = CConstant.ERROR;
                }
                row["errorMessage"] = errorMessage;
                dt.Rows.Add(row);
            }
        }

        /// <summary>
        /// 会员基本信息表的组装
        /// </summary>
        private void GetCustomerTable(BaseCustomerTable customerTable, DataRow dr) 
        {
            customerTable.USER_ID = CConvert.ToDecimal(dr["user_id"]);
            customerTable.EMAIL = CConvert.ToString(dr["email"]);
            customerTable.USER_NAME = CConvert.ToString(dr["user_name"]);
            customerTable.PASSWORD = CConvert.ToString(dr["password"]);
            customerTable.QUESTION = CConvert.ToString(dr["question"]);
            customerTable.ANSWER = CConvert.ToString(dr["answer"]);
            customerTable.SEX = CConvert.ToInt32(dr["sex"]);
            customerTable.BIRTHDAY = CConvert.ToDateTime(dr["birthday"]);
            customerTable.USER_MONEY = CConvert.ToDecimal(dr["user_money"]);
            customerTable.FROZEN_MONEY = CConvert.ToDecimal(dr["frozen_money"]);
            customerTable.PAY_POINTS = CConvert.ToInt32(dr["pay_points"]);
            customerTable.RANK_POINTS = CConvert.ToInt32(dr["rank_points"]);
            customerTable.ADDRESS_ID = CConvert.ToInt32(dr["address_id"]);
            customerTable.REG_TIME = CConvert.ToInt32(dr["reg_time"]);
            customerTable.LAST_LOGIN = CConvert.ToInt32(dr["last_login"]);
            customerTable.LAST_TIME = CConvert.ToDateTime(dr["last_time"]);
            customerTable.LAST_IP = CConvert.ToString(dr["last_ip"]);
            customerTable.VISIT_COUNT = CConvert.ToInt32(dr["visit_count"]);
            customerTable.USER_RANK = CConvert.ToInt32(dr["user_rank"]);
            customerTable.IS_SPECIAL = CConvert.ToInt32(dr["is_special"]);
            customerTable.SALT = CConvert.ToInt32(dr["salt"]);
            customerTable.PARENT_ID = CConvert.ToInt32(dr["parent_id"]);
            customerTable.FLAG = CConvert.ToInt32(dr["flag"]);
            customerTable.ALIAS = CConvert.ToString(dr["alias"]);
            customerTable.MSN = CConvert.ToString(dr["msn"]);
            customerTable.QQ = CConvert.ToInt32(dr["qq"]);
            customerTable.OFFICE_PHONE = CConvert.ToString(dr["office_phone"]);
            customerTable.HOME_PHONE = CConvert.ToString(dr["home_phone"]);
            customerTable.MOBILE_PHONE = CConvert.ToString(dr["mobile_phone"]);
            customerTable.IS_VALIDATED = CConvert.ToInt32(dr["is_validated"]);
            customerTable.CREDIT_LINE = CConvert.ToDecimal(dr["credit_line"]);
        }
        #endregion

        #region 会员收货地址
        /// <summary>
        /// 会员收货地址
        /// </summary>
        private void InsertCustomerAddress(DataSet ds, DataTable dt)
        {
            BCustomerAddress bll = new BCustomerAddress();
            BaseCustomerAddressTable customerAddressTable = null;
            bool b = false;
            string errorMessage = "";
            DataRow row = null;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                customerAddressTable = new BaseCustomerAddressTable();
                GetCustomerAddressTable(customerAddressTable, dr);
                b = false;
                errorMessage = "";
                row = dt.NewRow();
                row["code"] = customerAddressTable.ADDRESS_ID;
                try
                {
                    if (bll.Exists(customerAddressTable.ADDRESS_ID))
                    {
                        b = bll.Update(customerAddressTable);
                    }
                    else
                    {
                        if (bll.Add(customerAddressTable) > 0)
                        {
                            b = true;
                        }
                        else
                        {
                            b = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    b = false;
                    errorMessage = ex.Message;
                }

                if (b)
                {
                    row["status"] = CConstant.SUCCESS;
                }
                else
                {
                    row["status"] = CConstant.ERROR;
                }
                row["errorMessage"] = errorMessage;
                dt.Rows.Add(row);
            }
        }

        /// <summary>
        ///  会员收货地址表的组装
        /// </summary>
        private void GetCustomerAddressTable(BaseCustomerAddressTable customerAddressTable, DataRow dr)
        {
            customerAddressTable.ADDRESS_ID = CConvert.ToDecimal(dr["address_id"]);
            customerAddressTable.ADDRESS_NAME = CConvert.ToString(dr["address_name"]);
            customerAddressTable.USER_ID = CConvert.ToDecimal(dr["user_id"]);
            customerAddressTable.CONSIGNEE = CConvert.ToString(dr["consignee"]);
            customerAddressTable.EMAIL = CConvert.ToString(dr["email"]);
            customerAddressTable.COUNTRY = CConvert.ToInt32(dr["country"]);
            customerAddressTable.PROVINCE = CConvert.ToInt32(dr["province"]);
            customerAddressTable.CITY = CConvert.ToInt32(dr["city"]);
            customerAddressTable.DISTRICT = CConvert.ToInt32(dr["district"]);
            customerAddressTable.ADDRESS = CConvert.ToString(dr["address"]);
            customerAddressTable.ZIPCODE = CConvert.ToString(dr["zipcode"]);
            customerAddressTable.TEL = CConvert.ToString(dr["tel"]);
            customerAddressTable.MOBILE = CConvert.ToString(dr["mobile"]);
            customerAddressTable.SIGN_BUILDING = CConvert.ToString(dr["sign_building"]);
            customerAddressTable.BEST_TIME = CConvert.ToString(dr["best_time"]);
        }
        #endregion

    }//end class
}
