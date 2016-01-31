/********************************************************************************************
 * 文件名称:	CustomList.cs
 * 设计人员:	严向辉
 * 设计时间:	2007-09-12
 * 功能描述:	自定义实体列表，加入总页数属性
 *		
 *		
 * 注意事项:	
 *
 * 版权所有:	Copyright (c) 2007, Fujian SIRC
 *
 * 修改记录: 	修改时间		人员		修改备注
 *				----------		------		-------------------------------------------------
 *              2008-3-3        黄景灿      把类设置为可序列化[Serializable]
 ********************************************************************************************/
using System;
using System.Data;

namespace SIRC.Framework.Utility
{    
    /// <summary>
    /// 自定义实体列表，加入总页数属性
    /// </summary>
    [Serializable]
    public class CustomDataSet : DataSet
    {
        private int _totalAmout;
        /// <summary>
        /// 记录集的总页数
        /// </summary>
        public int TotalAmout
        {
            get { return _totalAmout; }
            set { _totalAmout = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resultSetAmout">记录数</param>
        /// <param name="ds">数据集</param>
        public CustomDataSet(int resultSetAmout, DataSet ds)
        {
            for (int i = 0; i < ds.Tables.Count; i++)
            {
                this.Tables.Add(ds.Tables[i].Copy());
            }
            this.TotalAmout = resultSetAmout;
        }
    }
}
