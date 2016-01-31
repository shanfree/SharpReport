/**  版本信息模板在安装目录下，可自行修改。
* Invoice.cs
*
* 功 能： N/A
* 类 名： Invoice
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/2/14 14:15:38   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using Sirc.SharpReport.Model;
using SIRC.Framework.Utility;
using System.Collections.Generic;

namespace Sirc.SharpReport.IDAL
{
	/// <summary>
	/// 接口层Invoice
	/// </summary>
    public interface IInvoice : IDBPersistenceBase<InvoiceInfo>
    {
        /// <summary>
        /// 获取报表的发票列表
        /// </summary>
        /// <param name="reportType">报表类型</param>
        /// <param name="keyID">报表主键</param>
        /// <returns></returns>
        IList<InvoiceInfo> GetInvoiceList(string reportType, string keyID);


        /// <summary>
        /// 根据发票编号获取实体
        /// </summary>
        /// <param name="number">发票编号</param>
        /// <returns>实体</returns>
        IList<InvoiceInfo> GetByNumber(string number);
    } 
}
