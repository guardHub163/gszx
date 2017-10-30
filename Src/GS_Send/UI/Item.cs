using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CZZD.GSZX.S.UI
{
    public class Item
    {
        private string _value;
        private string _text;
        private bool _status = false;
        private string _status_name;

        #region 构造函数
        public Item() { }

        public Item(string value, string text)
        {
            this._value = value;
            this._text = text;
        }

        public Item(string value, string text, bool status, string statusName)
        {
            this._value = value;
            this._text = text;
            this._status = status;
            this._status_name = statusName;
        }
        #endregion

        #region 属性
        public string VALUE
        {
            get { return _value; }
            set { _value = value; }
        }

        public string TEXT
        {
            get { return _text; }
            set { _text = value; }
        }

        public bool STATUS
        {
            get { return _status; }
            set { _status = value; }
        }

        public string STATUS_NAME
        {
            get { return _status_name; }
            set { _status_name = value; }
        }
        #endregion

        /// <summary>
        /// ToString
        /// </summary>
        public override string ToString()
        {
            return _text;
        }

    }//end class
}
