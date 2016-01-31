/**  版本信息模板在安装目录下，可自行修改。
* Ship.cs
*
* 功 能： N/A
* 类 名： Ship
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/2/14 14:15:44   N/A    初版
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
    /// 船舶装箱类型
    /// </summary>
    public enum ShipType
    {
        /// <summary>
        /// less cantainer load 散货拼箱
        /// </summary>
        LCL = 1,
        /// <summary>
        /// full cantainer load 整箱
        /// </summary>
        FCL = 2,
    }

    /// <summary>
    /// 船舶所有类型
    /// </summary>
    public enum ShipOperationType
    {
        /// <summary>
        /// 自有
        /// </summary>
        Own = 1,
        /// <summary>
        /// 租用
        /// </summary>
        Rent = 2,
    }

	/// <summary>
    /// Ship:船舶(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    [Persistence(ColumnName = "Ship")]
    public partial class ShipInfo
	{
        public ShipInfo()
		{}
		#region Model
		private string _id;
		private string _name;
		private string _code;
        private string _chiefengineer;
        private string _captain;
        private string _generalmanager;
		/// <summary>
		/// 
		/// </summary>
        [Persistence(IsPrimaryKey = true, ColumnName = "ID")]
        public string ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 船舶名称
		/// </summary>
        [Persistence(ColumnName = "Name")]
        public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 船舶编号
		/// </summary>
        [Persistence(ColumnName = "Code")]
        public string Code
		{
			set{ _code=value;}
			get{return _code;}
		}
        /// <summary>
        ///  轮机长
        /// </summary>
        [Persistence(ColumnName = "ChiefEngineer")]
        public string ChiefEngineer
        {
            set { _chiefengineer = value; }
            get { return _chiefengineer; }
        }
        /// <summary>
        /// 船长
        /// </summary>
        [Persistence(ColumnName = "Captain")]
        public string Captain
        {
            set { _captain = value; }
            get { return _captain; }
        }
        /// <summary>
        /// 机务主管
        /// </summary>
        [Persistence(ColumnName = "GeneralManager")]
        public string GeneralManager
        {
            set { _generalmanager = value; }
            get { return _generalmanager; }
        }

        private string _loadType = "1";
        /// <summary>
        /// 1:散货；2：集装箱
        /// </summary>
        [Persistence(ColumnName = "LoadType")]
        public string LoadType
        {
            set { _loadType = value; }
            get { return _loadType; }
        }
        /// <summary>
        /// 船舶装箱类型
        /// </summary>
        public ShipType LoadTypeEnum
        {
            get
            {
                return EnumHandler<ShipType>.GetEnumFromIntString(this.LoadType);
            }
        }

        private string _operationType = "1";
        /// <summary>
        /// 1:自营；2：租赁
        /// </summary>
        [Persistence(ColumnName = "OperationType")]
        public string OperationType
        {
            set { _operationType = value; }
            get { return _operationType; }
        }
        /// <summary>
        /// 船舶所有类型
        /// </summary>
        public ShipOperationType OperationTypeEnum
        {
            get
            {
                return EnumHandler<ShipOperationType>.GetEnumFromIntString(this.OperationType);
            }
        }

        private DateTime _rentDate = DateTime.Now;
        /// <summary>
        /// 租用期限到
        /// </summary>
        [Persistence(ColumnName = "RentDate")]
        public DateTime RentDate
        {
            set { _rentDate = value; }
            get { return _rentDate; }
        }
		#endregion Model

	}
}

