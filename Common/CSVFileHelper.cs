using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace PriceTagPrint.Common
{
    /**
    * 命名空间: PriceTagPrint.Common
    *
    * 功 能： 功能
    * 类 名： CSVFileHelper
    *
    * Ver 变更日期 负责人 变更内容
    * ───────────────────────────────────
    * V1.0.0 2018/8/17 11:55:46 刘欢 初版
    * CLR版本： 4.0.30319.42000
    *
    * Copyright (c) 2018 Lir Corporation. All rights reserved.
    *┌──────────────────────────────────┐
    *│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
    *│　版权所有：北京华联高级超市 　　　　　　　　　　　　　           　│
    *└──────────────────────────────────┘
    */
    public class CSVFileHelper
    {
        /// <summary>
        /// 将DataTable中数据写入到CSV文件中
        /// </summary>
        /// <param name="dt">提供保存数据的DataTable</param>
        /// <param name="fileName">CSV的文件路径</param>
        public static void SaveFile(DataTable dt, string fullPath)
        {
            var fi = new FileInfo(fullPath);
            if (!fi.Directory.Exists)
            {
                fi.Directory.Create();
            }
            var fs = new FileStream(fullPath, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            var sw = new StreamWriter(fs, System.Text.Encoding.UTF8);
            var data = string.Empty;
            for (var i = 0; i < dt.Columns.Count; i++)
            {
                data += dt.Columns[i].ColumnName.ToString();
                if (i < dt.Columns.Count - 1)
                {
                    data += ",";
                }
            }
            sw.WriteLine(data);
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                data = string.Empty;
                for (var j = 0; j < dt.Columns.Count; j++)
                {
                    var str = dt.Rows[i][j].ToString();
                    str = str.Replace("\"", "\"\"");
                    if (str.Contains(',') || str.Contains('"')
                        || str.Contains('\r') || str.Contains('\n'))
                    {
                        str = string.Format("\"{0}\"", str);
                    }

                    data += str;
                    if (j < dt.Columns.Count - 1)
                    {
                        data += ",";
                    }
                }
                sw.WriteLine(data);
            }
            sw.Close();
            fs.Close();
        }

        /// <summary>
        /// 将CSV文件的数据读取到DataTable中
        /// </summary>
        /// <param name="fileName">CSV文件路径</param>
        /// <returns>返回读取了CSV数据的DataTable</returns>
        public static DataTable OpenFile(string filePath, int startLine = 0, string encoding = "gb2312")
        {
            var dt = new DataTable();
            var fs = new FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);

            var sr = new StreamReader(fs, Encoding.GetEncoding(encoding));
            var strLine = string.Empty;
            for (var i = 0; i < startLine; i++)
            {
                if ((strLine = sr.ReadLine()) == null)
                {
                    return null;
                }
            }
            var aryLine = (string[])null;
            var tableHead = (string[])null;
            var columnCount = 0;
            var IsFirst = true;
            while ((strLine = sr.ReadLine()) != null)
            {
                if (IsFirst == true)
                {
                    tableHead = strLine.Split(',');
                    IsFirst = false;
                    columnCount = tableHead.Length;
                    for (var i = 0; i < columnCount; i++)
                    {
                        var dc = new DataColumn(tableHead[i]);
                        dt.Columns.Add(dc);
                    }
                }
                else
                {
                    aryLine = strLine.Split(',');
                    var dr = dt.NewRow();
                    for (var j = 0; j < columnCount; j++)
                    {
                        dr[j] = aryLine[j];
                    }
                    dt.Rows.Add(dr);
                }
            }
            if (aryLine != null && aryLine.Length > 0)
            {
                dt.DefaultView.Sort = tableHead[0] + " " + "asc";
            }

            sr.Close();
            fs.Close();
            return dt;
        }
    }
}
