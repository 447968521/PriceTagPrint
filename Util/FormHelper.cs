using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraPrinting.Native;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraWaitForm;

namespace PriceTagPrint.Util
{
    /**
    * 命名空间: PriceTagPrint.Util
    *
    * 功 能： 功能
    * 类 名： FormHelper
    *
    * Ver 变更日期 负责人 变更内容
    * ───────────────────────────────────
    * V1.0.0 2018/8/17 11:59:49 刘欢 初版
    * CLR版本： 4.0.30319.42000
    *
    * Copyright (c) 2018 Lir Corporation. All rights reserved.
    *┌──────────────────────────────────┐
    *│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
    *│　版权所有：北京华联高级超市 　　　　　　　　　　　　　           　│
    *└──────────────────────────────────┘
    */
    public static class FormHelper
    {
        private static DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        /// <summary>
        /// 显示等待对话框
        /// </summary>
        /// <param name="frm"></param>
        /// <param name="caption">标题</param>
        /// <param name="description">等待消息</param>
        public static void ShowWaitForm(this Form frm, string caption, string description)
        {
            splashScreenManager1 =
                  new SplashScreenManager(frm, typeof(WaitForm), true, true);
            splashScreenManager1.ShowWaitForm();
            if (!caption.IsEmpty())
                splashScreenManager1.SetWaitFormCaption(caption);
            if (!description.IsEmpty())
                splashScreenManager1.SetWaitFormDescription(description);
        }
        /// <summary>
        /// 显示等待对话框
        /// </summary>
        /// <param name="frm"></param>
        /// <param name="description">等待消息</param>
        public static void ShowWaitForm(this Form frm, string description)
        {
            splashScreenManager1 =
                  new SplashScreenManager(frm, typeof(WaitForm), true, true);
            splashScreenManager1.ShowWaitForm();
            if (!description.IsEmpty())
            {
                splashScreenManager1.SetWaitFormDescription(description);
            }
        }
        /// <summary>
        /// 设置描述
        /// </summary>
        /// <param name="frm"></param>
        /// <param name="caption">标题</param>
        public static void SetWaitFormCaption(this Form frm, string caption)
        {
            if (splashScreenManager1 == null)
            {
                return;
            }
            if (splashScreenManager1.IsSplashFormVisible)
            {
                if (!caption.IsEmpty())
                    splashScreenManager1.SetWaitFormCaption(caption);
            }
        }
        /// <summary>
        /// 设置描述
        /// </summary>
        /// <param name="frm"></param>
        /// <param name="description">等待消息</param>
        public static void SetWaitFormDescription(this Form frm, string description)
        {
            if (splashScreenManager1 == null)
            {
                return;
            }
            if (splashScreenManager1.IsSplashFormVisible)
            {
                if (!description.IsEmpty())
                    splashScreenManager1.SetWaitFormDescription(description);
            }
        }
        /// <summary>
        /// 设置等待消息
        /// </summary>
        /// <param name="frm"></param>
        /// <param name="caption">标题</param>
        /// <param name="description">等待消息</param>
        public static void SetWaitForm(this Form frm, string caption, string description)
        {
            if (splashScreenManager1 == null)
            {
                return;
            }
            if (splashScreenManager1.IsSplashFormVisible)
            {
                if (!caption.IsEmpty())
                {
                    splashScreenManager1.SetWaitFormCaption(caption);
                }
                if (!description.IsEmpty())
                    splashScreenManager1.SetWaitFormDescription(description);
            }
        }
        /// <summary>
        /// 关闭等待对话框
        /// </summary>
        /// <param name="frm"></param>
        public static void CloseWaitForm(this Form frm)
        {
            if (splashScreenManager1 != null)
            {
                if (splashScreenManager1.IsSplashFormVisible)
                    splashScreenManager1.CloseWaitForm();
            }
        }
    }
}
