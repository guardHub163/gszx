using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CZZD.GSZX.S.UI
{
    public class TimerInfo
    {
        private string _type = "";

        /// <summary>
        /// 构造函数
        /// </summary>
        public TimerInfo()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public TimerInfo(string type) 
        {
            this._type = type;
        }



        public string TYPE
        {
            get { return _type; }
            set { _type = value; }
        }

    }//end class
}
