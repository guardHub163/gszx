using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using CZZD.GSZX.S.Common;

namespace CZZD.GSZX.S.DBUtility
{
    public class PubConstant
    {
        private static string _sqlServerConn = string.Empty;
        private static string _mySqlConn = string.Empty;
        private static string _connEncrypt = ConfigurationManager.AppSettings["ConStringEncrypt"];


        /// <summary>
        /// 获取连接字符串
        /// </summary>
        public static string GetSqlServerConnectionString()
        {
            if (string.IsNullOrEmpty(_sqlServerConn))
            {
                string _connectionString = ConfigurationManager.AppSettings["ConnectionStringSqlServer"];
                if (_connEncrypt == "true")
                {
                    _connectionString = DESEncrypt.Decrypt(_connectionString, CConstant.DB_KEYS);
                }
                //_connectionString = DESEncrypt.DecryptString(_connectionString, null);
                _sqlServerConn = _connectionString;
            }

            return _sqlServerConn;
        }

        /// <summary>
        /// 获取连接字符串
        /// </summary>
        public static string GetMySqlConnectionString()
        {
            if (string.IsNullOrEmpty(_mySqlConn))
            {
                string _connectionString = ConfigurationManager.AppSettings["ConnectionStringMySql"];
                if (_connEncrypt == "true")
                {
                    _connectionString = DESEncrypt.Decrypt(_connectionString, CConstant.DB_KEYS);
                }
                //_connectionString = DESEncrypt.DecryptString(_connectionString, null);
                _mySqlConn = _connectionString;
            }

            return _mySqlConn;
        }


        /// <summary>
        /// 得到web.config里配置项的数据库连接字符串。
        /// </summary>
        /// <param name="configName"></param>
        /// <returns></returns>
        public static string GetConnectionString(string configName)
        {
            string connectionString = ConfigurationManager.AppSettings[configName];
            string ConStringEncrypt = ConfigurationManager.AppSettings["ConStringEncrypt"];
            if (ConStringEncrypt == "true")
            {
                connectionString = DESEncrypt.Decrypt(connectionString);
            }
            return connectionString;
        }
    }
}
