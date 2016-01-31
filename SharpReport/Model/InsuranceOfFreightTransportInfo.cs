/**  版本信息模板在安装目录下，可自行修改。
* InsuranceOfFreightTransport.cs
*
* 功 能： N/A
* 类 名： InsuranceOfFreightTransport
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/4/20 9:45:09   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using SIRC.Framework.Utility;
using System.Collections.Generic;


namespace Sirc.SharpReport.Model
{
    /// <summary>
    /// InsuranceOfFreightTransport:内贸线货运险投保货量及保费
    /// </summary>
    [Serializable]
    [Persistence(ColumnName = "InsuranceOfFreightTransport")]
    public partial class InsuranceOfFreightTransportInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public InsuranceOfFreightTransportInfo()
        { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        public InsuranceOfFreightTransportInfo(string ID)
        {
            this.ID = ID;
        }

        #region Model
        private string _id;
        /// <summary>
        /// 主键
        /// </summary>
        [Persistence(IsPrimaryKey = true, ColumnName = "ID")]
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        private string _dimtimeid;
        /// <summary>
        /// 报告期主键
        /// </summary>
        [Persistence(ColumnName = "DimTimeID")]
        public string DimTimeID
        {
            set { _dimtimeid = value; }
            get { return _dimtimeid; }
        }
        private string _voyageID;
        /// <summary>
        /// 船舶主键
        /// </summary>
        [Persistence(ColumnName = "VoyageID")]
        public string VoyageID
        {
            set { _voyageID = value; }
            get { return _voyageID; }
        }

        private string _inputuserid;
        /// <summary>
        /// 登记人
        /// </summary>
        [Persistence(ColumnName = "InputUserID")]
        public string InputUserID
        {
            set { _inputuserid = value; }
            get { return _inputuserid; }
        }
        private string _approveuserid;
        /// <summary>
        /// 财务部审核人员
        /// </summary>
        [Persistence(ColumnName = "ApproveUserID")]
        public string ApproveUserID
        {
            set { _approveuserid = value; }
            get { return _approveuserid; }
        }

        private DateTime _createtime = DateTime.Now;
        /// <summary>
        /// 报表创建时间
        /// </summary>
        [Persistence(ColumnName = "CreateTime")]
        public DateTime CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        private string _currencyID = string.Empty;
        /// <summary>
        /// 币种主键，默认1为人民币
        /// </summary>
        [Persistence(ColumnName = "CurrencyID")]
        public string CurrencyID
        {
            set { _currencyID = value; }
            get { return _currencyID; }
        }
        private string _exchangeRateID = string.Empty;
        /// <summary>
        /// 汇率主键，默认NULL，不进行转换
        /// </summary>
        [Persistence(ColumnName = "ExchangeRateID")]
        public string ExchangeRateID
        {
            set { _exchangeRateID = value; }
            get { return _exchangeRateID; }
        }

        private string _departure = string.Empty;
        /// <summary>
        /// 出发时间
        /// </summary>
        [Persistence(ColumnName = "Departure")]
        public string Departure
        {
            set { _departure = value; }
            get { return _departure; }
        }

        private string _arrival = string.Empty;
        /// <summary>
        /// 到达时间
        /// </summary>
        [Persistence(ColumnName = "Arrival")]
        public string Arrival
        {
            set { _arrival = value; }
            get { return _arrival; }
        }

        private string _amount50kilo20feet = string.Empty;
        /// <summary>
        /// 5万以上20英尺货柜数目
        /// </summary>
        [Persistence(ColumnName = "Amount50kilo20feet")]
        public string Amount50kilo20feet
        {
            set { _amount50kilo20feet = value; }
            get { return _amount50kilo20feet; }
        }
        private string _amount50kilo40feet = string.Empty;
        /// <summary>
        /// 5万以上40英尺货柜数目
        /// </summary>
        [Persistence(ColumnName = "Amount50kilo40feet")]
        public string Amount50kilo40feet
        {
            set { _amount50kilo40feet = value; }
            get { return _amount50kilo40feet; }
        }
        private string _备注 = string.Empty;
        /// <summary>
        /// _备注
        /// </summary>
        [Persistence(ColumnName = "备注")]
        public string 备注
        {
            set { _备注 = value; }
            get { return _备注; }
        }

        private string _总保费 = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "总保费")]
        public string 总保费
        {
            get
            {
                // 5万以下按5万收，费率0.02%
                int amount_50kilo20feet = int.Parse(this.Amount50kilo20feet);
                int amount_50kilo40feet = int.Parse(this.Amount50kilo40feet);
                double amount50kilo = 50000 * (amount_50kilo20feet + amount_50kilo40feet) * 0.0002;

                // 20万元的按每个货柜的价值×0.02%
                double amount200kilo = 0;
                foreach (ContainerInfo cInfo in this.ContainerList)
                {
                    double flee = double.Parse(cInfo.投保金额) * 0.0002;
                    amount200kilo += flee;
                }
                double total = (amount50kilo + amount200kilo) / 10000;
                return total.ToString();
            }
            set
            {
                _总保费 = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "总重柜量", IsExtend = true)]
        public string 总重柜量
        {
            get
            {
                // 5万以下按5万收，费率0.02%
                int amount_50kilo20feet = int.Parse(this.Amount50kilo20feet);
                int amount_50kilo40feet = int.Parse(this.Amount50kilo40feet);

                // 20万元
                int num200kilo = this.ContainerList.Count;
                int amount = amount_50kilo20feet + amount_50kilo40feet + num200kilo;
                return amount.ToString();
            }
        }

        private IList<ContainerInfo> _cList = new List<ContainerInfo>();
        /// <summary>
        /// 5万以上货柜的详细情况
        /// </summary>
        [Persistence(ColumnName = "总重柜量", IsExtend = true, IsLazyLoad = true)]
        public IList<ContainerInfo> ContainerList
        {
            get
            {
                return _cList;
            }
            set
            {
                _cList = value;
            }
        }

        #endregion Model

    }
}

