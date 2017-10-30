using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace CZZD.GSZX.S.DBUtility
{
    public class MySqlCommandInfo
    {
        private string _commandText;
        private MySqlParameter[] _parameters;

       
        /// <summary>
        /// 构适函数
        /// </summary>
        public MySqlCommandInfo(string sqlText, MySqlParameter[] para)
        {
            _commandText = sqlText;
            _parameters = para;
        }

        /// <summary>
        /// 
        /// </summary>
        public string CommandText
        {
            get { return _commandText; }
            set { _commandText = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public MySqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }

    }
}
