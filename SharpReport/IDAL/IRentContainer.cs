﻿/**  版本信息模板在安装目录下，可自行修改。
* RentContainer.cs
*
* 功 能： N/A
* 类 名： RentContainer
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/2/14 14:15:45   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using SIRC.Framework.Utility;
using Sirc.SharpReport.Model;
using System.Collections.Generic;

namespace Sirc.SharpReport.IDAL
{
    /// <summary>
    /// 接口层RentContainer
    /// </summary>
    public interface IRentContainer : IDBPersistenceBase<RentContainerInfo>
    {
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="reportID"></param>
        /// <returns>列表</returns>
        IList<RentContainerInfo> GetList(string reportID);

    }
}
