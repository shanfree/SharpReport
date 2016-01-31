/**  版本信息模板在安装目录下，可自行修改。
* XiuliInput.cs
*
* 功 能： N/A
* 类 名： XiuliInput
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/4/20 9:45:11   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using SIRC.Framework.Utility;

namespace Sirc.SharpReport.Model
{
    /// <summary>
    /// XiuliInput:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    [Persistence(ColumnName = "XiuliInput")]
    public partial class XiuliInputInfo : ReportBaseInfo
    {
        public XiuliInputInfo()
        { }
        public XiuliInputInfo(string ID)
        {
            this.ID = ID;
        }

        #region Model
        private string _总数 = "0";
        private string _自购物料;
        private string _备件;
        private string _修理费用;

        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "总数")]
        public string 总数
        {
            set { _总数 = value; }
            get
            {
                string result = NumericHandler.StringAdd(this.自购物料, this.备件);
                result = NumericHandler.StringAdd(result, this.修理费用);
                result = NumericHandler.StringAdd(result, this.服务工程);
                result = NumericHandler.StringAdd(result, this.甲板工程);
                result = NumericHandler.StringAdd(result, this.轮机工程);
                result = NumericHandler.StringAdd(result, this.电气工程);
                this.总数 = result;
                return _总数;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "自购物料")]
        public string 自购物料
        {
            set { _自购物料 = value; }
            get { return _自购物料; }
        }
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "备件")]
        public string 备件
        {
            set { _备件 = value; }
            get { return _备件; }
        }
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "修理费用")]
        public string 修理费用
        {
            set { _修理费用 = value; }
            get { return _修理费用; }
        }

        private string __服务工程 = "0";
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "服务工程")]
        public string 服务工程
        {
            set { __服务工程 = value; }
            get { return __服务工程; }
        }
        private string __甲板工程 = "0";
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "甲板工程")]
        public string 甲板工程
        {
            set { __甲板工程 = value; }
            get { return __甲板工程; }
        }
        private string __轮机工程 = "0";
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "轮机工程")]
        public string 轮机工程
        {
            set { __轮机工程 = value; }
            get { return __轮机工程; }
        }
        private string __电气工程 = "0";
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "电气工程")]
        public string 电气工程
        {
            set { __电气工程 = value; }
            get { return __电气工程; }
        }
        #endregion Model

    }
}

