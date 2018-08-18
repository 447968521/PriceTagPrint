using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
namespace PriceTagPrint.Util
{
    /**
    * 命名空间: PriceTagPrint.Util
    *
    * 功 能： 功能
    * 类 名： ControlHelper
    *
    * Ver 变更日期 负责人 变更内容
    * ───────────────────────────────────
    * V1.0.0 2018/8/17 11:58:33 刘欢 初版
    * CLR版本： 4.0.30319.42000
    *
    * Copyright (c) 2018 Lir Corporation. All rights reserved.
    *┌──────────────────────────────────┐
    *│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
    *│　版权所有：北京华联高级超市 　　　　　　　　　　　　　           　│
    *└──────────────────────────────────┘
    */
    public static class ControlHelper
    {
        private static void gridView1_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
        /// <summary>
        /// 初始化页面
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="grid"></param>
        public static void Init(this GridControl dgv, GridView grid)
        {
            dgv.UseEmbeddedNavigator = true;
            grid.GroupPanelText = @"请将分组字段托放到此处,进行分组显示!";
            //grid.BestFitColumns();
            //grid.OptionsView.ColumnAutoWidth = false;
            grid.Appearance.OddRow.BackColor = Color.FromArgb(251, 251, 243);
            grid.OptionsView.EnableAppearanceOddRow = true;
            grid.Appearance.EvenRow.BackColor = Color.FromArgb(224, 255, 255);
            grid.OptionsView.EnableAppearanceEvenRow = true;
            //grid.OptionsPrint.AutoWidth = false;
            grid.OptionsPrint.ExpandAllDetails = true;
            grid.OptionsPrint.PrintDetails = true;
            grid.OptionsBehavior.Editable = false;
            grid.CustomDrawRowIndicator += new RowIndicatorCustomDrawEventHandler(gridView1_CustomDrawRowIndicator);
            grid.IndicatorWidth = 55;
            grid.OptionsView.ShowAutoFilterRow = false;
        }
        /// <summary>
        /// 获取选中的数据行
        /// </summary>
        /// <param name="gridView"></param>
        /// <returns></returns>
        public static DataRow GetRow(this GridView gridView)
        {
            return (DataRow)gridView.GetFocusedDataRow();
        }
        /// <summary>
        /// 获取选中的行号
        /// </summary>
        /// <param name="gridView"></param> <returns></returns>
        public static Int32 GetRowNum(this GridView gridView)
        {
            return gridView.FocusedRowHandle;
        }
        /// <summary>
        /// 设置筛选行:需绑定数据
        /// </summary>
        /// <param name="gv"></param>
        public static void SetAutoFilterRow(this GridView gv)
        {
            gv.OptionsView.ShowAutoFilterRow = true;
            foreach (DevExpress.XtraGrid.Columns.GridColumn item in gv.Columns)
            {
                item.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;   //筛选条件设置为包含  
            }
        }
    }
}
