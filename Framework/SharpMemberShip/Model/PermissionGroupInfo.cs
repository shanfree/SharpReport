/********************************************************************************************
 * 文件名称: PermissionGroupInfo.cs
 * 设计人员: 严向晖 （yanxianghui@gmail.com）
 * 设计时间: 2013/2/19
 * 功能描述: 
 * 注意事项: 
 * 版权所有: Copyright (c) 2013, Fujian SIRC
 * 修改记录:       修改时间     人员     修改备注
 *	----------	   --------		-----     -----------------------------------------
 * 
 ********************************************************************************************/

using System;
using SIRC.Framework.Utility;

namespace SIRC.Framework.SharpMemberShip.Model
{
    /// <summary>
    /// 实体类PermissionGroupInfo 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    [Persistence(ColumnName = "PermissionGroup")]
    public class PermissionGroupInfo
    {
        public PermissionGroupInfo()
        { }

        #region 持久化字段
        private string _id;
        /// <summary>
        /// 主键
        /// </summary>
        [Persistence(IsPrimaryKey = true, ColumnName = "ID")]
        public string ID
        {
            set
            {
                _id = value;
            }
            get
            {
                return _id;
            }
        }
        private string _name;
        /// <summary>
        /// 权限组名称
        /// </summary>
        [Persistence(ColumnName = "Name")]
        public string Name
        {
            set
            {
                _name = value;
            }
            get
            {
                return _name;
            }
        }
        private string _remark;
        /// <summary>
        /// 描述信息
        /// </summary>
        [Persistence(ColumnName = "Remark")]
        public string Remark
        {
            set
            {
                _remark = value;
            }
            get
            {
                return _remark;
            }
        }
        private string _relationID;
        /// <summary>
        /// 栏目和权限组关系主键
        /// </summary>
        [Persistence(ColumnName = "RelationID", IsExtend = true)]
        public string RelationID
        {
            set
            {
                _relationID = value;
            }
            get
            {
                return _relationID;
            }
        }

        #endregion 持久化字段

    }
}

