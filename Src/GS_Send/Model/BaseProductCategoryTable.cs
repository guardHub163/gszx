using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CZZD.GSZX.S.Model
{
    /// <summary>
    /// BASE_PRODUCT_CATEGORY:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class BaseProductCategoryTable
    {
        public BaseProductCategoryTable()
        { }
        #region Model
        private int _cat_id;
        private string _cat_name;
        private string _keywords;
        private string _cat_desc;
        private int? _parent_id;
        private int? _sort_order;
        private string _template_file;
        private string _measure_unit;
        private int? _show_in_nav;
        private string _style;
        private int? _is_show;
        private int? _grade;
        private int? _filter_attr;
        /// <summary>
        /// 自增ID号
        /// </summary>
        public int CAT_ID
        {
            set { _cat_id = value; }
            get { return _cat_id; }
        }
        /// <summary>
        /// 分类名称
        /// </summary>
        public string CAT_NAME
        {
            set { _cat_name = value; }
            get { return _cat_name; }
        }
        /// <summary>
        /// 分类的关键字，可能是为了搜索
        /// </summary>
        public string KEYWORDS
        {
            set { _keywords = value; }
            get { return _keywords; }
        }
        /// <summary>
        /// 分类描述
        /// </summary>
        public string CAT_DESC
        {
            set { _cat_desc = value; }
            get { return _cat_desc; }
        }
        /// <summary>
        /// 该分类的父id，取值于该表的cat_id字段
        /// </summary>
        public int? PARENT_ID
        {
            set { _parent_id = value; }
            get { return _parent_id; }
        }
        /// <summary>
        /// 该分类在页面显示的顺序，数字越大顺序越靠后；同数字，id在前的先显示
        /// </summary>
        public int? SORT_ORDER
        {
            set { _sort_order = value; }
            get { return _sort_order; }
        }
        /// <summary>
        /// 不确定字段，按名字和表设计猜，应该是该分类的单独模板文件的名字
        /// </summary>
        public string TEMPLATE_FILE
        {
            set { _template_file = value; }
            get { return _template_file; }
        }
        /// <summary>
        /// 该分类的计量单位
        /// </summary>
        public string MEASURE_UNIT
        {
            set { _measure_unit = value; }
            get { return _measure_unit; }
        }
        /// <summary>
        /// 是否显示在导航栏，0，不；1，显示在导航栏
        /// </summary>
        public int? SHOW_IN_NAV
        {
            set { _show_in_nav = value; }
            get { return _show_in_nav; }
        }
        /// <summary>
        /// 该分类的单独的样式表的包括文件名部分的文件路径
        /// </summary>
        public string STYLE
        {
            set { _style = value; }
            get { return _style; }
        }
        /// <summary>
        /// 是否在前台页面显示，1，显示；0，不显示
        /// </summary>
        public int? IS_SHOW
        {
            set { _is_show = value; }
            get { return _is_show; }
        }
        /// <summary>
        /// 该分类的最高和最低价之间的价格分级，当大于1时，会根据最大最小价格区间分成区间，会在页面显示价格范围，如0-300,300-600,600-900这种
        /// </summary>
        public int? GRADE
        {
            set { _grade = value; }
            get { return _grade; }
        }
        /// <summary>
        /// 如果该字段有值，则该分类将还会按照该值对应在表goods_attr的goods_attr_id所对应的属性筛选，如，封面颜色下有红，黑分类筛选
        /// </summary>
        public int? FILTER_ATTR
        {
            set { _filter_attr = value; }
            get { return _filter_attr; }
        }
        #endregion Model

    }
}