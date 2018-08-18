using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PriceTagPrint.Common
{
    /**
    * 命名空间: PriceTagPrint.Common
    *
    * 功 能： 功能
    * 类 名： Log
    *
    * Ver 变更日期 负责人 变更内容
    * ───────────────────────────────────
    * V1.0.0 2018/8/17 11:46:08 刘欢 初版
    * CLR版本： 4.0.30319.42000
    *
    * Copyright (c) 2018 Lir Corporation. All rights reserved.
    *┌──────────────────────────────────┐
    *│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
    *│　版权所有：北京华联高级超市 　　　　　　　　　　　　　           　│
    *└──────────────────────────────────┘
    */
    public class Log
    {
        /// <summary>
        /// 写入错误日志
        /// </summary>
        /// <param name="ex">Exception</param>
        public void WriteLog(Exception ex)
        {
            if (!Directory.Exists(string.Format("{0}LOG", AppDomain.CurrentDomain.BaseDirectory)))
            {
                Directory.CreateDirectory(string.Format("{0}LOG", AppDomain.CurrentDomain.BaseDirectory));
            }
            var sb = new StringBuilder();
            sb.AppendLine("****************************异常文本****************************");
            sb.AppendLine("【出现时间】：" + DateTime.Now.ToString());
            if (ex != null)
            {
                sb.AppendLine("【异常类型】：" + ex.GetType().Name);
                sb.AppendLine("【异常信息】：" + ex.Message);
                sb.AppendLine("【堆栈调用】：" + ex.StackTrace);
            }
            else
            {
                sb.AppendLine("【未处理异常】：");
            }
            sb.AppendLine("****************************************************************");
            var sw = new StreamWriter(string.Format(@"{0}Log\{1}.log", AppDomain.CurrentDomain.BaseDirectory, DateTime.Now.ToString("yyyyMMdd")), true, Encoding.Default);
            sw.WriteLine(sb.ToString());
            sw.Close();
        }
        /// <summary>
        /// 写入文本日志
        /// </summary>
        /// <param name="log">文本日志</param>
        public void WriteLog(string log)
        {
            if (!Directory.Exists(string.Format("{0}LOG", AppDomain.CurrentDomain.BaseDirectory)))
            {
                Directory.CreateDirectory(string.Format("{0}LOG", AppDomain.CurrentDomain.BaseDirectory));
            }
            var sb = new StringBuilder();
            sb.AppendLine("****************************异常文本****************************");
            sb.AppendLine("【出现时间】：" + DateTime.Now.ToString());
            sb.Append(log);
            sb.Append("\r\n");
            sb.AppendLine("****************************************************************");
            var sw = new StreamWriter(string.Format(@"{0}LOG\{1}.log", AppDomain.CurrentDomain.BaseDirectory, DateTime.Now.ToString("yyyyMMdd")), true, Encoding.Default);
            sw.WriteLine(sb.ToString());
            sw.Close();
        }
        /// <summary>
        /// 异常信息
        /// </summary>
        /// <param name="ex">异常对象</param>
        /// <returns></returns>
        public static string ExceptionString(Exception ex)
        {
            var sb = new StringBuilder();
            sb.AppendLine("****************************异常文本****************************");
            sb.AppendLine("【出现时间】：" + DateTime.Now.ToString());
            if (ex != null)
            {
                sb.AppendLine("【异常类型】：" + ex.GetType().Name);
                sb.AppendLine("【异常信息】：" + ex.Message);
                //sb.AppendLine("【堆栈调用】：" + ex.StackTrace);
            }
            else
            {
                sb.AppendLine("【未处理异常】：");
            }
            sb.AppendLine("****************************************************************");
            return sb.ToString();
        }
        public static string ExceptionString(Exception ex, string commandText)
        {
            var sb = new StringBuilder();
            sb.AppendLine("****************************异常文本****************************");
            sb.AppendLine("【出现时间】：" + DateTime.Now.ToString());
            if (ex != null)
            {
                sb.AppendLine("【异常类型】：" + ex.GetType().Name);
                sb.AppendLine("【异常信息】：" + ex.Message);
                //sb.AppendLine("【堆栈调用】：" + ex.StackTrace);
            }
            else
            {
                sb.AppendLine("【未处理异常】：");
            }
            sb.AppendLine("【异常脚本】：\r\n" + commandText.ToUpper());
            sb.AppendLine("****************************************************************");
            return sb.ToString();
        }
    }
}
