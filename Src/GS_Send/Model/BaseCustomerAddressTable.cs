using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CZZD.GSZX.S.Model
{
    /// <summary>
    /// BASE_CUSTOMER_ADDRESS:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class BaseCustomerAddressTable
    {
        public BaseCustomerAddressTable()
        { }
        #region Model
        private decimal _address_id;
        private string _address_name;
        private decimal? _user_id;
        private string _consignee;
        private string _email;
        private int? _country;
        private int? _province;
        private int? _city;
        private int? _district;
        private string _address;
        private string _zipcode;
        private string _tel;
        private string _mobile;
        private string _sign_building;
        private string _best_time;
        /// <summary>
        /// 
        /// </summary>
        public decimal ADDRESS_ID
        {
            set { _address_id = value; }
            get { return _address_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ADDRESS_NAME
        {
            set { _address_name = value; }
            get { return _address_name; }
        }
        /// <summary>
        /// 用户表中的流水号'
        /// </summary>
        public decimal? USER_ID
        {
            set { _user_id = value; }
            get { return _user_id; }
        }
        /// <summary>
        /// '收货人的名字
        /// </summary>
        public string CONSIGNEE
        {
            set { _consignee = value; }
            get { return _consignee; }
        }
        /// <summary>
        /// '收货人的email'
        /// </summary>
        public string EMAIL
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 收货人的国家'
        /// </summary>
        public int? COUNTRY
        {
            set { _country = value; }
            get { return _country; }
        }
        /// <summary>
        /// 收货人的省份
        /// </summary>
        public int? PROVINCE
        {
            set { _province = value; }
            get { return _province; }
        }
        /// <summary>
        /// 收货人的城市
        /// </summary>
        public int? CITY
        {
            set { _city = value; }
            get { return _city; }
        }
        /// <summary>
        /// 收货人的地区
        /// </summary>
        public int? DISTRICT
        {
            set { _district = value; }
            get { return _district; }
        }
        /// <summary>
        /// 收货人的详细地址
        /// </summary>
        public string ADDRESS
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 收货人的邮编
        /// </summary>
        public string ZIPCODE
        {
            set { _zipcode = value; }
            get { return _zipcode; }
        }
        /// <summary>
        /// '收货人的电话
        /// </summary>
        public string TEL
        {
            set { _tel = value; }
            get { return _tel; }
        }
        /// <summary>
        /// 收货人的手机
        /// </summary>
        public string MOBILE
        {
            set { _mobile = value; }
            get { return _mobile; }
        }
        /// <summary>
        /// 收货地址的标志性建筑名
        /// </summary>
        public string SIGN_BUILDING
        {
            set { _sign_building = value; }
            get { return _sign_building; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BEST_TIME
        {
            set { _best_time = value; }
            get { return _best_time; }
        }
        #endregion Model

    }
}
