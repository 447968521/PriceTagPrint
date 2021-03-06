﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace PriceTagPrint.DataBase
{
    /**
    * 命名空间: PriceTagPrint.DataBase
    *
    * 功 能： 功能
    * 类 名： SqlHelperExtension
    *
    * Ver 变更日期 负责人 变更内容
    * ───────────────────────────────────
    * V1.0.0 2018/8/17 13:32:03 刘欢 初版
    * CLR版本： 4.0.30319.42000
    *
    * Copyright (c) 2018 Lir Corporation. All rights reserved.
    *┌──────────────────────────────────┐
    *│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
    *│　版权所有：北京华联高级超市 　　　　　　　　　　　　　           　│
    *└──────────────────────────────────┘
    */
    public sealed partial class SqlHelper
    {

        #region 实例方法

        public T ExecuteObject<T>(string commandText, params SqlParameter[] parms)
        {
            return ExecuteObject<T>(this.ConnectionString, commandText, parms);
        }

        public List<T> ExecuteObjects<T>(string commandText, params SqlParameter[] parms)
        {
            return ExecuteObjects<T>(this.ConnectionString, commandText, parms);
        }

        #endregion

        #region 静态方法

        public static T ExecuteObject<T>(string connectionString, string commandText, params SqlParameter[] parms)
        {
            //DataTable dt = ExecuteDataTable(connectionString, commandText, parms);
            //return AutoMapper.Mapper.DynamicMap<List<T>>(dt.CreateDataReader()).FirstOrDefault();
            using (SqlDataReader reader = ExecuteDataReader(connectionString, commandText, parms))
            {
                return AutoMapper.Mapper.DynamicMap<List<T>>(reader).FirstOrDefault();
            }
        }

        public static List<T> ExecuteObjects<T>(string connectionString, string commandText, params SqlParameter[] parms)
        {
            //DataTable dt = ExecuteDataTable(connectionString, commandText, parms);
            //return AutoMapper.Mapper.DynamicMap<List<T>>(dt.CreateDataReader());
            using (SqlDataReader reader = ExecuteDataReader(connectionString, commandText, parms))
            {
                return AutoMapper.Mapper.DynamicMap<List<T>>(reader);
            }
        }

        #endregion
    }
}
