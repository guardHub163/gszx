using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using CZZD.GSZX.Common;

namespace CZZD.GSZX.DBUtility
{
    public class PubConstant
    {
        private static string _sqlServerConn = string.Empty;
        private static string _mySqlConn = string.Empty;
        private static string ConStringEncrypt = ConfigurationManager.AppSettings["ConStringEncrypt"];

        /// <summary>
        /// 获取连接字符串
        /// </summary>
        public static string GetSqlServerConnectionString()
        {
            string _connectionString = ConfigurationManager.AppSettings["ConnectionStringSqlServer"];
            if (string.IsNullOrEmpty(_sqlServerConn))
            {
                if (ConStringEncrypt == "true")
                {
                    _connectionString = DESEncrypt.DecryptString(_connectionString, CConstant.DB_KEYS);
                }
                _sqlServerConn = _connectionString;
            }
            else
            {
                _connectionString = _sqlServerConn;
            }
            return _connectionString;
        }

        /// <summary>
        /// 获取连接字符串
        /// </summary>
        public static string GetMySqlConnectionString()
        {
            string _connectionString = ConfigurationManager.AppSettings["ConnectionStringMySql"];
            if (string.IsNullOrEmpty(_mySqlConn))
            {
                if (ConStringEncrypt == "true")
                {
                    _connectionString = DESEncrypt.DecryptString(_connectionString, CConstant.DB_KEYS);
                }
                _mySqlConn = _connectionString;
            }
            else
            {
                _connectionString = _mySqlConn;
            }
            return _connectionString;
        }
    }//end class
}
