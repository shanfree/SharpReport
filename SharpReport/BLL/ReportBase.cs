/**  版本信息模板在安装目录下，可自行修改。
* ReportBase.cs
*
* 功 能： N/A
* 类 名： ReportBase
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
using System.Collections.Generic;
using Sirc.SharpReport.Model;
using Sirc.SharpReport.DALFactory;
using Sirc.SharpReport.IDAL;

namespace Sirc.SharpReport.BLL
{
    /// <summary>
    /// 报表基类
    /// </summary>
    public partial class ReportBase<T> where T : ReportBaseInfo, new()
    {
        /// <summary>
        /// 报表基类
        /// </summary>
        public ReportBase()
        { }

        /// <summary>
        /// 获取报表基类实体
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public ReportBaseInfo GetReport(string ID)
        {
            ReportBaseInfo rInfo = new ReportBaseInfo();
            if (typeof(T) == typeof(WuliaoInputInfo))
            {
                rInfo = new WuliaoInput().GetByID(ID);
            }
            else if (typeof(T) == typeof(XiuliInputInfo))
            {
                rInfo = new XiuliInput().GetByID(ID);
            }
            else if (typeof(T) == typeof(JianyanInputInfo))
            {
                rInfo = new JianyanInput().GetByID(ID);
            }
            else if (typeof(T) == typeof(BeijianInputInfo))
            {
                rInfo = new BeijianInput().GetByID(ID);
            }
            else
            {
                throw new NotImplementedException("类型" + typeof(T).Name + "的方法未在基类方法GetReport中定义。");
            }
            return rInfo;
        }


        /// <summary>
        /// 获取主键为ID的报表的预估输入报表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetPreestimateModel(string id)
        {
            ReportBaseInfo rInfo = GetReport(id);
            if (string.IsNullOrEmpty(rInfo.PreestimateFormID))
            {
                return null;
            }
            return new FormLibrary<T>().GetByID(rInfo.PreestimateFormID);
        }

        /// <summary>
        /// 获取主键为ID的报表的修正输入报表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetAmendModel(string id)
        {
            ReportBaseInfo rInfo = GetReport(id);
            if (string.IsNullOrEmpty(rInfo.AmendFormID))
            {
                return null;
            }
            return new FormLibrary<T>().GetByID(rInfo.AmendFormID);
        }

    }
}

