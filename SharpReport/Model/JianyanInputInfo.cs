/**  版本信息模板在安装目录下，可自行修改。
* JianyanInput.cs
*
* 功 能： N/A
* 类 名： JianyanInput
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/4/20 9:45:10   N/A    初版
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
    /// JianyanInput:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    [Persistence(ColumnName = "JianyanInput")]
    public partial class JianyanInputInfo : ReportBaseInfo
    {
        public JianyanInputInfo()
        { }
        public JianyanInputInfo(string ID)
        {
            this.ID = ID;
        }

        #region Model
        private string _总数 = "0";

        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "总数")]
        public string 总数
        {
            set { _总数 = value; }
            get { return _总数; }
        }
        #endregion Model

    }
}

